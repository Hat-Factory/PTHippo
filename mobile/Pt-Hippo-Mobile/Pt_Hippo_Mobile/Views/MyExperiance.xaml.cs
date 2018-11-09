using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ResumesRest;
using Pt_Hippo_Mobile.ViewModel.ResumeViewModel;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class MyExperiance : ContentPage
    {
        DeleteResume delet;
       public  string id ;
        public MyExperiance()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                TextHelper.MaxLength = 30;

            }
            else
            {
                TextHelper.MaxLength = 100;
            }
            InitializeComponent();



        }
        

        protected async override void OnAppearing()
        {
            await Task.Yield();// to wait page to intilize
            LoadingIndicatorHelper.Intialize(this);
            clickbtn.IsEnabled = true;
            ((ResumeViewModel)this.BindingContext).GetData();

          
        }
      

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            constants.expirenceitem.Clear();
            var page = new AddExperience();
          
            NavigationPage.SetHasNavigationBar(page, false);
            clickbtn.IsEnabled = false;
            Navigation.PushAsync(page);
          
        }

        async void btn_delet(object sender, System.EventArgs e)
        {
            try
            {
                delet = new DeleteResume();
                var item = (MenuItem)sender;
                id = item.CommandParameter.ToString();
                var deletedItem = ((ResumeViewModel)this.BindingContext).ResumeViewList.FirstOrDefault(d => d.id == id);
                var answer = await DisplayAlert("Confirmation message", AlertMessages.DeleteConfirmation(deletedItem.@as), "Yes", "No");
                if (answer == true)
                {
                    await delet.deleteResume(id, URLConfig.DeleteResumes);
                    ((ResumeViewModel)this.BindingContext).ResumeViewList.Remove(deletedItem);
                    explist.ItemsSource = ((ResumeViewModel)this.BindingContext).ResumeViewList;
                    await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);

                }
            }
            catch(Exception ex)
                    {
                var logged = new LoggedException.LoggedException("Error in myexperince.xaml.cs", ex);
                await logged.LoggAPI();
                }
           
        }

        async void  btn_edit(object sender, System.EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                id = item.CommandParameter.ToString();
                constants.expirenceitem.Clear();
                var selectedItem = ((ResumeViewModel)this.BindingContext).ResumeViewList.FirstOrDefault(d => d.id == id);
                constants.expirenceitem.Add(selectedItem);
                var page = new AddExperience();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in myexperince.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }
    }
}
