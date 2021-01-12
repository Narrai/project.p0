using System;

namespace PizzaWorld.Client
{
    class Program
    {
        
        //  private  static readonly ClientSingleton _client = ClientSingleton.Instance; // readonly 

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
        

    
        
        // static void PringAllStores(){
        //     foreach(var store in _client.Stores)
        //     {   
        //         Console.WriteLine(store);

        //     }
        // }

        

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
                        _sql.ProcessPizza();
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
