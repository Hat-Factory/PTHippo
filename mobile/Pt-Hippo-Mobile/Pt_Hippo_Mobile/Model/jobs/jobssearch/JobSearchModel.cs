using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs
{
   public class JobSearchModel
    {
        public List<JobDataModel> result { get; set; }

        public int TotalCount { get; set; }
        public int TotalApplied { get; set; }
        public int TotalSaved { get; set; }


    }
}
