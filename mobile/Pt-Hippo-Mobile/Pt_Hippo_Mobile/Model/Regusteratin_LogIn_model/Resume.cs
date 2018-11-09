using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
   public class Resume
    {
        public string id { get; set; }
        public string workLocation { get; set; }
        public string @as { get; set; }
        public string doing { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startEndDatesText { get; set; }
        public string employeeProfileId { get; set; }
        public bool isCurrentWork { get; set; }
        public string originalFileName { get; set; }
        public string documentId { get; set; }
        public string createdDate { get; set; }
    }
}
