using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        
        private static readonly ClientSingleton _client = ClientSingleton.Instance; // readonly 

        // private  readonly ClientSingleton _client1;

        // public Program(){
        //     _client1 = ClientSingleton.Instance;
        // }
        private static readonly SqlClient _sql = new SqlClient();

        static void Main(string[] args)
        {
            // _client.MakeAStore();
            UserView();
        }
        
        
        static void PringAllStores(){
            foreach(var store in _client.Stores)
            {   
                Console.WriteLine(store);

            }
        }

        static void PringAllStoresWithEF(){
            foreach(var store in _sql.ReadStores())
            {   
                Console.WriteLine(store);

            }
        }

        static void UserView(){
            var user = new User();

            PringAllStoresWithEF();

            user.SelectedStore = _sql.SelectStore();
            user.SelectedStore.CreateOrders();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().MakeMeatPizza();
             _sql.ReadStores();
        //    IEnumerable<Order> orders =  _sql.ReadOrders(user.SelectedStore);
        //     foreach(var o in orders)
        //     {
        //         Console.WriteLine("order: " + o);
        //     }

            
            

            Console.WriteLine(user);
        }
    }
}
