using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.ResumesRest
{
    public class Updateresume:RestClient<Resume>
    {
        public async Task<bool> Updatespecficresume(string api,  object data)
        {


            var updated = await PutAsync(api,null, data);
            return updated;
        }

    }
}