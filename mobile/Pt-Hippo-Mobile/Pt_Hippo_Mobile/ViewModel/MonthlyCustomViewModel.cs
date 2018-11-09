using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class MonthlyCustomViewModel : BaseViewModel
    {
        public MonthlyCustomViewModel()
        {
           
        }
        private string _currentYear;
        public string CurrentYear
        {
            get { return _currentYear; }
            set
            {
                _currentYear = value;
                OnPropertyChangedEventhander();
            }
        }

        private string _currentMonth;
        public string CurrentMonth
        {
            get { return _currentMonth; }
            set
            {
                _currentMonth = value;
                OnPropertyChangedEventhander();
            }
        }

        public ICommand SlideRight
        {
            get
            {
                return new Command(() =>
                {
                    if(MonthlyControlHelper.SlideRight())
                    {
                        //Filter list
                    }
                    CurrentMonth = MonthlyControlHelper.CurrentMonth;
                    CurrentYear = MonthlyControlHelper.CurrentYear;
                });
            }
        }

        public ICommand SlideLeft
        {
            get
            {
                return new Command(() =>
                {
                    if (MonthlyControlHelper.SlideLeft())
                    {
                        //Filter list
                    }
                    CurrentMonth = MonthlyControlHelper.CurrentMonth;
                    CurrentYear = MonthlyControlHelper.CurrentYear;
                });
            }
        }
    }
}
