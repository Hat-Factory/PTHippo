using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class terms : ContentPage
    {
        public terms()
        {
            InitializeComponent();
            privacyPolicyLabel.Text = constants.useragremeenttext;
            privacyPolicyLabel.LineBreakMode = LineBreakMode.WordWrap;
            agreementtext.Text = constants.useragremeenttext;
            agreementtext.LineBreakMode = LineBreakMode.WordWrap;

        }
        protected override void OnSizeAllocated(double width, double height)
        {
            if (personalinodviewmodel.ReCenterViewToPassword)
            {
                agreement(null, null);
            }

            base.OnSizeAllocated(width, height);
            agreementgrid.TranslationX = Width;
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        async void agreement(object sender, System.EventArgs e)
        {
            personalinodviewmodel.ReCenterViewToPassword = true;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width + 5, 0),
                termsgrid.TranslateTo(-Width, 0),
                agreementgrid.TranslateTo(0, 0)
                //imagestack.TranslateTo(0,0)

                );
        }

        async void Term(object sender, System.EventArgs e)
        {
            personalinodviewmodel.ReCenterViewToPassword = false;

            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(0, 0),
                termsgrid.TranslateTo(0, 0),
                agreementgrid.TranslateTo(Width, 0)
                //imagestack.TranslateTo(0,0)
                );
        }
    }
}