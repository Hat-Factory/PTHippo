using System;
using Pt_Hippo_Mobile.Enums;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class RatingModel
    {
		public string Id { get; set; }
		public string Question { get; set; }
        public int answerType { get; set; }
        public Rater Rater { get; set; }
		public bool Checking { get; set; }
		public int Answer { get; set; }
    }
}
