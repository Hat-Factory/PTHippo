using System;
using Android.Gms.Common;
using Firebase.Iid;
using Pt_Hippo_Mobile.Droid.pushnotfications;
using Pt_Hippo_Mobile.Interface;
using Xamarin.Forms;
using WindowsAzure.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Dependency(typeof(PushNotficationsandroid))]
namespace Pt_Hippo_Mobile.Droid.pushnotfications
{
    public class PushNotficationsandroid :IpushNotfication
    {
        private NotificationHub Hub { get; set; }
        // Azure app-specific connection string and hub path
        public const string ConnectionString = "Endpoint=sb://pthippo.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=waWMvBCfHKz7Bjhu0WmgqClsChmw/Xj0+qqoJVSu4Sw=";
        public const string NotificationHubPath = "PTHippo";


		public Tuple<bool, string> IsNotificationsSupported()
		{
			int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Forms.Context);
			if (resultCode != ConnectionResult.Success)
			{
				if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
					return new Tuple<bool, string>(false, GoogleApiAvailability.Instance.GetErrorString(resultCode));
				else
				{
					new Tuple<bool, string>(false, "This device is not supported");
				}
				return new Tuple<bool, string>(false, "Uknown Error");
			}
			else
			{
				return new Tuple<bool, string>(true, "Google Play Services is available.");
			}

		}

		public string GetCurrentToken()
		{
			return FirebaseInstanceId.Instance.Token;
		}

        public async Task RegisterToAzure(string tag)
        {
            await Task.Run(() =>
            {
                Hub = new NotificationHub(NotificationHubPath, ConnectionString, Forms.Context);

                try
                {
                    Hub.UnregisterAll(GetCurrentToken());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                var tags = new List<string>() { tag };

                try
                {
                    var hubRegistration = Hub.Register(GetCurrentToken(), tags.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            });
        }

        public async Task UnRegisterToAzure()
        {
            await Task.Run(() =>
            {
                Hub = new NotificationHub(NotificationHubPath, ConnectionString, Forms.Context);

                try
                {
                    Hub.UnregisterAll(GetCurrentToken());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            });
        }
    }
}
   