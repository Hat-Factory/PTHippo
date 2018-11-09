using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpDaniaPage : ContentPage
    {
        private int tapCount;

        public SignUpDaniaPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //LoadingIndicatorHelper.Intialize(this,true,ReloadViewAfterLoading);

            BindingContext = new RegisterViewModel(Navigation);
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

            #region holdRegData
            var test = RegisterViewModel.RBM.isMale;
            if (RegisterViewModel.RBM.isMale)
                Male.Source = "RadiooCh.png";
            else
                Female.Source = "RadiooCh.png";
            firstName.Text = RegisterViewModel.RBM.firstName;
            lastName.Text = RegisterViewModel.RBM.lastName;
            password.Text = RegisterViewModel.RBM.password;
            zipCode.Text = RegisterViewModel.RBM.zipCode;
            email.Text = RegisterViewModel.RBM.email;
            mobile.Text = RegisterViewModel.RBM.mobile;
            #endregion 

        }
        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }


        protected override async void OnAppearing()
        {
            await Task.Yield();


        }

        private void ImageEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Toast.LongMessage("invalid");

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            tapCount++;
            if (tapCount % 2 == 0)
            {
                Male.Source = "RadiooUn.png";
                ((RegisterViewModel)this.BindingContext).IsMaleLocal = false;
            }
            else
            {
                Male.Source = "RadiooCh.png";
                Female.Source = "RadiooUn.png";
                ((RegisterViewModel)this.BindingContext).IsMaleLocal = true;
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            tapCount++;
            if (tapCount % 2 == 0)
            {
                Female.Source = "RadiooUn.png";
                ((RegisterViewModel)this.BindingContext).IsMaleLocal = false;
            }
            else
            {
                Female.Source = "RadiooCh.png";
                Male.Source = "RadiooUn.png";
                ((RegisterViewModel)this.BindingContext).IsMaleLocal = false;
            }
        }

        private void confirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        { }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private void mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {


                string data = mobile.Text;
                if (data.Length == 0)
                {
                    return;
                }
                if (data.Length > 12)
                {
                    data = data.Remove(data.Length - 1); // Remove Last character
                    mobile.Text = data;
                    return;
                }
                //string lastChar = data.Substring(data.Length - 1, 1);
                string lastChar = " ";
                if (e.OldTextValue != null)
                {
                    if (e.OldTextValue.Length == 0)
                    {
                        return;
                    }
                    lastChar = e.OldTextValue.Substring(e.OldTextValue.Length - 1, 1);
                }
                else
                {
                    lastChar = data.Substring(data.Length - 1, 1);
                }

                if (data.Length == 3 || data.Length == 7)
                {
                    if (lastChar == "-")
                    {
                        data = data.Remove(data.Length - 1); // Remove Last character
                        mobile.Text = data;
                        return;
                    }
                    data += "-";
                    mobile.Text = data;
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Personalnformation.xaml.cs", ex);
                logged.LoggAPI();
            }

        }
    }
}