using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Plugin.Connectivity;

//using Pt_Hippo_Mobile.Views.NotLogedMasterDetails.test;

namespace Pt_Hippo_Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
            LoadingIndicatorHelper.Intialize(this);
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
            HelpersIntializer.IntialilizeAllHelpers();
			BindingContext = new LoginViewModel(Navigation);
            Settings.AccessToken = null;
            Settings.Username = "";
            Settings.Password = "";
            cooloring.BackgroundColor = new Color(255, 255, 255, 0.6);

            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            }


            if (Device.RuntimePlatform == Device.iOS)
            {
                logo.WidthRequest = 300;
            }

        }



        async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
		{
            if (!CrossConnectivity.Current.IsConnected)
            {
                await InternetOrServeHelper.ShowCheckInternet();
            }
            else
            {
                await Navigation.PushModalAsync(new ForgetPassword());
            }
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
            if (!CrossConnectivity.Current.IsConnected)
            {
                await InternetOrServeHelper.ShowCheckInternet();
            }
            else
            {
                await Navigation.PushModalAsync(new SignUpDaniaPage());
            }
            
		}

	    private void whencomplete(object sender, EventArgs e)
	    { 
	        passwordentry.Focus(); 
	    }

	    private void Passwordentry_OnCompleted(object sender, EventArgs e)
	    {
	        ((LoginViewModel)this.BindingContext).LoginCommand.Execute(null);
        }
	}
}