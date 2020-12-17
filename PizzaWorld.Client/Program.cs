using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = ClientSingleton.Instance;
            cs.MakeAStore();
            // PringAllStores();
        }
        static IEnumerable<Store> GetAllStores()
        {
            return new List<Store>()
            {
                new Store(), new Store()
            };

        }
        static void PringAllStores(){
            foreach(var store in GetAllStores())
            {   
                Console.WriteLine(store);

            }
        }
    }
}
