using System;
using System.Collections.Generic;
//using Pt_Hippo_Mobile.Views.NotLogedMasterDetails.test;
using Xamarin.Forms;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Helpers;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Views.LicenceView;

namespace Pt_Hippo_Mobile.Views
{
    public partial class AddLicence : ContentPage
    {
       
        public AddLicence()
        {
            InitializeComponent();
            BindingContext = new Licencesupdateviewmodel(Navigation);
            datepicker.MinimumDate = DateTime.Now;


            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            }

            addLicence.BackgroundColor = new Color(255, 255, 255, 0.6);

            Device.OnPlatform(Android: () => stateentry.Margin=new Thickness(0,-6,0,0));
            if (Device.RuntimePlatform == Device.iOS && string.IsNullOrEmpty(Licencesupdateviewmodel.SelectedLicenseType.title))
            {
                BoxViewUnderline.Margin = new Thickness(0,25,0,0);
            }
        }

        protected override async void OnAppearing()
        {
            await Task.Yield();
            btnUpload.IsEnabled = true;
            LoadingIndicatorHelper.Intialize(this,true,CallBack);
            ((Licencesupdateviewmodel)this.BindingContext).isenabel = true;
            LicenseTitleLabel.Text = Licencesupdateviewmodel.SelectedLicenseType.title;
        }



        public void CallBack()
        {
            
            //((Licencesupdateviewmodel)this.BindingContext).SelectedState = Licencesupdateviewmodel._selectedState;
             //((Licencesupdateviewmodel)this.BindingContext).SelectedLicenseType = Licencesupdateviewmodel._selectedlicencetype;
            //StateDropDown.SelectedItem = Licencesupdateviewmodel._selectedState;
            //LicenseDropDown.SelectedItem = Licencesupdateviewmodel._selectedlicencetype;
        }
       
        int limit = 2;  //set text limit

        private async void Stateentry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateentry.Text))
                {


                    string _text = stateentry.Text; //Get Current Text
                    if (_text.Length > limit) //If it is more than the character restriction
                    {
                        _text = _text.Remove(_text.Length - 1); // Remove Last character
                        stateentry.Text = _text.ToUpper(); //Set the Old value
                    }
                    else
                    {
                        stateentry.Text = stateentry.Text.ToUpper();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Bankaccount.xaml.cs", ex);
                await logged.LoggAPI();
            }

        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            try
            {
                 
                await Navigation.PushModalAsync(new AddLicenceDropDown());
               
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();

            }
        }

         
    }
}
