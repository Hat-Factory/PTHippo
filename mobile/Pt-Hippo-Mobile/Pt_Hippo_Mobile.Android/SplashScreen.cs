
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace Pt_Hippo_Mobile.Droid
{
    [Activity(Label = "PT Hippo", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashScreen :  AppCompatActivity
	{
		// Launches the startup task
		protected override void OnResume()
		{
			base.OnResume();
            
            var intent = new Intent(Application.Context, typeof(MainActivity));
            
            //passing potential notification data
            if (Intent.Extras != null)
                intent.PutExtras(Intent.Extras);

            StartActivity(intent);
		}
    }

}
