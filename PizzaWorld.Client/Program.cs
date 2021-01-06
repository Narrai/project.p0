using System;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        
         private  static readonly ClientSingleton _client = ClientSingleton.Instance; // readonly 

         private static readonly SqlClient _sql = new SqlClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Are you a existing user? ");
            string yesOrNo = Console.ReadLine();

            switch(yesOrNo.ToLower())
            {
                case "yes":
                            PrintMenus();
                            break;
                case "no" :
                            Console.WriteLine("Enter your name: ");
                            string newUser = Console.ReadLine();
                            _sql.CreateUsers(newUser);
                            PrintMenus();
                            break;
                default:
                        Console.WriteLine("Please enter yes or no");
                        break;   
            }
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
                Console.WriteLine("Store = " + store);
                foreach(var o in store.Orders)
                {
                    Console.WriteLine(o);
                }
            }
        }

        static void PrintAllOrders()
        {
            foreach(var order in _sql.ReadOrders())
            {
                if(order.Name != null)
                {
                    Console.WriteLine(order.Name);
                }
            }
        }

        static void PrintMenus()
        {
            Console.Write("Enter your selections: \na:Select store\nb:List orders by store\nc:List orders\n");
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "a":
                        bool IsYes = false;
                        do
                        {
                            Console.Write("Enter your name: ");
                            string userName = Console.ReadLine();
                            var user = _sql.GetUser(userName);
                            Console.WriteLine("Select store: ");
                            PringAllStoresWithEF();
                            user.SelectedStore = _sql.SelectStore();
                            Console.Write("Order name: ");
                            string orderName = Console.ReadLine();
                            Console.Write("pizza type: ");
                            string pizzaType = Console.ReadLine();
                            Console.Write("topping: ");
                            string topping = Console.ReadLine();
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
                            _sql.AddOrder(user.SelectedStore, orderName, price);
                                
                                user.SelectedOrder = _sql.SelectOrder(orderName);
                                _sql.CreatePizza(user.SelectedOrder, orderName, pizzaType, topping, size, crust, price);
                                
                                Console.WriteLine("Your order is created");
                                Console.WriteLine("**********************");
                                _sql.PrintOrderDetails(orderName);

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
                        break;
                case "b":          
                        // diplay oders for each store
                        Console.WriteLine("Type store name: ");
                        _sql.OrdersByStores(Console.ReadLine());
                        break;
                case "c":
                        // print all orders
                        PrintAllOrders();
                        break;
            }
        }

    }
}
