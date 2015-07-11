using System;
using System.Linq;
using log4net;
using SWILL.Web.DataAccess;
using SWILL.Web.Models;

namespace SWILL.Web.Services
{
    /// <summary>
    /// Responsible for all of the logic around collecting lunches and managing the lunchtime workfow.
    /// </summary>
    public class LunchService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LunchService));

        public virtual Lunch GetServiceDetails(DateTime day)
        {
            try
            {
                var lunchAppService = new LunchAppQueryService();
                var allDishes = lunchAppService.GetDishesForDay(day).ToList();

                //All of the database code here needs to be replaced. This is just to remind you of how to access the database.
                using (var db = new SwillDataContext())
                {
                    //Pull the orders which we've saved out of the database.
                    var savedOrders = db.Orders.ToList();

                    //Loop through all of the dishes from the LunchApp.
                    foreach (var dish in allDishes)
                        foreach (var order in dish.Orders)
                        {
                            //See if we've saved any information about this order in the database
                            var saved = savedOrders.SingleOrDefault(o => o.Name == order.Name);

                            //If so, restore the state of the Collected property.
                            if (saved != null)
                                order.Collected = saved.Collected;
                        }
                }

                return new Lunch { Dishes = allDishes };
            }
            catch (Exception e)
            {
                logger.Error("Error retrieving service details.", e);
                throw;
            }
        }

        //This is an example of the sort of logic we might want, but probably shouldn't stay once we've written a proper data model.
        public virtual Order GetOrderForPerson(DateTime day, string dish, string person)
        {
            return GetServiceDetails(day)
                .Dishes
                .Single(d => d.Name == dish)
                .Orders
                .FirstOrDefault(o => o.Name == person);
        }

        public void MarkOrderAsCollected(string dish, string person)
        {
            try
            {
                //In reality, each dish should have a unique ID, so the name and person will become irrelevant.
                //Also, we should look to inject the Data Context and make this testable eventually.
                using (var db = new SwillDataContext())
                {
                    var order = GetOrderForPerson(DateTime.Now, dish, person);
                    var savedOrder = db.Orders.SingleOrDefault(o => o.Name == order.Name && o.Username == order.Username);

                    //If we haven't saved collection information...
                    if (savedOrder == null)
                    {
                        order.Collected = true;
                        db.Orders.Add(order);
                        db.SaveChanges(); //Remember to call SaveChanges!
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Error marking order as collected.", e);
                throw;
            }
        }
    }
}