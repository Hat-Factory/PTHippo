using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
   public class EmployeeSchedule
    {
        string from, to;
        public string Id { get; set; }
        public string From 
        {
            get;set;
        }
        public string To 
        {
            get;set;
        }

       // public string Totalhours { get; set; }
        public DateTime createdDate { get; set; }
        public int DayOfWeek { get; set; }
        public bool isAvailableFullDay { get; set; }

        public double TotalHour { get; set; }
        public string SpecificDateFormatted
        {
            get
            {
                if (SpecificDate != null && SpecificDate != DateTime.MinValue)
                {
                   
                    return _specificDate.Value.ToString("MM-dd-yy");
                }
                return string.Empty;
            }
        }
       /* public string TotalHours
        {
            get
            {
                if (From != null && To!=null)
                {

                    return (DateTime.Parse(from).TimeOfDay - DateTime.Parse(to).TimeOfDay).ToString();
                }
                return string.Empty;
            }
        }*/
        public string SpecificDateyear
        {
            get
            {
                if (SpecificDate != null && SpecificDate != DateTime.MinValue)
                {

                    return _specificDate.Value.Year.ToString();
                }
                return string.Empty;
            }
        }
        public string SpecificDatmonth
        {
            get
            {
                if (SpecificDate != null && SpecificDate != DateTime.MinValue)
                {

                    return _specificDate.Value.Month.ToString();
                }
                return string.Empty;
            }
        }
        private DateTime? _specificDate;
        public DateTime? SpecificDate { get
            {
                return _specificDate
                ;
            } set { _specificDate = value; } }
        public string EmployeeProfileId { get; set; }



        public DateTime ToTimeDate { get; set; }
        public DateTime FromTimeDate { get; set; }
    }
}
