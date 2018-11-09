using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.LoggedException;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.RestClient;
using Pt_Hippo_Mobile.RestClient.StripeService;
using Pt_Hippo_Mobile.Model.StripeModel;

namespace Pt_Hippo_Mobile.Views.Stripe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class striperegister : ContentPage
    {

        string client_id;

        public striperegister()
        {
            InitializeComponent();
        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await clientStripeData();
            await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
            string id =  EmployeeProfileHelper.EmployeeCurrentProfile.id;
            string _CurentUseremail = UserDataHelper.EmployeeCurrentData.email;
            bool _IsStripeProfileCompelete = EmployeeProfileHelper.EmployeeCurrentProfile.isStripeProfileCompelete;

            if (_IsStripeProfileCompelete == false)
            {
                 
                web_Stripe.Source = @"https://connect.stripe.com/express/oauth/authorize?client_id=" + client_id + "&state=" + id;
            }
            else
            {
               
                   web_Stripe.Source = @"https://connect.stripe.com/login?prefill_email=" + _CurentUseremail + "&client_id=" + client_id + "state=" + id + "&light_account=true&redirect=express/oauth/authorize?client_id=" + client_id + "&state=" + id;
            }

        }



        #region  stripedata
        public async Task<string> clientStripeData()
        {
            try
            {
                StripClientID cli = new StripClientID();
                var result  = await cli.getstripClientId(URLConfig.GetStripeRequest);
                 
                client_id = result ?? string.Empty;
             
            }
            catch(Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Get client id Stripe", ex);
                await logged.LoggAPI();
            }
            return null;
        }
        #endregion

        private void web_Stripe_Navigating(object sender, WebNavigatingEventArgs e)
        {
           bar.IsRunning = true;
            bar.IsVisible = true;
        }

        private void web_Stripe_Navigated(object sender, WebNavigatedEventArgs e)
        {
            bar.IsRunning = false;
            bar.IsVisible = false;


        }
    }
}