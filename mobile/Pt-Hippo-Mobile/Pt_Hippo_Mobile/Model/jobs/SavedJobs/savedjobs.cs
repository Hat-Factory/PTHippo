using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs.SavedJobs
{
   public class savedjobs
    {
        public string id { get; set; }
        public string jobId { get; set; }
        public string employeeProfileId { get; set; }
        public string clinicName { get; set; }
        public string address { get; set; }
        public double distance { get; set; }
        public string jobType { get; set; }
        public int jobLatitude { get; set; }
        public int employeeLatitude { get; set; }
        public int jobLongitude { get; set; }
        public int employeeLongitude { get; set; }

    }
}
