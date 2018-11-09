using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.Helpers;
namespace Pt_Hippo_Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgetPassword : ContentPage
	{
		public ForgetPassword()
		{
            LoadingIndicatorHelper.Intialize(this);
			InitializeComponent();
            BindingContext = new ForgetpasswordViewModel(Navigation);

            BackGroundColor.BackgroundColor = new Color(255, 255, 255, 0.6);

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


        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        async void Handle_Tappedimage(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new LoginPage());
		}
	}
}