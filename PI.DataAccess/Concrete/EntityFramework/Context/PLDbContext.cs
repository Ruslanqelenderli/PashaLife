
using Microsoft.EntityFrameworkCore;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DataAccess.Concrete.EntityFramework.Context
{
    public class PLDbContext:DbContext
    {
        public PLDbContext()
        {

        }
        public PLDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=DESKTOP-2A4NBF1;Database=PLProductCategoryDb;Trusted_Connection=True;Connect Timeout=40;MultipleActiveResultSets=True;"
                );

            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(q => q.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "TV",State=true ,CreatedDate=DateTime.Now},
                new Category() { Id = 2,Name ="Game",State=true ,CreatedDate=DateTime.Now}
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "LG",Price=500, State = true, IsDeleted = false,CreatedDate=DateTime.Now,CategoryId=1 },
                new Product() { Id = 2, Name = "GTA", Price = 100, State = true, IsDeleted = false, CreatedDate = DateTime.Now, CategoryId = 2 }

                );
           


        }
    }
}
