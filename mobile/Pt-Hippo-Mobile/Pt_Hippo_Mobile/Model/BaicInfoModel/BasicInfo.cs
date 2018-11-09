using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.BaicInfoModel
{
   public class BasicInfo
    {
        public string jobTypeId { get; set; }
        public int averageRating { get; set; }
        public int ratingCount { get; set; }
        public bool isProfessionalInEnglish { get; set; }
        public string coverLetter { get; set; }
        public int yearsOfExperience { get; set; }
        public string school { get; set; }
        public bool isLegalDocumentsVerified { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public int maxTravelDistance { get; set; }
        public int minTravelDistance { get; set; }
        public double minHourRate { get; set; }
        public double maxHourRate { get; set; }
        public string zipCode { get; set; }
        public string generalSkills { get; set; }
        public string afterWorkPhone { get; set; }

        public bool? EnableHomeCareAssignment { get; set; }
    }
}
