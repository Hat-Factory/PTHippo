using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.MasterList;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class Personalnformation : ContentPage
    { 

        public Personalnformation()
        {
         
            InitializeComponent();


            MessagingCenter.Subscribe<personalinodviewmodel, string>(this, "message", OnMessageReceived);

            NavigationHelper.INavigator = Navigation;

            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                this.BackgroundImage = "background_2";
            }
            else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
            {
                this.BackgroundImage = "background_Tablet";
            } 
            personallayout.BackgroundColor = new Color(255, 255, 255, 0.6);
            passwordlayout.BackgroundColor = new Color(255, 255, 255, 0.6); 
        }

        private void OnMessageReceived(personalinodviewmodel sender, string message)
        {

            DisplayAlert("Need Photos", message, "Ok");
        }


        protected async override void OnAppearing()
        {
            await Task.Yield();// to wait page to intilize
            await Task.WhenAll(UnderlineBoxView.TranslateTo(0, 0), personalinfogrid.TranslateTo(0, 0), passwordgrid.TranslateTo(Width, 0));
            LoadingIndicatorHelper.Intialize(this);
            await ((personalinodviewmodel)this.BindingContext).LoadBasicinfo(); 
            phone.Text = ((personalinodviewmodel) this.BindingContext).Phonelocal;
            var dateofbirthvar = ((personalinodviewmodel)this.BindingContext).BirthDate.Date.ToString("MM/dd/yyyy");
            if (dateofbirthvar != null)
            {
                DateLabel.Text = dateofbirthvar;
            }
            
            var isMale = ((personalinodviewmodel)this.BindingContext).IsMale;
            if (isMale)
            {
                Male.Source = "RadiooCh.png";
                Female.Source = "RadiooUn.png";
            }
            else
            {
                Male.Source = "RadiooUn.png";
                Female.Source = "RadiooCh.png";
            } 
        }

        void backbutton(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MasterDetailworking());
        }


        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            var fileName = ((dynamic)(Male.Source)).File;
            if (fileName == "RadiooCh" || fileName == "RadiooCh.png")
            {        
                Male.Source = "RadiooUn.png";
                ((personalinodviewmodel)this.BindingContext).IsMale = false;
            }
            else
            {
                Male.Source = "RadiooCh.png";
                Female.Source = "RadiooUn.png";
                ((personalinodviewmodel)this.BindingContext).IsMale = true;
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            var fileName = ((dynamic)(Female.Source)).File;
            if (fileName == "RadiooCh" || fileName == "RadiooCh.png")
            {
                Female.Source = "RadiooUn.png";
                ((personalinodviewmodel)this.BindingContext).IsMale = true;
            }
            else
            {
                Female.Source = "RadiooCh.png";
                Male.Source = "RadiooUn.png";
                ((personalinodviewmodel)this.BindingContext).IsMale = false;
            }
        }
         

        void OpenDatePicker(object sender, System.EventArgs e)
        {
            birthdate.Focus();
        }

        private void birthdate_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (DateLabel != null)
                DateLabel.Text = birthdate.Date.Date.ToString("MM/dd/yyyy");
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (personalinodviewmodel.ReCenterViewToPassword)
            {
                passsword(null, null);
            }

            base.OnSizeAllocated(width, height);
            passwordgrid.TranslationX = Width;
        }

        async void passsword(object sender, System.EventArgs e)
        {
            personalinodviewmodel.ReCenterViewToPassword = true;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width + 5, 0),
                personalinfogrid.TranslateTo(-Width, 0),
                passwordgrid.TranslateTo(0, 0)
 

                );
        }

        async void personaltab(object sender, System.EventArgs e)
        {
            personalinodviewmodel.ReCenterViewToPassword = false;

            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(0, 0),
                personalinfogrid.TranslateTo(0, 0),
                passwordgrid.TranslateTo(Width, 0)  );
        }
        static int i = 3;
        private async void phone_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                
              
              
                var textphone = ((personalinodviewmodel)this.BindingContext).Phonelocal;
              
                if (textphone == null)
                {
                    return;
                }
                else
                {

                    string data = ((personalinodviewmodel)this.BindingContext).Phonelocal;
                    if (data.Length > 12)
                    {
                        data = data.Remove(data.Length - 1); // Remove Last character
                        phone.Text = data;
                        return;
                    }
                    if (data.Length == 0)
                    {
                        return;
                    }
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
                  
                   
                    if (data.Length == 3 || data.Length == 7 )
                    {
                        if (lastChar == "-")
                        {
                            data = data.Remove(data.Length - 1); // Remove Last Character
                            ((personalinodviewmodel)this.BindingContext).Phonelocal = data;
                            return;
                        }
                        data += "-";
                        ((personalinodviewmodel)this.BindingContext).Phonelocal = data;
                    }
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Personalnformation.xaml.cs", ex);
                await logged.LoggAPI();
            }


        }
    }
}
