using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Pt_Hippo_Mobile.Droid;
using Pt_Hippo_Mobile.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(androidToast))]
namespace Pt_Hippo_Mobile.Droid
{
    class androidToast : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}