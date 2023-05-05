using BlazorAppDemo.Data;
using BlazorAppDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();


builder.Services.AddScoped<ApplicationStates>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
if (builder.Environment.IsProduction())
{
    GetEnvironemntInfo.Info = "#### Running In Production ####";
}
if (builder.Environment.IsDevelopment())
{
    GetEnvironemntInfo.Info = "#### Running In Development ####";
}
if (builder.Environment.IsStaging())
{
    GetEnvironemntInfo.Info = "#### Running In Staging ####";
}

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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Content")),
    RequestPath = "/Content"
});

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


public static class GetEnvironemntInfo
{
    public static string? Info { get; set; }
}
