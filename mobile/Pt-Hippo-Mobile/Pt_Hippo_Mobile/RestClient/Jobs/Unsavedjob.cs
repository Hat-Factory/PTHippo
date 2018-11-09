using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Jobs
{
    class Unsavedjob : RestClient<bool>
    {
        public async Task<bool> deleteData(string id, string url)
        {
            var deleted = await DeleteAsync(id, url);

            return deleted;
        }
    }
    }
