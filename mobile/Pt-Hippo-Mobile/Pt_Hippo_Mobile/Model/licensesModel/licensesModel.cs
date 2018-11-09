using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.licensesModel
{
   public class licensesModel
    {

      
        public string id { get; set; }
        public DateTime expirationDate { get; set; }
        public int type { get; set; }
        public string typeText { get; set;}
        public string licenseNumber { get; set; }
        public string college { get; set; }
        public string state { get; set; }
        public string employeeProfileId { get; set; }
        public int status { get; set; }
        public string DocumentId { get; set; }
        public string expirationDateText { get; set; }
        public string description { get; set; }
        public string originalFileName { get; set; }
        public string createdDate { get; set; }
 
    }
}
