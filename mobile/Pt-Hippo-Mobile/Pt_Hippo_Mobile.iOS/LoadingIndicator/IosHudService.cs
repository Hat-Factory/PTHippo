using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Pt_Hippo_Mobile.LoadinIndicator;
using BigTed;
using CoreGraphics;
using CoreAnimation;
using Pt_Hippo_Mobile.iOS.LoadingIndicator;

[assembly: Dependency(typeof(IosHudService))]
namespace Pt_Hippo_Mobile.iOS.LoadingIndicator
{

    /// <summary>
    /// Manages loading indicators in the app.
    /// </summary>
    public class IosHudService : IHudService
    {

        UIView _load;

        bool isHudVisible;

        #region IHudManager implementation

        /// <summary>
        /// Show loading indicator.
        /// </summary>
        /// <param name="ProgressText">Progress to set.</param>
        public void ShowHud(string ProgressText = "Loading...")
        {
            isHudVisible = true;
            SetText(ProgressText);
        }

        /// <summary>
        /// Hide loading indicator.
        /// </summary>
        public void HideHud()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Dismiss();
                if (_load != null)
                    _load.Hidden = true;
                isHudVisible = false;
            });
        }


        /// <summary>
        /// Method to change Progress Text and show custom loader with Challenge Logo
        /// </summary>
        /// <param name="ProgressText">Progress text.</param>
        public void SetProgress(double Progress, string ProgressText = "")
        {
            int progress = (int)(Progress * 100);
            string text = ProgressText + progress + "%";
            SetText(text);
        }

        /// <summary>
        /// Set text to loading indicator.
        /// </summary>
        /// <param name="text">Text to display.</param>
        public void SetText(string text)
        {
            if (!isHudVisible)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Show(status: text, maskType: ProgressHUD.MaskType.Black);

                try
                {
                    //if (_load == null) {
                    //  _load = CustomLoadingView (text);
                    //  ProgressHUD.Shared.AddSubview (_load);
                    //}
                    lblTitle.Text = text;

                    UIView[] subView = ProgressHUD.Shared.Subviews;
                    for (int i = 0; i < subView.Length; i++)
                    {
                        subView[i].Hidden = true;
                    }
                    _load.Hidden = false;
                    ProgressHUD.Shared.BringSubviewToFront(_load);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("IosHudService.cs - SetText() " + ex.Message);
#endif
                }
            });
        }

        UILabel lblTitle;
        /// <summary>
        /// Customs the loading view.
        /// </summary>
        /// <returns>The loading view.</returns>
        /// <param name="ProgressText">Progress text.</param>
        UIView CustomLoadingView(string ProgressText)
        {
            UIView loadingView = new UIView();
            loadingView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            UIImageView imgBg = new UIImageView();
            imgBg.Image = UIImage.FromFile("load_bg.png");
            imgBg.Frame = new CGRect((loadingView.Frame.Width / 2) - 65, (loadingView.Frame.Height / 2) - 70, 130, 140);
            loadingView.Add(imgBg);

            UIImageView someImageView = new UIImageView();
            someImageView.Frame = new CGRect((loadingView.Frame.Width / 2) - 40, (loadingView.Frame.Height / 2) - 50, 75, 75);
            someImageView.AnimationImages = new UIImage[]
            {
                UIImage.FromBundle("spinner.png"),
            };
            someImageView.AnimationRepeatCount = nint.MaxValue; // Repeat forever.
            someImageView.AnimationDuration = 1.0; // Every 1s.
            someImageView.StartAnimating();


            CABasicAnimation rotationAnimation = new CABasicAnimation();
            rotationAnimation.KeyPath = "transform.rotation.z";
            rotationAnimation.To = new NSNumber(Math.PI * 2);
            rotationAnimation.Duration = 1;
            rotationAnimation.Cumulative = true;
            rotationAnimation.RepeatCount = float.PositiveInfinity;
            someImageView.Layer.AddAnimation(rotationAnimation, "rotationAnimation");
            loadingView.Add(someImageView);


            lblTitle = new UILabel();
            lblTitle.Text = ProgressText;
            lblTitle.Frame = new CGRect(imgBg.Frame.X, someImageView.Frame.Y + someImageView.Frame.Height + 15, 130, 20);
            lblTitle.TextAlignment = UITextAlignment.Center;
            lblTitle.TextColor = UIColor.White;
            lblTitle.AdjustsFontSizeToFitWidth = true;
            loadingView.Add(lblTitle);
            return loadingView;
        }

        #endregion
    }
}