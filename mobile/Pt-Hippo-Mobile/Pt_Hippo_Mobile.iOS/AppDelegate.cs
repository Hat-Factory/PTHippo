using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ButtonCircle.FormsPlugin.iOS;
using Foundation;
using UIKit;
using WindowsAzure.Messaging;
using CoreLocation;
using ImageCircle.Forms.Plugin.iOS;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }
		private SBNotificationHub Hub { get; set; }
		// Azure app-specific connection string and hub path
		public const string ConnectionString = "Endpoint=sb://pthippo.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=waWMvBCfHKz7Bjhu0WmgqClsChmw/Xj0+qqoJVSu4Sw=";
		public const string NotificationHubPath = "PTHippo";

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyBOF7sekEfDBMpyxEC7OC2_BQptJ87SWjo");
            ButtonCircleRenderer.Init();
            ImageCircleRenderer.Init();
            //CLLocationManager locationmanager = new CLLocationManager();
            //locationmanager.RequestWhenInUseAuthorization();

            var cv = typeof(Xamarin.Forms.CarouselView);
			var assembly = Assembly.Load(cv.FullName);
            LoadApplication(new App());

			// Register for push notifications.
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
					   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
					   new NSSet()); 
				UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications();
			}
			else
			{
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
			}

            return base.FinishedLaunching(app, options);
        }


		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
            var finalString = deviceToken.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
            NSUserDefaults.StandardUserDefaults.SetString(finalString, "PushDeviceToken");

            //Console.WriteLine(new NSData(finalString, NSDataBase64DecodingOptions.IgnoreUnknownCharacters));

            //Hub = new SBNotificationHub(ConnectionString, NotificationHubPath);

            //Hub.UnregisterAllAsync(deviceToken, (error) => {
            //    if (error != null)
            //    {
            //        Console.WriteLine("Error calling Unregister: {0}", error.ToString());
            //        return;
            //    }

            //    NSSet tags = null; // create tags if you want
            //    Hub.RegisterNativeAsync(deviceToken, tags, (errorCallback) => {
            //        if (errorCallback != null)
            //            Console.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
            //    });
            //});
        }

		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
		{
            if (application.ApplicationState == UIApplicationState.Active)
            {
                ProcessNotification(userInfo, true);
            }
            else
            {
                ProcessNotification(userInfo, false);
            }
		}

		void ProcessNotification(NSDictionary options, bool appIsActive)
		{
			// Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
			if (null != options && options.ContainsKey(new NSString("aps")))
			{
				//Get the aps dictionary
				NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;

				string alert = string.Empty;

				//Extract the alert text
				// NOTE: If you're using the simple alert by just specifying
				// "  aps:{alert:"alert msg here"}  ", this will work fine.
				// But if you're using a complex alert with Localization keys, etc.,
				// your "alert" object from the aps dictionary will be another NSDictionary.
				// Basically the JSON gets dumped right into a NSDictionary,
				// so keep that in mind.
				if (aps.ContainsKey(new NSString("alert")))
					alert = (aps[new NSString("alert")] as NSString).ToString();

				//If this came from the ReceivedRemoteNotification while the app was running,
				// we of course need to manually process things like the sound, badge, and alert.
				if (appIsActive)
				{
					//Manually show an alert
					if (!string.IsNullOrEmpty(alert))
					{
						UIAlertView avAlert = new UIAlertView("Notification", alert, null, AlertMessages.OkayTitle, null);
						avAlert.Show();
					}
				}
                else
                {
                    if (aps.ContainsKey(new NSString("jobid")))
                    {
                        string jobid = (aps[new NSString("jobid")] as NSString).ToString();
                        ((App)App.Current).OpenJobPage(jobid);
                    }
                    else if (aps.ContainsKey(new NSString("jobapplicantid")))
                    {
                        string jobapplicantid = (aps[new NSString("jobapplicantid")] as NSString).ToString();
                        ((App)App.Current).OpenJobApplicantPage(jobapplicantid);
                    }
                }
			}
		}
    }
}
