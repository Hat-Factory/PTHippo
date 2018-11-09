using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs.SavedJobs
{
    class DeleteSaved :RestClient<bool>
    {
        public async Task<bool> deleteData(string id, string url)
        {
            try
            {
                var job = await DeleteAsync(id, url);
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deletesaved",ex);
            }
                       
        }
    }
}
