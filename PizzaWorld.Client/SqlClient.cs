using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;
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
            return _db.Stores;
        }

        public Store ReadOne(string name)
        {
            return _db.Stores.FirstOrDefault(s => s.Name == name);
        }

        public void Save(Store store)
        {
            _db.Add(store);
            _db.SaveChanges();
        }

        public void CreateStore()
        {
            Save(new Store());
        }

        public IEnumerable<Order> ReadOrders(Store store)
        {
            var s = ReadOne(store.Name);
            return s.Orders;
        }

        public Store SelectStore()
        {
            string input = Console.ReadLine();
            return ReadOne(input);
        }
    }
}