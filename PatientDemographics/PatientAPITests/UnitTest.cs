using System;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using PatientDemographicsRepository.Models;
using PatientDemographics;
using PatientDemographicsRepository.BussinessLayer;
using System.Web.Http.Results;
using System.Linq;

namespace PatientAPITests
{
    [TestFixture]
    public class UnitTest
    {
        // Creating object HTTP client
        private readonly HttpClient apiClient = new HttpClient();
        [Test, Description("Testing the API method to post the patient data")]
        public async Task PostTestMethod()
        {
            PatientRecordsController controllerObject = new PatientRecordsController(new PatientRepo());
            PatientDataModel patientData = new PatientDataModel() { ForeName = "Test ForeName", SurName = "Test SurName", Gender = "Male", DateofBirth = DateTime.Now, TelePhoneNumbers = new TelepohneNumber() { HomeNumber = "9999999999" } };
            var h = await controllerObject.PostPatientRecord(patientData) as OkNegotiatedContentResult<System.String>; ;
            Assert.AreEqual(h.Content.ToLower(), "data posted successfully");
        }

        [Test, Description("Testing the API method to get the patient data from db")]
        public void GetTestMethod()
        {
            PatientRecordsController controllerObject = new PatientRecordsController(new PatientRepo());
            IQueryable<PatientRecord> patientData = controllerObject.GetPatientRecords();
            Assert.LessOrEqual(0, patientData.Count<PatientRecord>());
        }
    }
}
