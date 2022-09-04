using Balta.Data;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;
using Balta.Infra.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Balta;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        // Dependences
        builder.Services.AddTransient<IRepositoryCurso, CursoRepository>();
        builder.Services.AddTransient<IRepositoryModulo, ModuloRepository>();
        builder.Services.AddTransient<IRepositoryAula, AulaRepository>();

        builder.Services.AddDbContext<DataContext>(); //"{_appEnv.ApplicationBasePath}/" 
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(AppContext.BaseDirectory + "/" +connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
          
        builder.Services.AddRazorPages();
        var app = builder.Build();
        app.UseMigrationsEndPoint();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        // Rotas
        app.MapAreaControllerRoute
            (
                name: "Cursos",
                areaName: "Cursos",
                pattern: "{controller}/{action}"
            );

        app.MapRazorPages();
        app.Run();
    }
}