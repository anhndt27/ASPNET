using ASPNETBLL.DTOs.Mapper;
using ASPNETBLL.Extentions;
using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using ASPNETDAL.Context;
using ASPNETDAL.Entities;
using ASPNETmvc;
using ASPNETmvc.ErrorExtentions;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(c => c.AddProfile<MapCourseProfile>(), typeof(Program));
builder.Services.AddServices();
var app = builder.Build();

/*// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error404");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseErrorLogging();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Response.Redirect("/Home/Error404");
        context.Response.ContentLength = 0;
    }
});*/
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();