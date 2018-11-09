using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.ChangePasswordRest
{
    class ChangePasswordRestClient:RestClient<ChangePassWord>
    {
        public async Task<bool> ChangePasswordAsync(string api, object data)
        {

            var validChange = await PutAsync(api,null, data);
            return validChange;
        }
    }
}
