using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Storing;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Client
{
    public class SqlClient
    {
       private readonly PizzaWorldContext _db = new PizzaWorldContext();
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
        private int AddOrder(Store store, string orderName, float price)
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
        public void CreatePizza(Order selectedOrder, string userName, string pizzaType, string size, string crust, float price){
            _db.Pizzas.Add(selectedOrder.MakePizza(userName, pizzaType, crust, size, price));
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
        private Store SelectStore()
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

        private User GetUser(string name)
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

        private void PizzaToppings(long PizzaId)
        {
           var pizza =  _db.Pizzas.Include("Toppings").FirstOrDefault(p => p.EntityId == PizzaId);
           foreach(var t in pizza.Toppings)
           {
               Console.WriteLine(t.Name);
           }
           Console.WriteLine("************************");

        }

        private void InsertToppings()
        {
            foreach(var t in _db.Toppings)
            {
                Console.WriteLine(t.Name);
            }
            bool IsYes = false;
            List<Topping> toppingsList = new List<Topping>();
            do{
                Console.WriteLine("Pick toppings: ");
                string toppingName = Console.ReadLine();
                var topping = _db.Toppings.FirstOrDefault(t => t.Name == toppingName);
                toppingsList.Add(topping);

                Console.WriteLine("Want add another topping: ");
                string YesOrNo = Console.ReadLine();
                if(YesOrNo.ToLower() == "yes")
                {
                    IsYes = true;
                }
                else{
                    IsYes = false;
                }
            }while(IsYes);

            var pizzas = _db.Pizzas.Include("Toppings").OrderBy(p => p.EntityId).LastOrDefault();
            pizzas.Toppings = toppingsList;
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
        // Process Pizza
        public void ProcessPizza()
        {
            bool IsYes = false;
                        do
                        {
                            Console.Write("Enter your name: ");
                            string userName = Console.ReadLine();
                            var user = GetUser(userName);
                            Console.WriteLine("Select store: ");
                            PringAllStoresWithEF();
                            user.SelectedStore = SelectStore();
                            Console.Write("Order name: ");
                            string orderName = Console.ReadLine();
                            Console.Write("pizza type: ");
                            string pizzaType = Console.ReadLine();
                            Console.Write("crust: ");
                            string crust = Console.ReadLine();
                            Console.Write("size: ");
                            string size = Console.ReadLine();

                            float price;

                            switch (size)
                                {
                                    case "small": 
                                                price = 10.99f;
                                                break;
                                    case "medium": 
                                                price = 12.99f;
                                                break;
                                    case "large":
                                                price = 14.99f;
                                                break;
                                    default:
                                                price = 0;
                                                break;
                                }
                                AddOrder(user.SelectedStore, orderName, price);
                                
                                user.SelectedOrder = SelectOrder(orderName);
                                CreatePizza(user.SelectedOrder, orderName, pizzaType, size, crust, price);

                                InsertToppings();
                                
                                Console.WriteLine("Your order is created");
                                Console.WriteLine("**********************");
                                PrintOrderDetails(orderName);

                                Console.WriteLine("Add more pizza?");
                                string yesOrNo = Console.ReadLine();
                                if(yesOrNo.ToLower() == "yes")
                                {
                                    IsYes = true;
                                }
                                else
                                {
                                    IsYes = false;
                                }
                        }while(IsYes);
        }

        private void PringAllStoresWithEF(){
            foreach(var store in ReadStores())
            {   
                Console.WriteLine("Store = " + store);
                foreach(var o in store.Orders)
                {
                    Console.WriteLine(o);
                }
            }
        }
        private void PrintOrderDetails(string orderName)
        {
            var pizzas = _db.Pizzas;
            float total = 0;
            Console.WriteLine("Your Order details:");
            foreach(var p in pizzas)
            { 
                if(!(p.OrderName == null) && (p.OrderName.Equals(orderName)))
                {
                    Console.WriteLine("Pizza = {0}", p.Name);
                    Console.WriteLine("Crust = {0}", p.Crust);
                    Console.WriteLine("Size = {0}", p.Size);
                    Console.WriteLine("Price = ${0}", p.Price);
                    PizzaToppings(p.EntityId);
                    Console.WriteLine("*************************");
                    total += p.Price;
                }
            }
            List<Order> orders = _db.Orders.ToList();
            Console.WriteLine("Total Order Cost: $ {0}", total);
            
        }

    }
}