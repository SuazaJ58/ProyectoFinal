using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DAL.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoFinal.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Supplier: El nombre debe ser único
            modelBuilder.Entity<Supplier>().HasIndex(s => s.Name).IsUnique();

            // Configuración para Product: El nombre debe ser único dentro de un mismo proveedor
            modelBuilder.Entity<Product>().HasIndex("Name", "SupplierId").IsUnique();

            // Configuración de la relación Supplier-Product (uno a muchos)
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        #region DbSets
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
