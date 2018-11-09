using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.licensesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient
{
   public class LicencesData : RestClient<licensesModel>
    {
        public async Task<bool> UpdateDocumentLicencesData(List<licensesModel> model, string url)
        {
            var job = await PutListAsync(model, url);
            return job;
        }
        public async Task<bool> UpdateLicencesData(string api, string id,  licensesModel data)
        {
            var job = await PutAsync(api,id, data);
            return job;
        }
       
        
    }
}
