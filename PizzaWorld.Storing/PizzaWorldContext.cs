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
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<PizzaToppings> PizzaToppings { get; set; }

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
            builder.Entity<Toppings>().HasKey(p => p.EntityId);
            builder.Entity<PizzaToppings>().HasKey(p => p.EntityId);
            builder.Entity<Sizes>().HasKey(p => p.EntityId);
            builder.Entity<Prices>().HasKey(p => p.EntityId);

            SeedData(builder);
        }

        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(
                new Store{EntityId = 1, Name="One"},
                new Store{EntityId = 2, Name="Two"}
            );

            builder.Entity<Order>().HasData(
                new Order{
                    EntityId=1
                }
            );

            builder.Entity<User>().HasData(
                new User{
                    EntityId=1
                }
            );
            builder.Entity<MeatPizza>().HasData(
                new MeatPizza{
                    EntityId = 1,
                    Name="meat Pizza",
                    Crust="stuffed",
                    Size = "small",
                    Price = 10.99f
                }
            );

            builder.Entity<VegePizza>().HasData(
                new VegePizza{
                    EntityId = 2,
                    Name="vege Pizza",
                    Crust="thick",
                    Size = "medium",
                    Price = 12.99f
                }
            );

            builder.Entity<Toppings>().HasData(
                new Toppings{EntityId = 1, Name = "tomato"},
                new Toppings{EntityId = 2, Name = "grilled chicken"},
                new Toppings{EntityId = 3, Name = "sauce"}
            );

            builder.Entity<Crusts>().HasData(
                new Crusts{EntityId=1, Name = "stuffed"},
                new Crusts{EntityId=2, Name = "thin"},
                new Crusts{EntityId=3, Name = "stuffed"}
            );

            builder.Entity<Sizes>().HasData(
                new Sizes{EntityId=1, Name="small"},
                new Sizes{EntityId=2, Name="medium"},
                new Sizes{EntityId=3, Name="large"}
            );

            builder.Entity<Prices>().HasData(
                new Prices{EntityId=1, Price=10.99f},
                new Prices{EntityId=2, Price=12.99f},
                new Prices{EntityId=3, Price=14.99f}
            );

            builder.Entity<PizzaToppings>().HasData(
                new PizzaToppings{
                    EntityId = 1
                }
            );
        }
    }
}