using Plugin.RestClient;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
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
    public partial class TappedWantedDocuments : ContentPage
    {
        public TappedWantedDocuments()
        {
            InitializeComponent();

            flyinglayout.BackgroundColor = Color.FromHex("#f79651");
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override async void OnAppearing()
        {
            try
            {
                await Task.Yield();

                flyinglayout.IsVisible = false;
                if (constants.CurrentDocumentType == DocumentType.initial)
                {
                    ChangeToCurrent(null, null);
                    constants.CurrentDocumentType = DocumentType.MedicalReports;
                    constants.reporttitle = "Report Type";
                    constants.placeholder = "Report Type";
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.MedicalReports);

                }
                else if (constants.CurrentDocumentType == DocumentType.MedicalReports)
                {
                    ChangeToCurrent(null, null);
                   
                    constants.CurrentDocumentType = DocumentType.MedicalReports;
                    constants.reporttitle = "Report Type";
                    constants.placeholder = "Report Type";
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.MedicalReports);
                }
                else if (constants.CurrentDocumentType == DocumentType.LiabilityInsurance)
                {
                    ChangeToSaved(null, null);
                    constants.CurrentDocumentType = DocumentType.LiabilityInsurance;
                    constants.reporttitle = "Report Type";
                    constants.placeholder = "Report Type";
                    ListHeadearLabelName.Text = "pending";
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.LiabilityInsurance);
                }
                else if (constants.CurrentDocumentType == DocumentType.BackgroundCheck)
                {
                    ChangeToApplied(null, null);
                    constants.CurrentDocumentType = DocumentType.BackgroundCheck;
                    constants.reporttitle = "Report Type";
                    constants.placeholder = "Report Type";
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.BackgroundCheck);
                }
                else
                {

                }

                if (EmployeeProfileHelper.EmployeeCurrentProfile.isBackgroundChecked == null)
                {
                    Gridhead.IsVisible = false;
                    RequestFromAdminButton.IsEnabled = true;
                }
                else if (EmployeeProfileHelper.EmployeeCurrentProfile.isBackgroundChecked == true)
                {
                    ListHeadearLabelName.Text = "Done";
                    RequestFromAdminButton.IsEnabled = false;
                } 
                else
                {
                    ListHeadearLabelName.Text = "Pending";
                    RequestFromAdminButton.IsEnabled = false;
                }

                //LoadingIndicatorHelper.Intialize(this);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }


        }
        protected override async void OnSizeAllocated(double width, double height)
        {
            try
            {
                base.OnSizeAllocated(width, height);
                SavedJobsLayout.TranslationX = Width;
                AppliedJobsLayout.TranslationX = Width * 2;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }
        private async void ChangeToCurrent(object sender, EventArgs e)
        {
            try
            {

                flyinglayout.IsVisible = false;
                namegrid.IsEnabled = false;
                CurrentJobsLayout.Opacity = 0.0;
                await CurrentJobsLayout.FadeTo(0);
                constants.CurrentDocumentType = DocumentType.MedicalReports;
                ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.MedicalReports);
                await CurrentJobsLayout.FadeTo(0);
                await Task.WhenAll(UnderlineBoxView.TranslateTo(0, 0), CurrentJobsLayout.TranslateTo(0, 0), SavedJobsLayout.TranslateTo(Width, 0), AppliedJobsLayout.TranslateTo(Width * 2, 0)
                  );
                await CurrentJobsLayout.FadeTo(1);
                CurrentJobsLayout.Opacity = 1;
                namegrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }

        }

        private async void ChangeToSaved(object sender, EventArgs e)
        {
            try
            {

                flyinglayout.IsVisible = false;
                namegrid.IsEnabled = false;
                SavedJobsLayout.Opacity = 0.0;
                await SavedJobsLayout.FadeTo(0);

                ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.LiabilityInsurance);
                constants.CurrentDocumentType = DocumentType.LiabilityInsurance;
                await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width, 0),
                    CurrentJobsLayout.TranslateTo(-Width, 0),
                    SavedJobsLayout.TranslateTo(0, 0),
                    AppliedJobsLayout.TranslateTo(Width, 0)

                );
                await SavedJobsLayout.FadeTo(1);
                SavedJobsLayout.Opacity = 1;
                namegrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void ChangeToApplied(object sender, EventArgs e)
        {
            try
            {
                flyinglayout.IsVisible = false;
                namegrid.IsEnabled = false;
                AppliedJobsLayout.Opacity = 0.0;
                await AppliedJobsLayout.FadeTo(0);
                constants.CurrentDocumentType = DocumentType.BackgroundCheck;
                ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.BackgroundCheck);
                await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width * 2, 0),
                    CurrentJobsLayout.TranslateTo(-Width * 2, 0),
                    SavedJobsLayout.TranslateTo(-Width, 0),
                    AppliedJobsLayout.TranslateTo(0, 0)
                );

                await AppliedJobsLayout.FadeTo(1);
                AppliedJobsLayout.Opacity = 1;
                namegrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }


        }

        private async void btn_edit(object sender, EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                constants.backgroundchecklist.Clear();
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());
                constants.reporttitle = "Report Type";
                constants.backgroundchecklist.Add(selectedItem);
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
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
                    ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.MedicalReports);
                    await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);

                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            try
            {
                constants.backgroundchecklist.Clear();
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                addded.IsEnabled = false;
                await Navigation.PushAsync(page);
                addded.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void btnli_edit(object sender, EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                constants.backgroundchecklist.Clear();
                constants.reporttitle = "File Title";
                constants.placeholder = "File Title";
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());
                constants.backgroundchecklist.Add(selectedItem);
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void btnli_delet(object sender, EventArgs e)
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
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void Handleli_Clicked(object sender, EventArgs e)
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
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void btnbc_edit(object sender, EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                constants.backgroundchecklist.Clear();
                constants.reporttitle = "File Title";
                constants.placeholder = "File Title";
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());
                constants.backgroundchecklist.Add(selectedItem);
                var page = new EdietExistingLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void btnbc_delet(object sender, EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                var selectedItem = ((DocumentsReports)this.BindingContext).FileName.FirstOrDefault(d => d.id == item.CommandParameter.ToString());

                deleteLicences deletebutton = new deleteLicences();
                var answer = await DisplayAlert("Confirmation message", AlertMessages.DeleteConfirmation(selectedItem.title), "Yes", "No");
                if (answer == true)
                {
                    if (await deletebutton.deleteData(item.CommandParameter.ToString(), URLConfig.DeleteAsyncurl))
                    {
                        ((DocumentsReports)this.BindingContext).BindingMethod((int)DocumentType.BackgroundCheck);
                        await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                    }
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        private async void Handlebc_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (flyinglayout.IsVisible)
                {
                    await flyinglayout.FadeTo(0);
                    flyinglayout.IsVisible = false;
                }
                else
                {
                    flyinglayout.IsVisible = true;
                    await flyinglayout.FadeTo(1);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }


        private async void AddnewDoc(object sender, EventArgs e)
        {
            try
            {
                AddnewDocButton.IsEnabled = false;
                constants.reporttitle = "File Title";
                constants.placeholder = "File Title";
                constants.backgroundchecklist.Clear();
                var page = new EdietExistingLicence();
                buttona.IsEnabled = false;
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
                buttona.IsEnabled = true;


            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                AddnewDocButton.IsEnabled = true;
            }
        }

        private async void RequestFromAdmin(object sender, EventArgs e)
        {
            try
            {
                RequestFromAdminButton.IsEnabled = false;
                var answer = await DisplayAlert("You are about to request a Background Check from Pt hippo",
                    AlertMessages.RequestBackgroundCheck, "Yes", "No");
                if (answer == true)
                {
                    RestClient<bool> RSTCL = new RestClient<bool>();
                    var result = await RSTCL.Post(URLConfig.BackgroundCheckRequest, null, true);
                    if (result == true)
                    {
                        await DisplayAlert("Your request has been sent", AlertMessages.RequestConfirmationMessage, "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in TappedWantedDocuments.xaml.cs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                RequestFromAdminButton.IsEnabled = true;
            }
        }
    }
}