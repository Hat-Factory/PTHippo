using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class Checkin_Checkout
    {
        public string JobApplicantId { get; set; } // JobApplicantId (length: 256)
        public System.DateTime? ClockIn { get; set; } // ClockIn
        public System.DateTime? ClockOut { get; set; } // ClockOut
        public double? Payment { get; set; } // Payment
        public double? ApprovedHrs { get; set; } // ApprovedHrs
        DateTime ApprovalTime { get; set; } // ApprovalTime
        public double? ClockInLat { get; set; } // ClockInLat
        public double? ClockInLong { get; set; } // ClockInLong
        public double? ClockOutLat { get; set; } // ClockOutLat
        public double? ClockOutLong { get; set; } // ClockOutLong
        public double? UnApprovedHrs { get; set; } // UnApprovedHrs
        public string JobScheduleId { get; set; } //JobScheduleId
        public string JobId { get; set; }
        public string clockInDeviceTimeStamp { get; set; }

        public string clockOutDeviceTimeStamp { get; set; }
    }
}
