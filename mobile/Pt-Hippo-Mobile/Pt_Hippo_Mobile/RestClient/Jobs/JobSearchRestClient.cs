using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Jobs
{
   public class JobSearchRestClient : RestClient<JobSearchModel>
    {
        public JobSearchModel job { get; set; }
        public JobSearchRestClient()
        {
            job = new JobSearchModel();
        }

        public async Task<JobSearchModel> GeTJobsearchDetails(string api, string searchtext, int pagesize, int pagenumber , string ZipCode , DateTime startdate , DateTime enddate ,double minhourrate , double maxhourate)
        {
            try
            {
                job = await GetSearch(api, searchtext, pagesize, pagenumber , ZipCode , startdate,enddate,minhourrate,maxhourate);
                return job;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobsearchrestclient", ex);
                await logged.LoggAPI();
            }
            return null;
             
        }
    }
}
