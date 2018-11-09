using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.BasicinformationRest
{
    class BasicinformationDetails : RestClient<EmployeeCurrentProfile>
    {

        public async Task<EmployeeCurrentProfile> GetCurentUserBasicinformationDetailsAsync(string apiurl)
        {
            var job = await GetAsync(apiurl,null);
            return job;
        }
    }
}
