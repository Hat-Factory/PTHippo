using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient
{
    public class JobsServices : RestClient<jobModel>
    {
        public jobModel job { get; set; }
        public JobsServices()
        {
            job = new jobModel();
        }
        public async Task<jobModel>  GeTJobDetails(string joburl , string jobid )
        {
            try
            {
                job = await GetAsync(joburl, jobid);
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in jobservices", ex);
              
                
            }
         
        }
    }
}
