using System;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class TextHelper
    {
        public static int MaxLength ;
        public static string TextTrimmer(string text)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                return text;
            }
            if (string.IsNullOrEmpty(text) == false)
            {
                if(text.Length > MaxLength)
                {
                    return text = text.Substring(0, MaxLength) + "...";
                }
            }
            return text;
        }
    }
}
