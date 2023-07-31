using AtikYonetim.Core.Entities;
using AtikYonetim.Core.Repo;
using AtikYonetim.Core.RepoWrapper;
using AtikYonetim.Models.Data.Context;
using AtikYonetim.Models.Data.Repo;
using AtikYonetim.Models.Data.RepoWrapper;
using AtikYonetim.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WasteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("WasteDbContext")));

builder.Services.AddMvc();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddTransient<WasteOperationService>();


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
