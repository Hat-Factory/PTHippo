using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.Controls;
using Pt_Hippo_Mobile.Views.jobs;
using Pt_Hippo_Mobile.RestClient.Rating;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.Views.BackgroundCheckFolder;
using Pt_Hippo_Mobile.Interface;

namespace Pt_Hippo_Mobile.Views.MasterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailworking : MasterDetailPage
    {

        public MasterDetailworking()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Pt_Hippo_Mobile.Helpers.LicenseHelper.IntializeStates();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }


        //static Page lastPage = null;

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterDetailworkingMenuItem;
            if (item == null)
                return;
            if (item.Title == SideMenuHelper.SignOut)
            {
                Settings.AccessToken = null;
                Settings.Username = "";
                Application.Current.MainPage = new NavigationPage(new LoginPage());

                DependencyService.Get<IpushNotfication>().UnRegisterToAzure();
            }
            else
            {
                OpenDetailPage(item.TargetType);
                MasterPage.ListView.SelectedItem = null;
            }
           
        }

      
        private void OpenDetailPage(Type TargetType)
        {
            try
            {
                var page = (Page)Activator.CreateInstance(TargetType);
                Detail = new NavigationPage(page);
                NavigationPage.SetHasNavigationBar(page, false);
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in banckaccountviewmodel", ex);
                logged.LoggAPI();
            }



        }
        public void OpenJob(string JobId)
        {
            Navigation.PushModalAsync(new NewJobDetail(JobId));
        }

        public void OpenJobApplicant()
        {
            OpenDetailPage(typeof(Ratingpage));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<CustomNavigationBar>(this, "ToggleDrawer", (sender) =>
            {
                IsPresented = !IsPresented;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<CustomNavigationBar>(this, "ToggleDrawer");
        }
    }
}
