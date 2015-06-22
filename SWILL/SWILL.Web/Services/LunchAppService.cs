using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace SWILL.Web.Services
{
    public class LunchAppService
    {
        public IEnumerable<Dish> GetDishesForDay(DateTime day)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SWILL.Web.Data.SampleApiResponse.json"))
            using (var reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<List<Dish>>(reader.ReadToEnd());
            }
        }
    }

    public class LunchService
    {
        public Service GetServiceDetails(DateTime day)
        {
            var lunchAppService = new LunchAppService();
            return new Service { Dishes = lunchAppService.GetDishesForDay(day).ToList() };
        }
    }

    public class Service
    {
        public ICollection<Dish> Dishes { get; set; } 
    }

    public class Dish
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("orders")]
        public IList<Order> Orders { get; set; }
    }

    public class Order
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        public bool Collected { get; set; }
    }
}