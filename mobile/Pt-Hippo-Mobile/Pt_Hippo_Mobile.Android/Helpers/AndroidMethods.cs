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
using Pt_Hippo_Mobile.Droid.Helpers;
using Pt_Hippo_Mobile.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Pt_Hippo_Mobile.Droid.Helpers
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}