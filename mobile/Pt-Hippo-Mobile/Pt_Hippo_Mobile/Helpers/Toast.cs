using Pt_Hippo_Mobile.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Helpers
{
    class Toast
    {
        public Toast()
        {

        }
        public static void ShortMessage(string message)
        {
            DependencyService.Get<IMessage>().ShortAlert(message);

        }
        public static void LongMessage(string message)
        {
            DependencyService.Get<IMessage>().LongAlert(message);
        }
    }
}
