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
   public class AppliedJobsViewModel  : BaseViewModel
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
        public AppliedJobsViewModel()
        {
            Appliedcounter = JobsCounterHelper.NoOfAppliedJobsText();
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
        }




        public string Appliedcounter
        {
            get { return JobsCounterHelper.NoOfAppliedJobsText(); }
            set
            {
                JobsCounterHelper._noOfAppliedJobsText = value;
                OnPropertyChangedEventhander();
            }


        }

        private Func<bool> start()
        {
            return ()=>true;
        }

        private Func<bool> stop()
        {
            return ()=>false;
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
                        || JobListHelper.AppliedJobsModel == null
                    || JobListHelper.AppliedJobsModel.Count() == 0)
                {
                    await JobsListResolver.LoadAppliedJobs();

                }


                JobSearchBindcast = new ObservableCollection<JobDataModel>(JobListHelper.AppliedJobsModel);

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
                Appliedcounter = JobsCounterHelper.NoOFSavedJobsText();

            }


        }


    }
}

