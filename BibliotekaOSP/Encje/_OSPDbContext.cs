﻿using Microsoft.EntityFrameworkCore;

namespace BibliotekaOSP.Encje;

public class OSPDbContext : DbContext
{
    public virtual DbSet<Członek> Członkowie { get; set; }
    public virtual DbSet<Firma> Firmy { get; set; }
    public virtual DbSet<Adres> Adresy { get; set; }

    public OSPDbContext(DbContextOptions<OSPDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}