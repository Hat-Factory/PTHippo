using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.LoginRestClient
{
    class LoginRest :RestClient<string>
    {
        //KeyValues = new List<KeyValuePair<string, string>>
        //    {
        //        new KeyValuePair<string, string>("client_id" ,account.clientId ),
        //         new KeyValuePair<string, string>("grant_type" , "password"),
        //        new KeyValuePair<string, string>("username", userName),
        //        new KeyValuePair<string, string>("password" , password)


        //    };
    public async Task<string> LoginrestAsync(string userName, string password, AccountIdApi account , string url , List<KeyValuePair<string, string>> KeyValues)
        {
            var job = await LoginAsync(userName, password , account , url , KeyValues);
            return job;
        }
    }
}
