using System;
using System.Collections.Generic;
using Pt_Hippo_Mobile.ViewModel;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Controls;
using Pt_Hippo_Mobile.LoadinIndicator;

namespace Pt_Hippo_Mobile.Views
{
    public partial class TermOfUsePage : ContentPage
    {
        public TermOfUsePage()
        {

            LoadingIndicatorHelper.Intialize(this);
             
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            

            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            }

            mainstack.BackgroundColor = new Color(255, 255, 255, 0.6);

        


        }

        protected override void OnAppearing()
        {
            termsOfUseLabel1.Text = constants.termsofused1;
            termsOfUseLabel2.Text = constants.termsofused2;
            termsOfUseLabel3.Text = constants.termsofused3;


        }


        protected override bool OnBackButtonPressed()
        {
            try
            {
                if (Device.OS == TargetPlatform.Android)
                    DependencyService.Get<IAndroidMethods>().CloseApp();

                return base.OnBackButtonPressed();

            }
            catch(Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in termof use.xaml.cs", ex);
               logged.LoggAPI();

            }
            return false;
           
        }
         
        void Handle_Clicked(object sender, System.EventArgs e)
        {
           
            Navigation.PushModalAsync(new Useragreementpage());
        }

       
    }
}
