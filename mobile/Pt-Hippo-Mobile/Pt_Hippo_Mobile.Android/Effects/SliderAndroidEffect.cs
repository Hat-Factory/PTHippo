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
using Xamarin.Forms;
using Pt_Hippo_Mobile.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportEffect(typeof(SliderAndroidEffect), "SliderEffect")]

namespace Pt_Hippo_Mobile.Droid.Effects
{
    class SliderAndroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var seekBar = (SeekBar)Control;
            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.FromRgb(247, 150, 81).ToAndroid(), PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.FromRgb(247, 150, 81).ToAndroid(), PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            // Use this method if you wish to reset the control to original state
        }
    }
}