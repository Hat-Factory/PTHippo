using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model
{
   public class EmployeeCurrentData
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool  isMale { get; set; }
        public string profilePicture { get; set; }
        public bool isVerified { get; set; }
        public bool agreedOnLicense { get; set; }
        public bool isFirstLogin { get; set; }
        public DateTime? birthDate { get; set; }
        public string zipCode { get; set; }
        public bool isStripeProfileCompelete { get; set; }


        
    }
}
