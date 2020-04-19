using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIDemo.DBO.Entities;

namespace WebAPIDemo.DBO.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() {Id=1, CategoryName = "Cat1"},
                 new Category() { Id = 2, CategoryName = "Cat2" },
                  new Category() { Id = 3, CategoryName = "Cat3" },
                  new Category() { Id = 4,  CategoryName = "Cat4" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() {Id = 1, ProductName = "Product1", Description = "Product1", CategoryId = 1 },
                new Product() { Id = 2, ProductName = "Product2", Description = "Product2", CategoryId = 2 },
                new Product() { Id = 3, ProductName = "Product3", Description = "Product3", CategoryId = 3 },
                new Product() { Id = 4, ProductName = "Product4", Description = "Product4", CategoryId = 4 }
                );
        }
    }
}
