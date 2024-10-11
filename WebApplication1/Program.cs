using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Interfaces;
using WebApplication1.Core.Mock;
using WebApplication1.Persistence;

var builder = WebApplication.CreateBuilder(args);




//ADDED
builder.Services.AddScoped<IBidService, MockBidService>();
builder.Services.AddScoped<IAuctionService, MockAuctionService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ProjectDbConnection")));






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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();