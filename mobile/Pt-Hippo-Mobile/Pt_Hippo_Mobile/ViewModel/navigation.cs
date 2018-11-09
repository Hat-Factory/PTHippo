using System;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class navigation
    {

		public INavigation Navigation { get; set; }
        public navigation()
        {
        }
        public navigation(INavigation nav)
		{
            this.Navigation = nav;
		}
    }
}
