using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model
{
   public class BankAccount
    {
        public string bankName { get; set; }
        public long accountNumber { get; set; }
        public string routingNumber { get; set; }
        public string employeeProfileId { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }

    }
}
