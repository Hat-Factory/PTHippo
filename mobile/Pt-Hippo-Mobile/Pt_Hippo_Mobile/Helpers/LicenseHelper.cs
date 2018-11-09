using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using System.Linq;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class LicenseHelper
    {

        public static List<statemodel> StatesList;
        public static List<licencetype> LicenceTypes;

        public static async Task IntializeStates()
        {
            if (StatesList == null)
            {
                StateApiGet getapi = new StateApiGet();
                StatesList = await getapi.GetStateapi(URLConfig.GetStates);

            }
        }

        public static async Task IntializeTypes()
        {
            if (LicenceTypes == null)
            {
                GetTitles gettype = new GetTitles();
                LicenceTypes = await gettype.Typess(URLConfig.GetLicencetypes);

            }
        }


    }
}
