using System;
namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class jobtimesheetmodel
    {

      
        public string Id { get; set; }

      
        public string JobId { get; set; } // JobId (length: 256)

        public string Title { get; set; }
        public string EmployerName { get; set; }
      
        public string ClockInDeviceTimeStamp { get; set; } // ClockInDeviceTimeStamp

        public string address { get; set; }
        public string ClockOutDeviceTimeStamp { get; set; } // ClockOutDeviceTimeStamp

        public System.DateTime? ClockIn { get; set; } // ClockIn
        public DateTime? ClockOut { get; set; } // ClockOut
        public double? ClockInLat { get; set; } // ClockInLat
        public double? ClockInLong { get; set; } // ClockInLong
        public double? ClockOutLat { get; set; } // ClockOutLat
        public double? ClockOutLong { get; set; } // ClockOutLong
        public string Location { get; set; }
        public string WorkDate { get; set; }
        public string Rate { get; set; }
        public string RateText { get { return "Agreed " + Rate; } }
        public string HourValue { get; set; }
        public double? TotalHours { get; set; }
        public string TotalHoursText { get { return TotalHours + " Hours"; } }

        public string Distance { get; set; }
        public string Acutal { get; set; }
        public string Schedule { get; set; }
        public string PaymentStatus { get; set; }
        public string Notes { get; set; }
        public string EmployeeName { get; set; }
        public string State { get; set; }
        public string stateText { get; set; }
        public string dateText { get; set; }
        public string PaymentStatusText { get; set; }
    }

}
