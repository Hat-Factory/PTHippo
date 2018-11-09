using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views;
using Pt_Hippo_Mobile.Views.jobs;
using Pt_Hippo_Mobile.Views.MasterList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Interface;

using System.Collections.ObjectModel;
using Pt_Hippo_Mobile.Views.Profile;
using Pt_Hippo_Mobile.Views.Signup;
using Pt_Hippo_Mobile.Views.SettingsViews;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Views.JobListings;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;

namespace Pt_Hippo_Mobile
{
    public partial class App : Application
    {
        public static bool DoBack
        {
            get
            {
                MasterDetailPage mainPage = App.Current.MainPage as MasterDetailPage;
                var testpage = App.Current.MainPage as Views.JobListings.JobListing;

                if (mainPage != null)
                {
                    //var test = testpage.IsPresented;

                    bool canDoBack = mainPage.Detail.Navigation.NavigationStack.Count > 1;

                    // we are on a top level page and the Master menu is NOT showing

                    if (!canDoBack)
                    {
                        // don't exit the app just show the Master menu page
                        mainPage.IsPresented = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
        }




        public static bool ft { get; set; }


        public App()
        {
            InitializeComponent();
            
            //Check is the app running for the first time    
           
            if (string.IsNullOrEmpty(Settings.IsFirstTime))
            {
                ft = true;
                MainPage = new TermOfUsePage(); 
                MainPage = new Firsttime();
                AskforPermissions(); 
            }
            else
            {
                ft = false;
                SetMainPage(); 
                AskforPermissions();
            }
        }
        private async void AskforPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    try
                    {


                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                        {
                            await App.Current.MainPage.DisplayAlert("Need location", "Gunna need that location", "OK");
                        }

                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                        status = results[Permission.Location];
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in location Permission on App.Xamal.cs", ex);
                        await logged.LoggAPI();
                    }
                }
 
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in App.Xamal.cs", ex);
                await logged.LoggAPI();
            }
        }

        private void SetMainPage()
        { 
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new MasterDetailworking();
            }
            else
            {
                MainPage = new LoginPage();
            }
        
        }

      

        public void OpenJobPage(string id)
        {
            if (string.IsNullOrEmpty(Settings.AccessToken)) return;
            if (MainPage is MasterDetailworking)
            {
                ((MasterDetailworking)MainPage).OpenJob(id);
            }
        }

        public void OpenJobApplicantPage(string id)
        {
            if (string.IsNullOrEmpty(Settings.AccessToken)) return;
            if (MainPage is MasterDetailworking)
            {
                ((MasterDetailworking)MainPage).OpenJobApplicant();
            }
        }

        protected override void OnStart()
        {



            // Handle when your app starts
            //var notificationToken = DependencyService.Get<IpushNotfication>().GetCurrentToken();
            //string platform = "gcm";

            /*var registrationInfo = new DeviceRegistrationJsonModel
			{
				DeviceTokenOrRegistirationId = notificationToken,
				Platform = platform
			};*/

            // Handle when your app starts
            //var notificationToken = DependencyService.Get<IpushNotfication>().GetCurrentToken();
            //string platform = "gcm";

            /*var registrationInfo = new DeviceRegistrationJsonModel
			{
				DeviceTokenOrRegistirationId = notificationToken,
				Platform = platform
			};*/


        }


        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
           

            // Handle when your app resumes

        }
    }
}
