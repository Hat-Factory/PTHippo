using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
    public class StateApiGet:RestClient<statemodel>
    {
        public async Task<List<statemodel>> GetStateapi(string api)
        {

            var job = await GetListOptionalId(api,null);
            return job;
        }
       
    }
}
