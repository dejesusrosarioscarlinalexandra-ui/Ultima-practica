using Microsoft.EntityFrameworkCore;
using Bookcase.Models;

namespace Bookcase.Database;

public class AppDbContext : DbContext
{
    public DbSet<MiembroModel> Miembros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=gym.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MiembroModel>()
            .ToTable("miembro");

        modelBuilder.Entity<MiembroModel>()
            .Property(m => m.NombreCompleto)
            .HasColumnName("nombre_completo");

        modelBuilder.Entity<MiembroModel>()
            .Property(m => m.Cedula)
            .HasColumnName("cedula");

        modelBuilder.Entity<MiembroModel>()
            .Property(m => m.Telefono)
            .HasColumnName("telefono");
    }
}