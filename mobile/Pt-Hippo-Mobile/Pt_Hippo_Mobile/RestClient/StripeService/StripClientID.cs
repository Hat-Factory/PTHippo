using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.StripeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.StripeService
{
    class StripClientID : RestClient<string>
    {
        public async Task<string> getstripClientId(string apiurl)
        {
            var clientid = await GetAsync(apiurl,null);
            return clientid;
        }
    }
}

 