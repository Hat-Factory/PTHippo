using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class ImageinfoModel
    {
        public string id { get; set; }
        public string originalFileName { get; set; }
        public object fileTitle { get; set; }
        public object createdById { get; set; }
        public DateTime uploadTime { get; set; }
        public string path { get; set; }
    }
}
