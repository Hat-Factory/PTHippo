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
using Pt_Hippo_Mobile.Interface;

namespace Pt_Hippo_Mobile.Views.NotLogedMasterDetails.test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailworking : MasterDetailPage
    {
        RatingCounter api = new RatingCounter();
        public MasterDetailworking()
        {
            InitializeComponent();

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            api.Getcounter(URLConfig.Getcounter);
           // NavigationPage.SetTitleIcon(this, "logo_white_icon.png");
           // getcountervalue();
        }

        static Page lastPage = null;

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterDetailworkingMenuItem;
            if (item == null)
                return;
            if (item.Title == SideMenuHelper.SignOut)

            {
                Settings.AccessToken = "";
                Settings.Username = "";
                Settings.Password = "";
                Navigation.PushModalAsync(new LoginPage());

                DependencyService.Get<IpushNotfication>().UnRegisterToAzure();
            }
            else if (item.Title == SideMenuHelper.ProfileAndSkills)
            {
                lastPage = new Profile.Profile();
            }
            else if (item.Title == SideMenuHelper.Support)
            {
                lastPage = new Mysupportpage();
            }
            else if (item.Title == SideMenuHelper.WorkExperience)
            {
                lastPage = new MyExperiance();
            }
            else if (item.Title == SideMenuHelper.MyLicenses)
            {
                lastPage = new Mylicences();
            }
            else if (item.Title == SideMenuHelper.MyTimeSheet)
            {
                lastPage = new jobtimesheet();
            }
            else if (item.Title == SideMenuHelper.Availiblity)
            {
                lastPage = new ChooseMytimes();
            }
            else if (item.Title == SideMenuHelper.MyBankAccount)
            {
                lastPage = new Bankaccount();
            }
            else if (item.Title == SideMenuHelper.AboutPTHippo)
            {
                //lastPage = new ;
            }
            else if (item.Title == SideMenuHelper.PrivacyAndTerms)
            {
                lastPage = new TermOfUsePage();
            }
            else if (item.Title == SideMenuHelper.Jobs)
            {
                lastPage = new JobListings.JobListing();
            }
            else if(item.Title==SideMenuHelper.PendingRatings)
            {
                //            Navigation.PushModalAsync(new  MasterDetailworking());
                if(lastPage == null)
                {
                    lastPage = new MasterDetailworking(); 
                }
                if (Int32.Parse(constants.RatingTitle) < 1)
                {
                    Application.Current.MainPage. DisplayAlert("Rating", "You don't have any rate yet", "ok");
                    Navigation.PushModalAsync(lastPage);
                }
                else
                {
                    Navigation.PushModalAsync(new Ratingpage());
                }
            }
            

            OpenDetailPage(item.TargetType);
            MasterPage.ListView.SelectedItem = null;
        }


        private void OpenDetailPage( Type TargetType )
        {
            var page = (Page)Activator.CreateInstance(TargetType);
             

            Detail = new NavigationPage(page);
            NavigationPage.SetHasNavigationBar(page, false);
            IsPresented = false;
        }
        public void OpenJob(string JobId)
        {
            Navigation.PushModalAsync(new jobdetails(JobId));
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