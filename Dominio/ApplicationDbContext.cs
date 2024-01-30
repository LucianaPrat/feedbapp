﻿using Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            modelBuilder.Entity<Client>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Email>().Property(e => e.Address).HasMaxLength(50);
            modelBuilder.Entity<Email>().Property(e => e.Topic).HasMaxLength(50);
            modelBuilder.Entity<Email>().Property(e => e.Body).HasMaxLength(500);
        }
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Email> Emails => Set<Email>();
    }
}
