using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using System;

namespace PizzaWorld.Domain.Models
{
    public class Store : AEntity
    {

        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Store()
        {
            Orders = new List<Order>();
        }
        
        public Order CreateOrders(Store store, string orderName, float Total)
        {
            return new Order{
                StoreName = store.Name,
                Name = orderName,
                OrderDate = DateTime.Now,
                TotalPrice = Total
            };
        }

        bool DeleteOrder(Order order)
        {
            try
            {
                Orders.Remove(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        
    }
}