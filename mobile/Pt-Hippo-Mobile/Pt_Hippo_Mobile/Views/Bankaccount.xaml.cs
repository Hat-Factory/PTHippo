using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Views.MasterList;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bankaccount : ContentPage
    {
        public Bankaccount()
        {
            LoadingIndicatorHelper.Intialize(this);
            InitializeComponent();
            BindingContext = new BankAccountViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            
            //Navigation.PopModalAsync();
            var page = new MasterDetailworking();
            NavigationPage.SetHasNavigationBar(page, false);
            Navigation.PushAsync(page);
            return base.OnBackButtonPressed();
        }
        int limit = 2;  //set text limit
        private async void statechangedtext(object sender, TextChangedEventArgs e)
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
    }
}