using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient
{
   public static class URLConfig
    {

        private static string _monthlyCalenderAPI;

        public static string MonthlyCalenderAPI
        {
            get { return _monthlyCalenderAPI = "api/employeeProfile/monthlyCalendar"; }
        }

        private static string putskillsListAsyncurl;

        public static string PutskillsListAsyncurl
        {
            get { return putskillsListAsyncurl = "api/UpdateSkills"; }
        }
        private static string mobilelogg;

        public static string MobileLogging
        {
            get { return mobilelogg = "api/MobileLogging"; }
        }

        private static string getemployeesettings;

        public static string GetEmployeeSettings
        {
            get { return getemployeesettings = "api/employeeProfile/settings"; }
        }
        
        private static  string unsavedjob;
        public static string Unsavedjob
        {
            get { return unsavedjob = "api/employeeSavedJob/"; }
        }


        private static string geTskillDetailsurl;

        //TODO : Handle 1
        public static string GeTskillDetailsurl
        {
            //TODO: REMOVE THIS FROM THE API CALL
            get { return geTskillDetailsurl = "api/job/getAllSkillsByJobTypeId/"; }
         
        }

		private static string getcounter;

		public static string Getcounter
		{
            get { return getcounter = "api/job/getEmployerToRateCount"; }

		}
        private static string postanswer;

        public static string Postanswers
        {
            get { return postanswer = "api/rating"; }

        }

        private static string updatemediafileurl;

        public static string Updatemediafileurl
        {
            get { return updatemediafileurl = "api/document/Upload"; }
        
        }
       
        private static string updatelicence;

        public static string UpdateLicence
        {
            get { return updatelicence = "api/updateLicense"; }

        }
        private static string updateresume;

        public static string UpdateResume
        {
            get { return updatelicence = "api/updateResume"; }

        }
        private static string putspecialdayupdate;

        public static string Putspecialdayupdate
        {
            get { return putspecialdayupdate = "api/updateSchedule"; }

        }
        private static string addspecialday;

        public static string AddSpecialDay
        {
            get { return addspecialday = "api/createSchedule"; }

        }
        private static string userBasicDataAPI;

        public static string UserBasicDataAPI
        {
            get { return userBasicDataAPI = "api/users/userData"; }
           
        }
        private static string editbasicinfo;

        public static string Editbasicinfo
        {
            get { return editbasicinfo = "api/users"; }

        }
		private static string getratingquestion;

		public static string GetRatingQuestion
		{
		    
            get { return getratingquestion = "api/rating/getQuestions/1"; }

		}


        private static string putCurentUserDetailsAsyncurl;

        public static string PutCurentUserDetailsAsyncurl
        {
            get { return putCurentUserDetailsAsyncurl = "api/users"; }
         
        }
       
        private static string uRlUploadfileService;

        public static string UploadfileServiceURl
        {
            get { return uRlUploadfileService = "api/document/Upload"; }
        }

        private static string updateDocumentLicencesDataurldata;

        public static string UpdateDocumentLicencesDataurldata
        {
            get { return updateDocumentLicencesDataurldata = "api/updateLicenses"; }
        }

        private static string getstates;

        public static string GetStates
        {
            get { return getstates = "api/location/states"; }
        }


		private static string gettypes;

		public static string GetLicencetypes
		{
            get { return gettypes = "api/employeeProfile/licensestypes"; }

		}
        private static string getapicontactus;

        public static string Getapicontactus
        {
            get { return getapicontactus = "api/admin/contactus"; }

        }
        
        private static string myTimeSheetAPI;

        public static string MyTimeSheetAPI
        {
            get
            {
                return myTimeSheetAPI = "api/jobapplicant/timesheet"; 
            }
        }


        private static string getjobdetailsapi;

        public static string getjobdetailsapiurl
        {
            get
            {
                return getjobdetailsapi = "api/job";
                
            }
        }
		private static string getjobsummary;

		public static string Getjobsummary
		{
			get
			{
                return getjobsummary = "api/job/getEmployerToRate";

			}
		}

        private static string deleteAsyncurl;

        public static string DeleteAsyncurl
        {
            get { return deleteAsyncurl = "api/documents"; }

        }

        private static string deletelicence;

        public static string DeleteLicence
        {
            get { return deletelicence = "api/deleteLicense"; }

        }
        private static string deleteresume;

        public static string DeleteResumes
        {
            get { return deletelicence = "api/deleteResume"; }

        }
        private static string addlicence;

        public static string Addlicence
        {
            get { return addlicence = "api/employeeProfile/createLicense"; }



        }
        private static string addexp;

        public static string AddExp
        {
            get { return addexp ="api/employeeProfile/createResume"; }



        }


        private static string putAgreeonlicencessAsync;

        public static string PutAgreeonlicencessAsync
        {
            get { return putAgreeonlicencessAsync = "api/users/AgreeOnLicense"; }

        }

        private static string updateBankAccountAsync;

        public static string UpdateBankAccountAsync
        {
            get { return updateBankAccountAsync = "api/UpdateBankAccount"; }

        }

        private static string changePasswordAsync;

        public static string ChangePasswordAsync
        {
            get { return changePasswordAsync = "api/users/ChangePassword"; }

        }
        private static string clockout;

        public static string Clockout
        {
            get { return clockout = "api/jobapplicant/clockout"; }

        }
        private static string clockin;

        public static string Clockin
        {
            get { return clockin = "api/jobapplicant/clockin"; }

        }

        private static string currentEmployeeProfileAPI;

        public static string CurrentEmployeeProfileAPI
        {
            get { return currentEmployeeProfileAPI = "api/employeeProfile/currentuser"; }

        }
        private static string updateSchedulesurl;

        public static string UpdateSchedulesurl
        {
            get { return updateSchedulesurl = "api/updateSchedules"; }

        }
        private static string forgetpasswordurl;

        public static string Forgetpasswordurl
        {
            get { return forgetpasswordurl = "api/users/ForgetPassword"; }

        }
        private static string clientidurl;

        public static string Clientidurl
        {
            get { return clientidurl = "api/Account/CallerId?callerSource=mobile"; }

        }
        private static string loginurl;

        public static string Loginurl
        {
            get { return loginurl = "oauth2/token"; }

        }
        private static string jobTypeurl;

        public static string JobTypeurl
        {
            get { return jobTypeurl = "api/users/jobType"; }

        }
        private static string signUpEmployeeurl;

        public static string SignUpEmployeeurl
        {
            get { return signUpEmployeeurl = "api/users/SignUpEmployee"; }

        }
        private static string deleteSchdeualurl;

        public static string DeleteSchdeualurl
        {
            get { return deleteSchdeualurl = "api/deleteSchedules"; }

        }
        private static string searchurl;

        public static string SearchUrl
        {
            get { return searchurl = "api/job/getBasicSearchForJobs"; }

        }

        private static string savedJobsurl;

        public static string SavedJobsUrl
        {
            get { return savedJobsurl = "api/job/getSavedByEmployeeId"; }

        }
        private static string save;
        public static string SaveJobsUrl
        {
            get { return save = "api/job/save"; }

        }

        private static string appliedJobsurl;

        public static string AppliedJobsurl
        {
            get { return appliedJobsurl = "api/job/getAppliedByEmployeeId"; }

        }
        private static string updatebasicinfos;

        public static string Updatebasicinfos
        {
            get { return updatebasicinfos = "api/updateBasicInfo"; }

        }

        private static string updateResumes;

        public static string UpdateResumes
        {
            get { return updateResumes = "api/updateResumes"; }

        }
        private static string deleteResume;

        public static string DeleteResume
        {
            get { return updateResumes = "api/deleteResume"; }

        }

        private static string deleteSkill;

        public static string DeleteSkill
        {
            get { return deleteSkill = "api/deleteSkill"; }

        }

        private static string zipcodeurl;

        public static string ZipcodeUrl
        {
            get { return zipcodeurl = "api/zipcode"; }

        }

        private static string changestatus;

        public static string Changestatus
        {
            get { return changestatus = "api/jobApplicant/changestatus"; }

        }

        private static string ApplyJob;

        public static string applyJop
        {
            get { return ApplyJob = "api/jobApplicant/apply"; }

        }

        private static string settingsapiurl;

        public static string Settingsurl
        {
            get { return settingsapiurl = "api/employeeProfile/settings"; }

        }

        //api/jobApplicant/apply


        private static string getdoctypeurl;

        public static string getDocumentsByTypeUrl
        {
            get { return getdoctypeurl = "api/employeeProfile/getDocumentsByTypeForCurrentEmployee"; }

        }

        private static string backgroundCheckRequest;

        public static string BackgroundCheckRequest
        {
            get { return backgroundCheckRequest = "api/document/backgroundCheckRequest"; }

        }


        private static string getStripeRequest;

        public static string GetStripeRequest
        {
            get { return getStripeRequest = "api/billing/getStripeClientId"; }

        }


    }
}
