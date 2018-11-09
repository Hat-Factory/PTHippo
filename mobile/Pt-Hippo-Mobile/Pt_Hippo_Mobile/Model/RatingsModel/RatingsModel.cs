using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Model.RatingsModel
{
   public class RatingsModel : BaseViewModel
    {
        public string id { get; set; }
        public string question { get; set; }
        public int rater { get; set; }
        public int answerType { get; set; }
    }

}
