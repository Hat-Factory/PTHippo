using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient
{
   public static class URLConfig
    {


        private static string putskillsListAsyncurl;

        public static string PutskillsListAsyncurl
        {
            get { return putskillsListAsyncurl = "api/UpdateSkills"; }
        }



        private static string geTskillDetailsurl;

        public static string GeTskillDetailsurl
        {
            get { return geTskillDetailsurl = "api/job/getAllSkillsByJobTypeId/1"; }
         
        }
        private static string getmytimesheet;

        public static string Getmytimesheet
        {
            get { return getmytimesheet = "http://13.94.204.175/api/jobapplicant/timesheet/"; }

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



        private static string getCurentUserDetailsAsyncurl;

        public static string GetCurentUserDetailsAsyncurl
        {
            get { return getCurentUserDetailsAsyncurl = "api/users/userData"; }
           
        }
		private static string getratingquestion;

		public static string GetRatingQuestion
		{
            get { return getratingquestion = "api/rating/"; }

		}


        private static string putCurentUserDetailsAsyncurl;

        public static string PutCurentUserDetailsAsyncurl
        {
            get { return putCurentUserDetailsAsyncurl = "api/users/"; }
         
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

     
        private static string getDocumentLicencesDataUrl;

        public static string GetDocumentLicencesDataUrl
        {
            get { return getDocumentLicencesDataUrl = "api/documents/employeeprofile/1"; }
            
        }

		private static string getapicontactus;

		public static string Getapicontactus
		{
			get { return getapicontactus = "api/admin/contactus"; }

		}
       

        private static string getjobdetailsapi;

        public static string getjobdetailsapiurl
        {
            get
            {
                return getjobdetailsapi = "api/jobapplicant/timesheet/";
                
            }
        }
		private static string getjobsummary;

		public static string Getjobsummary
		{
			get
			{
				return getjobsummary = "api/rating/jobsummary/";

			}
		}

        private static string deleteAsyncurl;

        public static string DeleteAsyncurl
        {
            get { return deleteAsyncurl = "api/documents/"; }

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

        private static string currentuserapiurl;

        public static string Currentuserapiurl
        {
            get { return currentuserapiurl = "api/employeeProfile/currentuser"; }

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
            get { return deleteSchdeualurl = "api/deleteSchedules/"; }

        }
        private static string searchurl;

        public static string SearchUrl
        {
            get { return searchurl = "api/job/getBasicSearchForJobs"; }

        }

        private static string savedJobsurl;

        public static string SavedJobsUrl
        {
            get { return savedJobsurl = "api/employeeSavedJob"; }

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
            get { return updateResumes = "api/updateResumes/"; }

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

       


    }
}
