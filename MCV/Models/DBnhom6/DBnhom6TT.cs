﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MCV.Models.DBnhom6
{
    public class DBnhom6TT:DbContext
    {
        public DBnhom6TT()
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Shoe> Shoe { get; set; }
        public DbSet<ShoeDetail> ShoeDetail { get; set; }
        public DbSet<Size> Size { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=bainhom6tt;User ID=sa;Password=thieu12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
