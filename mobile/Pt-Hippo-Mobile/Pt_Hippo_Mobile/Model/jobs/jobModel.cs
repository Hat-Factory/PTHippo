using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs
{
    public class jobModel
    {
        public string id { get; set; }
        public string skillsText { get; set; }
        public string note { get; set; }
        public object title { get; set; }
        public double minHrRate { get; set; }
        public bool isSaved { get; set; }
        public string jobTypeId { get; set; }
        public int gender { get; set; }
        public bool isPartialyAllowed { get; set; }
        public string employerProfileId { get; set; }
        public string addressDescription { get; set; } 
        public string address { get; set; }
        public bool hireFirstApplicant { get; set; } 
        public string jobRefrence { get; set; }
        public bool isExpired { get; set; }
        public DateTime expireDate { get; set; }
        public string expdate { get; set; }
        public string locationId { get; set; }
        public string jobTermId { get; set; }
        public string jobApplicantId { get; set; }
        public int status { get; set; }
        public bool hasParking { get; set; }
        public bool hasPublicTransportation { get; set; }
        public string jobTypeTitle { get; set; }
        public List<JobSchedule> jobSchedules { get; set; }
        public double maxHrRate { get; set; }
        public List<JobSkill> jobSkills { get; set; }
        public bool hasApplicants { get; set; }
        public string jobTermTitle { get; set; }
        public object locationLatitude { get; set; }
        public object locationLongitude { get; set; }
        public string jobTypeAbbreviation { get; set; }
        public string distance { get; set; }
        public string fromtostring { get; set; }
        public string fromtodateString { get; set; }
        public string facilityText { get; set; }
        public string jobTitle { get; set; }
        public string applicantStatusText { get; set; }
        public bool? male { get; set; }
        public bool? female { get; set; }
        public bool isProfessionalInEnglish { get; set; }
        public string langugaes { get; set; }
        public bool showApply { get; set; }
        public bool showConfirmHiring { get; set; }
        public bool showCheckIn { get; set; }
        public bool showCheckOut { get; set; }
        public bool showCancel { get; set; } 
        public string states { get; set; }
        public string employerState { get; set; }
        public int yearsOfExperience { get; set; }
        public object recommendations { get; set; }
        public bool workAttireAvailable { get; set; }
        public string workAttireAvailablestring { get; set; }
        public bool scrubAvailable { get; set; }
        public string scrubAvailablestring { get; set; }
        public bool labCoatAvailable { get; set; }

        public string labCoatAvailablestring { get; set; }
        
        public  double requestedHrRate { get; set; }
    }
}
