using Microsoft.EntityFrameworkCore;
using Mitrais.Data.Domain;
using System;

namespace Mitrais.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender() { Id = Guid.NewGuid(), Name = "Male" },
                new Gender() { Id = Guid.NewGuid(), Name = "Female" }
            );
        }
    }
}
