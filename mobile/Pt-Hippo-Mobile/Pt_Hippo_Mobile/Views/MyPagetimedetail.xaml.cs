using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class MyPagetimedetail : ContentPage
    {
        public MyPagetimedetail()
        {
            try
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
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
            LoadingIndicatorHelper.Intialize(this);

        }


    }
}
