using System;
using Microsoft.AspNet.SignalR;
using SWILL.Web.Models;
using SWILL.Web.Services;

namespace SWILL.Web.Hubs
{
    /// <summary>
    /// A SignalR Hub which co-ordinates all information about the day's lunch and broadcasts updates to different clients.
    /// </summary>
    public class SwillHub : Hub
    {
        private readonly LunchService lunchService;

        public SwillHub()
            : this(new LunchService()) { }

        //This constructor can be used for testing purposes.
        //For super-extra-bonus-points, implement proper Dependency Injection. There are lots of tutorials online.
        public SwillHub(LunchService lunchService)
        {
            this.lunchService = lunchService;
        }
        
        public Lunch GetLunchDetails(DateTime date)
        {
            return lunchService.GetServiceDetails(date);
            
        }

        public void MarkLunchAsCollected(string dish, string person)
        {
            lunchService.MarkOrderAsCollected(dish, person);

            //Note how we can return an anonymouse object here, which makes things neater on the client side.
            Clients.All.lunchCollected(new { dish = dish, person = person });
        }
    }
}