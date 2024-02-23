
using Microsoft.EntityFrameworkCore;
using Login_asp.net_core_mvc.Models;
using Login_asp.net_core_mvc.Servicios.Implementacion;
using Login_asp.net_core_mvc.Servicios.Contrato;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder1 = WebApplication.CreateBuilder(args);

// Add services to the container.
builder1.Services.AddControllersWithViews();

builder1.Services.AddDbContext<DbpruebaContext>(options =>
{
    options.UseSqlServer(builder1.Configuration.GetConnectionString("conectionString"));
});

builder1.Services.AddScoped<IUsuarioService, UsuarioServices>();
builder1.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder1.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None
        }
        );
});

var app = builder1.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();
