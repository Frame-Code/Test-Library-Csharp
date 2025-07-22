using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LibraryDB;Trusted_Connection=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity
                {
                    Name = "Clean Code",
                    Author = "Robert C. Martin",
                    Description = "A book to learn code",
                    Category = "Study"
                },
                new BookEntity
                {
                    Name = "Design Patterns",
                    Author = "Gang of Four",
                    Description = "A little book",
                    Category = "Code"
                });

        }

    }
}
