using System;
using System.Collections.ObjectModel;
using Pt_Hippo_Mobile.Model.howWork;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class howitworkViewmodel
    {

        public ObservableCollection<HowItWork> Informations { get; set; }
        public howitworkViewmodel()
        {
            Informations = new ObservableCollection<HowItWork>
            {
				new HowItWork
                {  ImageUrl = "email.png",
					Name = "page1"
                }
                ,
                new HowItWork
                {
					ImageUrl = "icon.png",
					Name = "page2"
                }
            };
        }
    }
}
