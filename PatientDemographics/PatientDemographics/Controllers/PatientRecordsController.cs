using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using PatientDemographicsRepository.Models;
using PatientDemographicsRepository.BussinessLayer;

namespace PatientDemographics
{
    public class PatientRecordsController : ApiController
    {
        private readonly IPatientRepository _patientRepo;
        public PatientRecordsController(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        /// <summary>
        /// This method is used to query patient data from db
        /// </summary>
        /// <returns>patient data</returns>
        [Route("api/patient"), HttpGet]
        public IQueryable<PatientRecord> GetPatientRecords()
        {
            return _patientRepo.GetPatientRecords();
        }


        /// <summary>
        /// This method post the patient data to database
        /// </summary>
        /// <param name="patientdata"></param>
        /// <returns>http status code 200 for successful submission</returns>
        [Route("api/patient"), HttpPost]
        public async Task<IHttpActionResult> PostPatientRecord(PatientDataModel patientdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int returnData = await _patientRepo.PostPatientRecord(patientdata);
            if (returnData == 2)
                return Conflict();
            else
                return Ok("Data posted successfully");
        }
    }
}