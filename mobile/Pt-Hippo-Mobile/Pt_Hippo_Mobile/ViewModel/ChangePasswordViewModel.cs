using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ChangePasswordRest;

using Pt_Hippo_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    class ChangePasswordViewModel
    {
        ChangePasswordRestClient CPRCLIENT = new ChangePasswordRestClient();

        //ApiServices apiservice = new ApiServices();
        public  string NewPassword { get; set; }
        public  string OldPassword { get; set; }
        public INavigation Navigation { get; set; }
        public ChangePasswordViewModel()
        {

        }
        public ChangePasswordViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
        public ICommand changepasswords
        {
            get
            {

                return new Command(async () =>
                {
                    // lma a5od api

                    // Navigation.PushModalAsync(new MainPage());

                    // await apiservice.Forget(email);

                    // Debug.WriteLine("hello am working ");
                    try
                    {
                        ChangePassWord change = new ChangePassWord
                        {
                            newPassword = NewPassword.Trim(),
                            oldPassword = OldPassword.Trim()

                        };
                        await CPRCLIENT.ChangePasswordAsync(URLConfig.ChangePasswordAsync, change);
                        //await apiservice.PutRestpassword(change, Settings.AccessToken);
                        await App.Current.MainPage.DisplayAlert("Missing fields", AlertMessages.Renterpass, AlertMessages.OkayTitle);
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    catch(Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("changepasswordviewmodel", ex);
                        await logged.LoggAPI();
                    }
                });
            }
        }
    }
}

