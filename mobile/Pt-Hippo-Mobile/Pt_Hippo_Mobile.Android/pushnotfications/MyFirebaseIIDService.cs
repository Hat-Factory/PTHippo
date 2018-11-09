using System;
using Android.App;
using Android.Util;
using Firebase.Iid;
using Newtonsoft.Json;
using Pt_Hippo_Mobile.Enums;
using WindowsAzure.Messaging;
using System.Collections.Generic;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.Droid.pushnotfications
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]

    public class MyFirebaseIIDService :FirebaseInstanceIdService
    {
        private NotificationHub Hub { get; set; }
        // Azure app-specific connection string and hub path
        public const string ConnectionString = "Endpoint=sb://pthippo.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=waWMvBCfHKz7Bjhu0WmgqClsChmw/Xj0+qqoJVSu4Sw=";
        public const string NotificationHubPath = "PTHippo";

        public MyFirebaseIIDService()
        {
        }
		const string TAG = "MyFirebaseIIDService";
		public override void OnTokenRefresh()
		{
			var refreshedToken = FirebaseInstanceId.Instance.Token;
			SendRegistrationToServer(refreshedToken);
		}

		void SendRegistrationToServer(string token)
		{
			Log.Debug(TAG, "Refreshed token: " + token);

            if (!string.IsNullOrEmpty(Pt_Hippo_Mobile.Helpers.Settings.Username))
            {
                Hub = new NotificationHub(NotificationHubPath, ConnectionString, BaseContext);

                try
                {
                    Hub.UnregisterAll(token);
                    Log.Error(TAG, "Firebase UnregisterAll");

                }
                catch (Exception ex)
                {
                    Log.Error(TAG, ex.Message);
                }
                
              //  var tags = new List<string>() { Helpers.Settings.Username };

                try
                {
                //    var hubRegistration = Hub.Register(token, tags.ToArray());
                }
                catch (Exception ex)
                {
                    Log.Error(TAG, ex.Message);
                }
            }
            
        }
	}
}
