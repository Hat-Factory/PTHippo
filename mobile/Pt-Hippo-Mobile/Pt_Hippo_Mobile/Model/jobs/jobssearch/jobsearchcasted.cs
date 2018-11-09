using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs.jobssearch
{
   public class jobsearchcasted
    {
        public string Id { get; set; }
        public string JobType { get; set; }
        public string DesiredHrRate { get; set; }
        public string HireFirstApplicant { get; set; }
        public string JobRefrence { get; set; }
        public string FacilityName { get; set; }

        public string ExpireDate { get; set; }
        public string JobLocation { get; set; }
        public string HasParking { get; set; }
        public string HasPublicTransportation { get; set; }
        public string Distance { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
        public string JobTypeAbbreviation { get; set; }
        //public JobApplicantStatus Status { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedDate { get; set; }
        public string JobId { get; set; }
    }
}
