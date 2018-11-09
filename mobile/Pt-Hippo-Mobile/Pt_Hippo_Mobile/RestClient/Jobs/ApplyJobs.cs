using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Jobs
{
   public class ApplyJobs  : RestClient<bool>
    {


        public async Task<bool> GeTSavedJobs(string api , object data)
        {
            var job = await Post(api , data);
            return job;
        }
    }
}
