﻿using Caserita_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caserita_Data
{
    public class CaseritaDbContext : DbContext
    {
        public CaseritaDbContext(DbContextOptions<CaseritaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Settings)
                .WithMany(s => s.Users)
                .UsingEntity<UserSetting>();

            modelBuilder.Entity<Setting>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserSetting>()
                .HasKey(us => new { us.UserId, us.SettingId });
        }
    }
}
