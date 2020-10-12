using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class PrimeDBContext : DbContext
    {
        public PrimeDBContext(DbContextOptions<PrimeDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //dbContextOptionsBuilder.Us
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recibo>().HasKey(r => new {r.Id});
            
            modelBuilder.Entity<Ficheiro>()
                .HasOne(f => f.recibo)
                .WithOne(r => r.ficheiro).HasForeignKey<Recibo>(f => f.FicheiroId);

            modelBuilder.Entity<Item>().HasKey(i => new { i.Id });

            modelBuilder.Entity<Item>()
                .HasOne(r => r.recibo)
                .WithMany(i => i.Detalhes)
                .HasForeignKey(r => r.ReciboId);

            modelBuilder.Entity<Ficheiro>().HasKey(f => new { f.Id });
        }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Ficheiro> Ficheiros { get; set; }
    }
}
