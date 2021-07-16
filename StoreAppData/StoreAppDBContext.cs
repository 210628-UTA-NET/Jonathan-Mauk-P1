using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreAppData
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreModels.OrderLineItem> OrderLineItems { get; set; }
        public DbSet<StoreModels.StoreLineItem> StoreLineItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<StoreFront> StoreFronts{ get; set; }
        public DbSet<Products> Products { get; set; }
        public StoreAppDBContext() : base()
        { }
        public StoreAppDBContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.CustomerId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<OrderLineItem>()
                .Property(orderItem => orderItem.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<StoreLineItem>()
                .Property(storeItem => storeItem.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Orders>()
                .Property(ord => ord.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<StoreFront>()
                .Property(store => store.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Products>()
                .Property(prod => prod.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
