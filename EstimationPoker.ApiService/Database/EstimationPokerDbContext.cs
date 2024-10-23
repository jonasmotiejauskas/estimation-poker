﻿using Microsoft.EntityFrameworkCore;

namespace EstimationPoker.ApiService.Database
{
    public class EstimationPokerDbContext : DbContext
    {
        public EstimationPokerDbContext(DbContextOptions<EstimationPokerDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe" });
        }
    }
}