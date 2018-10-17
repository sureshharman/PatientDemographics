using System;
using System.Linq;
using System.Threading.Tasks;
using PatientDemographicsRepository.Models;
using System.Data.Entity.Infrastructure;

namespace PatientDemographicsRepository.BussinessLayer
{
    /// <summary>
    /// Interface to implement DI on PatientRepo class
    /// </summary>
    public interface IPatientRepository
    {
        IQueryable<PatientRecord> GetPatientRecords();
        Task<int> PostPatientRecord(PatientDataModel patientdata);
    }

    public class PatientRepo : IPatientRepository
    {
        private PatientDataEntities db = new PatientDataEntities();

        /// <summary>
        /// Method to retrieve patients from db
        /// </summary>
        /// <returns>list of patient data</returns>
        public IQueryable<PatientRecord> GetPatientRecords()
        {
            return db.PatientRecords;
        }

        /// <summary>
        ///Method to add patients in to db
        /// </summary>
        /// <param name="patientdata"></param>
        /// <returns>1 for successful posting and 2 for conflicts in data</returns>
        public async Task<int> PostPatientRecord(PatientDataModel patientdata)
        {
            Guid gid = Guid.NewGuid();
            PatientRecord pr = new PatientRecord()
            {
                PatientID = gid.ToString(),
                ForeName = patientdata.ForeName,
                SurName = patientdata.SurName,
                Gender = patientdata.Gender,
                DateofBirth = patientdata.DateofBirth,
                HomeNumber = patientdata.TelePhoneNumbers.HomeNumber,
                WorkNumber = patientdata.TelePhoneNumbers.WorkNumber,
                MobileNumber = patientdata.TelePhoneNumbers.MobileNumber,
            };
            db.PatientRecords.Add(pr);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientRecordExists(pr.PatientID))
                {
                    return 2;
                }
                else
                {
                    throw;
                }
            }
            return 1;
        }

        /// <summary>
        /// Method to check if patient is already exist in the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the patient data already exists</returns>
        private bool PatientRecordExists(string id)
        {
            return db.PatientRecords.Count(e => e.PatientID == id) > 0;
        }
    }
}