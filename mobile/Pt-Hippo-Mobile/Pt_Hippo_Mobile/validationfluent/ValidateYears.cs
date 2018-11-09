using System;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.validationfluent
{
    public static class ValidateYears
    {
        public static string Validate(string input)
        {
            int years = -1;

            try
            {
                string _text = input; 
                if (string.IsNullOrEmpty(_text))
                {
                    return string.Empty;
                }

                Int32.TryParse(_text, out years);
                if (years == -1)
                {
                    App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Invalid years of experience", AlertMessages.OkayTitle);
                    return input;
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in validating years of experience", ex);
                logged.LoggAPI();
            }
            if(years > 99)
            {
                years = 99;
            }
            return years.ToString();
        }
    }
}
