using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class Licences
    {
        public string licenseId { get; set; }
        public string id { get; set; }
        public string expirationDate { get; set; }
        public int type { get; set; }
        public string licenseNumber { get; set; }
        public string college { get; set; }
        public string employeeProfileId { get; set; }
        public int status { get; set; }
        public string documentId
        {
            get; set;
        }
    }
}
