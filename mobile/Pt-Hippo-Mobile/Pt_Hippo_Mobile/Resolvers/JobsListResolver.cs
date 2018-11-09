using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Jobs;

namespace Pt_Hippo_Mobile.Resolvers
{
    public static class JobsListResolver
    {

        public static async Task LoadSavedJobs()
        {
            try
            {
                JobSavedRestClient js = new JobSavedRestClient();


                List<JobDataModel> newJobsList = await js.GetSavedJobs(URLConfig.SavedJobsUrl);

                newJobsList = await BindJobsData(newJobsList);

                if (newJobsList != null && newJobsList.Count > 0)
                {

                    JobListHelper.SavedJobsModel = newJobsList.OrderByDescending(d => d.SavedDate).ToList();
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to bind saved jobs models", ex);
                await logged.LoggAPI();

            }

        }

        public static async Task LoadAppliedJobs()
        {
            try
            {
                JobSavedRestClient js = new JobSavedRestClient();
                List<JobDataModel> newJobsList = await js.GetSavedJobs(URLConfig.AppliedJobsurl);
                newJobsList = await BindJobsData(newJobsList);

                if (newJobsList != null && newJobsList.Count > 0)
                {
                    foreach (var item in newJobsList)
                    {
                        if (JobListHelper.AppliedJobsModel.Any(d => d.Id == item.Id) == false)
                        {
                            JobListHelper.AppliedJobsModel.Add(item);
                        }
                    }

                    JobListHelper.AppliedJobsModel = JobListHelper.AppliedJobsModel.OrderByDescending(d => d.CreatedDate).ToList();
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to bind applied jobs models", ex);
                await logged.LoggAPI();

            }

        }

        private static async Task<List<JobDataModel>> BindJobsData(List<JobDataModel> jobsList)
        {

            if (jobsList != null && jobsList.Count > 0)
            {
                try
                {
                    foreach (var item in jobsList)
                    {

                        item.locationAdress = item.addressDescription + " / " + item.Distance + "MI";
                        item.jobTitle = item.jobTitle + " / " + item.JobRefrence;
                        //item.maxHrRate = item.maxHrRate + " / " + "Hour";
                        item.monthpropstart = item.startDate.ToString("MMM");
                        item.monthpropend = item.endDate.ToString("MMM");
                        item.daypropstart = item.startDate.Day.ToString();
                        item.daypropend = item.endDate.Day.ToString();
                        item.hourpropsart = item.startDate.Hour.ToString();
                        item.AmPmPropsatrt = item.startDate.ToString("hh:mm tt ");
                        item.AmPmPropend = item.endDate.ToString("hh:mm tt");
                        item.hourpropend = item.endDate.Hour.ToString();
                        item.startdatestring = item.daypropstart + item.monthpropstart;
                        item.enddatestring = item.daypropend + item.monthpropend;
                        item.startTime = item.AmPmPropsatrt;
                        item.endTime = item.AmPmPropend;
                        item.DateTimeFormated = item.startdatestring + " - " + item.enddatestring + ", " +
                                                item.startTime + " - " + item.endTime;
                        item.isSaved = item.isSaved;
                        if (item.isSaved)
                        {
                            item.Image = "star";

                        }
                        else
                        {
                            item.Image = "emptystar";
                        }


                        if (item.HasParking == true)
                            item.hasbarkingstrig = "No";
                        else if (item.HasParking == false)
                            item.hasbarkingstrig = "Yes";
                        if (item.HasPublicTransportation == true)
                            item.HasPublicTransportationstring = "Yes";
                        else if (item.HasPublicTransportation == false)
                            item.HasPublicTransportationstring = "No";

                        if (!string.IsNullOrEmpty(item.minHrRate) && !string.IsNullOrEmpty(item.maxHrRate))
                        {
                            double min;
                            double max;
                            int minInt;
                            int maxInt;
                            int minint = 0;
                            var x = int.TryParse(item.minHrRate, out minint);
                            if (x == false)
                            {
                                min = double.Parse(item.minHrRate);
                                max = double.Parse(item.maxHrRate);
                                var sum = min + max;
                                var mult = (sum / 2);
                                var avr = mult.ToString();
                                var AverageResult = avr;
                                item.minHrRate = AverageResult; 
                            }
                            else
                            {
                                //Then value is integer 
                                minInt = int.Parse(item.minHrRate);
                                maxInt = int.Parse(item.maxHrRate);
                                var sum = minInt + maxInt;
                                var mult = (sum / 2);
                                var avr = mult.ToString();
                                var AverageResult = avr;
                                item.minHrRate = AverageResult;
                            }
                        }



                    }



                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error while trying to bind jobs models", ex);
                    await logged.LoggAPI();
                }

            }

            return jobsList;
        }

        public static async Task LoadJobsListSearch(string searchtext, string ZipCode, DateTime startDate, DateTime endDate, double minhourrate, double maxhourate)
        {
            try
            {
                if (JobListHelper.SearchJobsModel == null)
                {
                    JobListHelper.IntialzieList();
                }


                JobSearchRestClient JobSearch = new JobSearchRestClient();
                var currentPage = JobListHelper.CurrentPage;
                var pageSize = JobListHelper.PageSize;

                if (string.IsNullOrEmpty(searchtext))
                {
                    searchtext = "null";
                }
                if (string.IsNullOrEmpty(ZipCode))
                {
                    ZipCode = "null";
                }

                if (JobListHelper.IsSearching == false)
                {
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MinValue;
                    searchtext = "null";
                    ZipCode = "null";
                    minhourrate = 0;
                    maxhourate = 0;

                    if (JobListHelper.SearchJobsModel == null || JobListHelper.SearchJobsModel.result == null || JobListHelper.SearchJobsModel.result.Count() == 0)
                    {
                        JobListHelper.CurrentPage = 1;
                    }
                    else
                    {
                        JobListHelper.CurrentPage++;
                    }

                    pageSize = JobListHelper.PageSize;
                }
                else
                {
                    JobListHelper.CurrentPage = 1;
                    currentPage = JobListHelper.CurrentPage;
                    pageSize = JobListHelper.SearchJobsModel.TotalCount;
                    //JobListHelper.FilterPageSize;
                    JobListHelper.SearchJobsModel.result = new System.Collections.Generic.List<Model.jobs.JobDataModel>();

                }


                var newJobsList = await JobSearch.GeTJobsearchDetails(URLConfig.SearchUrl, searchtext, pageSize, currentPage, ZipCode, startDate, endDate, minhourrate, maxhourate);
                //TODO: Time Out Exception
                if (newJobsList == null)
                {
                    return;
                }
                newJobsList.result = await BindJobsData(newJobsList.result);

                if (newJobsList != null && newJobsList.result.Count > 0)
                {
                    foreach (var item in newJobsList.result)
                    {
                        if (JobListHelper.SearchJobsModel.result.Any(d => d.Id == item.Id) == false)
                        {
                            JobListHelper.SearchJobsModel.result.Add(item);
                        }
                    }

                    JobsCounterHelper.NoOfCurrentJobs = newJobsList.TotalCount;
                    JobsCounterHelper.NoOFSavedJobs = newJobsList.TotalSaved;
                    JobsCounterHelper.NoOfAppliedJobs = newJobsList.TotalApplied;

                    JobListHelper.SearchJobsModel.result = JobListHelper.SearchJobsModel.result.OrderByDescending(d => d.CreatedDate).ToList();

                    JobListHelper.SearchJobsModel.TotalCount = newJobsList.TotalCount;
                }
                else
                {
                    if (JobListHelper.IsSearching)
                    {
                        JobListHelper.SearchJobsModel.result = new System.Collections.Generic.List<Model.jobs.JobDataModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to load jobs in the search screen", ex);
                await logged.LoggAPI();
            }

        }


    }
}
