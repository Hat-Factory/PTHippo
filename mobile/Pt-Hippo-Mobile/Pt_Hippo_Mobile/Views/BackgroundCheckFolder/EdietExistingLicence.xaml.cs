using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
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
    public partial class EdietExistingLicence : ContentPage
    {
       
        public EdietExistingLicence()
        {
            InitializeComponent();
            LoadingIndicatorHelper.Intialize(this);
            BindingContext = new DocumentsReports(Navigation);
            string title = constants.CurrentDocumentType.ToString();

            StringBuilder builder = new StringBuilder();
            foreach (char c in title)
            {
                if (Char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }
            title = builder.ToString();

            ScreenTitlenavbar.Title = title;
            titletype.Text = constants.reporttitle;
           
            filetitle.Placeholder = constants.placeholder;

        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override async void OnAppearing()
        {
            await Task.Yield(); 
            LoadingIndicatorHelper.Intialize(this);
            if (constants.CurrentDocumentType == DocumentType.initial)
            {
                btnUpload.Text = " Medical Report ";

            }
            else if (constants.CurrentDocumentType == DocumentType.MedicalReports)
            {
                btnUpload.Text = " Medical Report ";
            }
            else if (constants.CurrentDocumentType == DocumentType.LiabilityInsurance)
            {
                btnUpload.Text = " Liability Insurance ";
            }
            else if (constants.CurrentDocumentType == DocumentType.BackgroundCheck)
            {
                btnUpload.Text = " Background Check ";
            }
            //UploadDocName
        }
        int limit = 15;
        private async void filetitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(filetitle.Text))
                {


                    string _text = filetitle.Text; //Get Current Text
                    if (_text.Length > limit) //If it is more than the character restriction
                    {
                        _text = _text.Remove(_text.Length - 1); // Remove Last character
                        filetitle.Text = _text.ToUpper(); //Set the Old value
                    }
                    else
                    {
                        filetitle.Text = filetitle.Text;
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