using System;
using System.Collections.Generic;
using System.Linq;
//using UXDivers.Artina.Shared;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Views;
using Pt_Hippo_Mobile.Droid.Renderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonCompatRenderer))]

namespace Pt_Hippo_Mobile.Droid.Renderers
{
    public class CustomButtonCompatRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public CustomButtonCompatRenderer() : base()
        {
            SetWillNotDraw(false);
        }


        private GradientDrawable _normal,
                                        _pressed;


        // resolves: button text alignment lost after click or IsEnabled change
        //public override void ChildDrawableStateChanged(Android.Views.View child)
        //{
        //  base.ChildDrawableStateChanged(child);
        //  Control.Text = Control.Text; 
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                SetAlignment();

                var density = Math.Max(1, Resources.DisplayMetrics.Density);
                var button = e.NewElement;
                var mode = MeasureSpec.GetMode((int)button.BorderRadius);
                var borderRadius = button.BorderRadius * density;
                var borderWidth = button.BorderWidth * density;

                // Create a drawable for the button's normal state
                _normal = new Android.Graphics.Drawables.GradientDrawable();

                if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
                    _normal.SetColor(Android.Graphics.Color.ParseColor("#ff2c2e2f"));
                else
                    _normal.SetColor(button.BackgroundColor.ToAndroid());

                _normal.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
                _normal.SetCornerRadius(borderRadius);

                // Create a drawable for the button's pressed state
                _pressed = new Android.Graphics.Drawables.GradientDrawable();
                var highlight = Context.ObtainStyledAttributes(new int[]
                                    {
                                        Android.Resource.Attribute.ColorAccent  //  .ColorActivatedHighlight
                                    }).GetColor(0, Android.Graphics.Color.Gray);

                _pressed.SetColor(highlight);
                _pressed.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
                _pressed.SetCornerRadius(borderRadius);

                // Add the drawables to a state list and assign the state list to the button
                var sld = new StateListDrawable();
                sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
                sld.AddState(new int[] { }, _normal);
                Control.SetBackground(sld);     //.SetBackgroundDrawable(sld); // deprecated
            }
        }

        private void SetAlignment()
        {
            var element = this.Element as Button;

            if (element == null || this.Control == null)
            {
                return;
            }

            this.Control.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            //element.VerticalAlignment.ToDroidVerticalGravity() |  
            //element.HorizontalAlignment.ToDroidHorizontalGravity();  
        }

        void DrawCustom(Button targetButton)
        {
            if (Control == null || targetButton == null)
                return;

        }
    }
}