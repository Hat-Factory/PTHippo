using Pt_Hippo_Mobile.Model.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class JobListHelper
    {
        public static int CurrentPage = 1;
        public static int PageSize = 100;
        public static int FilterPageSize = 1;
        public static bool IsSearching = false;
        public static bool IsApplied = false;
        public static bool IsSaved = false;

        public static bool ExpireTimerEnabled = false;
        public static void IntialzieList()
        {
            if(SearchJobsModel == null)
            {
                IsSearching = false;
                IsApplied = false;
                ExpireTimerEnabled = false;
                SearchJobsModel = new JobSearchModel();
                SearchJobsModel.result = new List<JobDataModel>();
                SavedJobsModel = new List<JobDataModel>();
                AppliedJobsModel = new List<JobDataModel>();
                CurrentPage = 1;
            }
        }
        public static JobSearchModel SearchJobsModel;
        public static List<JobDataModel> SavedJobsModel;
        public static List<JobDataModel> AppliedJobsModel;

        public static bool IsFirstTime = true;
        public static ObservableCollection<JobDataModel> jhcast;
        public static DateTime LastScrollTime = DateTime.Now;


    }
}
