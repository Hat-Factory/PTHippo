using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.JobListings;
using Pt_Hippo_Mobile.Views.jobs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.Views.MasterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailworkingDetail : ContentPage
    {

        public MasterDetailworkingDetail()
        {
            NavigationPage.SetHasNavigationBar(this, false); 
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            await Task.Yield();
            LoadingIndicatorHelper.Intialize(this);
            await Navigation.PushAsync(new JobListing());

          

        }
 

    }
}