using System;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace Pt_Hippo_Mobile.RestClient.ResumesRest
{
    public class DeleteResume: RestClient<bool>
    {
        public async Task<bool> deleteResume(string id, string url)
        {
            var job = await DeleteAsync(id, url);

            return job;
        }

    }
}