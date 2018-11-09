using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.ForgetPassword
{
    class ForgetPasswordRestClient : RestClient<bool>
    {
          

        public async Task<bool> ForgetPasswordAsync(string api, object data)
        {

            var job = await PutAsync(api,null, data, false);
            return job;
        }
    }
}
