using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.ViewModel;
using Xamarin.Forms;
using Pt_Hippo_Mobile.RestClient.CheckoutandPutCheckin;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Xamarin.Forms.GoogleMaps;
using Plugin.Geolocator;
using Plugin.RestClient;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Views.jobs;

namespace Pt_Hippo_Mobile.Views
{
    public partial class NewJobDetail : ContentPage
    {
        JobApply JA = new JobApply();
        private ObservableCollection<JobSchedule> myVar;
        public static bool ISMapPage { get; set; } 
        public NewJobDetail(string jobid)
        {
            idforsaving = jobid;
            InitializeComponent();
           
            tepmdateselected = new ObservableCollection<JobSchedule>();
            dateselecedlistview.ItemsSource = tepmdateselected;
            ISMapPage = false;
        }
       
        public ObservableCollection<JobSchedule> tepmdateselected
        {
            get
            { 
                return myVar; 
            }
            set
            {
                myVar = value; 
            }
        }


        Checkout_Checkin inout = new Checkout_Checkin();
        public double? ClockOutLats { get; set; }
        public double? ClockOutLongs { get; set; }
        private int sldrvalue =  0;
        Checkin_Checkout checkin, checkout;
        public List<string> possibleAddresses { get; set; }
        public Geocoder geoCoder { get; set; }
        public Position MyPropertyPosition { get; set; }
        public Pin MyPropertypin { get; set; }

        private int tapCount;
        public string idforsaving { get; set; }

        //jobApplicantId
        public string jaid { get; set; }

      


        protected override async void OnAppearing()
        {

            try
            {
                
                await Task.Yield(); 
                if (Device.Idiom == TargetIdiom.Tablet )
                {
                    HeadGrid2.IsVisible = false;
                    HeadGrid3.IsVisible = false;
                    HeadGrid1.IsVisible = true;
                   
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    HeadGrid2.IsVisible = false;
                    HeadGrid3.IsVisible = true;
                    HeadGrid1.IsVisible = false;
                }
                else 
                {
                    HeadGrid2.IsVisible = true;
                    HeadGrid1.IsVisible = false;
                    HeadGrid3.IsVisible = false;
                }
                dateselecedlistview.ItemsSource = tepmdateselected;

                //TODO : WOrking Here 
                if (ISMapPage == false)
                {
                    await loadData(idforsaving);
                    ISMapPage = false;
                }
                 
                //controlling the button apperance Apply , Cancel , Checkin and out etc ..
                await ButtonApperance();
                //setting the values to the slider from the Api to The Ui

                bool sliderEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                double min = ((jobsDetailsViewModel)this.BindingContext)._jobModel.minHrRate;
                double max = ((jobsDetailsViewModel)this.BindingContext)._jobModel.maxHrRate; ;
                Slder.Maximum = max;
                Slder.Value = (min + max) / 2;
                avrhrate.Text= Convert.ToInt32(((min + max) / 2)).ToString();
                sldrvalue = Convert.ToInt32(((min + max) / 2));
                if (sliderEnabled == false)
                {
                    Slder.Value = ((jobsDetailsViewModel)this.BindingContext)._jobModel.requestedHrRate;
                    Slder.IsEnabled = false;
                }
                ratetext.Text = "Rate " + " $" + Convert.ToInt32(Slder.Value) ;
                Slder.Minimum = min;
                skilstr.Text = ((jobsDetailsViewModel)this.BindingContext).skillsstring;
                confirmjobname.Text = ((jobsDetailsViewModel)this.BindingContext)._jobModel.jobTypeTitle;
                HiringDate.Text = DateTime.Now.ToString("d");
                jaid = ((jobsDetailsViewModel)this.BindingContext)._jobModel.jobApplicantId;
                var jobmodelfortext = ((jobsDetailsViewModel)this.BindingContext)._jobModel; 
                ApplyTexthelperone.FormattedText = jobdetailstexthelper.LabelTextFormating(jobmodelfortext, sldrvalue);
                 
                ApplyTexthelpertwo.Text = "Once hiring is confirmed, you’ll be paid above hourly rate.";
                ApplyTexthelperthree.FormattedText = jobdetailstexthelper.LabelTextFormating();
                if (((jobsDetailsViewModel)this.BindingContext)._jobModel.isExpired)
                {
                    expiredlabel.Text = "Expired";
                }
                var collection = ((jobsDetailsViewModel) this.BindingContext).jobscollection;
                //lx.HeightRequest = (40 * collection.Count) + (10 * collection.Count);
                lx.HeightRequest = (35 * collection.Count) + (50);
                //( 5 * collection.Count );
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
                await logged.LoggAPI();
            }


        }

        
        public string disablelist { get; set; }

        public async Task ButtonApperance()
        {
            //Controling the Buttons Apperance 
            try
            {
                B1.IsVisible = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                B3.IsVisible = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showCheckIn;
                B4.IsVisible = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showCheckOut;

                B5.IsVisible = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showCancel;
                B6.IsVisible = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showConfirmHiring;
                //LIST VIEW ENABLE AND DISABLE Based ON THE Following Flag  
                //lx.IsEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                bool sliderEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                if (sliderEnabled == false)
                {
                    Slder.Value = ((jobsDetailsViewModel)this.BindingContext)._jobModel.requestedHrRate;
                    Slder.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("jobdetails.xaml.cs", ex);
                await logged.LoggAPI();
            }

        }
        public async Task loadData(string jobid)
        {
            try
            {

                await ((jobsDetailsViewModel)this.BindingContext).startupMethod(jobid);
                double lat = ((jobsDetailsViewModel)this.BindingContext).LocationLat;
                double lang = ((jobsDetailsViewModel)this.BindingContext).LocationLong;
            
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
                await logged.LoggAPI();

            }
        }


 
      
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //select  fine dates 
            try
            {
                tapCount++;
                var imageSender = (Image)sender;

                //lx.IsEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                if (((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply == false)
                {
                   return;
                }
                if (((jobsDetailsViewModel)this.BindingContext)._jobModel.isPartialyAllowed == true)
                {
                    //for double tap to check
                    if (((dynamic)(imageSender.Source)).File == "UNCWWBackround.png")
                    {
                        if (!(e is TappedEventArgs))
                        {
                            return;
                        } 
                        var item = ((TappedEventArgs)e).Parameter;
                        var dateselected = ((jobsDetailsViewModel)this.BindingContext).jobscollection.FirstOrDefault(xx => xx.id == item.ToString());

                        //to not add the same item twice .. 
                        //if (!((jobsDetailsViewModel)this.BindingContext).DatesSelected.Contains(dateselected))
                        if (!((jobsDetailsViewModel)this.BindingContext).DatesSelected.Contains(dateselected))
                        {
                            //add the selected item ..
                            ((jobsDetailsViewModel)this.BindingContext).DatesSelected.Add(dateselected);

                            // change the controle background .. 
                            imageSender.Source = "CheckedCaroot.png";

                            //order the list after adding the elements ..

                            var listcasst = ((jobsDetailsViewModel)this.BindingContext).DatesSelected.OrderBy(x => x.from);

                            ObservableCollection<JobSchedule> castlistordering = new ObservableCollection<JobSchedule>(listcasst);
                            ((jobsDetailsViewModel)this.BindingContext).DatesSelected = castlistordering;
                        }
                    }
                    else
                    {
                        //for single tap to check ..
                        if (!(e is TappedEventArgs))
                        {
                            return;
                        }
                        var item = ((TappedEventArgs)e).Parameter;
                        //select date to remove ..
                        var dateselected = ((jobsDetailsViewModel)this.BindingContext).jobscollection.FirstOrDefault(XX => XX.id == item.ToString());
                        //avoid dublicate add ..
                        if (((jobsDetailsViewModel)this.BindingContext).DatesSelected.Contains(dateselected))
                        {
                            //remove the selected item .. 
                            ((jobsDetailsViewModel)this.BindingContext).DatesSelected.Remove(dateselected);

                            //change the control background ..
                            imageSender.Source = "UNCWWBackround.png";

                            //order the list after adding the last elemnts ..
                            var listcasst = ((jobsDetailsViewModel)this.BindingContext).DatesSelected;
                      
                            ObservableCollection<JobSchedule> castlistordering = new ObservableCollection<JobSchedule>(listcasst);
                            ((jobsDetailsViewModel)this.BindingContext).DatesSelected = castlistordering;

                           
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in selecting dates inside job details", ex);
                await logged.LoggAPI();
            }
        }



        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            // close the Apply to Job Modal
            secondGrid.IsVisible = false;
            firstgrid.IsVisible = true;
            await firstgrid.FadeTo(1);
            await secondGrid.FadeTo(0);
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            if (((jobsDetailsViewModel)this.BindingContext)._jobModel.jobTypeTitle != EmployeeProfileHelper.EmployeeCurrentProfile.jobTypeTitle + $" ({((jobsDetailsViewModel)this.BindingContext)._jobModel.jobTypeAbbreviation})")
            {
                await DisplayAlert("", "The job speciality does not match the specialization mentioned in your skills information ", "OK");
                return;
            }
            //TODO : Order Here once  
            if (((jobsDetailsViewModel)this.BindingContext).DatesSelected.Any())
            {
                ((jobsDetailsViewModel)this.BindingContext).DatesSelected = new ObservableCollection<JobSchedule>(((jobsDetailsViewModel)this.BindingContext).DatesSelected.OrderBy(x => x.from));
                int counter = 0;
                if (((jobsDetailsViewModel)this.BindingContext).DatesSelected != null)
                {
                    foreach (var element in ((jobsDetailsViewModel)this.BindingContext).DatesSelected)
                    {
                        element.DayNumber = " Day " + (counter + 1).ToString();
                        counter++;
                    }
                }
                dateselecedlistview.ItemsSource = ((jobsDetailsViewModel)this.BindingContext).DatesSelected;
                var temps = ((jobsDetailsViewModel)this.BindingContext)._jobModel; 
                ApplyTexthelperone.FormattedText = jobdetailstexthelper.LabelTextFormating(temps , sldrvalue);
            }
            else
            {

            }

            // Job Apply
            firstgrid.IsVisible = false;
            secondGrid.IsVisible = true;
            await firstgrid.FadeTo(0);
            await secondGrid.FadeTo(1); 
            dateselecedlistview.HeightRequest = (25 * ((jobsDetailsViewModel)this.BindingContext).DatesSelected.Count) + (20);
        }

        private void Slder_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            try
            {

                ratetext.Text = "Rate " + " $" +Convert.ToInt32(Slder.Value) ;
                //slider value Changed Event ..
                sldrtxt.Text = " $" + Convert.ToInt32(Slder.Value);
                double min = ((jobsDetailsViewModel)this.BindingContext)._jobModel.minHrRate;
                double max = ((jobsDetailsViewModel)this.BindingContext)._jobModel.maxHrRate;  
                avrhrate.Text = Convert.ToInt32(((min + max) / 2)).ToString();
                var temps = ((jobsDetailsViewModel)this.BindingContext)._jobModel;
                sldrvalue = Convert.ToInt32(Slder.Value);
                ApplyTexthelperone.FormattedText = jobdetailstexthelper.LabelTextFormating(temps, sldrvalue);
            }
            catch (Exception exception)
            { 
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", exception);
                logged.LoggAPI();
            }
        }
        private async void B4_Clicked(object sender, EventArgs e)
        {
            try
            { 

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                if (locator.IsGeolocationEnabled)
                {
                    B4.IsEnabled = false;
                    //Check out 

                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    checkout = new Checkin_Checkout
                    {
                        ClockOut = position.Timestamp.DateTime,
                        ClockInLat = ClockOutLats,
                        ClockInLong = ClockOutLats,
                        ClockOutLat = position.Latitude,
                        ClockOutLong = position.Longitude,
                        JobId = idforsaving,
                        clockOutDeviceTimeStamp = DateTime.Now.ToString(),
                        clockInDeviceTimeStamp = DateTime.Now.ToString()
                    };

                    var succeed = await inout.PutCheckinoroutAsync(URLConfig.Clockout, checkout);
                    if (succeed)
                    {
                        await DisplayAlert(AlertMessages.Checkedout, AlertMessages.Checkedout, "Ok");
                        await loadData(idforsaving);
                        await ButtonApperance();
                        B4.IsEnabled = true;

                    }
                }
                else
                {
                    await DisplayAlert(AlertMessages.ErrorTitle,AlertMessages.EnableLocationSettings, "Ok");

                }

            }
            catch (Exception exception)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", exception);
                logged.LoggAPI();
            }
        }

        private async void B5_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Cancel Job
                B5.IsEnabled = false;
                var answer = await DisplayAlert("You are about to cancel a job ", AlertMessages.Canceljob, "Yes", "No");
                if (answer == true)
                {
                   //await loadData(idforsaving);
                    RestClient<bool> Dl = new RestClient<bool>();
                    JobCancel jc = new JobCancel() { id = ((jobsDetailsViewModel)this.BindingContext)._jobModel.jobApplicantId, status = (int)(JobStatus.Canceled) }; 
                    var res = await Dl.PutAsync(URLConfig.Changestatus, null, jc);
                    if (res == true)
                    {
                        await loadData(idforsaving);
                        await ButtonApperance();
                    }

                }
                B5.IsEnabled = true;
            }
            catch (Exception exception)
            {

                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", exception);
                logged.LoggAPI();
            }
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            //ApplyButton
            ApplyButton.IsEnabled = false;

            try
            {
                
                if (((jobsDetailsViewModel)this.BindingContext)._jobModel.isPartialyAllowed == true && ((jobsDetailsViewModel)this.BindingContext).jobscollection.ToList() == null)
                {
                    await DisplayAlert("", "Schedule", "Please select fine dates");
                    return;
                }
                else if (((jobsDetailsViewModel)this.BindingContext)._jobModel.isPartialyAllowed == true)
                {
                    JA = new JobApply()
                    {
                        jobId = ((jobsDetailsViewModel)this.BindingContext)._jobModel.id,
                        requestedHrRate = Convert.ToInt32(Slder.Value),
                        jobApplicantSchedules = ((jobsDetailsViewModel)this.BindingContext).DatesSelected.ToList(),

                    };
                }

                else
                {
                    JA = new JobApply()
                    {
                        jobId = ((jobsDetailsViewModel)this.BindingContext)._jobModel.id,
                        requestedHrRate = Convert.ToInt32(Slder.Value),
                        jobApplicantSchedules = ((jobsDetailsViewModel)this.BindingContext).jobscollection.ToList(),
                    };
                }
                RestClient<bool> Applytojob = new RestClient<bool>();


                var xbool = await Applytojob.PostApi(URLConfig.applyJop, JA);
                //await loadData(idforsaving);
                //await ButtonApperance();
                if (xbool == true)
                {
                    JobListHelper.IsApplied = true;
                    ThirdGrid.IsVisible = false;
                    secondGrid.IsVisible = false;
                    firstgrid.IsVisible = true;
                    await firstgrid.FadeTo(1);
                    await secondGrid.FadeTo(0);
                    await ThirdGrid.FadeTo(0); 
                    //Refresh the Page 
                    await loadData(idforsaving);
                    await ButtonApperance();
                }
                else
                {
                    ThirdGrid.IsVisible = false;
                    secondGrid.IsVisible = false;
                    firstgrid.IsVisible = true;
                    await firstgrid.FadeTo(1);
                    await secondGrid.FadeTo(0);
                    await ThirdGrid.FadeTo(0);
                    //await loadData(idforsaving);
                    //await ButtonApperance();
                }
                //dateselecedlistview.HeightRequest = (35 * tepmdateselected.Count);
                //dateselecedlistview.HeightRequest = (40 * tepmdateselected.Count) + (10 * tepmdateselected.Count);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                ApplyButton.IsEnabled = true;
            }
           
             
        }
          
        private async void Button_Clicked_5(object sender, EventArgs e)
        {
            try
            { 
                //Confirm Hiring
                confirmhiring.IsEnabled = false;
                RestClient<bool> Dl = new RestClient<bool>();
                JobCancel jc = new JobCancel() { id = jaid, status = (int)(UserType.Employee) };
                var responsex = await Dl.PutAsync(URLConfig.Changestatus, null, jc);
                if (responsex == true)
                {
                    await loadData(idforsaving);
                    await ButtonApperance();
                } 
                ThirdGrid.IsVisible = false;
                secondGrid.IsVisible = false;
                firstgrid.IsVisible = true;
                await firstgrid.FadeTo(1);
                await secondGrid.FadeTo(0);
                await ThirdGrid.FadeTo(0);
                await ButtonApperance();
                confirmhiring.IsEnabled = true;
            }
            catch (Exception exception)
            { 
              var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", exception);
              await logged.LoggAPI();
            }
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            //Close Confirm Hiring Modal 
            ThirdGrid.IsVisible = false;
            secondGrid.IsVisible = false;
            firstgrid.IsVisible = true;
            await firstgrid.FadeTo(1);
            await secondGrid.FadeTo(0);
            await ThirdGrid.FadeTo(0);
        }

        private async void B6_Clicked(object sender, EventArgs e)
        {
            //Open confirm hiring modal
            ThirdGrid.IsVisible = true;
            secondGrid.IsVisible = false;
            firstgrid.IsVisible = false;
            await firstgrid.FadeTo(0);
            await secondGrid.FadeTo(0);
            await ThirdGrid.FadeTo(1);
        }



        private async void CancelButtonn_Clicked(object sender, EventArgs e)
        { 
            secondGrid.IsVisible = false;
            firstgrid.IsVisible = true;
            await firstgrid.FadeTo(1);
            await secondGrid.FadeTo(0);
        }

        private async void cancelConfirmHiring_Clicked(object sender, EventArgs e)
        {
            ThirdGrid.IsVisible = false;
            secondGrid.IsVisible = false;
            firstgrid.IsVisible = true;
            await firstgrid.FadeTo(1);
            await secondGrid.FadeTo(0);
            await ThirdGrid.FadeTo(0);
        }

        private async void B3_Clicked(object sender, EventArgs e)
        {
            try
            {



                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                if (locator.IsGeolocationEnabled)
                {
                    // Check in
                    B3.IsEnabled = false;
                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    ClockOutLats = position.Latitude;
                    ClockOutLongs = position.Longitude;
                    checkin = new Checkin_Checkout
                    {
                        ClockIn = position.Timestamp.DateTime,
                        ClockInLat = ClockOutLats,
                        ClockInLong = ClockOutLongs,
                        JobId = idforsaving,
                        clockInDeviceTimeStamp = DateTime.Now.ToString(),
                        clockOutDeviceTimeStamp = DateTime.Now.ToString()
                    };
                    var issucced = await inout.PutCheckinoroutAsync(URLConfig.Clockin, checkin);
                    if (issucced)
                    {
                        await DisplayAlert(AlertMessages.Success, AlertMessages.Checkedin, "Ok");
                        await loadData(idforsaving);
                        await ButtonApperance();
                        B3.IsEnabled = true;

                    }
                }
                else
                {
                    await DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.EnableLocationSettings, "Ok");

                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
               await logged.LoggAPI();
            }
        }

        private async void OpenMapFullScreen(object sender, EventArgs e)
        {
            try
            {
                mapimage.IsEnabled = false;
                mapimage1.IsEnabled = false;
                mapimage2.IsEnabled = false;
                double lat = ((jobsDetailsViewModel)this.BindingContext).LocationLat;
                double lang = ((jobsDetailsViewModel)this.BindingContext).LocationLong;
                var page = new MapJobLocation(lat, lang);
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushModalAsync(page);
                mapimage.IsEnabled = true;
                mapimage1.IsEnabled = true;
                mapimage2.IsEnabled = true;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Newjobdetails.xaml.cs", ex);
                await logged.LoggAPI();
            }
      
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.pthippo.com/faq"));
        }

        private void Lx_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lx.ScrollTo(lx.SelectedItem, ScrollToPosition.MakeVisible,false);
        }
    }
}
