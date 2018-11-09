using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.SettingsRestClint
{
   public class SettingsApi : RestClient<bool> 
    {
        public async Task<bool> UpdateSettingsState(string api, object data)
        {
            try
            {
                var updated = await PutAsync(api,null, data);
                return updated;

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error while trying to update settings", ex);
                logged.LoggAPI();
            }

            return false;
        }
    }
}
