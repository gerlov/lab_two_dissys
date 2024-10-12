using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Interfaces;
using WebApplication1.Core.Mock;
using WebApplication1.Core.Services;
using WebApplication1.Persistence;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);




//ADDED
builder.Services.AddScoped<IBidPersistence, MySQLBidListPersistence>();
builder.Services.AddScoped<IAuctionPersistence, MySQLAuctionPersistence>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBidService, BidListService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ProjectDbConnection")));
builder.Services.AddDefaultIdentity<WebApplication1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApplication1Context>();
builder.Services.AddDbContext<WebApplication1Context>(options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDbConnection")));





// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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