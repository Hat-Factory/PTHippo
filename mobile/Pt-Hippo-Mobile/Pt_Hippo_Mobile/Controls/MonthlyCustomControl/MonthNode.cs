using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Controls.MonthlyCustomControl
{
    public class MonthNode
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public MonthNode Next { get; set; }
        public MonthNode Previous { get; set; }

    }
}
