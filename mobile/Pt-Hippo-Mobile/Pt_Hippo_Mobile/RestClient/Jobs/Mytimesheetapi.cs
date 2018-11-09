using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.Jobs
{
    public class Mytimesheetapi: RestClient<jobtimesheetmodel>
    {
        public async Task<List<jobtimesheetmodel>> Getlistapi(string apiurl)
        {
            var mytime = await GetListOptionalId(apiurl,null);
            return mytime;
        }
    }
}
