using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Service
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Application>().HasKey(a => new { a.ApplicationId });
            modelBuilder.Entity<Client>().HasKey(c => new { c.ClientId });
            modelBuilder.Entity<Scope>().HasKey(s => new { s.ClientId, s.ApplicationId });

            modelBuilder.Entity<Scope>().HasOne(s => s.Application)
                .WithMany(a => a.Scopes).HasForeignKey(s => s.ApplicationId);  
            
            modelBuilder.Entity<Scope>().HasOne(s => s.Client)
                .WithMany(a => a.Scopes).HasForeignKey(s => s.ClientId);
                  }

        public DbSet<Scope> Scopes { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
