using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;

using Pt_Hippo_Mobile.RestClient.LoginRestClient;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.Views.MasterList;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.Vaildation;
using Pt_Hippo_Mobile.Interface;

namespace Pt_Hippo_Mobile.ViewModel
{
    class LoginViewModel : BaseViewModel

    {
        Getbasicinfo BasicinfoData = new Getbasicinfo();
        BasicinformationDetails api = new BasicinformationDetails();
        string emailtext, passtext;
        public string Emailtext
        {
            get { return emailtext; }
            set
            {
                emailtext = value; OnPropertyChangedEventhander();
            }
        }
        public string Passtext
        {
            get { return passtext; }
            set
            {
                passtext = value; OnPropertyChangedEventhander();
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        //EmployeeCurrentData firstlog = null;
        AccountIdApi id = new AccountIdApi();
        public INavigation Navigation { get; set; }


        public LoginViewModel()
        {

        }

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

        }

        private EmployeeCurrentProfile employee;

        public EmployeeCurrentProfile Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChangedEventhander();
            }
        }

        public ICommand LoginCommand
        {
            get
            {

                return new Command(async () =>
                {
                    try
                    {


                        if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Email is required", AlertMessages.OkayTitle);
                            return;
                        }


                        if (!ValidatorsFactory.IsValidEmail(UserName))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Email is not valid", AlertMessages.OkayTitle);
                            return;
                        }


                        if (string.IsNullOrEmpty(Password))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Password is required", AlertMessages.OkayTitle);
                            return;
                        }

                        ClientIDRest CLIDR = new ClientIDRest();
                        id = await CLIDR.getClientIdformobile(URLConfig.Clientidurl);

                        LoginRest LR = new LoginRest();

                        List<KeyValuePair<string, string>> KeyValues = new List<KeyValuePair<string, string>>
                     {
                        new KeyValuePair<string, string>("client_id" ,id.clientId ),
                        new KeyValuePair<string, string>("grant_type" , "password"),
                        new KeyValuePair<string, string>("username", UserName),
                        new KeyValuePair<string, string>("password" , Password)
                    };



                        try
                        {
                            var accesstoken = await LR.LoginrestAsync(UserName, Password, id, URLConfig.Loginurl, KeyValues);
                            if (accesstoken == null)
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Emailvaild, AlertMessages.OkayTitle);
                                return;
                            }
                            else
                            {
                                try
                                {


                                    Settings.AccessToken = accesstoken;
                                    Settings.Username = UserName;
                                    ((App)App.Current).MainPage = new MasterDetailworking();
                                    await DependencyService.Get<IpushNotfication>().RegisterToAzure(Settings.Username);
                                }
                                catch (Exception exs)
                                {

                                    var logged = new LoggedException.LoggedException("Error in loginviewmodel", exs);
                                    await logged.LoggAPI();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error in loginviewmodel", ex);
                            await logged.LoggAPI();
                        }
                    }
                    catch (Exception e)
                    {
                        var logged = new LoggedException.LoggedException("Error in loginviewmodel", e);
                        await logged.LoggAPI();
                    }

                });
            }
        }


    }
}
