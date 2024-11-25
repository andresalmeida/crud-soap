using Microsoft.EntityFrameworkCore;
using SOAP_LibrosApp.Data;
using System.ServiceModel; // Importar espacio de nombres necesario para SOAP

var builder = WebApplication.CreateBuilder(args);

// Registrar el cliente SOAP como servicio
builder.Services.AddScoped<BookServiceReference.BookServiceClient>(provider =>
{
    // Configurar el binding y el endpoint para el servicio SOAP
    var binding = new BasicHttpBinding
    {
        Security = { Mode = BasicHttpSecurityMode.None } // Sin seguridad, ajusta según sea necesario
    };
    var endpoint = new EndpointAddress("http://localhost:64441/BookService.svc"); // Cambia a la URL de tu servicio
    return new BookServiceReference.BookServiceClient(binding, endpoint);
});

// Registrar el DbContext para SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registrar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libro}/{action=Index}/{id?}");

app.Run();
