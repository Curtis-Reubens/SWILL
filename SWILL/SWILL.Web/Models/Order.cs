using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SWILL.Web.Models
{
    public class Order
    {
        [JsonProperty("username")]
        [Key, Column(Order = 0)]
        public string Username { get; set; }
        
        [JsonProperty("name")]
        [Key, Column(Order = 1)]
        public string Name { get; set; }

        [JsonProperty("collected")]
        public bool Collected { get; set; }
    }
}