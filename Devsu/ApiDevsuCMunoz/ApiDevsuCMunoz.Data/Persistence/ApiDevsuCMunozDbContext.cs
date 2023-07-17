﻿using ApiDevsuCMunoz.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDevsuCMunoz.Infrestructure.Persistence
{
    public class ApiDevsuCMunozDbContext : DbContext
    {
        public ApiDevsuCMunozDbContext(DbContextOptions<ApiDevsuCMunozDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.();
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Devsu;Trusted_Connection=True;Encrypt=False;")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<Cliente>()
                .HasMany(m => m.Cuentas)
                .WithOne(m => m.Cliente)
                .HasForeignKey(m => m.ClienteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Cuenta>()
                .HasMany(m => m.Movimientos)
                .WithOne(m => m.Cuenta)
                .HasForeignKey(m => m.CuentaNumero)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public List<Cliente>? Clientes { get; set; }
        public List<Cuenta>? Cuentas { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
    }
}