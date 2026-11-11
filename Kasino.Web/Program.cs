
using Kasino.Application.Interfaces;
using Kasino.Infrastructure.Data;
using Kasino.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

// Priprava webovej aplikacie
var builder = WebApplication.CreateBuilder(args);

// Zapnutie MVC
builder.Services.AddControllersWithViews();

// Registracia databazoveho kontextu
builder.Services.AddDbContext<KasinoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Registracia generickeho Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Vytvorenie aplikacie
var app = builder.Build();

// Spracovanie chyb
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Presmerovanie na HTTPS
app.UseHttpsRedirection();

// Nastavenie smerovania
app.UseRouting();

// Kontrola pristupovych opravneni
app.UseAuthorization();

// Predvolena MVC adresa
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Spustenie aplikacie
app.Run();
