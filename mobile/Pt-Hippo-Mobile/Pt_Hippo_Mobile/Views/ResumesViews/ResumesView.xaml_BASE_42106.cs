using Pt_Hippo_Mobile.Model.jobs.SavedJobs;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.ViewModel.ResumeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.ResumesViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumesView : ContentPage
    {
        public ResumesView()
        {
            InitializeComponent();
        }

        private void dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var expdate = e.NewDate.ToString();
            ((ResumeViewModel)this.BindingContext).ResumesElements.startDate = expdate;
        }

        private void dps_DateSelected(object sender, DateChangedEventArgs e)
        {
            var expdate = e.NewDate.ToString();
            ((ResumeViewModel)this.BindingContext).ResumesElements.endDate = expdate;
        }

       
         

        private async void delete_Clicked(object sender, EventArgs e)
        {
            DeleteSaved deletebutton = new DeleteSaved();
            var answer = await DisplayAlert("Delete", "Do you wan't to Delete this ?", "Yes", "No");
            if (answer == true)
            {
                var item = (Xamarin.Forms.Button)sender;
                try
                {
                    await deletebutton.deleteData(item.CommandParameter.ToString(), URLConfig.DeleteResume);
                }
                catch (Exception ex)
                {

                    throw ex; 
                }
               

                ((ResumeViewModel)this.BindingContext).GetData();
            }
            else
            {

            }
        }
    }
}