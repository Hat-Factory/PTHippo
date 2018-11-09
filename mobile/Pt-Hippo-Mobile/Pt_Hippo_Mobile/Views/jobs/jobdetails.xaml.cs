using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.ViewModel;
using System.Collections.ObjectModel;
using Plugin.Geolocator;
using Pt_Hippo_Mobile.RestClient.CheckoutandPutCheckin;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.Views.jobs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class jobdetails : ContentPage
    {
        JobApply JA = new JobApply();

        private ObservableCollection<JobSchedule> myVar;
        public jobdetails(string jobid)
        {
            idforsaving = jobid;
            InitializeComponent();
            tepmdateselected = new ObservableCollection<JobSchedule>();
            dateselecedlistview.ItemsSource = tepmdateselected;
             
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
                dateselecedlistview.ItemsSource = tepmdateselected;
                await loadData(idforsaving);
                //controlling the button apperance Apply , Cancel , Checkin and out etc ..
                await ButtonApperance();
                //setting the values to the slider from the Api to The Ui

                bool sliderEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
                double min = ((jobsDetailsViewModel)this.BindingContext)._jobModel.minHrRate;
                double max = ((jobsDetailsViewModel)this.BindingContext)._jobModel.maxHrRate; ;
                Slder.Maximum = max;
                Slder.Value = (min + max) / 2;

                if (sliderEnabled == false)
                {
                    Slder.Value = ((jobsDetailsViewModel)this.BindingContext)._jobModel.requestedHrRate;
                    Slder.IsEnabled = false;
                }
                ratetext.Text = "Rate " + Convert.ToInt32(Slder.Value) + " $";
                Slder.Minimum = min;
                skilstr.Text = ((jobsDetailsViewModel)this.BindingContext).skillsstring;
                confirmjobname.Text = ((jobsDetailsViewModel)this.BindingContext)._jobModel.jobTypeTitle;
                HiringDate.Text = DateTime.Now.ToString("d");
                jaid = ((jobsDetailsViewModel)this.BindingContext)._jobModel.jobApplicantId;

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
                lx.IsEnabled = ((jobsDetailsViewModel)this.BindingContext)._jobModel.showApply;
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
                //TODO:solve the errors at the following method
                Reverselanglat(lat, lang);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
                await logged.LoggAPI();

            }
        }


        public async void Reverselanglat(double lat, double lngt)
        {
            geoCoder = new Geocoder();

            try
            {
                MyPropertyPosition = new Position(lat, lngt);
                possibleAddresses = new List<string>(await geoCoder.GetAddressesForPositionAsync(MyPropertyPosition));
                if (possibleAddresses.Count != 0)
                {

                    foreach (var address in possibleAddresses)
                        MyPropertypin = new Pin
                        {
                            Type = PinType.Place,
                            Position = MyPropertyPosition,
                            Label = "Address",
                            Address = $"{address}"
                        };

                    map.Pins.Add(MyPropertypin);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lngt), Distance.FromKilometers(1.5)));
                    var mapTypeValues = new List<MapType>();
                    foreach (var mapType in Enum.GetValues(typeof(MapType)))
                    {
                        mapTypeValues.Add((MapType)mapType);
                    }

                    map.MapType = mapTypeValues[0];
                    // MyLocationEnabled

                    map.MyLocationEnabled = true;


                    // IsTrafficEnabled

                    map.IsTrafficEnabled = true;


                    // IndoorEnabled


                    map.IsIndoorEnabled = true;

                    // CompassEnabled


                    map.UiSettings.CompassEnabled = true;

                    // RotateGesturesEnabled 

                    map.UiSettings.RotateGesturesEnabled = true;

                    // MyLocationButtonEnabled 

                    map.UiSettings.MyLocationButtonEnabled = true;

                    // IndoorLevelPickerEnabled 

                    map.UiSettings.IndoorLevelPickerEnabled = true;

                    // ScrollGesturesEnabled 

                    map.UiSettings.ScrollGesturesEnabled = true;

                    // TiltGesturesEnabled 

                    map.UiSettings.TiltGesturesEnabled = true;

                    // ZoomControlsEnabled 

                    map.UiSettings.ZoomControlsEnabled = true;

                    // ZoomGesturesEnabled 
                    map.UiSettings.ZoomGesturesEnabled = true;
                }
                else if (possibleAddresses.Count == 0)
                {
                    MyPropertypin = new Pin
                    {
                        Type = PinType.Place,
                        Position = MyPropertyPosition,
                        Label = "Address",
                        Address = "No Address Found !"
                    };

                    map.Pins.Add(MyPropertypin);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lngt), Distance.FromMiles(0)));
                    var mapTypeValues = new List<MapType>();
                    foreach (var mapType in Enum.GetValues(typeof(MapType)))
                    {
                        mapTypeValues.Add((MapType)mapType);
                    }

                    map.MapType = mapTypeValues[0];
                    // MyLocationEnabled

                    map.MyLocationEnabled = true;


                    // IsTrafficEnabled

                    map.IsTrafficEnabled = true;


                    // IndoorEnabled


                    map.IsIndoorEnabled = true;

                    // CompassEnabled


                    map.UiSettings.CompassEnabled = true;

                    // RotateGesturesEnabled 

                    map.UiSettings.RotateGesturesEnabled = true;

                    // MyLocationButtonEnabled 

                    map.UiSettings.MyLocationButtonEnabled = true;

                    // IndoorLevelPickerEnabled 

                    map.UiSettings.IndoorLevelPickerEnabled = true;

                    // ScrollGesturesEnabled 

                    map.UiSettings.ScrollGesturesEnabled = true;

                    // TiltGesturesEnabled 

                    map.UiSettings.TiltGesturesEnabled = true;

                    // ZoomControlsEnabled 

                    map.UiSettings.ZoomControlsEnabled = true;

                    // ZoomGesturesEnabled 
                    map.UiSettings.ZoomGesturesEnabled = true;
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", ex);
                logged.LoggAPI();
            }
        }



        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //select  fine dates 
            try
            {
                tapCount++;
                var imageSender = (Image)sender;
                //var item = ((TappedEventArgs)e).Parameter;
                //await ButtonApperance();

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

                            //order the list after adding the elements ..

                            //TODO : ESlam

                            //count the list to break befor the last element ..
                            //int counter = 0;
                            //if (((jobsDetailsViewModel)this.BindingContext).DatesSelected != null)
                            //{
                            //    foreach (var element in ((jobsDetailsViewModel)this.BindingContext).DatesSelected)
                            //    {
                            //        element.DayNumber = " Day " + (counter + 1).ToString();
                            //        counter++;

                            //    }
                            //}

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
                            //.OrderBy(x => x.from);
                            ObservableCollection<JobSchedule> castlistordering = new ObservableCollection<JobSchedule>(listcasst);
                            ((jobsDetailsViewModel)this.BindingContext).DatesSelected = castlistordering;

                            //TODO : ESlam

                            //int counter = 0;
                            //if (((jobsDetailsViewModel)this.BindingContext).DatesSelected != null)
                            //{
                            //    foreach (var element in ((jobsDetailsViewModel)this.BindingContext).DatesSelected)
                            //    {

                            //        element.DayNumber = " day " + (counter + 1).ToString();
                            //        counter++;

                            //    }
                            //}

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
            }
            else
            {

            }

            // Job Apply
            firstgrid.IsVisible = false;
            secondGrid.IsVisible = true;
            await firstgrid.FadeTo(0);
            await secondGrid.FadeTo(1);

        }

        private void Slder_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ratetext.Text = "Rate " + Convert.ToInt32(Slder.Value) + " $";
                //slider value Changed Event ..
                sldrtxt.Text = (Convert.ToInt32(Slder.Value).ToString()) + " $";
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
                if(locator.IsGeolocationEnabled)
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
                if(succeed)
                {
                    await DisplayAlert(AlertMessages.Checkedout, AlertMessages.Checkedout, "Ok");
                    await loadData(idforsaving);
                    await ButtonApperance();
                    B4.IsEnabled = true;
                    
                }
                }
                else
                {
                    await DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.EnableLocationSettings, "Ok");

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
                    RestClient<bool> Dl = new RestClient<bool>();
                    JobCancel jc = new JobCancel() { id = jaid, status = (int)(JobStatus.Canceled) };
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
                await loadData(idforsaving);
                await ButtonApperance();
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
                    await loadData(idforsaving);
                    await ButtonApperance();
                }
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


        //await Navigation.PushAsync(new MapJobLocation(lat, lang));

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
                logged.LoggAPI();
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
            firstgrid.IsVisible = true;
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


                // Check in
                B3.IsEnabled = false;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                if(locator.IsGeolocationEnabled)
                {
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
            catch (Exception exception)
            {

                var logged = new LoggedException.LoggedException("Error in jobdetails.xaml.cs", exception);
                logged.LoggAPI();
            }
        }
    }
}