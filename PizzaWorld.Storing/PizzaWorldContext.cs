using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<Store> Stores {get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders {get; set;}
        public DbSet<APizzaModel> Pizzas { get; set; }

        public DbSet<Crusts> Crusts { get; set; }

        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<PizzaToppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=narpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorldDB;User ID=sqladmin;Password=Password84;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);
            builder.Entity<Crusts>().HasKey(p => p.EntityId);
            builder.Entity<Topping>().HasKey(p => p.EntityId);
            builder.Entity<PizzaToppings>().HasKey(p => p.EntityId);
            builder.Entity<Sizes>().HasKey(p => p.EntityId);
            SeedData(builder);
        }

        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(
                new Store{EntityId = 1, Name="One"},
                new Store{EntityId = 2, Name="Two"}
            );
        }
    }
}