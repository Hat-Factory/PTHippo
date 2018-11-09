using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Helpers
{
     public class CarouselViewHelper
      {
          public static List<string> imagenames { get; set; }
        public CarouselViewHelper()
          {
              imagenames = new List<string>();
              imagenames = new List<string>
              {
                  "i1.jpg","i2.jpg","i3.jpg","i4.jpg","i5.jpg"
              };
          }
    
          


    }
}
