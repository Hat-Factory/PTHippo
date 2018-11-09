using System;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
    public class licencetype : BaseViewModel
    {
        public string id { get; set; }
        public string title { get; set; }

        private string _imagesource;

        public string imagesource
        {
            get { return _imagesource; }
            set { _imagesource = value; OnPropertyChangedEventhander(); }
        }

    }
}
