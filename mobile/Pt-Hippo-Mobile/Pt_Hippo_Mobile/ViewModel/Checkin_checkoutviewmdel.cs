using Plugin.Geolocator;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.CheckoutandPutCheckin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    class Checkin_checkoutviewmdel
    {
        Checkout_Checkin inout = new Checkout_Checkin();

        Checkin_Checkout checkin, checkout;
        //public System.DateTime? ClockIns { get; set; } // checkin why this is requried
        //public System.DateTime? ClockOuts { get; set; } // ClockOut
        //public double? ClockInLats { get; set; } // ClockInLat
        //public double? ClockInLongs{ get; set; } // ClockInLong
        //public double? ClockOutLats { get; set; } // ClockOutLat
        //public double? ClockOutLongs { get; set; } // ClockOutLong
        //public string JobScheduleId { get; set; } //JobScheduleId

        public ICommand Checkin
        {
            get
            {
                return new Command(async () =>
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    
                    checkin = new Checkin_Checkout
                    {
                        ClockIn = position.Timestamp.DateTime,
                        ClockInLat= position.Longitude,
                        ClockInLong= position.Longitude,
                        JobApplicantId = "70ea7d4d-08a6-42d2-a95f-5dc280a2312b"
                    };
                    var issucced = await inout.PutCheckinoroutAsync(URLConfig.Clockin, checkin);
                    if (!issucced)
                    {
                        Toast.LongMessage("You don't have work today , you can not perform checkout now ");
                    }
                    else
                    {
                        Toast.LongMessage("Wish You Happy Day");
                    }


                });
            }
        }
       
        public ICommand Checkout
        {
            get
            {
                return new Command(async () =>
                {


                    //  place();

                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    //ClockOutLats = position.Latitude;
                    //ClockOutLongs = position.Longitude;
                    //ClockOuts = position.Timestamp.DateTime;
                    checkout = new Checkin_Checkout
                    {
                        ClockOut= position.Timestamp.DateTime,
                        //ClockInLat =ClockInLats,
                        //ClockInLong=ClockInLongs,
                        ClockOutLat= position.Latitude,
                        ClockOutLong = position.Longitude,
                        JobApplicantId = "70ea7d4d-08a6-42d2-a95f-5dc280a2312b"
                    };
                    var succeed = await inout.PutCheckinoroutAsync(URLConfig.Clockout, checkout);
                    if (!succeed)
                    {
                        Toast.LongMessage("You don't have work today , you can not perform checkout now ");
                    }
                    else
                    {
                        Toast.LongMessage("Good Bye ");
                    }
                });
            }
        }
    }

}