using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.licensesModel;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
    public class AddLicence:RestClient<licensesModel>
    {
        public async Task<licensesModel> Addnewlicence(string api, object data)
        {

            var Licencedata = await Post(api, data);
            return Licencedata;
        }
       
    }
}
