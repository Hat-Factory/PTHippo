using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ForgetPassword;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Views;
using Pt_Hippo_Mobile.RestClient.LoginRestClient;

namespace Pt_Hippo_Mobile.ViewModel
{
    class ForgetpasswordViewModel : BaseViewModel
    {
         
        ForgetPasswordRestClient FP = new ForgetPasswordRestClient();
        public string email { get; set; }
        public INavigation navigation;
        public ForgetpasswordViewModel()

        {

        }
        public ForgetpasswordViewModel(INavigation nav)

        {
            this.navigation = nav;
        }
        public ICommand forgetpassword
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(email))
                        {
                            await Application.Current.MainPage.DisplayAlert("Error", AlertMessages.EnterEmail, AlertMessages.OkayTitle);
                        }
                        else
                        {
                             
                            ClientIDRest CLIDR = new ClientIDRest();
                            AccountIdApi model = new AccountIdApi();
                            model = await CLIDR.getClientIdformobile(URLConfig.Clientidurl);
                            ForgetPasswordBindingModel forgetPassword = new ForgetPasswordBindingModel
                            {
                                Email = email.Trim(),
                                ClientId = model.clientId,
                            };

                            var succeed = await FP.ForgetPasswordAsync(URLConfig.Forgetpasswordurl, forgetPassword);
                            if (succeed)
                            {
                                 
                                await Application.Current.MainPage.DisplayAlert(" E-mail  Sent ", AlertMessages.SendEmail, AlertMessages.OkayTitle);
                                await navigation.PushModalAsync(new LoginPage());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in forgetpasswordviewmodel", ex);
                        await logged.LoggAPI();
                    }

                });
            }
        }
    }
}
