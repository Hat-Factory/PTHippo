using System;
using System.Collections.Generic;
using Pt_Hippo_Mobile.Enums;

namespace Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model
{
    public class RatingModelanswers
    {
		public string JobApplicantId { get; set; }

		public string Comment { get; set; }

		public string JobReference { get; set; }
		public string FacilityName { get; set; }
		public double RateValue { get; set; }
		public Rater Rater { get; set; }
		public string EmployeeName { get; set; }

		public List<RatinganswerModel> RatingAnswers { get; set; }
    }
}
