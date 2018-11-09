using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.validationfluent;
using Pt_Hippo_Mobile.Views.MasterList;

namespace Pt_Hippo_Mobile.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        int limit = 2;
        public async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(yearsofexperience.Text))
                {

                    string _text = yearsofexperience.Text;
                    if (string.IsNullOrEmpty(_text))
                    {
                        return;
                    }

                    if (_text.Length > 2)
                    {
                        _text = _text.Remove(_text.Length - 1);  // Remove Last character
                        yearsofexperience.Text = _text;        //Set the Old value
                    }

                    string lastChar = _text.Substring(_text.Length - 1, 1);
                    int number = 0;
                    var x = int.TryParse(lastChar, out number);
                    //if (number == 0)
                    //{
                    //    _text = _text.Remove(_text.Length - 1);  // Remove Last character
                    //    yearsofexperience.Text = _text;        //Set the Old value
                    //}
                    if (x == false)
                    {
                        _text = _text.Remove(_text.Length - 1);  // Remove Last character
                        yearsofexperience.Text = _text;        //Set the Old value
                    }

                    string years = ValidateYears.Validate(yearsofexperience.Text);

                    if (string.IsNullOrEmpty(years) == false)
                    {
                        RegisterViewModel.RBM.yearsOfExperience = int.Parse(years); 
                    }
                    else
                    {
                        RegisterViewModel.RBM.yearsOfExperience = 0;
                    }
                     
                }
                else
                {
                    return;
                }


                if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
                {
                    this.BackgroundImage = "background_2";
                }
                else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
                {
                    this.BackgroundImage = "background_Tablet";
                }

               EditProfile.BackgroundColor = new Color(255, 255, 255, 0.6);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Bankaccount.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        public Profile()
        {
            InitializeComponent();
            LoadingIndicatorHelper.Intialize(this);

            Device.OnPlatform(Android: () => enable.Margin = new Thickness(0, 2, 0, 0));
            Device.OnPlatform(Android: () => stackselect.Margin = new Thickness(0, 7, 0, 0),  iOS:()=> yearsofexperience.Margin=new Thickness(0,-21,0,0));

            Device.OnPlatform(Android: () => stackselect.Margin = new Thickness(0, 6, 0, 0),iOS:()=> yearsofexperience.Margin=new Thickness(0,-20,0,0));

        }

        protected override async void OnAppearing()
        {
            await Task.Yield();
           
            try
            {
                //if (Device.RuntimePlatform == Device.iOS)
                //{
                //    yearsofexperience.HeightRequest = 60;
                //}
                   
               // App.HardwareBackPressed = () => Task.FromResult<bool?>(null);
                try
                {

                    btnt.IsEnabled = true;
                    ((RegisterViewModel)this.BindingContext).isenabelbtn = true;
                    LangaugeText.Text = SkillsHelper.PreapreSkillsText(SkillCategories.Languages);
                    Softwareskillstext.Text = SkillsHelper.PreapreSkillsText(SkillCategories.ComputerSkills);
                    TechnicalskillsText.Text = SkillsHelper.PreapreSkillsText(SkillCategories.Other);
                }
                catch (Exception ex)
                {

                    var logged = new LoggedException.LoggedException("Error in  region OtherSkills ", ex);
                    await logged.LoggAPI();
                }


                fromvalue.Text = ((int)EmployeeProfileHelper.EmployeeCurrentProfile.MinHourRate).ToString();
                tovalue.Text = ((int)EmployeeProfileHelper.EmployeeCurrentProfile.MaxHourRate).ToString();
                SmallerValue.Text = ((int)EmployeeProfileHelper.EmployeeCurrentProfile.MinTravelDistance).ToString();
                DBigvalue.Text = ((int)EmployeeProfileHelper.EmployeeCurrentProfile.MaxTravelDistance).ToString();
                SpecialilizationLabel.Text = EmployeeProfileHelper.EmployeeCurrentProfile.jobTypeTitle;

                 
                if (string.IsNullOrWhiteSpace(RegisterViewModel.SelectedJobTypeId))
                {
                    SpecialilizationLabel.Text = EmployeeProfileHelper.EmployeeCurrentProfile.jobTypeTitle;
                }
                else
                {
                    var selecttexttoDisplay = RegisterViewModel.JobTypeForProfile.FirstOrDefault(x => x.id == RegisterViewModel.SelectedJobTypeId);
                    if (selecttexttoDisplay != null)
                    {
                        SpecialilizationLabel.Text = selecttexttoDisplay.title;
                        EmployeeProfileHelper.EmployeeCurrentProfile.jobTypeTitle = selecttexttoDisplay.title;
                    }
                }
                    

                //Loadi(ngIndicatorHelper.HideIndicator();


            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page ", ex);
                await logged.LoggAPI();

            }

        }
      


        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            try
            {
                YXLayout.IsEnabled = false;
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Languages));
                YXLayout.IsEnabled = true;

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();

            }

        }

        private async void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            try
            {
                SSlayout.IsEnabled = false;
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.ComputerSkills));
                SSlayout.IsEnabled = true;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }

        }


        private async void RangeSlider_UpperValueChanged(object sender, EventArgs e)
        {
            try
            {
                var castedRslv = (int)RangeSlider.UpperValue;
                tovalue.Text = castedRslv.ToString() ;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }

        }

        private async void RangeSlider_LowerValueChanged(object sender, EventArgs e)
        {
            try
            {
                var castedRslv = ((int)(RangeSlider.LowerValue)).ToString();
                var x = castedRslv ;
                fromvalue.Text = x;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }

        }


        private async void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {

            try
            {
                TSLayout.IsEnabled = false;
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Other));
                TSLayout.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();

            }

        }

        private async void TravelDistance_LowerValueChanged(object sender, EventArgs e)
        {
            try
            {
                var castedRslv = (int)TravelDistance.LowerValue;
                SmallerValue.Text = castedRslv.ToString();
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }

        }
                         
        private async void TravelDistance_UpperValueChanged(object sender, EventArgs e)
        {
            try
            {
                var castedRslv = (int)TravelDistance.UpperValue;
                DBigvalue.Text = castedRslv.ToString();

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }

        }

        private async void SpecializationClicked(object sender, EventArgs e)
        {
            splayout.IsEnabled = false;
            await Navigation.PushModalAsync(new SpecialitySkills());
            splayout.IsEnabled = true;
        }
    }
}