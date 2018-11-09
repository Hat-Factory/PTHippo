using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using Pt_Hippo_Mobile.Services;
using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeSchdule : TabbedPage
    {
        public static int y;
        private ApiServices apiSevices = new ApiServices();
        public List<EmployeeSchedule> scheduleListOFData = new List<EmployeeSchedule>();
        private ObservableCollection<EmployeeSchedule> uu = new ObservableCollection<EmployeeSchedule>();

        public EmployeeSchdule()
        {
            InitializeComponent();

            this.CurrentPageChanged += EmployeeSchdule_CurrentPageChanged;

            //this.Disappearing += EmployeeSchdule_Disappearing;
            constants.x = this.Children.IndexOf(this.CurrentPage) + 1;
            Debug.WriteLine("Page No:" + constants.x);

            Debug.WriteLine("test" + y);

        
        }

        //when page ta5atafe
        public async Task apiput()
        {
            await apiSevices.PutEmployeeSchedule(scheduleListOFData, Settings.AccessToken);
        }

        private void EmployeeSchdule_CurrentPageChanged(object sender, EventArgs e)
        {
            ((EmployeeScheduleViewmodel)this.BindingContext).Method();
            // apiget();
            scheduleListOFData.Clear();
            constants.x = 0;
            var i = this.Children.IndexOf(this.CurrentPage);
            constants.x = i + 1;

            var employeeSch = ((EmployeeScheduleViewmodel)this.BindingContext).Employee.EmployeeScheduels;

            var shc1 = employeeSch.FirstOrDefault(y => y.DayOfWeek == 0);

            uu.Clear();
            //var z = employeeSch.Find(y => y.DayOfWeek == 0);
            var data = employeeSch.Where(y => y.DayOfWeek == 0);
            foreach (var item in employeeSch.Where(y => y.DayOfWeek == 0).ToList())
            {
                uu.Add(item);
            }

            var sch = employeeSch.FirstOrDefault(d => d.DayOfWeek == constants.x);
            if (sch != null)
            {
                ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(sch.From).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(sch.To).TimeOfDay;
                ((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                //((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = sch.isAvailableFullDay;
                // OnPropertyChangedEventhander();
            }
            else if (constants.x == 8)
            {
                if (shc1 != null)
                {
                    ((EmployeeScheduleViewmodel)this.BindingContext).Timefrom = DateTime.Parse(shc1.From).TimeOfDay;
                    ((EmployeeScheduleViewmodel)this.BindingContext).Timeto = DateTime.Parse(shc1.To).TimeOfDay;
                    ((EmployeeScheduleViewmodel)this.BindingContext).isAvailableFullDay = shc1.isAvailableFullDay;

                    ((EmployeeScheduleViewmodel)this.BindingContext).specific = shc1.SpecificDate ?? DateTime.Today;

                    ((EmployeeScheduleViewmodel)this.BindingContext).data = new EmployeeSchedule
                    {
                        From = shc1.From,
                        To = shc1.To,
                        SpecificDate = shc1.SpecificDate,
                        Id = shc1.Id
                    };

                    foreach (var item in uu)
                    {
                        ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule.Add(item);
                    }
                    myss.ItemsSource = ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule;
                    // myss.IsRefreshing = true;
                }
            }

            scheduleListOFData.AddRange(employeeSch.ToList());

            System.Diagnostics.Debug.WriteLine("Page No:" + constants.x);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            deleteLicences deletebutton = new deleteLicences();

            
            var item = (Xamarin.Forms.Button)sender;

            var succeed = await deletebutton.deleteData(item.CommandParameter.ToString(), URLConfig.DeleteSchdeualurl);
            if (succeed)
            {
                var deletedItem = ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule.FirstOrDefault(d => d.Id == item.CommandParameter.ToString());
                ((EmployeeScheduleViewmodel)this.BindingContext).MYschdeule.Remove(deletedItem);
                Toast.LongMessage("Deleted succesfully");
            }
            else
            {
                Toast.LongMessage(constants.Message);
            }
            //  uu.Remove()
        }
    }
}