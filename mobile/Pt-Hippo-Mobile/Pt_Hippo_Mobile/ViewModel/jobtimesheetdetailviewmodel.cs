using System;
using System.Collections.ObjectModel;
using Plugin.Geolocator.Abstractions;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class jobtimesheetdetailviewmodel : BaseViewModel
    {
        public jobtimesheetdetailviewmodel()
        {
            binddata();
        }
        string loc, rate, hourvalue, distance, actualhour, schedulehour, notes, payment, date, employername, title, totalhour;
        ObservableCollection<jobtimesheetmodel> jobtimelist = new ObservableCollection<jobtimesheetmodel>();

        public string Location
        {
            get { return loc; }
            set { loc = value; OnPropertyChangedEventhander(); }
        }
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChangedEventhander(); }
        }
        public string WorkDate
        {
            get { return date; }
            set { date = value; OnPropertyChangedEventhander(); }
        }
        public string Rate
        {
            get { return rate; }
            set { rate = value; OnPropertyChangedEventhander(); }
        }
        public string HourValue
        {
            get { return hourvalue; }
            set { hourvalue = value; OnPropertyChangedEventhander(); }
        }
        public string TotalHours
        {
            get { return totalhour; }
            set { totalhour = value; OnPropertyChangedEventhander(); }
        }
        public string Distance
        {
            get { return distance; }
            set { distance = value; OnPropertyChangedEventhander(); }
        }
        public string Acutal
        {
            get { return actualhour; }
            set { actualhour = value; OnPropertyChangedEventhander(); }
        }
        public string Schedule
        {
            get { return schedulehour; }
            set { schedulehour = value; OnPropertyChangedEventhander(); }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChangedEventhander(); }
        }
        public string Paymentstatus
        {
            get { return payment; }
            set { payment = value; OnPropertyChangedEventhander(); }
        }
        public string Employername
        {
            get { return employername; }
            set { employername = value; OnPropertyChangedEventhander(); }
        }
        private string _address;

        public string _Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChangedEventhander(); }
        }




        public void binddata()
        {
            try
            {
                foreach (var item in constants.jobtime)
                {
                    _Address = item.address;
                    Title = item.Title;
                    Location = item.Location;
                    Acutal = item.Acutal;
                    Schedule = item.Schedule;
                    WorkDate = item.WorkDate;
                    Rate = item.Rate;
                    Distance = item.Distance;
                    HourValue = item.HourValue;
                    TotalHours = item.TotalHours.ToString();
                    Notes = item.Notes;
                    Employername = item.EmployerName;
                    Paymentstatus = item.PaymentStatus;
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in binddata in job time sheet details view model", ex);
                logged.LoggAPI();
            }

        }



    }
}
