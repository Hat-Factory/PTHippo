using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecialitySkills : ContentPage
    {
        public SpecialitySkills()
        {
            InitializeComponent();

        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        protected override async void OnAppearing()
        {
            await Task.Yield();
            ((RegisterViewModel)this.BindingContext).typesasync();
            
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
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
                var selectedimage = RegisterViewModel.JobTypeForProfile.FirstOrDefault(d => d.id == itemtaped.ToString());
                if (selectedimage == null)
                {
                    return;
                }
                foreach (var itemoncolec in RegisterViewModel.JobTypeForProfile)
                {
                    itemoncolec.imagesource = "RoundCBUN.png";
                    if (itemoncolec.id == selectedimage.id)
                    {
                        itemoncolec.imagesource = "RoundCB.png";
                        RegisterViewModel.SelectedJobTypeId = selectedimage.id;
                        RegisterViewModel.RBM.jobTypeId = selectedimage.id;
                    }
                }
            }
            else if (((dynamic)(imageSender.Source)).File == "RoundCB.png")
            {
                return;
            }
            ((RegisterViewModel)this.BindingContext).JobTypeNonStatic = RegisterViewModel.JobTypeForProfile;

        }

    }
}