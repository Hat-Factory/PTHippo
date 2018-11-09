using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Views.JobListings;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Views
{
    public partial class jobtimesheet : ContentPage
    {
        public jobtimesheet()
        {
            InitializeComponent();
            timesheettext.BackgroundColor = Color.FromHex("#87c8ee");
            itimesheettext.Source = "Timesheeti.png";
            timesheettextLabel.TextColor = Color.White;
            LoadingIndicatorHelper.Intialize(this);

          
        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            try
            {
                constants.jobtime.Clear();
                var item = (ListView)sender;
                constants.jobtime.Add((jobtimesheetmodel)item.SelectedItem); 
                Navigation.PushModalAsync(new MyPagetimedetail());
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Personalnformation.xaml.cs", ex);
                 logged.LoggAPI();
            }
        }

        protected override async void OnAppearing()
        {
            await Task.Yield();
        
          

            await ((jobtimeesheetviewmodel)this.BindingContext).getdata();
            if (((jobtimeesheetviewmodel)this.BindingContext).Getsheet == null|| ((jobtimeesheetviewmodel)this.BindingContext).Getsheet.Count==0)
            {
                nogrid.IsVisible = true;
                timeview.IsVisible = false;
            }
            else
            {
                nogrid.IsVisible = false;
                timeview.IsVisible = true;
            }
          

        }
        protected override bool OnBackButtonPressed()
        { 
        base.OnBackButtonPressed();
            return false ;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            constants.SearchView = true;
            var page = new JobListing();
            searchtap.IsEnabled = false;
            gridselect.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            searchtap.IsEnabled = true;
            gridselect.IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            var page = new JobListing();
            MyJobstap.IsEnabled = false;
            gridselect.IsEnabled = false;
            constants.SearchView = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            MyJobstap.IsEnabled = true;
            gridselect.IsEnabled = true;
        }

       

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var page = new ChooseMytimes();
            Availabilitytext.IsEnabled = false;
            gridselect.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            Availabilitytext.IsEnabled = true;
            gridselect.IsEnabled = true;
        }
    }
}
