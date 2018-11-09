using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace Pt_Hippo_Mobile.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public async void  OnActivityResumed(Activity activity)
        {
            try
            {
                CrossCurrentActivity.Current.Activity = activity;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in main application", ex);
                await logged.LoggAPI();
            }

        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public  async void OnActivityStarted(Activity activity)
        {
            try
            {
                CrossCurrentActivity.Current.Activity = activity;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Errror in main application ", ex);
                await logged.LoggAPI();
            }
          
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}