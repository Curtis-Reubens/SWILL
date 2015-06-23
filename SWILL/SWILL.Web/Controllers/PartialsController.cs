using System.Web.Mvc;

namespace SWILL.Web.Controllers
{
    /// <summary>
    /// AngularJS will load the majority of content as a partial view. 
    /// 
    /// This controller allows us to specify the name of the view in Views/Partials and get back the contents of the partial view.
    /// </summary>
    public class PartialsController : Controller
    {
        public ActionResult GetPartial(string view)
        {
            return PartialView(view);
        }
    }
}