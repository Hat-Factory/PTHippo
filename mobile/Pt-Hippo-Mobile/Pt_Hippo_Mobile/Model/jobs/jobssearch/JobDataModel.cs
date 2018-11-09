using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs
{
   public class JobDataModel : BaseViewModel
    {
        public string Id { get; set; }
        public string JobType { get; set; }
        public string employerProfileId { get; set; }

        public double? DesiredHrRate { get; set; }
        public bool HireFirstApplicant { get; set; }
        public string JobRefrence { get; set; }
        public string FacilityName { get; set; }
        public System.DateTime ExpireDate { get; set; }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value;
                OnPropertyChangedEventhander();
            }
        }


        public string facilityText { get; set; }
        public string addressDescription { get; set; }
        public string JobLocation { get; set; }
        public bool HasParking { get; set; }
        public string hasbarkingstrig { get; set; }
        public bool HasPublicTransportation { get; set; }
        public string HasPublicTransportationstring { get; set; }
        public double? Distance { get; set; }
        public double? LocationLatitude { get; set; }
        public double? LocationLongitude { get; set; }
        public string JobTypeAbbreviation { get; set; }
        //public JobApplicantStatus Status { get; set; }
        public string CreatedUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime AppliedDate { get; set; }
        public System.DateTime SavedDate { get; set; }

        public DateTime startDate { get; set; }
        public string startdatestring { get; set; }
        public string startTime { get; set; }
        public DateTime endDate { get; set; }
        public string enddatestring { get; set; }
        public string endTime { get; set; }
        public string JobId { get; set; } // JobId (length: 256)
        public string minHrRate { get; set; }
        public string maxHrRate { get; set; }

        public string jobTitle { get; set; }

        public string monthpropstart { get; set; }
        public string monthpropend { get; set; }
        public string daypropstart { get; set; }
        public string daypropend { get; set; }
        public string AmPmPropsatrt { get; set; }
        public string AmPmPropend { get; set; }
        public string hourpropsart { get; set; }
        public string hourpropend { get; set; }
        public bool isSaved { get; set; }
        public string locationAdress { get; set; }
        public string DateTimeFormated { get; set; }
    }
}
