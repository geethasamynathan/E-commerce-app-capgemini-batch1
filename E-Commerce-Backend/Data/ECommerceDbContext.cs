using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace E_Commerce_Backend.Data
{
    public class ECommerceDbContext :DbContext
    {


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
