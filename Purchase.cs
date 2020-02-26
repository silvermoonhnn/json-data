using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Json_Data
{
    public class Order
    {
        public string Order_id { get; set;}
        public DateTime Created_at { get; set; }
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Item 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }

    public class Purchase
    {
        static string path = @"/Users/gigaming/Json_Data/Database/Purchase.json";

        public static void Febuary()
        {
            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Order>>(json);
            
            var result = jsonCon.Where(a => a.Created_at.Date.Month == 02).Select(a => a.Order_id).Count();
            
            Console.WriteLine("All purchases made in February :");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Ari()
        {
            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Order>>(json);

            var result = jsonCon.Where(a => a.Customer.Name.ToLower() == "ari").Sum(b => b.Items.Sum(c => c.Price * c.Qty));
            Console.WriteLine("All purchases made by Ari, and the grand total price of items :");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Grand()
        {
            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Order>>(json);

            var result = jsonCon.GroupBy(a => a.Customer.Name).Select(a => new { name = a.First().Customer.Name, total = a.Select(b => b.Items.Sum(c => c.Price * c.Qty)).Sum()}).Where( x => x.total < 300000);
            Console.WriteLine("People who have purchases with grand total lower than 300000 :");
            Console.WriteLine(String.Join(",", result));
        }
    }
}