using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Controls;
using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.JobListings;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class ChooseMytimes : ContentPage
    {
        deleteLicences deletebutton = new deleteLicences();
        public string ids;
        public ChooseMytimes()
        {

            //LoadingIndicatorHelper.Intialize(this);
            InitializeComponent();
            LoadingIndicatorHelper.Intialize(this);
            fromtime.Time = DateTime.Today.TimeOfDay;
            totime.Time = DateTime.Today.TimeOfDay;
            availabilitytext.BackgroundColor = Color.FromHex("#87c8ee");
            iAvailabilitytext.Source = "Availabilityi";
            AvailabilitytextLabel.TextColor = Color.White;

            if (MonthlyControlHelper.forceReload == false)
            {
                MonthlyControlHelper.forceReload = true;
            }
        }

        protected async override void OnAppearing()
        {

            try
            {

                await Task.Yield();


                //if (MonthlyControlHelper.forceReload == false)
                //{
                //    MonthlyControlHelper.forceReload = true;
                //}
                //if (MonthlyControlHelper.forceReload )
                //{
                MonthlyControlHelper.forceReload = true;
                await MonthlyControlHelper.ReloadAPIData();
                Month.Text = MonthlyControlHelper.CurrentMonth;
                Year.Text = MonthlyControlHelper.CurrentYear;
                ((EmployeeScheduleViewmodel)this.BindingContext).loadData();
                ((EmployeeScheduleViewmodel)this.BindingContext).get();

                monlabel.TextColor = Color.White;
                monlabel.BackgroundColor = Color.FromHex("#f79651");

                tueslabel.TextColor = Color.DimGray;
                tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

                wedslabel.TextColor = Color.DimGray;
                wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

                thurslabel.TextColor = Color.DimGray;
                thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

                frilabel.TextColor = Color.DimGray;
                frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

                satlabel.TextColor = Color.DimGray;
                satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

                sunlabel.TextColor = Color.DimGray;
                sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");


                if (constants.currentDayOfWeek == 1)
                {
                    var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
                    var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
                    if (sch != null)
                    {
                        ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                        ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                        ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                    }
                    else
                    {
                        ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                        ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                        ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
                    }
                }
                if (timedetailviewmodel.currenttemp != null)
                {

                    MonthlyControlHelper.current = null;
                    //var date = timedetailviewmodel.data.SpecificDate;
                    //timedetailviewmodel.currenttemp.Month = Convert.ToDateTime(timedetailviewmodel.data.SpecificDate).ToString("MMMM");
                    //timedetailviewmodel.currenttemp.Year = Convert.ToDateTime(timedetailviewmodel.data.SpecificDate).Year.ToString();
                    MonthlyControlHelper.head = timedetailviewmodel.currenttemp;
                    ((EmployeeScheduleViewmodel)this.BindingContext).SlideLeft.Execute(null);
                }
                //}

            }
            catch (Exception e)
            {


                var logged = new LoggedException.LoggedException("Error in choosetime.xaml.cs", e);
                await logged.LoggAPI();
            }

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            freegrid.TranslationX = Width;
            // griddata.TranslationX = Width;
            // btngrid.TranslationX = width;
        }

        async void avaialble(object sender, System.EventArgs e)
        {
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(0, 0),
                       freegrid.TranslateTo(Width, 0),
                dayofweek.TranslateTo(0, 0)

                );
        }

        async void freedate(object sender, System.EventArgs e)
        {
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width, 0),
                       dayofweek.TranslateTo(-Width, 0),
                freegrid.TranslateTo(0, 0)



                );
        }
        async void monday(object sender, System.EventArgs e)
        {
            UnderlineBoxView1.Opacity = 0.0;
            await Task.WhenAll(
                    UnderlineBoxView1.TranslateTo(0, 15)
                );
            monlabel.TextColor = Color.White;
            monlabel.BackgroundColor = Color.FromHex("#f79651");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");
            UnderlineBoxView1.Opacity = 1;
            constants.currentDayOfWeek = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;

            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;

            }
        }
        async void tuesday(object sender, System.EventArgs e)
        {

            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 2;
            await Task.WhenAll(
                UnderlineBoxView1.TranslateTo(tueslabel.Width * 1, 15)
                );

            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.White;
            tueslabel.BackgroundColor = Color.FromHex("#f79651");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            UnderlineBoxView1.Opacity = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
            }
        }
        async void wedesday(object sender, System.EventArgs e)
        {
            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 3;
            await Task.WhenAll(
               UnderlineBoxView1.TranslateTo(wedslabel.Width * 2, 15)
               );

            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.White;
            wedslabel.BackgroundColor = Color.FromHex("#f79651");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            UnderlineBoxView1.Opacity = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
            }
        }
        async void thrusday(object sender, System.EventArgs e)
        {

            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 4;
            await Task.WhenAll(
              UnderlineBoxView1.TranslateTo(thurslabel.Width * 3, 15)
              );


            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.White;
            thurslabel.BackgroundColor = Color.FromHex("#f79651");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");
            UnderlineBoxView1.Opacity = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);

            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
            }
        }
        async void friday(object sender, System.EventArgs e)
        {
            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 5;
            await Task.WhenAll(
              UnderlineBoxView1.TranslateTo(frilabel.Width * 4, 15)
              );
            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.White;
            frilabel.BackgroundColor = Color.FromHex("#f79651");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");
            UnderlineBoxView1.Opacity = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;

            }
        }

        async void saturday(object sender, System.EventArgs e)
        {
            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 6;

            await Task.WhenAll(
             UnderlineBoxView1.TranslateTo(satlabel.Width * 5, 15)
             );
            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.White;
            satlabel.BackgroundColor = Color.FromHex("#f79651");

            sunlabel.TextColor = Color.DimGray;
            sunlabel.BackgroundColor = Color.FromHex("#ecf0f1");
            UnderlineBoxView1.Opacity = 1;
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;

            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
            }
        }

        async void sunday(object sender, System.EventArgs e)
        {
            UnderlineBoxView1.Opacity = 0.0;
            constants.currentDayOfWeek = 0;
            await Task.WhenAll(
              UnderlineBoxView1.TranslateTo(sunlabel.Width * 6, 15)
              );
            monlabel.TextColor = Color.DimGray;
            monlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            tueslabel.TextColor = Color.DimGray;
            tueslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            wedslabel.TextColor = Color.DimGray;
            wedslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            thurslabel.TextColor = Color.DimGray;
            thurslabel.BackgroundColor = Color.FromHex("#ecf0f1");

            frilabel.TextColor = Color.DimGray;
            frilabel.BackgroundColor = Color.FromHex("#ecf0f1");

            satlabel.TextColor = Color.DimGray;
            satlabel.BackgroundColor = Color.FromHex("#ecf0f1");

            sunlabel.TextColor = Color.White;
            sunlabel.BackgroundColor = Color.FromHex("#f79651");

            UnderlineBoxView1.Opacity = 1;
            //var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            //var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;
            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = sch.TotalHour;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Today.TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).TotalHours = 0.0;
                //sch.TotalHour;
            }
        }

        void Edit(object sender, System.EventArgs e)
        {
            constants.senddata.Clear();
            var item = (MenuItem)sender;
            ids = item.CommandParameter.ToString();
            var selectedItem = ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule2.FirstOrDefault(d => d.Id == ids);
            constants.senddata.Add(selectedItem);
            var page = new SelectDay();
            NavigationPage.SetHasNavigationBar(page, false);
            Navigation.PushAsync(page);
        }

        async void Delete(object sender, System.EventArgs e)
        {

            var item = (MenuItem)sender;
            ids = item.CommandParameter.ToString();
            var deletedItem = ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule2.FirstOrDefault(d => d.Id == ids);

            var ans = await DisplayAlert("Confirmation message", AlertMessages.DeleteConfirmation(deletedItem.SpecificDateFormatted), "Yes", "No");
            if (ans == true)
            {
                var succeed = await deletebutton.deleteData(ids, URLConfig.DeleteSchdeualurl);
                if (succeed)
                {
                    ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule2.Remove(deletedItem);
                    EmployeeScheduleViewmodel.tempschadual.Remove(deletedItem);
                    EmployeeProfileHelper.EmployeeCurrentProfile.EmployeeScheduels.Remove(deletedItem);
                    EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                    await DisplayAlert(AlertMessages.Success, AlertMessages.DelteMessage, AlertMessages.OkayTitle);
                    MonthlyControlHelper.forceReload = true;
                    //TODO : Ash test
                    MonthlyControlHelper.ReloadAPIData();
                    //TODO: Added by Ashraf  to refresh the data 
                    ((EmployeeScheduleViewmodel)this.BindingContext).loadData();
                    if (((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule2 == null)
                    {
                        ((EmployeeScheduleViewmodel)this.BindingContext).SlideLeft.Execute(null);
                    }
                    daylist.ItemsSource = ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule2;
                }
            }

        }

        void Add(object sender, System.EventArgs e)
        {
            constants.senddata.Clear();
            var page = new SelectDay();
            add_btn.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            Navigation.PushAsync(page);
            add_btn.IsEnabled = true;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            daylist.SelectedItem = null;
        }
        private bool _userTapped;
        private async void opensearchview(object sender, EventArgs e)
        {
            // JobListing.istoopen = true;
            grdiselect1.IsEnabled = false;
            constants.SearchView = true;
            var page = new JobListing();

            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            searchtext.IsEnabled = true;
            grdiselect1.IsEnabled = true;

        }

        private async void openjoblisting(object sender, EventArgs e)
        {

            var page = new JobListing();
            constants.SearchView = false;
            grdiselect1.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            grdiselect1.IsEnabled = true;
        }

        private async void opentimesheet(object sender, EventArgs e)
        {
            ;
            grdiselect1.IsEnabled = false;
            var page = new jobtimesheet();
            timesheettext.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            timesheettext.IsEnabled = true;

            grdiselect1.IsEnabled = true;
        }

    }

}
