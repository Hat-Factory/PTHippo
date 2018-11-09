using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.jobs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapJobLocation : ContentPage
    {

        public List<string> possibleAddresses { get; set; }
        public Geocoder geoCoder { get; set; }
        public Position MyPropertyPosition { get; set; }
        public Pin MyPropertypin { get; set; }
        double  locallat;
        double loacllang;
        public MapJobLocation(double lat, double lngt)
        {
            InitializeComponent();
            try
            {
                 locallat = lat;
                loacllang = lngt;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in MapJobLocation.xaml.cs", ex);
                logged.LoggAPI();
            }
     
        }

        protected override async void OnAppearing()
        {
            try
            {

                if (locallat != null && loacllang != null)
                {
                     Reverselanglat(locallat, loacllang);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in MapJobLocation.xaml.cs", ex);
                logged.LoggAPI();
            }
            finally
            {
                NewJobDetail.ISMapPage = true;
            }
        }
        public async void Reverselanglat(double lat, double lngt)
        {

            geoCoder = new Geocoder();

            try
            {
                MyPropertyPosition = new Position(lat, lngt);
                //possibleAddresses = new List<string>(await geoCoder.GetAddressesForPositionAsync(MyPropertyPosition));
                //if (possibleAddresses.Count != 0)
                //{

                    //foreach (var address in possibleAddresses)
                        MyPropertypin = new Pin
                        {
                            Type = PinType.Place,
                            Position = MyPropertyPosition,
                            Label = "Address",
                            Address = "-"
                        };

                    map.Pins.Add(MyPropertypin);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lngt), Distance.FromKilometers(2.5)));
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
                //}
                /*else if (possibleAddresses.Count == 0)
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
                }*/
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in MapJobLocation.xaml.cs", ex);
                logged.LoggAPI();
            }
        }

        //public async void toastaya()
        //{
        //    await DisplayAlert("Locations", "Location Not Exists", "OK");
        //}
    }
}