using System.Web.Mvc;
using System.Web.Routing;

namespace SWILL.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //Angular needs to get the HTML for partial views.
            //This route invokes the PartialsController with the specified view.
            routes.MapRoute(
                name: "AngularPartials",
                url: "partials/{view}",
                defaults: new { controller = "Partials", action = "GetPartial", view = "Home" }
            );

            //For everything else, we just need to redirect to Home.
            //Angular will then inspect the URL on the client side and load the right partial view.
            routes.MapRoute(
                name: "AngularTemplateCatchAll",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
