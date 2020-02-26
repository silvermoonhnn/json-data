using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Json_Data
{
    public class Items
    {
        public int Inventory_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Tags { get; set; }
        public int Purchased_at { get; set; }
        public Placement Placement { get; set; }
    }

    public class Placement
    {
        public int Room_id { get; set; }
        public string Name { get; set; }
    }

    public class Inventory 
    {
        static string path = @"/Users/gigaming/Json_Data/Database/Inventory.json";

        public static void Items()
        {
            var path1 = @"/Users/gigaming/Json_Data/Database/items.json";

            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Items>>(json);
            var result = jsonCon.Where(a => a.Placement.Name.ToLower() == "meeting room");
            var fin = JsonConvert.SerializeObject(result);
            
            File.WriteAllText(path1, fin);
        }

        public static void Electronic()
        {
            var path2 = @"/Users/gigaming/Json_Data/Database/electronic.json";

            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Items>>(json);
            var result = jsonCon.Where(a => a.Type.Contains("electronic"));
            var fin = JsonConvert.SerializeObject(result);
            
            File.WriteAllText(path2, fin);
        }

        public static void Furnitures()
        {
            var path3 = @"/Users/gigaming/Json_Data/Database/furnitures.json";

            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Items>>(json);
             var result = jsonCon.Where(a => a.Type.Contains("furniture"));
            var fin = JsonConvert.SerializeObject(result);
            
            File.WriteAllText(path3, fin);
        }

        public static void Brown()
        {
            var path5 = @"/Users/gigaming/Json_Data/Database/all-browns.json";

            var json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Items>>(json);
            var result = jsonCon.Where(a => a.Tags.Contains("brown"));
            var fin = JsonConvert.SerializeObject(result);
            
            File.WriteAllText(path5, fin);
        }

    }
}