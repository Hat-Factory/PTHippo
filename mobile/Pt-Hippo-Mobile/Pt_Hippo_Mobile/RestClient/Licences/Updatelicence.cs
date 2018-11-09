using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.licensesModel;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
    public class Updatelicence : RestClient<licensesModel>
    {
        public async Task<bool> Updatespecficlicence(string api ,string id, object data)
        {

           
            var job = await PutAsync(api,id, data);
            return job;
        }

    }
}
