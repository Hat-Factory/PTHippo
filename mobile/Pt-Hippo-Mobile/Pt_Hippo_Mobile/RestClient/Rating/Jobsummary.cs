using System;
using Plugin.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.Model.jobs;

namespace Pt_Hippo_Mobile.RestClient.Rating
{
	// Check is the app running for the first time
	public class Jobsummary :RestClient<JobDataModel>
    {
		public async Task<List<JobDataModel>> Getjobsummary(string apiurl)
		{
            var jobsummarys = await GetListOptionalId(apiurl,null);
			return jobsummarys;
		}
    }
}
