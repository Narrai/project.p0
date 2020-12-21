using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private const string _path = @"./pizzaworkd.xml";
        private static ClientSingleton _instance;
        public static ClientSingleton Instance 
        { 
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
            Read();
        }

        // public IEnumerable<Store> GetAllStores()
        // {
            
        // }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            SaveStore();
        }

        private void SaveStore()
        {
            string path = _path;
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>));
            xml.Serialize(file, Stores);
        }

        private void Read()
        {
            if(!File.Exists(_path))
            {
                Stores = new List<Store>();
                return;
            }
            var file = new StreamReader(_path);
            var xml = new XmlSerializer(typeof(List<Store>));

            Stores = xml.Deserialize(file) as List<Store>;
             // null if cannot convert
            // Stores = (List<Store>) xml.Deserialize(file); // excetption if cannot convert
        }


        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out var input);
            return Stores.ElementAtOrDefault(input);
        }
    }
}