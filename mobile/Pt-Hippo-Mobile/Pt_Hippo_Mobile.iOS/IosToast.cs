using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Pt_Hippo_Mobile.iOS;
using Pt_Hippo_Mobile.Interface;

[assembly:Xamarin.Forms.Dependency(typeof(IosToast))]
namespace Pt_Hippo_Mobile.iOS
{
    class IosToast :IMessage
    {
        const double Long_Delay = 3.5;
        const double Short_Delay = 2.0;
        NSTimer alertDelay;
        UIAlertController alert;
        public IosToast()
        {
        }

        public void LongAlert(string message)
        {
            ShowAlert(message, Long_Delay);
        }


        public void ShortAlert(string message)
        {

            ShowAlert(message, Short_Delay);
        }
        private void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();

            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        private void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}