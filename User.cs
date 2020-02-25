using System.Xml.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Json_Data
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Profile Profile { get; set; }
        public List<Articles> Articles { get; set; }
    }

    public class Profile
    {
        public string Full_name { get; set; }
        public string Birthday { get; set; }
        public List<string> Phones { get; set; }
    }

    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Published_at { get; set; }
    }

    public class DataUser
    {
        static string path = @"/Users/gigaming/Json_Data/Database/User.json";
        
        public static void Phone()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);
            
            var result = jsonCon.Where(a => a.Profile.Phones.Count==0).Select(a => a.Profile.Full_name);
            
            Console.WriteLine("Users who doesn't have any phone numbers?");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Article()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.Where(a => a.Articles.Count != 0).Select(a => a.Profile.Full_name);

            Console.WriteLine("Users who have articles?");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Annis()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.Where(a => a.Profile.Full_name.ToLower().Contains("annis")).Select(a => a.Profile.Full_name);

            Console.WriteLine("Users who have 'annis' on their name?");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Year()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.Where(a => a.Articles.Any(b => b.Published_at.Date.Year == 2020)).Select(a => a.Profile.Full_name);

            Console.WriteLine("Users who have articles on year 2020?");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Born()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.Where(a => a.Profile.Birthday.Contains("1986")).Select(a => a.Profile.Full_name);

            Console.WriteLine("Users who are born on 1986?");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Tips()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.SelectMany(a => a.Articles.Where(b => b.Title.ToLower().Contains("tips")).Select( b => b.Title));

            Console.WriteLine("Articles that contain 'tips' on the title :");
            Console.WriteLine(String.Join(",", result));
        }

        public static void Published()
        {
            string json = File.ReadAllText(path);
            var jsonCon = JsonConvert.DeserializeObject<List<Users>>(json);

            var result = jsonCon.SelectMany(a => a.Articles.Where(b => b.Published_at.Month < 08).Select(b => b.Title));
            
            Console.WriteLine("Articles published before August 2019 :");
            Console.WriteLine(String.Join(",", result));
        }
    }
}