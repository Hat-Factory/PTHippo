using Android.Text.Method;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportEffect(typeof(Pt_Hippo_Mobile.Droid.Effects.ShowHidePassEffect), "ShowHidePassEffect")]
namespace Pt_Hippo_Mobile.Droid.Effects
{
    public class ShowHidePassEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            try
            {
                EditText editText = ((EditText)Control);
                editText.TransformationMethod = PasswordTransformationMethod.Instance;
                editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.hide, 0);
                editText.SetOnTouchListener(new OnDrawableTouchListener());
            }
            catch (System.Exception ex)
            {
                var logged = new LoggedException.LoggedException("ShowHidePassEffect.cs ", ex);
                logged.LoggAPI();
            }


        }
    }

    public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            try
            {
                if (v is EditText && e.Action == MotionEventActions.Up)
                {
                    EditText editText = (EditText)v;
                    if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                    {
                        //TODO : ShowHide Password 
                        if (editText.TransformationMethod == null)
                        {
                            editText.TransformationMethod = PasswordTransformationMethod.Instance;
                            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.hide, 0);
                        }
                        else
                        {
                            editText.TransformationMethod = null;
                            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.view, 0);
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (System.Exception ex)
            {

                 throw  ex;
            }

        }
    }
}