using Pt_Hippo_Mobile.Controls;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.Profile;
using Pt_Hippo_Mobile.Views.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.validationfluent;
using System.Collections.ObjectModel;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPartTwo : ContentPage
    {
        private int tapCount;

        public SignUpPartTwo()
        {


            InitializeComponent();
            LoadingIndicatorHelper.Intialize(this);
            BindingContext = new RegisterViewModel(Navigation);




            if (RegisterViewModel.RBM.yearsOfExperience > 0)
            {
                yearsofexperience.Text = RegisterViewModel.RBM.yearsOfExperience.ToString();
                //((RegisterViewModel)this.BindingContext).Enteryearsofexperience = RegisterViewModel.RBM.yearsOfExperience.ToString();
            }

            try
            {
                selectedLanguge.Text = RegisterViewModel.LangaugeSkillstext;
                selectedOther.Text = RegisterViewModel.SpecialitySkillstext;
                selectedComputer.Text = RegisterViewModel.Computerskillstext;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in ", ex);
                logged.LoggAPI();
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                logo.WidthRequest = 300;
            }

            BackGroundColor.BackgroundColor = new Color(255, 255, 255, 0.6);

            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            }
            Device.OnPlatform(Android: () => selectstack.Margin = new Thickness(0, 7, 0, 0));
            Device.OnPlatform(Android: () => yearsofexperience.Margin = new Thickness(0, -4, 0, 0));

        }


        protected override async void OnAppearing()
        {
            await Task.Yield();


            selectedLanguge.Text = RegisterViewModel.LangaugeSkillstext;
            selectedOther.Text = RegisterViewModel.SpecialitySkillstext;
            selectedComputer.Text = RegisterViewModel.Computerskillstext;
            if (RegisterViewModel.RBM.yearsOfExperience > 0)
            {
                yearsofexperience.Text = RegisterViewModel.RBM.yearsOfExperience.ToString();
            }
            if (string.IsNullOrWhiteSpace(RegisterViewModel.SelectedJobTypeId))
            {
                jobTypeName.Text = RegisterViewModel.SelectOneText;
            }
            else
            {
                var selecttexttoDisplay = RegisterViewModel.JobTypeForProfile.FirstOrDefault(x => x.id == RegisterViewModel.SelectedJobTypeId);
                RegisterViewModel.RBM.jobTypeId = selecttexttoDisplay.id;
                jobTypeName.Text = selecttexttoDisplay.title;
            }
        }



        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.ComputerSkills));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.ComputerSkills));
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Other));
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Other));
        }


        private async void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Languages));
        }


        private async void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Languages));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpDaniaPage());

        }

        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            Ls.IsEnabled = false;
            if (!string.IsNullOrEmpty(RegisterViewModel.SelectedJobTypeId))
            {
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Languages));
            }
            else
            {
                await DisplayAlert("Missing field", "You have to select Specialization first", "Ok");
            }
            Ls.IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            ss.IsEnabled = false;
            if (!string.IsNullOrEmpty(RegisterViewModel.SelectedJobTypeId))
            {
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.ComputerSkills));
            }
            else
            {
                await DisplayAlert("Missing field", "You have to select Specialization first", "Ok");
            }
            ss.IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            os.IsEnabled = false;
            if (!string.IsNullOrEmpty(RegisterViewModel.SelectedJobTypeId))
            {
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.Other));
            }
            else
            {
                await DisplayAlert("Missing field", "You have to select Specialization first", "Ok");
            }
            os.IsEnabled = true;
        }

        private async void privacyclick(object sender, EventArgs e)
        {
            constants.IsSignUp = true;
            await Navigation.PushModalAsync(new Useragreementpage());
        }

        private async void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            constants.IsSignUp = true;
            await Navigation.PushModalAsync(new TermOfUsePage());

        }


        private async void SpecializationClicked(object sender, EventArgs e)
        {
            splayout.IsEnabled = false;

            await Navigation.PushModalAsync(new SpecialitySkills());

            splayout.IsEnabled = true;
        }
        private async void yearsofexperience_TextChanged(object sender, TextChangedEventArgs e)
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
                //RegisterViewModel.RBM.yearsOfExperience = Convert.ToInt32(_text);
            }

            string lastChar = _text.Substring(_text.Length - 1, 1);
            int number = 0;
           var x = int.TryParse(lastChar, out number);
            //if (number == 0)
            //{
            //    _text = _text.Remove(_text.Length - 1);  // Remove Last character
            //    yearsofexperience.Text = _text;        //Set the Old value
            //    //RegisterViewModel.RBM.yearsOfExperience = Convert.ToInt32(_text);
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
    }
}