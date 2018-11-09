using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using Pt_Hippo_Mobile.ViewModel;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class Mylicences : ContentPage
    {
        deleteLicences delet=new deleteLicences();
        //licensesModel data;
        public  string Ids;
        public string title;
        public Mylicences()
        {
            InitializeComponent();
            Pt_Hippo_Mobile.Helpers.LicenseHelper.IntializeStates();
            Pt_Hippo_Mobile.Helpers.LicenseHelper.IntializeTypes();


        }

       

       
        protected  async override void OnAppearing()
        {
            await Task.Yield();// to wait page to intilize
            LoadingIndicatorHelper.Intialize(this);

            ((GetLicenceView)this.BindingContext).BindingMethod();
        }

      
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Licencesupdateviewmodel._selectedlicencetype = null;
                Licencesupdateviewmodel.SelectedLicenseType = null;
                constants.licencesitem.Clear();
                var page = new AddLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                ADD.IsEnabled = false;
                await Navigation.PushAsync(page);//add
                ADD.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in mylicence.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

      

        async void edit_btn(object sender, System.EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;
                Ids = item.CommandParameter.ToString();
                constants.licencesitem.Clear();
                var selectedItem = ((GetLicenceView)this.BindingContext).LicensesDataListView.FirstOrDefault(d => d.id == Ids);
                constants.licencesitem.Add(selectedItem);
                if (Licencesupdateviewmodel.SelectedLicenseType == null)
                {
                    Licencesupdateviewmodel.SelectedLicenseType = new licencetype();
                }
                Licencesupdateviewmodel.SelectedLicenseType.id = selectedItem.type.ToString();
                var Ltitle =  LicenseHelper.LicenceTypes.FirstOrDefault(x => x.id == selectedItem.type.ToString());
                if (Ltitle !=null)
                {
                    Licencesupdateviewmodel.SelectedLicenseType.title = Ltitle.title;
                }
                
                var page = new AddLicence();
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in mylicence.xaml.cs", ex);
                await logged.LoggAPI(); 
            }
        }

        async void btn_delete(object sender, System.EventArgs e)
        {
            try
            {
                var item = (MenuItem)sender;

                Ids = item.CommandParameter.ToString();
                var deletedItem = ((GetLicenceView)this.BindingContext).LicensesDataListView.FirstOrDefault(d => d.id == Ids);

                var answer = await DisplayAlert("Confirmation message", AlertMessages.DeleteConfirmation(deletedItem.typeText), "Yes", "No");
                if (answer == true)
                if(await delet.deleteData(Ids, URLConfig.DeleteLicence))
                {
                    ((GetLicenceView)this.BindingContext).LicensesDataListView.Remove(deletedItem);
                        mydata.ItemsSource = ((GetLicenceView)this.BindingContext).LicensesDataListView;
                        await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true); 
                }


            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in mylicence.xaml.cs", ex);
                await logged.LoggAPI();
                }
           
        }
    }
}
