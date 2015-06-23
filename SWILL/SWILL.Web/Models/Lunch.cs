using System.Collections.Generic;
using Newtonsoft.Json;

namespace SWILL.Web.Models
{
    public class Lunch
    {
        [JsonProperty("dishes")]
        public ICollection<Dish> Dishes { get; set; } 
    }
}