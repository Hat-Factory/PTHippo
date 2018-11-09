using Pt_Hippo_Mobile.Model.SettingsModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.RestClient.SettingsRestClint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using Plugin.RestClient;

namespace Pt_Hippo_Mobile.ViewModel.SettingsViewModel
{
    public class SettingsControler : BaseViewModel
    {
        public static int IntialLoad = 0;
        public SettingsControler()
        {
            settings = new SettingsModel();
            getuserinfo();
        }
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();
        SettingsApi UpdateSettings = new SettingsApi();
        private SettingsModel settings;

        public SettingsModel SettingsProp
        {
            get { return settings; }
            set
            {
                settings = value;
                OnPropertyChangedEventhander();
            }
        }

        public async void getuserinfo()
        {
            try
            {
                RestClient<SettingsModel> RC = new RestClient<SettingsModel>();
                var ApiSettings = await RC.GetAsync(URLConfig.GetEmployeeSettings, null);

                SettingsProp = new SettingsModel { enableJobBroadcasting = ApiSettings.enableJobBroadcasting };
                
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in settimgsviewmodel", ex);
                await logged.LoggAPI();
            }
        }
        public async Task UpdateSettingsState()
        {
            try
            {
                     await UpdateSettings.UpdateSettingsState(URLConfig.Settingsurl, SettingsProp);
                    EmployeeProfileHelper.EmployeeCurrentProfile.EnableJobBroadcasting = SettingsProp.enableJobBroadcasting;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in settimgsviewmodel", ex);
                await logged.LoggAPI();
            }

        }


    }
}
