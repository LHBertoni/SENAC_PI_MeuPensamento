using MeuPensamento.DAO;
using MeuPensamento.DAO.Models;
using MeuPensamento.DAO.Services;
using MeuPensamento.Services;
using MeuPensamento.Tools.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.Cookie = new CookieBuilder()
        {
            Name = "CoockieAuthenticationMeuPensamento",
            HttpOnly = true,
            SameSite = SameSiteMode.None
        };
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie = new CookieBuilder()
    {
        Expiration = TimeSpan.FromMinutes(10),
        HttpOnly = true,
        SameSite = SameSiteMode.None,
        Name = "CoockieSessionMeuPensamento"
    };

});

builder.Services.AddScoped<SessionService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<MeuPensamentoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MeuPensamentoDbContext")));
builder.Services.AddSingleton<CriptografiaProvider>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PensamentoService>();

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

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.UseSession();

app.Run();
