using System;
using System.Collections.Generic;
using Pt_Hippo_Mobile.ViewModel;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;

namespace Pt_Hippo_Mobile.Views
{
    public partial class SelectDay : ContentPage
    {
        public SelectDay()
        {
            LoadingIndicatorHelper.Intialize(this);
            InitializeComponent();
            BindingContext = new timedetailviewmodel(Navigation);
            date.MinimumDate = DateTime.Now;
          
           
            if(((timedetailviewmodel)this.BindingContext).Id==null)
            {
                date.Date = DateTime.Today.Date;
                ((timedetailviewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((timedetailviewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                from.Time = DateTime.Today.TimeOfDay;
                to.Time = DateTime.Today.TimeOfDay;
            }
            else
            {
                date.Date=((timedetailviewmodel)this.BindingContext).Date;
                from.Time = ((timedetailviewmodel)this.BindingContext).Timefrom;
                to.Time = ((timedetailviewmodel)this.BindingContext).Timeto;
            }
            
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override void OnAppearing()
        {
            Task.Yield();
            if (((timedetailviewmodel)this.BindingContext).Id == null)
            {
                date.Date = DateTime.Today.Date;
                ((timedetailviewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((timedetailviewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                from.Time = DateTime.Today.TimeOfDay;
                to.Time = DateTime.Today.TimeOfDay;
            }
            else
            {
                date.Date = ((timedetailviewmodel)this.BindingContext).Date;
                from.Time = ((timedetailviewmodel)this.BindingContext).Timefrom;
                to.Time = ((timedetailviewmodel)this.BindingContext).Timeto;
            }
            MonthlyControlHelper.forceReload = false; 
        }

    }
}
