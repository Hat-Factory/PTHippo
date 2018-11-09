using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.Model.RatingsModel;
namespace Pt_Hippo_Mobile.RestClient.Rating
{
    public class RatingApi:RestClient<RatingsModel>
    {
		public async Task<List<RatingsModel>> GetRatingQuestion(string apiurl,string rate)
		{
            var ratequestion = await GetListOptionalId(apiurl, rate);
			return ratequestion;
		}
    }
}
