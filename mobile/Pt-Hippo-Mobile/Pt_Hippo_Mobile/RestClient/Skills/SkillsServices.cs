using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.skillsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient
{
   public class SkillsServices : RestClient<SkillsModel>
    {
        public async Task<List<SkillsModel>> GeTskillDetails(string apiurl)
        {
            var job = await GetListOptionalId(apiurl, null, false);      
            return job;
        }

        public async Task<bool> PutskillsListAsync(List<SkillsModel> _updateSkills, string api)
        {
            var updatedskills = await PutListAsync(_updateSkills, api);
            return updatedskills;
        }
    }
}
