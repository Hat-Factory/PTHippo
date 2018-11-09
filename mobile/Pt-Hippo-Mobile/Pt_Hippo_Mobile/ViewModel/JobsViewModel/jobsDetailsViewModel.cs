using Plugin.Geolocator;
using Pt_Hippo_Mobile.Model.jobs;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator.Abstractions;
using Pt_Hippo_Mobile.Enums;
using Plugin.RestClient;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.Helpers;
using System.Threading;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class jobsDetailsViewModel : BaseViewModel
    {

        public jobsDetailsViewModel()
        {
           
            LocationLat = new double();
            LocationLong = new double();
            DatesSelected = new ObservableCollection<JobSchedule>();
        }

        private ObservableCollection<JobSchedule> myVar;

        public ObservableCollection<JobSchedule> DatesSelected
        {
            get
            {


                return myVar;

            }
            set
            {
                myVar = value;
                OnPropertyChangedEventhander();
            }
        }

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
        private jobModel jobModel;

        public jobModel _jobModel
        {
            get
            {
                return jobModel;

            }
            set
            {
                jobModel = value;
                OnPropertyChangedEventhander();
            }
        }

        string idformethod;
        public jobsDetailsViewModel(string jobid)
        {
            //refactor if the concept workes fine 
            idformethod = jobid;
            startupMethod(idformethod);

        }



        private string location;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChangedEventhander();
            }
        }
        private string parking;

        public string Parking
        {
            get { return parking; }
            set
            {
                parking = value;
                OnPropertyChangedEventhander();
            }
        }

        private string publicTransportation;

        public string PublicTransportation
        {
            get { return publicTransportation; }
            set
            {
                publicTransportation = value;
                OnPropertyChangedEventhander();
            }
        }



        private ObservableCollection<JobSchedule> _jobscollection;

        public ObservableCollection<JobSchedule> jobscollection
        {
            get
            {
                return _jobscollection;
            }
            set
            {
                _jobscollection = value;
                OnPropertyChangedEventhander();
            }
        }

        private string SkillsString;

        public string skillsstring
        {
            get { return SkillsString; }
            set { SkillsString = value; OnPropertyChangedEventhander(); }
            
        }


        private ObservableCollection<JobSkill> _jobSkillsCollection;

        public ObservableCollection<JobSkill> jobSkillCollection
        {
            get
            {
                return _jobSkillsCollection;
            }
            set
            {
                _jobSkillsCollection = value;
                OnPropertyChangedEventhander();
            }
        }

        private string exdvar;

        public string edstring
        {
            get { return exdvar; }
            set
            {
                exdvar = value;
                OnPropertyChangedEventhander();
            }
        }

         string days,hours,minutes;
        public string Days
        {
            get { return days; }
            set { days = value;  OnPropertyChangedEventhander();}
        }
        public string Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChangedEventhander(); }
        }
        public string Minutes
        {
            get { return minutes; }
            set { minutes = value; OnPropertyChangedEventhander(); }
        }
        private DateTime CalculateExpirayText(int counter)
        {
            var newExpiryDate = jobModel.expireDate.AddMinutes(-1 * counter);
            TimeSpan ts = newExpiryDate.Subtract(DateTime.Now);
            Days = ts.Days.ToString();
            Hours = ts.Hours.ToString();
            Minutes = ts.Minutes.ToString();
            edstring = $"{ts.Days} day(s): {(int)ts.Hours} hour(s): {(int)ts.Minutes} minute(s)";
            return newExpiryDate;
        }

        public async Task startupMethod(string jobid)
        {

            JobsServices js = new JobsServices(); 
            try
            {
                jobModel jobmodels = null;

                if (string.IsNullOrEmpty(jobid) == false)
                {
                    jobmodels = await js.GeTJobDetails(URLConfig.getjobdetailsapiurl, jobid);
                }
             
                _jobModel = jobmodels;


                int counter = 0;
                if (DateTime.Now > _jobModel.expireDate)
                {
                    edstring = "Expired";
                }
                else
                {

                    var newExpiary = CalculateExpirayText(counter);
                    Device.StartTimer(TimeSpan.FromSeconds(60), () =>
                    {
                        newExpiary = CalculateExpirayText(counter);

                        if (DateTime.Now >= newExpiary)
                        {
                            return false;
                        }
                        counter++;
                        if(JobListHelper.ExpireTimerEnabled)
                        {
                            return true;
                        }

                        return false;
                    });

                }

                if (jobmodels.hasPublicTransportation == true)
                {
                    PublicTransportation = "checkmarkpng.png";
                }
                else
                {
                    PublicTransportation = "crosimage.png";
                } 
                if (jobmodels.hasParking == true)
                {
                    Parking = "checkmarkpng.png";
                }
                else
                {
                    Parking = "crosimage.png";
                }
                if (_jobModel.workAttireAvailable == true)
                {
                    jobModel.workAttireAvailablestring = "checkmarkpng.png";
                }
                else
                {
                    jobModel.workAttireAvailablestring = "crosimage.png";
                }
                if (_jobModel.labCoatAvailable == true)
                {
                    _jobModel.labCoatAvailablestring = "checkmarkpng.png";
                }
                else
                {
                    jobModel.labCoatAvailablestring = "crosimage.png";
                }
                if (_jobModel.scrubAvailable == true)
                {
                    _jobModel.scrubAvailablestring = "checkmarkpng.png";
                }
                else
                {
                    _jobModel.scrubAvailablestring = "crosimage.png";
                }


                var cassstlist = jobmodels.jobSchedules.OrderBy(c => c.from).ToList();
                ObservableCollection<JobSchedule> jobSchedulesCollection = new ObservableCollection<JobSchedule>(cassstlist);
                jobscollection = jobSchedulesCollection;
                var x = jobscollection.FirstOrDefault();
                var Y = jobscollection.LastOrDefault();
                _jobModel.fromtodateString = "“" + x.from.ToString("D") + "”" + "," + "from" + "“" + x.from.Hour.ToString() + x.from.ToString("tt ") + "”" + " to " + "“" + x.to.Hour.ToString() + x.to.ToString("tt ") + "”"; 
                     
                _jobModel.distance = _jobModel.distance + " Miles";


                foreach (var item in jobscollection)
                {
                    _jobModel.fromtostring = item.from.Hour.ToString() + " " + item.from.ToString("tt ") + " - " + item.to.Hour.ToString() + " " + item.to.ToString("tt ");
                    item.Datefromto = item.from.ToString("dddd") + " - " + item.from.Date.ToString("MM/dd/yyyy") + " - " + item.from.Hour.ToString() + item.from.ToString("tt ") + " / " + item.to.Hour.ToString() + item.to.ToString("tt ");
                }
                ObservableCollection<JobSkill> jobSkillsCollection = new ObservableCollection<JobSkill>(jobmodels.jobSkills);
                jobSkillCollection = jobSkillsCollection;

                foreach (var item in jobSkillCollection)
                {
                    if (item.skillCategory == 1)
                    {

                        item.Categorytitle = SkillCategories.Languages.ToString();
                    }
                    else if (item.skillCategory == 2)
                    {
                        item.Categorytitle = SkillCategories.ComputerSkills.ToString();
                    }
                    else if (item.skillCategory == 10)
                    {
                        item.Categorytitle = SkillCategories.Other.ToString();
                    }
                    else
                    {
                        return;
                    }

                } 
                try
                {
                    if (jobModel.locationLatitude == null || _jobModel.locationLongitude == null)
                    {
                        locationlat = 0.0;
                        locationLong = 0.0;
                    }
                    else
                    {
                        locationlat = (double)_jobModel.locationLatitude;
                        locationLong = (double)_jobModel.locationLongitude;
                    }

                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in jobdetailsviewmodel", ex);
                    await logged.LoggAPI();
                }



                //TODO : this Block of Code needs to handeld 
                //start of the Block 
                if (_jobModel.isPartialyAllowed == true)
                {
                    foreach (var item in jobscollection)
                    {
                        item.imagesource = "UNCWWBackround.png";
                    }
                }
                else if (_jobModel.isPartialyAllowed == false)
                {
                    foreach (var item in jobscollection)
                    {
                        item.imagesource = "CheckedCaroot.png";
                        DatesSelected = jobscollection;
                        var LISTCASST = DatesSelected.OrderBy(xz => xz.from);
                        ObservableCollection<JobSchedule> castlistordering = new ObservableCollection<JobSchedule>(LISTCASST);
                        DatesSelected = castlistordering;
                        var xlenght = DatesSelected.Count();
                        //int counter = 0;
                        if (DatesSelected != null)
                        {
                            foreach (var element in DatesSelected)
                            {
                                element.DayNumber = "Day" + (counter + 1).ToString();
                                counter++;
                            }
                        }
                    }
                }
                //end of the Block 



                //in case of employee already applied on job
                foreach (var item in jobscollection)
                {
                    if (item.isSelected == true)
                    {
                        item.imagesource = "CheckedCaroot.png";
                    }
                    else { item.imagesource = "UNCWWBackround.png"; }
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetialaviewmodel", ex);
                await logged.LoggAPI();
            }


            SkillsString = _jobModel.skillsText;

        }
        private double locationlat;

        public double LocationLat
        {
            get { return locationlat; }
            set
            {
                locationlat = value;
                OnPropertyChangedEventhander();
            }
        }

        private double locationLong;

        public double LocationLong
        {
            get { return locationLong; }
            set
            {
                locationLong = value;
                OnPropertyChangedEventhander();
            }
        }



    }
}
