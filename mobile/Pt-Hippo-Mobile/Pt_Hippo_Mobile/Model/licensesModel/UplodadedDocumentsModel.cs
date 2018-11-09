using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.licensesModel
{
   public class UplodadedDocumentsModel
    {
        public string id { get; set; }
        
        public string filePath { get; set; }

        public string employerProfileId { get; set; }

        public int documentType { get; set; }

    }
}
