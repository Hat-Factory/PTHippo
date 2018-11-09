using System;
using System.Collections.Generic;
using System.Windows.Input;
using Plugin.Connectivity;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Rating;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Model.RatingsModel;
using Pt_Hippo_Mobile.Views.MasterList;
using Pt_Hippo_Mobile.Model.jobs;
using Pt_Hippo_Mobile.Views;
using System.Linq;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class RatingViewModel : BaseViewModel
    {
        public INavigation Naviagation { get; set; }


        RatingApi apirate = new RatingApi();
        PostRating postrate = new PostRating();
        Jobsummary summaryapi = new Jobsummary();


        string id;
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChangedEventhander(); }
        }

        string jobtitle;
        public string Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; OnPropertyChangedEventhander(); }
        }
        string jobtype;
        public string Jobtype
        {
            get { return jobtype; }
            set { jobtype = value; OnPropertyChangedEventhander(); }
        }
        string datetime;
        public string Date
        {
            get { return datetime; }
            set { datetime = value; OnPropertyChangedEventhander(); }
        }
        string minhrrate;
        public string MinRate
        {
            get { return minhrrate; }
            set { minhrrate = value; OnPropertyChangedEventhander(); }
        }
        string location;
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChangedEventhander(); }
        }
        string hasbarking;
        public string Hasparking
        {
            get { return hasbarking; }
            set { hasbarking = value; OnPropertyChangedEventhander(); }
        }
        string haspublictransportion;
        public string Haspublictrasnportion
        {
            get { return haspublictransportion; }
            set { haspublictransportion = value; OnPropertyChangedEventhander(); }
        }


        public string JobApplicantId { get; set; }
        public Rater Rater { get; set; }
        string comments;
        public string Comment
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChangedEventhander();
            }
        }
        List<JobDataModel> DataBind;
        List<JobDataModel> summarys;
        public List<JobDataModel> Summarys
        {
            get { return summarys; }
            set { summarys = value; OnPropertyChangedEventhander(); }
        }
        // public string Question { get; set; }

        private List<RatingsModel> rating;

        public List<RatingsModel> Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChangedEventhander();
            }
        }
        JobDataModel summarybind;
        public JobDataModel Summarybind
        {
            get { return summarybind; }
            set { summarybind = value; OnPropertyChangedEventhander(); }
        }

        private string label2;

        public string Label2
        {
            get { return label2; }
            set
            {
                label2 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string label1;

        public string Label1
        {
            get { return label1; }
            set
            {
                label1 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string label3;

        public string Label3
        {
            get { return label3; }
            set
            {
                label3 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string label4;

        public string Label4
        {
            get { return label4; }
            set
            {
                label4 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string label5;

        public string Label5
        {
            get { return label5; }
            set
            {
                label5 = value;
                OnPropertyChangedEventhander();
            }
        }

        private string label6;

        public string Label6
        {
            get { return label6; }
            set
            {
                label6 = value;
                OnPropertyChangedEventhander();
            }
        }

        private string id1;

        public string ID1
        {
            get { return id1; }
            set
            {
                id1 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string id2;

        public string ID2
        {
            get { return id2; }
            set
            {
                id2 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string id3;

        public string ID3
        {
            get { return id3; }
            set
            {
                id3 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string id4;

        public string ID4
        {
            get { return id4; }
            set
            {
                id4 = value;
                OnPropertyChangedEventhander();
            }
        }
        private string id5;

        public string ID5
        {
            get { return id5; }
            set
            {
                id5 = value;
                OnPropertyChangedEventhander();
            }
        }

        private string id6;

        public string ID6
        {
            get { return id6; }
            set
            {
                id6 = value;
                OnPropertyChangedEventhander();
            }
        }

        public async void RatingData()
        {
            try
            {
        

                //ma7taga job apllicantid sha8al
                Summarys = await summaryapi.Getjobsummary(URLConfig.Getjobsummary);
                if (Summarys == null || Summarys.Count == 0)
                {
                    return;
                }
                else
                {
                    Summarybind = Summarys.FirstOrDefault();
                    DataBind = new List<JobDataModel>();
                    DataBind.Add(Summarybind);
                    foreach (var item in DataBind)
                    {
                        Location = item.addressDescription + " / " + item.Distance + "MI";
                        Jobtitle = item.jobTitle + " / " + item.JobRefrence;
                        item.AmPmPropsatrt = item.startDate.ToString("hh:mm tt ");
                        item.AmPmPropend = item.endDate.ToString("hh:mm tt");
                        item.hourpropend = item.endDate.Hour.ToString();
                        item.startdatestring = item.daypropstart + item.monthpropstart;
                        item.enddatestring = item.daypropend + item.monthpropend;
                        item.startTime = item.AmPmPropsatrt;
                        item.endTime = item.AmPmPropend;
                        item.monthpropstart = item.startDate.ToString("MMM");
                        item.monthpropend = item.endDate.ToString("MMM");
                        item.daypropstart = item.startDate.Day.ToString();
                        item.daypropend = item.endDate.Day.ToString();
                        item.hourpropsart = item.startDate.Hour.ToString();
                        Jobtype = item.JobType;
                        Date = item.startdatestring + " - " + item.enddatestring + ", " + item.startTime + " - " + item.endTime;
                        Id = item.JobId;
                        JobApplicantId = item.Id;
                        MinRate = item.minHrRate;
                        if (item.HasParking == true)
                            Hasparking = "No";
                        else if (item.HasParking == false)
                            Hasparking = "Yes";
                        if (item.HasPublicTransportation == true)
                            Haspublictrasnportion = "Yes";
                        else if (item.HasPublicTransportation == false)
                            Haspublictrasnportion = "No";

                    }

                }

                int ratingemployee = Convert.ToInt32(Rater.Employee);
               
                var emptorateid = Summarys.FirstOrDefault().employerProfileId;
                Rating = await apirate.GetRatingQuestion(URLConfig.GetRatingQuestion, emptorateid);

                Label1 = Rating.Where(x => x.id == "1").FirstOrDefault().question;
                ID1 = Rating.Where(x => x.id == "1").FirstOrDefault().id;
                Label2 = Rating.Where(x => x.id == "2").FirstOrDefault().question;
                ID2 = Rating.Where(x => x.id == "2").FirstOrDefault().id;
                Label3 = Rating.Where(x => x.id == "3").FirstOrDefault().question;
                ID3 = Rating.Where(x => x.id == "3").FirstOrDefault().id;
                Label4 = Rating.Where(x => x.id == "4").FirstOrDefault().question;
                ID4 = Rating.Where(x => x.id == "4").FirstOrDefault().id;
                Label5 = Rating.Where(x => x.id == "5").FirstOrDefault().question;
                ID5 = Rating.Where(x => x.id == "5").FirstOrDefault().id;
                Label6 = Rating.Where(x => x.id == "11").FirstOrDefault().question;
                ID6 = Rating.Where(x => x.id == "11").FirstOrDefault().id;

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in ratingviewmodel", ex);
                await logged.LoggAPI();
            }
        }

        public RatingViewModel(INavigation nav)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                isenabel = true;
                RatingData();
                this.Naviagation = nav;
            }
            else
            {
                InternetOrServeHelper.ShowCheckInternet();
            }

        }
        public RatingViewModel()
        {

        }
        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
        }


        public ICommand submitcommand
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        isenabel = false;
                        RatingModelanswers rates = new RatingModelanswers
                        {
                            JobApplicantId = JobApplicantId,
                            Comment = Comment,
                            Rater = Rater.Employee,
                            RatingAnswers = constants.mysubmits


                        };
                        var succeed = await postrate.postquestion(URLConfig.Postanswers, rates);
                        if (succeed)
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                            RatingData();
                            var page = new Rate();
                            NavigationPage.SetHasNavigationBar(page, false);
                            await Naviagation.PushAsync(page);
                        }
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in ratingviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }
                });
            }
        }
    }
}