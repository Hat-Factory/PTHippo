using Pt_Hippo_Mobile.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.Model.skillsModel;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public  class EmployeeCurrentProfile
    {
        public string id { get; set; }
        public string JobTypeId { get; set; }
        public string jobTypeTitle { get; set; }
        public double? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        public bool IsProfessionalInEnglish { get; set; }
        public string CoverLetter { get; set; }    
        public int YearsOfExperience { get; set; }
        public string School { get; set; }
        public bool IsLegalDocumentsVerified { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double MaxTravelDistance { get; set; }
        public double MinTravelDistance { get; set; }
        public double MinHourRate { get; set; }
        public double MaxHourRate { get; set; }
        public string ZipCode { get; set; } // ZipCode (length: 10)
       public ProfileStatus Status { get; set; }
        public string GeneralSkills { get; set; }
        public string AfterWorkPhone { get; set; }

        public EmployeeBasicInfo User { get; set; }
        //why it should be list ?
        public BankAccount BankAccount { get; set; }
        public  List<EmployeeSchedule> EmployeeScheduels { get; set; }
        public  List<SkillsModel> EmployeeSkills { get; set; }
        public List<licensesModel.licensesModel> Licenses { get; set; }
        public  List<Resume> Resumes { get; set; }
        public List<UplodadedDocumentsModel> documents { get; set; }
        public bool EnableHomeCareAssignment { get; set; }

        public bool EnableJobBroadcasting { get; set; }
        public bool? isBackgroundChecked { get; set; }
        public int IndexSelected { get; set; }

        public bool isStripeProfileCompelete { get; set; }
    }

}
