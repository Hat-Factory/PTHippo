using System;
namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class RatinganswerModel
    {
		public string Id { get; set; }
		public int RateValue { get; set; }
		public string RatingQuestionId { get; set; }
		public string Question { get; set; }
    }
}
