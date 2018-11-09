using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Pt_Hippo_Mobile.Interface;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pt_Hippo_Mobile.iOS.PushNotifications;
using WindowsAzure.Messaging;

[assembly: Dependency(typeof(PushNotficationsios))]
namespace Pt_Hippo_Mobile.iOS.PushNotifications
{
    public class PushNotficationsios : IpushNotfication
    {
        private SBNotificationHub Hub { get; set; }
        // Azure app-specific connection string and hub path
        public const string ConnectionString = "Endpoint=sb://pthippo.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=waWMvBCfHKz7Bjhu0WmgqClsChmw/Xj0+qqoJVSu4Sw=";
        public const string NotificationHubPath = "PTHippo";

        public string GetCurrentToken()
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");
        }

        public Tuple<bool, string> IsNotificationsSupported()
        {
            return new Tuple<bool, string>(true, "APNS available");
        }

        public async Task RegisterToAzure(string tag)
        {
            Hub = new SBNotificationHub(ConnectionString, NotificationHubPath);

            var tokenNSdata = new NSData(GetCurrentToken(), NSDataBase64DecodingOptions.IgnoreUnknownCharacters);

            Hub.UnregisterAllAsync(tokenNSdata, (error) => {
                if (error != null)
                {
                    Console.WriteLine("Error calling Unregister: {0}", error.ToString());
                    return;
                }
                NSSet tags = new NSSet(tag);
                Hub.RegisterNativeAsync(tokenNSdata, tags, (errorCallback) => {
                    if (errorCallback != null)
                        Console.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
                });
            });
        }

        public async Task UnRegisterToAzure()
        {
            Hub = new SBNotificationHub(ConnectionString, NotificationHubPath);

            var tokenNSdata = new NSData(GetCurrentToken(), NSDataBase64DecodingOptions.IgnoreUnknownCharacters);

            Hub.UnregisterAllAsync(tokenNSdata, (error) => {
                if (error != null)
                {
                    Console.WriteLine("Error calling Unregister: {0}", error.ToString());
                    return;
                }
            });
        }
    }
}