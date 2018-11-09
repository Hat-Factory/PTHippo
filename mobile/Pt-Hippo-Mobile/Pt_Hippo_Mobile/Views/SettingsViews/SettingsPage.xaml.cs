using Pt_Hippo_Mobile.ViewModel.SettingsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.SettingsModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.RestClient;
using Pt_Hippo_Mobile.RestClient;

namespace Pt_Hippo_Mobile.Views.SettingsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
             await  Task.Yield();
            //LoadingIndicatorHelper.Intialize(this);

        }
        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            
           await ((SettingsControler)this.BindingContext).UpdateSettingsState();
        }
    }
}