using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.RegistrationRest
{
  public class RegistrationJobType : RestClient<jobType>
    {
        public async Task<List<jobType>> JOBS(string url)
        {
            var job = await GetListOptionalId(url, null, false);
            return job;
        }

        public async Task<bool> RegistrationPostAsync(string url , RegisterBindingModel model)
        {
            return await PostApi(url , model);
        }
    }
}
