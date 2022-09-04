using Microsoft.EntityFrameworkCore;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DataAccess.Concrete.EntityFramework.Context
{
    public class PLStockDbContext:DbContext
    {
        public PLStockDbContext()
        {

        }
        public PLStockDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=DESKTOP-2A4NBF1;Database=PLStockDb;Trusted_Connection=True;Connect Timeout=40;MultipleActiveResultSets=True;"
                );



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductStock>().HasData(
                new ProductStock() { Id = 1000, ProductId = 1,StockCount=30,IsDeleted=false, State = true, CreatedDate = DateTime.Now },
                new ProductStock() { Id = 1001, ProductId = 2, StockCount = 45, IsDeleted = false, State = true, CreatedDate = DateTime.Now }
                );
            



        }
    }
}
