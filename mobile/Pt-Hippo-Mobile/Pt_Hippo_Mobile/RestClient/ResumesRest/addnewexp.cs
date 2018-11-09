using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.ResumesRest
{
    public class addnewexp: RestClient<Resume>
    {
        public async Task<Resume> AddnewExp(string api, object data)
        {

            var Resumedata = await Post(api,data);
            return Resumedata;
        }

    }
}

