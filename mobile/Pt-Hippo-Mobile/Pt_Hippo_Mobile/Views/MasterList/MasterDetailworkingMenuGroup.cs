using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Views.MasterList
{
    public class MasterDetailworkingMenuGroup : List<MasterDetailworkingMenuItem>
    {
        public string Title { get; set; }
        public string ImageSource { get; set; }

        public MasterDetailworkingMenuGroup(string title)
        {
            Title = title;
        }
    }
}
