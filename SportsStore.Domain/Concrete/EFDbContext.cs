﻿using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("SportsStore")
        {
            
        }
        public virtual DbSet<Product> Products { get; set; } 
    }
}
