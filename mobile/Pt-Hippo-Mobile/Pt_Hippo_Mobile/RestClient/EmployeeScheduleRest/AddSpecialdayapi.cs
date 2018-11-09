using System;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace Pt_Hippo_Mobile.RestClient.EmployeeScheduleRest
{
    public class AddSpecialdayapi : RestClient<bool>
    {
        public async Task<bool> AddSpecialsDays(string api, object data)
        {

            var add = await PostApi(api, data);
            return add;
        }
    }
}
