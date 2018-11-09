using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.ViewModel.ReportsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.BackgroundCheckFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Liabilityinsurance : ContentPage
    {

        public Liabilityinsurance()
        {
            InitializeComponent();

            constants.CurrentDocumentType = DocumentType.LiabilityInsurance;

        }
        protected override async void OnAppearing()
        {
            await Task.Yield();
            LoadingIndicatorHelper.Intialize(this);
            ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.LiabilityInsurance);

        }

        private async void btn_edit(object sender, EventArgs e)
        {
            try
            {


                var item = (MenuItem)sender;
                constants.reporttitle = "File Title";
                constants.placeholder = "File Title";
                constants.backgroundchecklist.Clear();
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());
                constants.backgroundchecklist.Add(selectedItem);
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Liability.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void btn_delet(object sender, EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());

                deleteLicences deletebutton = new deleteLicences();
                var answer = await DisplayAlert("Confirmation message", AlertMessages.DeleteConfirmation(selectedItem.title), "Yes", "No");
                if (answer == true)
                {
                    await deletebutton.deleteData(item.CommandParameter.ToString(), URLConfig.DeleteAsyncurl);
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.LiabilityInsurance);
                    await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);

                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Liability.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {

            try
            {
                constants.backgroundchecklist.Clear();
                constants.reporttitle = "File Title";
                constants.placeholder = "File Title";
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                button1a.IsEnabled = false;

                await Navigation.PushAsync(page);
                button1a.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in backgroundcheck.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }
    }
}