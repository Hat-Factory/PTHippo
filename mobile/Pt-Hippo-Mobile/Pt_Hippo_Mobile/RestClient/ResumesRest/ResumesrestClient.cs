using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.ResumesRest
{
   public class ResumesrestClient : RestClient<Resume>
    {
        public async Task<bool> UpdateResumeAsync(string api, string ID, ObservableCollection<Resume> data)
        {
            try
            {
                var job = await PutAsync(api, ID, data);
                return job;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in resumeviewmodel", ex);
                await logged.LoggAPI();
            }


            return false;
        }
    }
}
