using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;
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
    public partial class Monthly : ContentPage
    {
        public Monthly()
        {
            InitializeComponent();
            if (MonthlyControlHelper.forceReload == false)
            {
                MonthlyControlHelper.forceReload = true;
            }
        }

        protected override async void OnAppearing()
        {
            await Task.Yield();
            await MonthlyControlHelper.ReloadAPIData();
            Month.Text = MonthlyControlHelper.CurrentMonth;
            Year.Text = MonthlyControlHelper.CurrentYear;

        }

        private void TapGestureRecognizer_Tapped_Left(object sender, EventArgs e)
        {
            MonthlyControlHelper.SlideLeft();
        }
        private void TapGestureRecognizer_Tapped_Right(object sender, EventArgs e)
        {
            MonthlyControlHelper.SlideRight();
        }
    }
}