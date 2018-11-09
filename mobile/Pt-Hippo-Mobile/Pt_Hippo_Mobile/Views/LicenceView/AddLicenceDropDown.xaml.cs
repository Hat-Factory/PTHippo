using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.LicenceView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLicenceDropDown : ContentPage
    {
        public AddLicenceDropDown()
        {
            InitializeComponent();

            lx.ItemsSource = Helpers.LicenseHelper.LicenceTypes;

            if (string.IsNullOrEmpty(Licencesupdateviewmodel.SelectedLicenseType.title))
            {
                foreach (var item in Helpers.LicenseHelper.LicenceTypes)
                {
                    item.imagesource = "RoundCBUN.png";
                }
            }
            else
            {
                foreach (var item in Helpers.LicenseHelper.LicenceTypes)
                {
                    item.imagesource = "RoundCBUN.png";
                    if (Licencesupdateviewmodel.SelectedLicenseType.id == item.id)
                    {
                        item.imagesource = "RoundCB.png";
                    }
                }
            }


        }


        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {


                //// Check : RoundCB
                //// Uncheck : RoundCBUN
                var imageSender = (Image)sender;
                if (!(e is TappedEventArgs))
                {
                    return;
                }

                var itemtaped = ((TappedEventArgs)e).Parameter;
                if (((dynamic)(imageSender.Source)).File == "RoundCBUN.png")
                {
                    var selectedimage = Helpers.LicenseHelper.LicenceTypes.FirstOrDefault(d => d.id == itemtaped.ToString());

                    if (selectedimage == null)
                    {
                        return;
                    }
                    Licencesupdateviewmodel.SelectedLicenseType = selectedimage;
                    foreach (var itemoncolec in Helpers.LicenseHelper.LicenceTypes)
                    {
                        itemoncolec.imagesource = "RoundCBUN.png";
                        if (itemoncolec.id == selectedimage.id)
                        {
                            itemoncolec.imagesource = "RoundCB.png";
                            Licencesupdateviewmodel.SelectedLicenseType.id = selectedimage.id;
                            Licencesupdateviewmodel.SelectedLicenseType.title = selectedimage.title;

                        }
                    }
                }
                else if (((dynamic)(imageSender.Source)).File == "RoundCB.png")
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in mylicence.xaml.cs", ex);
                logged.LoggAPI();
            }
        }
    }
}