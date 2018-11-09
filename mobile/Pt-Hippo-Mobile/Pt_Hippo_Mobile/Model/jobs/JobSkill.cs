using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs
{
    public class JobSkill
    {
        public string id { get; set; }
        public string skillId { get; set; }
        public string jobId { get; set; }
        public int skillCategory { get; set; }
        public object title { get; set; }
        public object jobTypeTitle { get; set; }
        public object jobTypeAbbreviation { get; set; }
        public object jobTypeDescription { get; set; }
        public string Categorytitle { get; set; }

        
    }
}
