using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BibliotekaOSP.Encje;

public class OSPDbContext : DbContext
{
    public virtual DbSet<Członek> Członkowie { get; set; }
    public virtual DbSet<Firma> Firmy { get; set; }
    public virtual DbSet<Adres> Adresy { get; set; }
    public virtual DbSet<Portfel> Portfele { get; set; }
    public virtual DbSet<Przelew> Przelewy { get; set; }

    public OSPDbContext(DbContextOptions<OSPDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Przelew>(przel =>
        {
            przel.Property(p => p.Kwota)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Kwota>(v, (JsonSerializerOptions)null));
            });
    }
}
