using System;
using System.Collections.ObjectModel;
using System.Linq;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{

    public class Allspecialdays : BaseViewModel
    {
        ObservableCollection<EmployeeSchedule> MYschdeule1 = new ObservableCollection<EmployeeSchedule>();
        public ObservableCollection<EmployeeSchedule> MYschdeule2
        {
            get { return MYschdeule1; }
            set { MYschdeule1 = value; OnPropertyChangedEventhander(); }
        }
        EmployeeScheduleViewmodel obj;
        public INavigation Navigation { get; set; }
        string date, timefrom, timeto;
        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChangedEventhander(); }
        }
        public string Timefrom
        {
            get { return timefrom; }
            set { timefrom = value; OnPropertyChangedEventhander(); }
        }

        public string Timeto
        {
            get { return timeto; }
            set { timeto = value; OnPropertyChangedEventhander(); }
        }
        public bool avaialable { get; set; }
        private employeebasicinfomodel employee;

        public employeebasicinfomodel Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChangedEventhander();
            }
        }
        public Allspecialdays()
        {
            loadData();
        }
        /*   public Allspecialdays(INavigation nav)
            {
                this.Navigation = nav;
                loadData();
            }*/

        public async void loadData()
        {

            BasicinformationDetails BID = new BasicinformationDetails();
            Employee = await BID.GetCurentUserBasicinformationDetailsAsync(URLConfig.Currentuserapiurl);
            //await apiSevices.GetBasicinformation(Settings.AccessToken);

            var employeeSch = Employee.EmployeeScheduels;
            var shc1 = employeeSch.FirstOrDefault(y => y.DayOfWeek == -1);

            //uu.Clear();
            //var z = employeeSch.Find(y => y.DayOfWeek == 0);
            var data = employeeSch.Where(y => y.DayOfWeek == -1);
            Device.BeginInvokeOnMainThread(() => {
                foreach (var item in employeeSch.Where(y => y.DayOfWeek == -1).ToList())
                {
                    //uu.Add(item);
                    MYschdeule2.Add(item);
                }
            });
            constants.datas = MYschdeule2;
        }

        public async void RefreshData()
        {

            BasicinformationDetails BID = new BasicinformationDetails();
            Employee = await BID.GetCurentUserBasicinformationDetailsAsync(URLConfig.Currentuserapiurl);
            //await apiSevices.GetBasicinformation(Settings.AccessToken);

            var employeeSch = Employee.EmployeeScheduels;
            var shc1 = employeeSch.Where(y => y.DayOfWeek == -1);
            ObservableCollection<EmployeeSchedule> castlist = new ObservableCollection<EmployeeSchedule>(shc1);
            MYschdeule2 = castlist;
        }
    }
}

