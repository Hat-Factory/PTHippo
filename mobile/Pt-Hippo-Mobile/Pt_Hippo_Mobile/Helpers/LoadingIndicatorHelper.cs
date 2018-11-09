using Pt_Hippo_Mobile.LoadinIndicator;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class LoadingIndicatorHelper
    {
        /*public static ActivityIndicator activity;
        private static ContentPage CurrentPage;
        public static View OriginalView;
        private static DateTime LastShowTime;
        public static Grid grid;
        public static Grid gridProgress;
        private static Action _callBack;*/

        public static void Intialize(ContentPage page, bool forceReset = true , Action callBack = null)
        {
            return;

            /*if(page == CurrentPage)
            {
                return;
            }
            _callBack = callBack;
            if (activity == null || forceReset == true)
            {
                CurrentPage = page;
                OriginalView = null;
                activity = null;
                grid = null;
            }*/
        }
        public async static void AddProgressDisplay()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DependencyService.Get<IHudService>().ShowHud("Loading...");
            });


            try
            {
                //  await Task.Delay(15000);
                Device.StartTimer(TimeSpan.FromSeconds(15), () =>
                {
                    HideIndicator();

                    return false;
                });

                /*if (CurrentPage == null)
                {
                    return;
                }

                if (OriginalView != null)
                {
                    return;
                }

                if (grid != null)
                {
                    return;
                }

                if (activity == null)
                {
                    activity = new ActivityIndicator
                    {
                        IsEnabled = true,
                        IsVisible = true,
                        Color = Color.DarkOrange,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };
                }
                else
                {
                    if (activity.IsRunning)
                    {
                        return;
                    }
                }

                activity.IsRunning = true;
                var content = CurrentPage.Content;
                if (content != null)
                {
                    OriginalView = content;
                    grid = new Grid();
                    grid.Children.Add(OriginalView);
                    gridProgress = new Grid { BackgroundColor = Color.AliceBlue, Opacity = 0.5, Padding = new Thickness(50) };
                    gridProgress.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    gridProgress.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    gridProgress.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    gridProgress.SetBinding(VisualElement.IsVisibleProperty, "IsWorking");
                    gridProgress.Children.Add(activity, 0, 1);
                    grid.Children.Add(gridProgress);
                    CurrentPage.Content = grid;
                    LastShowTime = DateTime.Now;
                }
                else
                {
                    activity.IsRunning = false;
                }*/

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to add loading indicator", ex);
                logged.LoggAPI();
            }

        }

        public static void HideIndicator()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DependencyService.Get<IHudService>().HideHud();
                });

                /*if (activity != null)
                {
                    //var diff = DateTime.Now - LastShowTime;
                    //if(diff.TotalSeconds > 5)
                    {
                        if (OriginalView != null)
                        {
                            activity.IsRunning = false;
                            if (OriginalView != grid)
                            {
                                grid.Children.Remove(gridProgress);
                                CurrentPage.Content = OriginalView;
                            }
                            grid = null;
                            OriginalView = null;
                            activity = null;
                            if (_callBack != null)
                            {
                                _callBack.Invoke();
                            }
                        }
                    }

                }*/
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to remove loading indicator", ex);
                logged.LoggAPI();
            }
        }

    }
}
