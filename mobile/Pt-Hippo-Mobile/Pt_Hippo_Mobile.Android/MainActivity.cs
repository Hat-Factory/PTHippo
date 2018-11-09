using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using ButtonCircle.FormsPlugin.Droid;
using Xamarin.Forms.Platform.Android;
using System.Reflection;
using Pt_Hippo_Mobile.Droid.Renderers;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Gms.Common;
using Firebase;

namespace Pt_Hippo_Mobile.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, Label = "PT Hippo", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTask, Theme = "@style/MainTheme", MainLauncher = false , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        string TAG = "MyMainActivity";
        protected override void OnCreate(Bundle bundle)
        {

            try
            {
              
                if (Intent.Extras != null)
                {
                    foreach (var key in Intent.Extras.KeySet())
                    {
                        var value = Intent.Extras.GetString(key);
                        Log.Debug("FCM", "Key: {0} Value: {1}", key, value);
                    }
                }
                ToolbarResource = Resource.Layout.Toolbar;
                TabLayoutResource = Resource.Layout.Tabbar;


                base.OnCreate(bundle);
                global::Xamarin.FormsMaps.Init(this, bundle);
                Xamarin.Forms.Forms.Init(this, bundle);
                global::Xamarin.FormsGoogleMaps.Init(this, bundle);

                ButtonCircleRenderer.Init();
                var cv = typeof(Xamarin.Forms.CarouselView);
                var assembly = Assembly.Load(cv.FullName);
                LoadApplication(new App());

                IsPlayServicesAvailable();

                //handle any potential notifications.
                string jobid = Intent.GetStringExtra("jobid") ?? null;
                if (!string.IsNullOrEmpty(jobid))
                {
                    ((App)App.Current).OpenJobPage(jobid);
                }
                else 
                {
                    string jobapplicantid = Intent.GetStringExtra("jobapplicantid") ?? null;
                    if (!string.IsNullOrEmpty(jobapplicantid))
                        ((App)App.Current).OpenJobApplicantPage(jobapplicantid);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in mainactivity.cs", ex);
                 logged.LoggAPI();
            }
           
            
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            //handle any potential notifications.
            string jobid = intent.GetStringExtra("jobid") ?? null;
            if (!string.IsNullOrEmpty(jobid))
            {
                ((App)App.Current).OpenJobPage(jobid);
            }
            else
            {
                string jobapplicantid = intent.GetStringExtra("jobapplicantid") ?? null;
                if (!string.IsNullOrEmpty(jobapplicantid))
                ((App)App.Current).OpenJobApplicantPage(jobapplicantid);
            }
        }
        
       
        public override void OnBackPressed()
        {
            if (App.DoBack)
            {
                base.OnBackPressed();
            }

        }

		public bool IsPlayServicesAvailable()
		{

			int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
			if (resultCode != ConnectionResult.Success)
			{

				if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(TAG, GoogleApiAvailability.Instance.GetErrorString(resultCode));
				else
				{
                    Log.Debug(TAG, "This device is not supported");
					Finish();
				}
				return false;
			}
			else
			{

                    Log.Debug(TAG, "Google Play Services is available.");
                try
                {
                    FirebaseApp app = FirebaseApp.InitializeApp(Android.App.Application.Context);

                    Log.Debug(TAG, "Token" + FirebaseInstanceId.Instance.Token);
                    var FCMToken = FirebaseInstanceId.Instance.Token;
                    if (string.IsNullOrEmpty(FCMToken))
                    {
                        Log.Debug(TAG, $"FCM Registration Token: coming null");

                    }
                }
                catch (Exception ex)
                {
                    
                    
                    Log.Debug(TAG, "firebase not initialized yet");
                    var logged = new LoggedException.LoggedException("Firebase excpetion", ex);
                    logged.LoggAPI();
                    return true;
                }
                return true;
			}
		}
    }
}