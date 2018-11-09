using System;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class EmployeeProfileHelper
    {
        public static Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model.EmployeeCurrentProfile EmployeeCurrentProfile;

        public static async Task<EmployeeCurrentProfile> RefreshEmployeeCurrentProfile(bool refresh = false)
        {
            if (refresh)
            {
                BasicinformationDetails api = new BasicinformationDetails();
                EmployeeCurrentProfile = await api.GetCurentUserBasicinformationDetailsAsync(URLConfig.CurrentEmployeeProfileAPI);
            }

            return EmployeeCurrentProfile;
        }
    }
}
