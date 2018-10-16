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

namespace PatientDemographics.BussinessLayer
{
    public interface IRepo
    {
        IQueryable<PatientRecord> GetPatientRecords();
        Task<int> PostPatientRecord(PatientDataModel patientdata);
    }
    public class PatientRepo : IRepo
    {
        private PatientDemographicsDBEntities1 db = new PatientDemographicsDBEntities1();
        //Method to retrieve patients from db
        public IQueryable<PatientRecord> GetPatientRecords()
        {
            return db.PatientRecords;
        }

        //Method to add patients
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

        //Method to check if patient is already exist in the db
        private bool PatientRecordExists(string id)
        {
            return db.PatientRecords.Count(e => e.PatientID == id) > 0;
        }
    }
}