using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pt_Hippo_Mobile.Controls.MonthlyCustomControl;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.EmployeeScheduleRest;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.Abstractions;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class timedetailviewmodel : BaseViewModel
    {
        TimeSpan timefrom, timeto;
        /*EmployeeScheduleUpdate ESU = new EmployeeScheduleUpdate();
       */
        UpdateSpecialdayapi updates = new UpdateSpecialdayapi();
        AddSpecialdayapi add = new AddSpecialdayapi();
        ObservableCollection<EmployeeSchedule> reciveddata = new ObservableCollection<EmployeeSchedule>();
        string from, to, id;
        int dayno;
        private DateTime dfrom, dto, date;

        public EmployeeSchedule data;
        //   public INavigation naviagtion { get; set; }
        bool isavilabale;

        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChangedEventhander(); }
        }
        public int Dayno
        {
            get { return dayno; }
            set { dayno = value; OnPropertyChangedEventhander(); }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChangedEventhander(); }
        }
        public TimeSpan Timefrom
        {
            get { return timefrom; }
            set
            {
                timefrom = value;

                dfrom = Convert.ToDateTime(timefrom.ToString());

                from = dfrom.ToString("hh:mm tt");

                OnPropertyChangedEventhander();
            }
        }
        public INavigation Navigation { get; set; }
        public TimeSpan Timeto
        {
            get { return timeto; }
            set
            {
                timeto = value;
                dto = Convert.ToDateTime(timeto.ToString());

                to = dto.ToString("hh:mm tt");


                OnPropertyChangedEventhander();
            }
        }

        public bool avaialable
        {
            get { return isavilabale; }
            set { isavilabale = value; OnPropertyChangedEventhander(); }

        }

        public timedetailviewmodel()
        {
            // loadData();
        }
        public timedetailviewmodel(INavigation nav)
        {
            this.Navigation = nav;
            //get();
            isenabel = true;
            loadData();
            currenttemp = MonthlyControlHelper.current;
            //currenttemp = MonthlyControlHelper.current;
            //currenttemp.Month = Convert.ToDateTime(data.SpecificDate).ToString("MMMM");
            //currenttemp.Year = Convert.ToDateTime(data.SpecificDate).Year.ToString();
            //MonthlyControlHelper.head = currenttemp;
            //MonthlyControlHelper.forceReload = true;
            //get();
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
        public async void loadData()
        {
            try
            {
                reciveddata = constants.senddata; // de feha 8alat
                foreach (var item in reciveddata)
                {
                    Id = item.Id;
                    Date = item.SpecificDate ?? DateTime.Today;
                    Timeto = DateTime.Parse(item.To).TimeOfDay;
                    Timefrom = DateTime.Parse(item.From).TimeOfDay;
                    avaialable = item.isAvailableFullDay;
                    Dayno = item.DayOfWeek;
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in timedetailviewmodel", ex);
                await logged.LoggAPI();
            }
        }

        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
        }

        public List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            startDate = Convert.ToDateTime(startDate.ToString("t"));
            endDate = Convert.ToDateTime(endDate.ToString("t"));

            var allDates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddMinutes(1))
            {
                allDates.Add(date);
            }

            return allDates;
        }
        public static MonthNode currenttemp;
        //public static MonthNode currentyeartemp;

        public ICommand adddays
        {

            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        currenttemp = MonthlyControlHelper.current;
                        
                        isenabel = false;
                        bool isvalid = true;
                        if (isvalid && string.IsNullOrEmpty(from))
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.TimeFrom, AlertMessages.OkayTitle);
                            isvalid = false;
                            return;
                        }
                        if (isvalid && string.IsNullOrEmpty(to))
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Timeto, AlertMessages.OkayTitle);
                            isvalid = false;
                            return;
                        }
                        if (Timefrom >= Timeto)
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.VaildTime, AlertMessages.OkayTitle);
                            return;
                        }
                        if (Id == null)
                        {


                            data = new EmployeeSchedule
                            {
                                Id = Id,
                                From = from,
                                To = to,
                                isAvailableFullDay = avaialable,
                                DayOfWeek = -1,
                                SpecificDate = Date,
                            };

                            DateTime now = DateTime.Now;
                             

                            foreach (var item in EmployeeScheduleViewmodel._Listtofilter)
                            {
                                if (Convert.ToDateTime(data.SpecificDate).ToString("d") == Convert.ToDateTime(item.SpecificDate).ToString("d") && item.DayOfWeek == -1)
                                {
                                    var Datesbetween = GetDatesBetween(Convert.ToDateTime(item.From), Convert.ToDateTime(item.To));
                                    DateTime minDate = Datesbetween.Min();
                                    DateTime maxDate = Datesbetween.Max();
                                    bool case1, case2, case3;
                                    string text = "";
                                    if ((Convert.ToDateTime(data.From) > minDate && Convert.ToDateTime(data.From) < maxDate))
                                    {
                                        case1 = true;
                                        text = "From is greter than min date and less than the max so it is inbetween to dates already exists ";
                                    }
                                    else
                                    {
                                        case1 = false;
                                    }
                                    if ((Convert.ToDateTime(data.To) > minDate && Convert.ToDateTime(data.To) <= maxDate))
                                    {
                                        case2 = true;
                                        text = "TO is greater than the minimum date and less than or equel the max date ";
                                    }
                                    else
                                    {
                                        case2 = false;
                                    }
                                    if ((Convert.ToDateTime(data.From) < minDate && Convert.ToDateTime(data.To) > maxDate))
                                    {
                                        case3 = true;
                                        text = "from is less than the minimum date and to greater than the max date ";
                                    }
                                    else
                                    {
                                        case3 = false;
                                    }
                                   
                                    if (case1 || case2 || case3)
                                    {
                                        await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, text + " " + "one of these values Already Exists ", AlertMessages.OkayTitle);
                                        currenttemp = null;
                                        MonthlyControlHelper.forceReload = false;
                                        return;
                                    }
                                }
                            }
                            var succeed = await add.AddSpecialsDays(URLConfig.AddSpecialDay, data);
                            if (succeed)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                                MonthlyControlHelper.forceReload = true;
                                MonthlyControlHelper.ReloadAPIData();
                                //Convert.ToDateTime(data.SpecificDate).ToString()
                                //var year = DateTime.ParseExact(, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month
                                //Convert.ToDateTime(data.SpecificDate).ToString("MMM ddd d HH:mm yyyy");]\
                                if (currenttemp !=null)
                                {
                                    currenttemp.Month = Convert.ToDateTime(data.SpecificDate).ToString("MMMM");
                                    currenttemp.Year = Convert.ToDateTime(data.SpecificDate).Year.ToString();
                                    MonthlyControlHelper.head = currenttemp; 
                                }
                                await Navigation.PopAsync();
                            }

                        }

                        else
                        {

                            isenabel = false;

                            data = new EmployeeSchedule
                            {
                                Id = Id,
                                From = from,
                                To = to,
                                isAvailableFullDay = avaialable,
                                DayOfWeek = Dayno,
                                SpecificDate = Date,
                            };
                             
                            var Datesbetween = GetDatesBetween(Convert.ToDateTime(data.From), Convert.ToDateTime(data.To));
                            DateTime minDate = Datesbetween.Min();
                            DateTime maxDate = Datesbetween.Max();
                             
                            if ((Convert.ToDateTime(data.From) >= minDate && Convert.ToDateTime(data.To) <= maxDate))
                            {
                                var succeed = await updates.Update(URLConfig.Putspecialdayupdate, Id, data);
                                if (succeed)
                                {
                                    await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                    await App.Current.MainPage.DisplayAlert("", AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                                    MonthlyControlHelper.forceReload = true;
                                    MonthlyControlHelper.ReloadAPIData();
                                    currenttemp.Month = Convert.ToDateTime(data.SpecificDate).ToString("MMMM");
                                    currenttemp.Year = Convert.ToDateTime(data.SpecificDate).Year.ToString();
                                    MonthlyControlHelper.head = currenttemp;
                                    await Navigation.PopAsync();
                                } 
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "one of these values Already Exists ", AlertMessages.OkayTitle);
                                return;
                            } 
                        }
                        OnPropertyChangedEventhander();
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in timedetailviewmodel", ex);
                        await logged.LoggAPI();
                    }

                    finally
                    {
                        isenabel = true;
                    }
                });
            }
        }
        public ICommand updatesheet
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        data = new EmployeeSchedule
                        {
                            Id = Id,
                            From = from,
                            To = to,
                            isAvailableFullDay = avaialable,
                            DayOfWeek = Dayno,
                            SpecificDate = Date,


                        };
                        var succeed = await updates.Update(URLConfig.Putspecialdayupdate, Id, data);
                        if (succeed)
                        {
                            await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                            await App.Current.MainPage.DisplayAlert("", AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                        }

                        OnPropertyChangedEventhander();
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in timedetailviewmodel", ex);
                        await logged.LoggAPI();
                    }

                });

            }
        }
    }
}
