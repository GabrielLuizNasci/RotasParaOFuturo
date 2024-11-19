using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Data;
using RotasParaOFuturo.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("conexao");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar o IdentityContext para autenticação e autorização
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Admin, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 10;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
