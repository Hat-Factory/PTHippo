using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.skillsModel
{
    public class SkillsModel
    {
        public string skillId;
        public string Imaage { get; set; }
        public string id { get { return skillId; } set { skillId = value; } }
        public string skillCategoryId { get; set; }
        public string skillCategoryTitle { get; set; }
        public string jobTypeId { get; set; }
        public string title { get; set; }
        public string skillCategory { get; set; }
        public string skillTitle
        {
            get { return title; }
            set { title = value; }
        }
    }
}
