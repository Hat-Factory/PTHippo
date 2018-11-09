using System;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace Pt_Hippo_Mobile.RestClient.EmployeeScheduleRest
{
    public class UpdateSpecialdayapi : RestClient<bool>
        {

            public async Task<bool> Update(string api, string id, object data)
            {

                var Day = await PutAsync(api, id, data);
                return Day;
            }
        }
    }
