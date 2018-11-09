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
using Xamarin.Forms.Platform.Android;
using Pt_Hippo_Mobile.Droid.Effects;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ResolutionGroupName("MyCompany")]

[assembly: ExportEffect(typeof(DroidBackgroundEntryEffect), "BackgroundEffect")]

namespace Pt_Hippo_Mobile.Droid.Effects
{
    class DroidBackgroundEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try

            {

                var nativeEditText = (global::Android.Widget.EditText)Control;

                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());

                shape.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();

                shape.Paint.SetStyle(Paint.Style.Stroke);

                nativeEditText.Background = shape;

            }

            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("error in background effect android ", ex);
               logged.LoggAPI();
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);

            }
        }

        protected override void OnDetached()
        {
         
        }
    }
}