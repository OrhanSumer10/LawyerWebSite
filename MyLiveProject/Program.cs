using AspNetCoreHero.ToastNotification;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddAuthentication(
      CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(x =>
      {
          x.LoginPath = "/Login/Index";
      });

builder.Services.AddHttpClient();




    builder.Services.AddMvc();
    builder.Services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });

    builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            options.LoginPath = "/Login/Index";
            options.SlidingExpiration = true;

            // Other configurations...

            // Services
        });


// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseExceptionHandler("/Home/Error");

app.UseHsts();
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");


app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
