﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Relational;
using PikaPika.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PikaPika.DL
{
    public class PikaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public PikaDBContext([NotNull] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModelBuilderForUser(modelBuilder);
        }

        void ConfigureModelBuilderForUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .Property(user => user.Name)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(60)
                .IsRequired();
        }

    }
}
