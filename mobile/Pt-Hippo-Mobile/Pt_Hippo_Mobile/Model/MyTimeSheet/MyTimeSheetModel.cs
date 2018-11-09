using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.MyTimeSheet
{
  public class MyTimeSheetModel
    {
        public string JobApplicantId { get; set; } // JobApplicantId (length: 256)
        public string JobId { get; set; } // JobId (length: 256)

        public System.DateTime? ClockIn { get; set; } // ClockIn
        public System.DateTime? ClockOut { get; set; } // ClockOut
        public double? ClockInLat { get; set; } // ClockInLat
        public double? ClockInLong { get; set; } // ClockInLong
        public double? ClockOutLat { get; set; } // ClockOutLat
        public double? ClockOutLong { get; set; } // ClockOutLong
    }
}
