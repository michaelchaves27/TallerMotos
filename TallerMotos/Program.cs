using Microsoft.EntityFrameworkCore;
using TallerMotos.Application.Perfiles;
using TallerMotos.Application.Services.Implementations;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Repository.Implementations;
using TallerMotos.Infraestructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();
//********************************
//Configurar D.I.
//***Repository
builder.Services.AddTransient<IRepositoryFacturas, RepositoryFacturas>();
//**Services
builder.Services.AddTransient<IServiceFacturas, ServiceFacturas>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<FacturaProfile>();
});

//***********************reservas
//***Repository
builder.Services.AddTransient<IRepositoryReservas, RepositoryReservas>();
//**Services
builder.Services.AddTransient<IServiceReservas, ServiceReservas>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ReservasProfile>();
});
//****************************************************************

//************************ Productos
//***Repository
builder.Services.AddTransient<IRepositoryProductos, RepositoryProductos>();
//**Services
builder.Services.AddTransient<IServiceProductos, ServiceProductos>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ProductosProfile>();
});

//***********************

// Configuar Conexión a la Base de Datos SQL
builder.Services.AddDbContext<TallerMotosContext>(options =>
{
    // it read appsettings.json file

    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));
    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
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
    pattern: "{controller=Login}/{action=Index}/{id?}");


app.Run();
