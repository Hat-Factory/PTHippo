using System;
using System.Collections.Generic;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Views.MasterList;
using Xamarin.Forms;


namespace Pt_Hippo_Mobile.Views
{
    public partial class Useragreementpage : ContentPage
    {
        public Useragreementpage()
        {
            LoadingIndicatorHelper.Intialize(this);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
           // agreement.Text = constants.useragremeenttext;

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
            agreement1.Text = constants.termsofused1;
            agreement2.Text = constants.termsofused2;
            agreement3.Text = constants.termsofused3;

        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.IsFirstTime))
            {
                Settings.IsFirstTime = "No";
            }

            if (constants.IsSignUp)
            {
                constants.AgreedOnTOSAndPrivacy = true;
                Navigation.PushModalAsync(new SignUpPartTwo());
                return;
            }

           
                ((App)App.Current).MainPage = new LoginPage();
        
           
        }

       
    }
}
