using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Interfaces;
using WebApplication1.Core.Services;
using WebApplication1.Persistence;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Data;
using WebApplication1.Persistence.Implementations;
using WebApplication1.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);




//ADDED

builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IBidPersistence, MySQLBidListPersistence>();
builder.Services.AddScoped<IAuctionPersistence, MySQLAuctionPersistence>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBidService, BidListService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ProjectDbConnection")));
builder.Services.AddDefaultIdentity<WebApplication1User>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<WebApplication1Context>();
builder.Services.AddDbContext<WebApplication1Context>(options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDbConnection")));
builder.Services.AddControllersWithViews();
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<WebApplication1User>>();
    await EnsureRolesAsync(roleManager, userManager);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager, UserManager<WebApplication1User> userManager)
{
    // Define roles
    string[] roleNames = { "Admin", "User" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminUser = await userManager.FindByEmailAsync("joar@gmail.com");
    if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}