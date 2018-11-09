using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;
using Pt_Hippo_Mobile.RestClient.EmployeeScheduleRest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;

using Xamarin.Forms;
using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;
using System.Globalization;

namespace Pt_Hippo_Mobile.ViewModel
{
    class EmployeeScheduleViewmodel : BaseViewModel
    {

        EmployeeScheduleUpdate ESU = new EmployeeScheduleUpdate();

        public EmployeeSchedule data;
        public ObservableCollection<EmployeeSchedule> scheduleListOFData = new ObservableCollection<EmployeeSchedule>();
        public List<EmployeeSchedule> getdata = new List<EmployeeSchedule>();
        public ObservableCollection<EmployeeSchedule> MYschdeule = new ObservableCollection<EmployeeSchedule>();

        public string From, To;
        double totalhours;
        private TimeSpan timefrom, timeto;
        private DateTime dfrom, dto;
        private DateTime Specificdays;
        public DateTime min;

        public double TotalHours
        {
            get { return totalhours; }
            set { totalhours = value; OnPropertyChangedEventhander(); }
        }
        public DateTime Minumdatetime
        {
            get { return min; }
            set { min = value; OnPropertyChangedEventhander(); }
        }

        public DateTime specific
        {
            get { return Specificdays; }
            set
            {
                Specificdays = value;
                if (Specificdays == null || Specificdays == DateTime.MinValue)
                {
                    Specificdays = DateTime.Today;
                }
                OnPropertyChangedEventhander();
            }
        }

        public TimeSpan Timefrom
        {
            get { return timefrom; }
            set
            {
                timefrom = value;
                dfrom = Convert.ToDateTime(timefrom.ToString());
                Debug.WriteLine(dfrom.ToString("hh:mm tt"));
                From = dfrom.ToString("hh:mm tt");

                Debug.WriteLine(dfrom.DayOfWeek);

                OnPropertyChangedEventhander();
            }
        }

        public TimeSpan Timeto
        {
            get { return timeto; }
            set
            {
                timeto = value;
                dto = Convert.ToDateTime(timeto.ToString());
                Debug.WriteLine(dto.ToString("hh:mm tt"));
                To = dto.ToString("hh:mm tt");

                Debug.WriteLine(dto.DayOfWeek);
                OnPropertyChangedEventhander();
            }
        }

        ObservableCollection<EmployeeSchedule> MYschdeule1 = new ObservableCollection<EmployeeSchedule>();
        public ObservableCollection<EmployeeSchedule> MYschdeule2
        {
            get { return MYschdeule1; }
            set { MYschdeule1 = value; OnPropertyChangedEventhander(); }
        }
        public static ObservableCollection<EmployeeSchedule> tempschadual
        {
            get;
            set;
        }

        private static ObservableCollection<EmployeeSchedule> Listtofilter;

        public static ObservableCollection<EmployeeSchedule> _Listtofilter
        {
            get { return Listtofilter; }
            set { Listtofilter = value; }
        }

        public int dayOfWeek { get; set; }
        public DateTime specificDate { get; set; }
        private bool isavailable;
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
                return new Command(async () =>
                {
                    try
                    {
                        List<EmployeeSchedule> filterlist = new List<EmployeeSchedule>();
                        if (MonthlyControlHelper.SlideRight())
                        {
                            //Filter list
                            filterlist = tempschadual.Where(x => x.SpecificDateyear == MonthlyControlHelper.CurrentYear && x.SpecificDatmonth == MonthlyControlHelper.GetCurrentMonthNumber().ToString()).ToList();
                        }
                        if (filterlist != null)
                        {
                            MYschdeule2 = new ObservableCollection<EmployeeSchedule>(filterlist);
                        }
                        CurrentMonth = MonthlyControlHelper.CurrentMonth;
                        CurrentYear = MonthlyControlHelper.CurrentYear;
                    }
                    catch (Exception ex)
                    {

                        var logged = new LoggedException.LoggedException("error in EmployeeScheduleViewmodel.cs", ex);
                        await logged.LoggAPI();
                    }

                });
            }
        }

        public  ICommand SlideLeft
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        List<EmployeeSchedule> filterlist = new List<EmployeeSchedule>();

                        if (MonthlyControlHelper.SlideLeft())
                        {
                            filterlist = tempschadual.Where(x => x.SpecificDateyear == MonthlyControlHelper.CurrentYear && x.SpecificDatmonth == MonthlyControlHelper.GetCurrentMonthNumber().ToString()).ToList();
                        }
                        if (filterlist != null)
                        {
                            MYschdeule2 = new ObservableCollection<EmployeeSchedule>(filterlist);
                        }
                        CurrentMonth = MonthlyControlHelper.CurrentMonth;
                        CurrentYear = MonthlyControlHelper.CurrentYear;
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("error in EmployeeScheduleViewmodel.cs", ex);
                        await logged.LoggAPI();
                    }

                });
            }
        }
        
        public bool isAvailableFullDay

        {
            get { return isavailable; }

            set

            {
                isavailable = value;
                Debug.WriteLine("hey" + isavailable.ToString());

                OnPropertyChangedEventhander();
            }
        }
        public async void loadData()
        {
            MYschdeule2 = new ObservableCollection<EmployeeSchedule>();
            List<EmployeeSchedule> filterdatatoshow = new List<EmployeeSchedule>();
            try
            {
                BasicinformationDetails BID = new BasicinformationDetails();
                Employee = EmployeeProfileHelper.EmployeeCurrentProfile;
                //await apiSevices.GetBasicinformation(Settings.AccessToken);
                var employeeSch = Employee.EmployeeScheduels;
                var allSpecificcDates = employeeSch.Where(y => y.DayOfWeek == -1).ToList();
                tempschadual = new ObservableCollection<EmployeeSchedule>(allSpecificcDates.OrderByDescending(d => d.createdDate));
                _Listtofilter = tempschadual;
                foreach (var item in _Listtofilter)
                {
                    item.ToTimeDate = Convert.ToDateTime(item.To); 
                    item.FromTimeDate = Convert.ToDateTime(item.From); 
                }
                MYschdeule2 = new ObservableCollection<EmployeeSchedule>(tempschadual.Where(x => x.SpecificDateyear == MonthlyControlHelper.CurrentYear && x.SpecificDatmonth == MonthlyControlHelper.GetCurrentMonthNumber().ToString()).ToList());
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Employeescheduleviewmodel.cs", ex);
                await logged.LoggAPI();
            }
        }


        private EmployeeCurrentProfile employee;

        public EmployeeCurrentProfile Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChangedEventhander();
            }
        }

        public async void get()
        {
            try
            {
                BasicinformationDetails BID = new BasicinformationDetails();
                Employee = EmployeeProfileHelper.EmployeeCurrentProfile;


                var employeeSch = Employee.EmployeeScheduels;
                var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.currentDayOfWeek);
                if (sch != null)
                {
                    Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                    Timeto = DateTime.Parse(sch.To).TimeOfDay;
                    isAvailableFullDay = sch.isAvailableFullDay;
                    TotalHours = sch.TotalHour;
                }
                scheduleListOFData.Clear();
                foreach (var item in employeeSch)
                {
                    scheduleListOFData.Add(item);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in employeescheduleviewmodel", ex);
                await logged.LoggAPI();
            }
        }

        public EmployeeScheduleViewmodel()
        {
            constants.currentDayOfWeek = 1;
            get();

            Minumdatetime = DateTime.Now;
            loadData();
        }

        public ICommand putdata
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        if (From == To)
                        {
                            //await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.VaildTime, AlertMessages.OkayTitle);
                            //return;
                        }
                        if (Timefrom >= Timeto)
                        {
                            //Timefrom+=
                            //await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.VaildTime, AlertMessages.OkayTitle);
                            //return;
                        }
                        data = new EmployeeSchedule
                        {
                            From = From,
                            To = To,
                            isAvailableFullDay = isAvailableFullDay,
                            DayOfWeek = constants.currentDayOfWeek,
                            SpecificDate = DateTime.MinValue

                        };


                        for (int i = 0; i < scheduleListOFData.Count; i++)
                        {
                            if (scheduleListOFData[i].DayOfWeek == data.DayOfWeek)
                            {
                                scheduleListOFData.Remove(scheduleListOFData[i]);
                            }
                        }

                        scheduleListOFData.Add(data);


                        var succeed = await ESU.EmployeeScheduleUpdatesync(URLConfig.UpdateSchedulesurl, scheduleListOFData);
                        if (succeed)
                        {
                            BasicinformationDetails BID = new BasicinformationDetails();
                            await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);

                            Employee.EmployeeScheduels = scheduleListOFData.ToList();
                            //TODO: Added by Ashraf  to refresh the data 
                            get();
                        }

                        OnPropertyChangedEventhander();
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in employeescheduleviewmodel", ex);
                        await logged.LoggAPI();
                    }
                });
            }
        }



        public ICommand ShowMyschdule
        {
            get
            {
                return new Command(() =>
                {
                    data = new EmployeeSchedule
                    {
                        From = From,
                        To = To,
                        isAvailableFullDay = isAvailableFullDay,
                        DayOfWeek = 0,
                        SpecificDate = specific
                    };
                    MYschdeule.Add(data);
                });
            }
        }

    }
}