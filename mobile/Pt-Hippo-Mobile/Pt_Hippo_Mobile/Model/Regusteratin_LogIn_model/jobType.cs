using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Model
{
    public class jobType : BaseViewModel
    {
        public string id { get; set; }
        public string title { get; set; }

         

        private string _imagesource;

        public string imagesource
        {
            get { return _imagesource; }
            set { _imagesource = value;  OnPropertyChangedEventhander();}
        }

    }
}
