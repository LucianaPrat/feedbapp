using Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Client
            modelBuilder.Entity<Client>().Property(c => c.Name).HasMaxLength(50);

            // Email
            modelBuilder.Entity<Email>().Property(e => e.Address).HasMaxLength(50);
            modelBuilder.Entity<Email>().Property(e => e.Topic).HasMaxLength(50);
            modelBuilder.Entity<Email>().Property(e => e.Body).HasMaxLength(500);

            // Admin
            modelBuilder.Entity<Entity.Admin>().Property(c => c.Name).HasMaxLength(50);

            // Leader
            //modelBuilder.Entity<Leader>().HasOne<Client>().WithMany(c => c.Leaders).HasForeignKey(e => e.ClientId).IsRequired();

            // seed
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, Active = true, Removed = false, Name = "FraSal" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 2, Active = true, Removed = false, Name = "YouTube" });
        }

        public DbSet<Entity.Client> Clients => Set<Client>();
        public DbSet<Entity.Email> Emails => Set<Email>();
        public DbSet<Entity.Leader> Leaders => Set<Leader>();
        public DbSet<Entity.Developer> Developers => Set<Developer>();
        public DbSet<Entity.Admin> Admins => Set<Admin>();
        public DbSet<Entity.Position> Positions => Set<Position>();
        public DbSet<Entity.Delivery> Deliveries => Set<Delivery>();
    }
}
