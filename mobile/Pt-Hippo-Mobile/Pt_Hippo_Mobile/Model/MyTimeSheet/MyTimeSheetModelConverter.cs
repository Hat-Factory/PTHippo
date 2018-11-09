using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.MyTimeSheet
{
  public class MyTimeSheetModelConverter
    {
        public string JobApplicantId { get; set; } // JobApplicantId (length: 256)
        public string JobId { get; set; } // JobId (length: 256)
        public string ClockIn { get; set; } // ClockIn
        public string ClockOut { get; set; } // ClockOut
        public string ClockInLat { get; set; } // ClockInLat
        public string ClockInLong { get; set; } // ClockInLong
        public string ClockOutLat { get; set; } // ClockOutLat
        public string ClockOutLong { get; set; } // ClockOutLong
    }
}
