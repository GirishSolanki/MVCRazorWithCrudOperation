using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Serialization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<WebApi>(new WebApi(builder.Configuration.GetSection("WebApiUrl").Value));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(x => x.LoginPath = "/Login/Login");

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc(config => { config.Filters.Add<GobalErrorHandlerAttribute>(); });
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
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

app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
        response.StatusCode == (int)HttpStatusCode.Forbidden)
        response.Redirect("/Login/Login");
});

app.UseSession();
app.MapRazorPages();

app.Run();
