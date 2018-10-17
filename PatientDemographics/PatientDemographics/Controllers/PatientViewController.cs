using System.Web.Mvc;

namespace PatientDemographics.Controllers
{
    public class PatientViewController : Controller
    {
        /// <summary>
        /// This action method is used to render view to display list of patient details
        /// </summary>
        /// <returns>view to show patients</returns>
        [Route("PatientView/PatientDetails")]
        public ActionResult Index()
        {
            return View();
        }
    }
}