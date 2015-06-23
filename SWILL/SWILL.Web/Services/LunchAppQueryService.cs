using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SWILL.Web.Models;

namespace SWILL.Web.Services
{
    /// <summary>
    /// Responsible for querying the LunchApp API.
    /// </summary>
    public class LunchAppQueryService
    {
        //Dummy implementation for testing. Make sure we get rid of this and delete the sample response at some point.
        public IEnumerable<Dish> GetDishesForDay(DateTime day)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SWILL.Web.Data.SampleApiResponse.json"))
            using (var reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<List<Dish>>(reader.ReadToEnd());
            }
        }
    }
}