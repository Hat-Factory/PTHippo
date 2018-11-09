using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Model.jobs
{
    public class JobSchedule : BaseViewModel
    {
        public string id { get; set; }
        //public DateTime from { get; set; }
        private DateTime _from;

        public DateTime from
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChangedEventhander();
            }
        }

        //public DateTime to { get; set; }
        private DateTime _to;

        public DateTime to
        {
            get { return _to; }
            set { _to = value; OnPropertyChangedEventhander();}
        }

        public string jobId { get; set; }
        public bool isPratiallyApplied { get; set; }
        
        private string _daynumber;

        public string DayNumber
        {
            get { return _daynumber; }
            set { _daynumber = value; OnPropertyChangedEventhander(); }
        }

        //public string Datefromto { get; set; }
        private string _Datefromto;

        public string Datefromto
        {
            get { return _Datefromto; }
            set { _Datefromto = value; OnPropertyChangedEventhander();}
        }

        //public string imagesource { get; set; }

        private string _imagesource;

        public string imagesource
        {
            get { return _imagesource; }
            set { _imagesource = value; OnPropertyChangedEventhander(); }
        }

        public string jobScheduleId { get {return id; } }
        public bool isSelected { get; set; }



    }
}
