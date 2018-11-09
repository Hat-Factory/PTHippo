using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.MyTimeSheet;

using Pt_Hippo_Mobile.Views.jobs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
  public class Mytimesheetviewmodel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        //MyTimeSheetModelConverter converter;
        public double checkinla, checkinlong, checkoutlat, checkoutlong;

        private ObservableCollection<MyTimeSheetModelConverter> Converter;

        public ObservableCollection<MyTimeSheetModelConverter> MyConvertlist
        {
            get
            {
                return Converter;

            }
            set
            {
                Converter = value; OnPropertyChangedEventhander();
            }

        }

        public Mytimesheetviewmodel(INavigation navigation)
        {
            this.Navigation = navigation;
            MySheet();
        }
        private List<MyTimeSheetModel> mytimesheet;

        public Mytimesheetviewmodel()
        {
           
            
        }

        public List<MyTimeSheetModel> Mytimesheet
        {
            get
            {
                return mytimesheet;
            }
            set
            {
                mytimesheet = value;
                OnPropertyChangedEventhander();
            }
        }
        public ICommand locationCheckin
        {
            get
            {
                return new Command( async() =>
                {
                   //checkinla=  Double.Parse(converter.ClockInLat);
                   // checkinlong = Double.Parse(converter.ClockInLong);
                   

                    await Navigation.PushModalAsync(new MapJobLocation(checkinla,checkinlong));
                });
                    
            }
        }
        public ICommand locationCheckout
        {
            get
            {
                return new Command(async () =>
                {
                    //checkoutlat = Double.Parse(converter.ClockOutLat);
                    //checkoutlong = Double.Parse(converter.ClockOutLong);
                    await Navigation.PushModalAsync(new MapJobLocation(checkoutlat, checkoutlong));

                });
            }
        }

        public async void MySheet()
        {
            try
            {

                MyConvertlist = new ObservableCollection<MyTimeSheetModelConverter>();
                foreach (var item in Mytimesheet)
                {
                    MyConvertlist.Add(new MyTimeSheetModelConverter
                    {
                        ClockIn = item.ClockIn.ToString(),
                        ClockInLat = item.ClockInLat.ToString(),
                        ClockInLong = item.ClockInLong.ToString(),
                        ClockOut = item.ClockOut.ToString(),
                        ClockOutLat = item.ClockOutLat.ToString(),
                        ClockOutLong = item.ClockOutLong.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new LoggedException.LoggedException("Error in mytimesheetviewmodel", ex);
            }
        }
    }
}
