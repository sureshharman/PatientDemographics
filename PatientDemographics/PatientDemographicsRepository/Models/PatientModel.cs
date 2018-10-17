using System;
using System.Runtime.Serialization;

namespace PatientDemographicsRepository.Models
{
    [DataContract(Namespace = "")]
    public class PatientDataModel
    {
        [DataMember]
        public string PatientID { get; set; }
        [DataMember]
        public string ForeName { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime DateofBirth { get; set; }
        [DataMember]
        public TelepohneNumber TelePhoneNumbers { get; set; }
    }

    [DataContract(Namespace = "")]
    public class TelepohneNumber
    {
        [DataMember]
        public string HomeNumber { get; set; }
        [DataMember]
        public string WorkNumber { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }

    }
}