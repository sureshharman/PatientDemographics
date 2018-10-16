using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDemographics.Controllers
{
    public class PatientViewController : Controller
    {
        // GET: PatientView
        [Route("PatientView/PatientDetails")]
        public ActionResult Index()
        {
            return View();
        }
    }
}