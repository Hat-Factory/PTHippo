using System;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class InternetOrServeHelper
    {
        public static bool ShowNoInternetMessage = false;


        public async static Task ShowCheckInternet(bool showAgain = false)
        {
            if (InternetOrServeHelper.ShowNoInternetMessage == false && App.Current.MainPage != null)
            {
                InternetOrServeHelper.ShowNoInternetMessage = true;
                string message = showAgain == true ? AlertMessages.StillNoInternetConnection : AlertMessages.internetconnection;

                LoadingIndicatorHelper.HideIndicator();

                await App.Current.MainPage.DisplayAlert("Internet Connection", message, "Okay");

                if (!CrossConnectivity.Current.IsConnected)
                {
                    InternetOrServeHelper.ShowNoInternetMessage = false;
                    await ShowCheckInternet(true);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Settings.AccessToken))
                    {

                        InternetOrServeHelper.ShowNoInternetMessage = false;
                        if (EmployeeProfileHelper.EmployeeCurrentProfile == null
                           || EmployeeProfileHelper.EmployeeCurrentProfile.User == null)
                        {
                            await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                        }
                    }
                }

            }
        }

        public static bool ShowErrorFlagMessage = false;

        public async static Task ShowErrorMessage(string refrence)
        {
            if (InternetOrServeHelper.ShowErrorFlagMessage == false && ShowNoInternetMessage == false)
            {
                ShowErrorFlagMessage = true;
                string message = $"Error has occured your refrence number {refrence}..Please contact PT Hippo administration";
                if(App.Current.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", message, "Okay"); 
                }
                ShowErrorFlagMessage = false;

            }
        }
    }
}
