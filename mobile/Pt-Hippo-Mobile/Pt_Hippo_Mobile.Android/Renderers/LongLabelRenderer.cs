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
using Pt_Hippo_Mobile.Controls;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LongLabel), typeof(LongLabelRenderer))]
namespace Pt_Hippo_Mobile.Droid.Renderers
{
    public class LongLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.SetMaxLines(10000); 
            Control.ScrollX = 2000;
        }
    }
}