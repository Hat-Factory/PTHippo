using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.SettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.SettingsRestClint
{
    class settingsget : RestClient<SettingsModel>
    {
        public async Task<SettingsModel> GetCurentUserDetailsAsync(string apiurl)
        {
            try
            {
                var MyProperty = await GetAsync(apiurl,null);
                return MyProperty;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
    }
}
