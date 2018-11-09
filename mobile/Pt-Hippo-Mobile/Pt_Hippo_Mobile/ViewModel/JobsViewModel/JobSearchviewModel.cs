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
    public class JobSearchviewModel : BaseViewModel
    {
        private string Searchtext;

        public string searchtext
        {
            get { return Searchtext; }
            set
            {
                Searchtext = value;
                OnPropertyChangedEventhander();
            }
        }



        private static DateTime? lasLoadTime = null;
        //public ICommand LoadMoreCommand
        //{
        //    get
        //    {

        //        return new Command(async () =>
        //        {
        //            if (JobListHelper.SearchJobsModel.TotalCount == JobSearchBindcast.Count)
        //            {
        //                return;
        //            }
        //            else
        //            {


        //                await JobsListResolver.LoadJobsListSearch(searchtext, ZipCode, startdate, enddate, (int)minhourvar, (int)maxhourate);
        //                try
        //                {
        //                    JobSearchBindcast = new ObservableCollection<JobDataModel>(JobListHelper.SearchJobsModel.result);

        //                }
        //                catch (Exception ex)
        //                {
        //                    var logged = new LoggedException.LoggedException("Error in jobsearchviewmodel", ex);
        //                    await logged.LoggAPI();
        //                }
        //                finally
        //                {
        //                    JobsCounterHelper.NoOfCurrentJobs = JobSearchBindcast.Count();
        //                    CurrentCounter = JobsCounterHelper.NoOfCurrentJobsText();
        //                    Applied = JobsCounterHelper.NoOfAppliedJobsText();
        //                    Saved = JobsCounterHelper.NoOFSavedJobsText();
        //                    IsLoadingData = false;

        //                }
        //            }

        //        });


        //    }
        //}
        public ICommand LoadMoreCommand
        {
            get
            {
                if (lasLoadTime == null || (DateTime.Now - lasLoadTime.Value).TotalSeconds > 2)
                {
                    return new Command(() =>
                    {
                        JobSearchBindcast = new ObservableCollection<JobDataModel>(JobListHelper.SearchJobsModel.result);
                        lasLoadTime = DateTime.Now;
                    });
                }
                return new Command(() => { });

            }
        }

        public ObservableCollection<JobDataModel> JobSearchBindcast
        {
            get { return JobListHelper.jhcast; }
            set
            {
                JobListHelper.jhcast = value;
                OnPropertyChangedEventhander();
            }
        }



        public JobSearchviewModel()
        {
            CurrentCounter = JobsCounterHelper.NoOfCurrentJobsText();

            JobSearchBindcast = new ObservableCollection<JobDataModel>();
            if (!CrossConnectivity.Current.IsConnected)
            {
                InternetOrServeHelper.ShowCheckInternet();
            }
            else
            {
                BindData();

            }

            MyProperty = new jobsearchcasted();
            minhourrate = new double();
            maxhourate = new double();
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

        private DateTime datestartvar;

        public DateTime startdate
        {
            get { return datestartvar; }
            set
            {
                datestartvar = value;
                OnPropertyChangedEventhander();
            }
        }


        private DateTime enddatevar;

        public DateTime enddate
        {
            get { return enddatevar; }
            set
            {
                enddatevar = value;
                OnPropertyChangedEventhander();
            }
        }



        private double minhourvar;

        public double minhourrate
        {
            get { return minhourvar; }
            set
            {
                minhourvar = value;
                OnPropertyChangedEventhander();
            }
        }



        private double maxvarhaour;

        public double maxhourate
        {
            get { return maxvarhaour; }
            set
            {
                maxvarhaour = value;
                OnPropertyChangedEventhander();
            }
        }
        private string zipcodevar;

        public string ZipCode
        {
            get { return zipcodevar; }
            set
            {
                zipcodevar = value;
                OnPropertyChangedEventhander();
            }
        }
        private string currentcounter;

        public string CurrentCounter
        {
            get { return currentcounter; }
            set
            {
                currentcounter = value;
                OnPropertyChangedEventhander();
            }
        }
        bool issaved;
        public bool Issaved
        {
            get { return issaved; }
            set { issaved = value; OnPropertyChangedEventhander(); }
        }

        private string addressbymiles;

        public string AddressbyMile
        {
            get { return addressbymiles; }
            set { addressbymiles = value; }
        }


        public string Saved
        {
            get { return JobsCounterHelper.NoOFSavedJobsText(); }
            set
            {
                JobsCounterHelper._noOFSavedJobsText = value;
                OnPropertyChangedEventhander();
            }
        }

        public string Applied
        {
            get { return JobsCounterHelper.NoOfAppliedJobsText(); }
            set
            {
                JobsCounterHelper._noOfAppliedJobsText = value;
                OnPropertyChangedEventhander();
            }
        }

        private bool IsLoadingData = false;

        public async Task BindData(bool reloadData = false, bool clearSerach = false)
        {
            if (clearSerach)
            {
                ZipCode = null;
                enddate = DateTime.Now;
                startdate = DateTime.Now;
                minhourrate = 0;
                maxhourate = 0;
                //JobListHelper.IsSearching = false;
            }
            if (IsLoadingData)
                return;

            //if (diff.TotalSeconds <= 2)
            //return;
            JobListHelper.LastScrollTime = DateTime.Now;


            LoadingIndicatorHelper.AddProgressDisplay();

            IsLoadingData = true;

            if (reloadData
                || JobListHelper.SearchJobsModel == null
                || JobListHelper.SearchJobsModel.result == null
                || JobListHelper.SearchJobsModel.result.Count() == 0)
            {

                await JobsListResolver.LoadJobsListSearch(searchtext, ZipCode, startdate, enddate, (int)minhourvar, (int)maxhourate);

            }

            try
            {


                JobSearchBindcast = new ObservableCollection<JobDataModel>(JobListHelper.SearchJobsModel.result);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobsearchviewmodel", ex);
                await logged.LoggAPI();
            }
            finally
            {
                JobsCounterHelper.NoOfCurrentJobs = JobSearchBindcast.Count();
                CurrentCounter = JobsCounterHelper.NoOfCurrentJobsText();
                Applied = JobsCounterHelper.NoOfAppliedJobsText();
                Saved = JobsCounterHelper.NoOFSavedJobsText();
                IsLoadingData = false;

            }


            LoadingIndicatorHelper.HideIndicator();

        }

    }
}