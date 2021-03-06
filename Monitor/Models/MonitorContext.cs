﻿using Microsoft.EntityFrameworkCore;

namespace Monitor.Models
{
    public class MonitorContext : DbContext
    {
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<User> Users { get; set; }

        public MonitorContext(DbContextOptions<MonitorContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Monitor;Persist Security Info=True;User ID=sa;Password=123456");
        }
    }
}
