using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PatientDemographics.Models;
using PatientDemographics.BussinessLayer;

namespace PatientDemographics
{
    public class PatientRecordsController : ApiController
    {
        private readonly IRepo _repo;
        public PatientRecordsController(IRepo repo)
        {
            _repo = repo;
        }

        // GET: api/PatientRecords
        [Route("api/getpatientdata"), HttpGet]
        public IQueryable<PatientRecord> GetPatientRecords()
        {
           return _repo.GetPatientRecords();
        }

        // POST: api/PatientRecords
        [Route("api/postpatientdata"), HttpPost]
        public async Task<IHttpActionResult> PostPatientRecord(PatientDataModel patientdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int returnData = await _repo.PostPatientRecord(patientdata);
            if (returnData == 2)
                return Conflict();
            else
                return Ok("Data posted successfully");
        }
    }
}