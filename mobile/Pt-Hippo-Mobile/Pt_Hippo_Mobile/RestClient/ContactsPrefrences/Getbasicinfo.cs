using Plugin.RestClient;
using Pt_Hippo_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.RestClient.ContactsPrefrences
{
    class Getbasicinfo : RestClient<EmployeeCurrentData>
    {
        public EmployeeCurrentData job { get; set; }

        public Getbasicinfo()
        {
            job = new EmployeeCurrentData();
        }
        public async Task<EmployeeCurrentData> GetCurentUserDetailsAsync(string apiurl)
        {
            try
            {
                job = await GetAsync(apiurl,null);
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getbasicinfo",ex);
              

            }
            return job;
        }
        
    }
}
