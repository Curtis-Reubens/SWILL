using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace SWILL.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Set up our logging config to read from the App.Config settings.
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger(typeof(MvcApplication)).InfoFormat("SWILL::Application_Start");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
