using System;
using System.Collections.Generic;

namespace Json_Data
{
    public class Inventory
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

    // public class Inventory 
    // {
    //     static string path = @"/Users/gigaming/Json_Data/Database/Inventory.json";


    // }
}