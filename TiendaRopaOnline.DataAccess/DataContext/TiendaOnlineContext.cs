using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TiendaRopaOnline.Models;

namespace TiendaRopaOnline.DataAccess.DataContext;

public partial class TiendaOnlineContext : DbContext
{
    public TiendaOnlineContext()
    {
    }

    public TiendaOnlineContext(DbContextOptions<TiendaOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07B0BDAF76");

            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
