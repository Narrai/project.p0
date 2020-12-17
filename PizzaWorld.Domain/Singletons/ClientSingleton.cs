using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        public static ClientSingleton Instance{
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }
                return _instance;
            }
        }

        public  List<Store>  Stores { get; set; }
        private ClientSingleton(){
            Stores = new List<Store>();
        }

        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            var s = new Store();
            Stores.Add(s);
            SaveStore();
        }

        private void SaveStore()
        {
            string path = @"./pizzaworkd.xml";
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>));
            xml.Serialize(file, Stores);
        }

        public static implicit operator List<object>(ClientSingleton v)
        {
            throw new NotImplementedException();
        }
    }
}