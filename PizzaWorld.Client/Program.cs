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

        static void UserView(){
            var user = new User();

            PringAllStores();

            user.SelectedStore = _client.SelectStore();
            user.SelectedStore.CreateOrders();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().MakeMeatPizza();
            

            Console.WriteLine(user);
        }
    }
}
