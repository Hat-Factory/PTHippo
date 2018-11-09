using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationBar : ContentView
    {
        public enum NavigationBarTypeEnum
        {
            MasterDetail, Modal, NavigationPage
        }
        private bool busy = false;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public string Title
        {
            set { BarTitle.Text = value; }
        }

        private NavigationBarTypeEnum _navigationBarTypeEnum;

        public NavigationBarTypeEnum NavigationBarType
        {
            get { return _navigationBarTypeEnum; }
            set
            {
                _navigationBarTypeEnum = value;
                switch (value)
                {
                    case NavigationBarTypeEnum.Modal:
                    case NavigationBarTypeEnum.NavigationPage:
                        TopLeftButtonImage.Source = "back_white.png";
                        break;
                    case NavigationBarTypeEnum.MasterDetail:
                    default:
                        TopLeftButtonImage.Source = "menu.png";
                        break;
                }
            }
        }

        public CustomNavigationBar()
        {
            InitializeComponent();
        }

        private async void TopLeftButtonClicked(object sender, EventArgs e)
        {
            try
            {
            TLB.IsEnabled = false;
            switch (NavigationBarType)
            {
                case NavigationBarTypeEnum.MasterDetail:
                    ToggleDrawerMasterPage();
                    break;
                case NavigationBarTypeEnum.Modal:
                    PopModalAsync();
                    break;
                case NavigationBarTypeEnum.NavigationPage:
                    await PopAsync();
                    break;
                default:
                    break;
            }
            TLB.IsEnabled = true;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in ToggleDrawerMasterPage CustomNavigationBar", ex);
                await logged.LoggAPI();
            }
        }

        private async void ToggleDrawerMasterPage()
        {
            try
            { 
            MessagingCenter.Send<CustomNavigationBar>(this, "ToggleDrawer");
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in ToggleDrawerMasterPage CustomNavigationBar", ex);
                 await logged.LoggAPI();
            }
        }

        private async Task PopAsync()
        { 
            if (IsBusy)
                return;
            try
            {
                IsBusy = true; 
                var navigation = GetNavigation();
                if (navigation != null)
                await navigation.PopAsync();
            }
            catch (Exception ex)
            { 
                var logged = new LoggedException.LoggedException("Error in PopAsync CustomNavigationBar", ex);
                await logged.LoggAPI();
            }
            finally
            {
                IsBusy = false;
            } 
        }
        private async void PopModalAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var navigation = GetNavigation();
                if (navigation != null)
                await navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in PopModalAsync CustomNavigationBar", ex);
                await logged.LoggAPI();
            }
            finally
            {
                IsBusy = false;
            }


        }

        private INavigation GetNavigation()
        {
            try
            {
            var parent = this.Parent;

            while (parent != null)
            {
                if (parent is Page)
                    return ((Page)parent).Navigation;
                parent = parent.Parent;
            }

            return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}