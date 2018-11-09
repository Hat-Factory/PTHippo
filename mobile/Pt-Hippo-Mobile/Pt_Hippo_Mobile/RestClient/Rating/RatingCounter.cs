using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.Rating
{
    public class RatingCounter:RestClient<string>
    {
     
        public async Task<string> Getcounter(string api)
        {
            var rating = await GetAsync(api,null);
            // RatingTitle = RatingTitle + "(" + rating +")";
            //Settings.ratingcount = rating;
            try
            {
                constants.PendingRatingCount = int.Parse(rating);

            }
            catch{
                constants.PendingRatingCount = 0;
            }
            return rating;
        }
    }
}
