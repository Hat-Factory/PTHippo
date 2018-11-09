using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Views.MasterList;

namespace Pt_Hippo_Mobile.Views.MasterList
{

    public class MasterDetailworkingMenuItem
    {
        public MasterDetailworkingMenuItem()
        {
            TargetType = typeof(MasterDetailworkingDetail);
        }
        public string Title { get; set; }
        public string image { get; set; }
       
        public Type TargetType { get; set; }
    }
}