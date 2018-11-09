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
using AndroidHUD;
using Android.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(Pt_Hippo_Mobile.Droid.LoadingIndicator.DroidHudService))]
namespace Pt_Hippo_Mobile.Droid.LoadingIndicator
{
    public class DroidHudService: Pt_Hippo_Mobile.LoadinIndicator.IHudService
    {

        #region IHudManager implementation

        bool isHudVisible;

        public void ShowHud(string ProgressText = "Loading...")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Show(Forms.Context, ProgressText, maskType: MaskType.Black);
                isHudVisible = true;

            });
        }

        public void HideHud()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Dismiss(Forms.Context);
                isHudVisible = false;
            });
        }

        public void SetProgress(double Progress, string ProgressText = "")
        {
            if (!isHudVisible)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                int progress = (int)(Progress * 100);
                AndHUD.Shared.Show(Forms.Context, ProgressText + progress + "%", progress, MaskType.Black);
            });
        }
        public void SetText(string Text)
        {
            if (!isHudVisible)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Show(Forms.Context, Text, maskType: MaskType.Black);
            });
        }

        Android.Views.View CustomLoadingView(string ProgressText)
        {
            Android.Views.View loadingView = new Android.Views.View(Forms.Context);

            return loadingView;
        }

        #endregion
    }
}