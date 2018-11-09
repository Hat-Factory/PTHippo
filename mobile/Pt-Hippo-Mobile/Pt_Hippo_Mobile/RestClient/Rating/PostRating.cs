using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.Rating
{
    public class PostRating:RestClient<RatingModelanswers>
    {
		public async Task<bool> postquestion(string api, object data)
		{
			var job = await Post(api, data);

            return ((job == null) ? false : true);
		}
    }
}
