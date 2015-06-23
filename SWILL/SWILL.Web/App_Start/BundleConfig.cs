using System.Web.Optimization;

namespace SWILL.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/swill").Include(
                      "~/Scripts/lodash.js", 
                      "~/Scripts/angular.js", 
                      "~/Scripts/angular-route.js",
                      "~/Scripts/Swill/SWILL.js").IncludeDirectory(
                      "~/Scripts/Swill/Controllers", "*.js")); //If we create any new controllers in /Scripts/Swill/Angular, these will automatically be loaded.

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/SWILL.css"));

            //TODO: We should set this to true in release mode. 
            BundleTable.EnableOptimizations = false;
        }
    }
}
