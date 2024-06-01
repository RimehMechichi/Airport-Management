using AM.Core.Interfaces;
using AM.Core.Services;
using AM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//injection de d�pendences 
builder.Services.AddScoped<IPlaneService, PlaneService>();
builder.Services.AddScoped<IFlightService, FlightService>();//par requete
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();//par requete
builder.Services.AddDbContext<DbContext, AMContext>();//base de donn�e

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
app.MapControllerRoute(
    name: "MYAPI",
    pattern: "returnflight/{flight}",
    defaults: new {Controller = "Flight" , action ="flighyt"});


app.Run();
