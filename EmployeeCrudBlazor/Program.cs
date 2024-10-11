using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using EmployeeCrudBlazor.Data;
using EmployeeCrudBlazor.Context;
using DotNetEnv;

// Load .env file
Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<EmployeeService>();

// Connection to the Database
// string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Will fetch the connection string from .env file(1 arg), if not will give the error message(2 arg): 
string? connectionString = Env.GetString("CONNECTIONSTRING", "Variable not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
    builder => builder.MigrationsAssembly("EmployeeCrudBlazor")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

