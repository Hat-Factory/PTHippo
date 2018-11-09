using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Jobs
{
   public class JobSavedRestClient : RestClient<JobDataModel>
    {
        public List<JobDataModel> job { get; set; }
        public JobSavedRestClient()
        {
            job = new List<JobDataModel>();
        }
        public async Task<List<JobDataModel>> GetSavedJobs(string api)
        {
            try
            {
                 job = await GetListOptionalId(api,null);
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in jobsaved",ex);

            }            
        }

        public async Task<bool> PostSaveJob(string api , string id)
        {
            try
            {
                var valid = await Post(api, id);
                return valid;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in jobsaved", ex);
            }
      
        }
    }
}
