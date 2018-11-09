using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class JobsCounterHelper
    {
        public static int NoOfCurrentJobs = 0;
        public static int NoOFSavedJobs = 0;
        public static int NoOfAppliedJobs = 0;

        public static void Intialize()
        {
            NoOfCurrentJobs = 0;
            NoOFSavedJobs = 0;
            NoOfAppliedJobs = 0; 
        }
        public static string _noOfCurrentJobsText = "";
        public static string _noOFSavedJobsText = "";
        public static string _noOfAppliedJobsText = "";

        public static string NoOfCurrentJobsText()
        {
            _noOfCurrentJobsText = $" Current ({NoOfCurrentJobs}) ";
            return _noOfCurrentJobsText;
        }

        public static string NoOFSavedJobsText()
        {
            _noOFSavedJobsText = $" Saved ({NoOFSavedJobs}) ";
            return _noOFSavedJobsText;
        }

        public static string NoOfAppliedJobsText()
        {
            _noOfAppliedJobsText = $" Applied ({NoOfAppliedJobs}) ";
            return _noOfAppliedJobsText;
        }

    }
}
