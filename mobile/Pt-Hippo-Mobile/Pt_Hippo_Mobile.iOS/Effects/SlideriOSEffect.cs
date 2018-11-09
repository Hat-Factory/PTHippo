using Pt_Hippo_Mobile.iOS.Effects;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SlideriOSEffect), "SliderEffect")]

namespace Pt_Hippo_Mobile.iOS.Effects
{
    public class SlideriOSEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var slider = (UISlider)Control;
            slider.ThumbTintColor = UIColor.FromRGB(247, 150, 81);
            slider.MaximumTrackTintColor = UIColor.FromRGB(198, 194, 190);
            slider.MinimumTrackTintColor= UIColor.FromRGB(247, 150, 81);
        }

        protected override void OnDetached()
        {
            // Use this method if you wish to reset the control to original state
        }
    }
}
