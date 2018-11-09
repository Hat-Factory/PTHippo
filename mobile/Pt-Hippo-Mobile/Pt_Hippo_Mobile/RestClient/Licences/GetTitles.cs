using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
    public class GetTitles : RestClient<licencetype>
    {
        public async Task<List<licencetype>> Typess(string url)
        {
            var job = await GetListOptionalId(url,null);
            return job;
        }
    }
}
