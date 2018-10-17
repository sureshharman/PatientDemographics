using System.Web.Mvc;

namespace PatientDemographics.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This method returns index view to add patient data in db.
        /// </summary>
        /// <returns>view to add patient</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}