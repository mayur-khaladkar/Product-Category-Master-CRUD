﻿using Microsoft.EntityFrameworkCore;

namespace ProductCategory.Models
{
    public class ProductCategoryContext : DbContext
    {
        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
