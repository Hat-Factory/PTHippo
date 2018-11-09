using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Pt_Hippo_Mobile.iOS.Effects;

[assembly: ResolutionGroupName("MyCompany")]

[assembly: ExportEffect(typeof(iOSBackgroundEntryEffect), "BackgroundEffect")]

namespace Pt_Hippo_Mobile.iOS.Effects
{
    class iOSBackgroundEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try

            {

                var view = this.Control as UITextField;

                if (view == null)

                    return;



                view.BorderStyle = UITextBorderStyle.Line;

            }

            catch (Exception ex)

            {
                var logged = new LoggedException.LoggedException("Error in iosbackgroundentryeffect", ex);
                logged.LoggAPI();
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);

            }
        }

        protected override void OnDetached()
        {

        }
    }
}