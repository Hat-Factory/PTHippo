using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.LoginRestClient
{
    class ClientIDRest : RestClient<AccountIdApi>
    {
        public async Task<AccountIdApi> getClientIdformobile( string apiurl)
        {
            var job = await GetClientId(apiurl);
            return job;
        }
    }
}
