using System;
using System.Collections.Generic;
using System.Linq;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.ViewModel.ResumeViewModel;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Views.Signup;
using Pt_Hippo_Mobile.Enums;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.Views
{
    public partial class AddExperience : ContentPage
    {
        public AddExperience()
        {
            InitializeComponent();
            BindingContext = new AddNewExperience(Navigation);
            from.MaximumDate = DateTime.Now;
            to.MaximumDate = DateTime.Now;
            from.MinimumDate = new DateTime(1950, 1, 1);
            to.MinimumDate = new DateTime(1950, 1, 1);
            //from.Date = DateTime.Today.Date;
            to.TextColor = Color.FromHex("#60afdf");
            from.BackgroundColor = Color.Transparent;
            to.BackgroundColor = Color.Transparent;
            // to.Date= DateTime.Today.Date;
            if (((AddNewExperience)this.BindingContext).Id == null)
            {
                ((AddNewExperience)this.BindingContext).Totimes = DateTime.Today.Date;
                ((AddNewExperience)this.BindingContext).Fromtimes = DateTime.Today.Date;
                to.Date = DateTime.Today.Date;
            }
        



            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            }

            addexperinec.BackgroundColor = new Color(255, 255, 255, 0.6);

        }

        protected override bool OnBackButtonPressed()
        {

            return base.OnBackButtonPressed();
        }
        protected override async void OnAppearing()
        {
            await Task.Yield();
            LoadingIndicatorHelper.Intialize(this);
            btnUpload.IsEnabled = true;
            SkillstextDescription.Text += RegisterViewModel.AllSkilssText;
            RegisterViewModel.ExperienceSkills = null;
            RegisterViewModel.AllSkilssText = string.Empty;

            if (SkillstextDescription.Text == RegisterViewModel.SelectOneText)
            {
                SkillstextDescription.Text = string.Empty;
            }

            if (((AddNewExperience)this.BindingContext).Current)
            {
                currenr.Source = "CheckedCaroot.png";
                to.IsEnabled = false;
                to.BackgroundColor = Color.FromHex("#f1f1f1");


            }
            else
            {
                currenr.Source = "UNCWWBackround.png";
                to.IsEnabled = true;
                to.TextColor = Color.FromHex("#60afdf");
                to.BackgroundColor = Color.Transparent;
                //to.Date = DateTime.Today.Date;
            }

        }






        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var fileName = ((dynamic)(currenr.Source)).File;
            if (fileName == "UNCWWBackround.png")
            {
                currenr.Source = "CheckedCaroot.png";
                to.IsEnabled = false;
                to.BackgroundColor = Color.FromHex("#f1f1f1");
                ((AddNewExperience)this.BindingContext).Current = true;
            }
            else
            {
                currenr.Source = "UNCWWBackround.png";
                to.IsEnabled = true;
                to.BackgroundColor = Color.Transparent;
                to.TextColor = Color.FromHex("#60afdf");
                to.Date = DateTime.Today.Date;
                ((AddNewExperience)this.BindingContext).Current = false;
            }
        }

        private async void skillsTapped(object sender, EventArgs e)
        {
            try
            {
                TSLayout.IsEnabled = false;
                await Navigation.PushModalAsync(new SkillsSignUp(SkillCategories.All));
                TSLayout.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Profile Page", ex);
                await logged.LoggAPI();
            }
        }
    }

}





