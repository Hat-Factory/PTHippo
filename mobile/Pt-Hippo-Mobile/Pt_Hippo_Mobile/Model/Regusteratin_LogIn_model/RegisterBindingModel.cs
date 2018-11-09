using Pt_Hippo_Mobile.Model.skillsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model
{
   public class RegisterBindingModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int userType { get; set; }
        public int minTravelDistance { get; set; }
        public int maxTravelDistance { get; set; }
        public int minHourRate { get; set; }
        public int maxHourRate { get; set; }
        public int yearsOfExperience { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public bool isMale { get; set; }
        public bool agreedOnLicense { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string jobTypeId { get; set; }
        public List<SkillsModel> employeeProfileSkills { get; set; }
    }

}
