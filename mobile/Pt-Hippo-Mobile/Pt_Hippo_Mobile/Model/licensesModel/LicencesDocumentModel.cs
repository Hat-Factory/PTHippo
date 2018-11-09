using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.licensesModel
{
  public  class LicencesDocumentModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string filePath { get; set; }
        public object employerProfileId { get; set; }
        public string employeeProfileId { get; set; }
        public int documentType { get; set; }
        public DateTime createDate { get; set; }
        public object link { get; set; }
        public bool isDocumentVerified { get; set; }
        public string employeeOrEmployerName { get; set; }
        public string FileName { get; set; }
        public string  Dateformated { get; set; }
        public string originalFileName { get; set; }
    }
}
