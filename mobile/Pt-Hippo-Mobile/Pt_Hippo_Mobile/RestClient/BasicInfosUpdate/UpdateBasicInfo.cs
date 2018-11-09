using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.BaicInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.BasicInfosUpdate
{
    public  class UpdateBasicInfo : RestClient<EmployeeCurrentProfile>
    {

        public async Task<bool> UpdateBasicInfoAsync(string api, object data)
        {
            try
            {
                var updated = await PutAsync(api,null, data);
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updatebasicinfo", ex);
            }
            return false;
        }
         
    }
}
