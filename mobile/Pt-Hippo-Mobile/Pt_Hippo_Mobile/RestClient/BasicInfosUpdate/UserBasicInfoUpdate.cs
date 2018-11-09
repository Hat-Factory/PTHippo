using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.Model.licensesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.BasicInfosUpdate
{
    public class UserBasicInfoUpdate : RestClient<EmployeeCurrentProfile>
    {
        public EmployeeCurrentProfile MyProperty { get; set; }
        public UserBasicInfoUpdate()
        {
            MyProperty = new EmployeeCurrentProfile();
        }
        public async Task<EmployeeCurrentProfile> GetCurentUserDetailsAsync(string apiurl)
        {
            try
            {


                MyProperty  = await GetAsync(apiurl,null);
                return MyProperty;
            }
            catch (Exception ex)
            {

                throw new Exception("Error in userbasicinfoupdates",ex);
                
            }
          
        }


    }
}
