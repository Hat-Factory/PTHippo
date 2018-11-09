using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.Model.jobs.jobssearch;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Connectivity;
using Pt_Hippo_Mobile.Resolvers;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class savedjobsViewModel : BaseViewModel
    {


        private List<JobDataModel> myVar;

        public List<JobDataModel> jobsearchList
        {
            get { return myVar; }
            set
            {
                myVar = value;
                OnPropertyChangedEventhander();
            }

        }
        private ObservableCollection<JobDataModel> jhcast;
        public ObservableCollection<JobDataModel> JobSearchBindcast
        {
            get { return jhcast; }
            set

            {
                jhcast = value;
                OnPropertyChangedEventhander();
            }
        }
        public savedjobsViewModel()
        {
            Savedcounter = JobsCounterHelper.NoOFSavedJobsText();
            jobsearchList = new List<JobDataModel>();
            JobSearchBindcast = new ObservableCollection<JobDataModel>();
            if (!CrossConnectivity.Current.IsConnected)
            {
                InternetOrServeHelper.ShowCheckInternet();
            }
            else
            {
                BindData(true);
            }
            MyProperty = new jobsearchcasted();
        }

        public jobsearchcasted MyProperty { get; set; }

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

        public string Savedcounter
        {
            get { return JobsCounterHelper.NoOFSavedJobsText(); }
            set
            {
                JobsCounterHelper._noOFSavedJobsText = value;
                OnPropertyChangedEventhander();
            }

            /*get { return JobsCounterHelper.NoOFSavedJobsText(); }
            set
            {
                JobsCounterHelper._noOFSavedJobsText = value;
                OnPropertyChangedEventhander();
            }*/
        }
        private bool IsLoadingData = false;
        public async Task BindData(bool reloadData = false)
        {
            if (IsLoadingData)
                return;


            try
            {
                IsLoadingData = true;

                if (reloadData
                        || JobListHelper.SavedJobsModel == null
                    || JobListHelper.SavedJobsModel.Count() == 0)
                {
                    JobListHelper.SavedJobsModel = new List<JobDataModel>();
                    await JobsListResolver.LoadSavedJobs();
                }
                
                JobSearchBindcast = new ObservableCollection<JobDataModel>(JobListHelper.SavedJobsModel);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in savedjobviewmodel", ex);
                await logged.LoggAPI();

            }
            finally
            {
                IsLoadingData = false;
                JobsCounterHelper.NoOFSavedJobs = JobSearchBindcast.Count();
                Savedcounter = JobsCounterHelper.NoOFSavedJobsText();

            }


        }


    }
}

