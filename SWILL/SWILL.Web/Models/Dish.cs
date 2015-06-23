using System.Collections.Generic;
using Newtonsoft.Json;

namespace SWILL.Web.Models
{
    public class Dish
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("orders")]
        public IList<Order> Orders { get; set; }
    }
}