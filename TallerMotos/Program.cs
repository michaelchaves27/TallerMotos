using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerMotos.Application.Config;
using TallerMotos.Application.Perfiles;
using TallerMotos.Application.Services.Implementations;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Data;
using TallerMotos.Infraestructure.Repository.Implementations;
using TallerMotos.Infraestructure.Repository.Interfaces;
using TallerMotos.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppConfig>(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllersWithViews();



//***************Tarea Programada*****************

builder.Services.AddHostedService<TareaHostedService>();
//*******************************************




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

//DetalleFactura
//***Repository
builder.Services.AddTransient<IRepositoryDetalleFactura, RepositoryDetalleFactura>();
//**Services
builder.Services.AddTransient<IServiceDetalleFactura, ServiceDetalleFactura>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DetalleFacturaProfile>();
});

//Servicios
//***Repository
builder.Services.AddTransient<IRepositoryServicios, RepositoryServicios>();
//**Services
builder.Services.AddTransient<IServiceServicios, ServiceServicios>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ServiciosProfile>();
});

//Sucursales
//***Repository
builder.Services.AddTransient<IRepositorySucursales, RepositorySucursales>();
//**Services
builder.Services.AddTransient<IServiceSucursales, ServiceSucursales>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<SucursalesProfile>();
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

//***********************Usuarios
//***Repository
builder.Services.AddTransient<IRepositoryUsuarios, RepositoryUsuarios>();
//**Services
builder.Services.AddTransient<IServiceUsuarios, ServiceUsuarios>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UsuariosProfile>();
});

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


//************************ Horarios
//***Repository
builder.Services.AddTransient<IRepositoryHorarios, RepositoryHorarios>();
//**Services
builder.Services.AddTransient<IServiceHorarios, ServiceHorarios>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<HorariosProfile>();
});



//************************ categorias
//***Repository
builder.Services.AddTransient<IRepositoryCategoria, RepositoryCategoria>();
//**Services
builder.Services.AddTransient<IServiceCategoria, ServiceCategoria>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CategoriaProfile>();
});


//************************ Rol
//***Repository
builder.Services.AddTransient<IRepositoryRol, RepositoryRol>();
//**Services
builder.Services.AddTransient<IServiceRol, ServiceRol>();
//***Configurar Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<RolProfile>();
});



//Seguridad
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.AccessDeniedPath = "/Login/Forbidden";
    });
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        });
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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
 pattern: "{controller=Login}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
