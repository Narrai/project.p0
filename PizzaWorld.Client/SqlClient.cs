using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Storing;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client
{
    public class SqlClient
    {
        private  readonly  PizzaWorldContext _db = new PizzaWorldContext();
        public SqlClient()
        {

            if(ReadStores().Count() == 0)
            {
                CreateStore();
            }
        }
        public IEnumerable<Store> ReadStores()
        {
            var stores = from store in _db.Stores
                         select store;
                        
            return  stores;
        }

        public Store ReadOne(string name)
        {
            return _db.Stores.FirstOrDefault(s => s.Name == name);

        }

        public Order ReadOrder(string name)
        {
            return _db.Orders.FirstOrDefault(o => o.Name == name);

        }

        
        public void CreateStore()
        {
            _db.Stores.Add(
               new Store{
                   EntityId = 3,
                   Name = "Three"
               }
            );

            
            _db.Database.OpenConnection();
            try
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Stores ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Stores OFF");
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _db.Orders;
        }

        // add order to database
        public int AddOrder(Store store, string orderName, float price)
        {
            float total = ComputePrice(price);
            _db.Orders.Add(store.CreateOrders(store, orderName, total));
            _db.Database.OpenConnection();
            try
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders OFF");
            }
            finally
            {
                _db.Database.CloseConnection();
            }
           
            return _db.Orders.Count();
        }

        // calculate running total to store in order table
        public float ComputePrice(float price)
        {
            List<Order> orders = _db.Orders.ToList();
            float total = 0;
            if(orders.Count() == 0)
            {
                total = price;
            }
            foreach(var o in orders){
                total = o.TotalPrice;
                total += price;
            }
            return total;
            
        }

        // List orders by store
        public void OrdersByStores(string name ){
            var orders = _db.Orders;
            Console.WriteLine($"Store {name} order lists: ");
            foreach(var o in orders)
            {
                if(o.StoreName == name)
                {
                    Console.WriteLine($"Orders Id = {o.EntityId}, Store name = {o.StoreName}, Order's name = {o.Name}");
                }
            }
        }

        // add pizza to database
        public void CreatePizza(Order selectedOrder, string userName, string pizzaType, string topping, string size, string crust, float price){
            _db.Pizzas.Add(selectedOrder.MakePizza(userName, pizzaType, crust, size, topping, price));
            _db.Database.OpenConnection();
            try
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizzas ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizzas OFF");
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        // select order
        public Order SelectOrder(string orderName)
        {
            // string input = Console.ReadLine();
            return ReadOrder(orderName);
        }


        // select store
        public Store SelectStore()
        {
            string input = Console.ReadLine();
            return ReadOne(input);
        }

        public bool IsUserExist(string name){
            foreach(var user in _db.Users)
           {
               if(user.Name == name)
               {
                   return true;
               }
           }
           return false;
        }

        // create user
        public  void CreateUsers(string name)
        {
           foreach(var user in _db.Users)
           {
               if(user.Name == name)
               {
                   Console.WriteLine($"{name} already exist");
                   break;
               }
           }

           _db.Users.Add(new User{
               Name = name
           });
           _db.Database.OpenConnection();
            try
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        public User GetUser(string name)
        {
            foreach(var user in _db.Users)
            {
                if(user.Name == name)
                 {
                     return user;
                 }
            }
            return null;
        }

        public void PrintOrderDetails(string orderName)
        {
            var pizzas = _db.Pizzas.ToList();
            float total = 0;
            Console.WriteLine("Your Order details:");
            foreach(var p in pizzas)
            {
                if(p.OrderName.Equals(orderName))
                {
                    Console.WriteLine("Pizza = {0}", p.Name);
                    Console.WriteLine("Crust = {0}", p.Crust);
                    Console.WriteLine("Size = {0}", p.Size);
                    Console.WriteLine("Topping = {0}", p.Topping);
                    Console.WriteLine("Price = ${0}", p.Price);
                    Console.WriteLine("*************************");
                    total += p.Price;
                }
            }
            List<Order> orders = _db.Orders.ToList();
            Console.WriteLine("Total Order Cost: $ {0}", total);
            
        }

    }
}