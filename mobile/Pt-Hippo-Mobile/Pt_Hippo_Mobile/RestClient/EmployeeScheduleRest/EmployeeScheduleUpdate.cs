using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.EmployeeScheduleRest
{
   public class EmployeeScheduleUpdate : RestClient<bool>
    {
        public async Task<bool> EmployeeScheduleUpdatesync(string api, object data)
        {
            var job = await PutAsync(api,null, data);
            return job;
        }
    }
}
