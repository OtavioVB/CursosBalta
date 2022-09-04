using Balta.Domain.Application;
using Microsoft.EntityFrameworkCore;

namespace Balta.Infra.Data;

public class DataContext : DbContext
{
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Aula> Aulas { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Primary Key's
        builder.Entity<Curso>().HasKey(p => p.Identificador);
        builder.Entity<Curso>().Property(p => p.Identificador).ValueGeneratedOnAdd();


        builder.Entity<Modulo>().HasKey(p => p.Identificador);
        builder.Entity<Modulo>().Property(p => p.Identificador).ValueGeneratedOnAdd();

        builder.Entity<Aula>().HasKey(p => p.Identificador);
        builder.Entity<Aula>().Property(p => p.Identificador).ValueGeneratedOnAdd();


        // Foreign Key's
        builder.Entity<Aula>()
            .HasOne(p => p.Modulo)
            .WithMany(p => p.Aulas)
            .HasForeignKey(p => p.IdentificadorModulo);
        builder.Entity<Modulo>()
            .HasOne(p => p.Curso)
            .WithMany(p => p.Modulos)
            .HasForeignKey(p => p.IdentificadorCurso);
    }
}
