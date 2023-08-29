using IntroASP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Se usa EntityFramework y EntityFrameworkSQL
// Inyección de Dependencias EntityFrameworkCore - introAspModels - json de la conexión a la BD
// PubContext es el archivo que se encuentra en los modelos que se crea con el comando que trae a la BD
// Scaffold-DbContext "Server=DESKTOP-SGFRJH9\SQLEXPRESS; Database=Pub; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

builder.Services.AddDbContext<PubContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PubContext"));
});

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
