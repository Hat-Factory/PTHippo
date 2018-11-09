using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Jobs;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class jobtimeesheetviewmodel : BaseViewModel
    {


        Mytimesheetapi getapidata = new Mytimesheetapi();




        private ObservableCollection<jobtimesheetmodel> getsheet;

        public ObservableCollection<jobtimesheetmodel> Getsheet
        {
            get { return getsheet; }
            set
            {
                getsheet = value;
                OnPropertyChangedEventhander();
            }
        }
        private bool busy = false;

        public bool Isbusy
        {
            get { return busy; }
            set
            {
               

                busy = value;
                OnPropertyChangedEventhander();
            }
        }
        async public Task  getdata()
        {
           
            try
                {
              
               // LoadingIndicatorHelper.AddProgressDisplay();

                var list = await getapidata.Getlistapi(URLConfig.MyTimeSheetAPI);
                if (list != null)
                {
                    Getsheet = new ObservableCollection<jobtimesheetmodel>(list);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobtimesheetviewmodel", ex);
                await logged.LoggAPI();
            }
            

            /*
            if (IsBusy)
                return;

            LoadingIndicatorHelper.AddProgressDisplay();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    IsBusy = true;

                    try
                    {
                       
                    }
                    finally
                    {
                        IsBusy = false;
                    } 

                });

                LoadingIndicatorHelper.HideIndicator();
                return false;
            });*/

        }
        public jobtimeesheetviewmodel()
        {
            Isbusy = false;


            


        }
    }
}

