using Pt_Hippo_Mobile.Model.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Helpers
{
 public   static class jobdetailstexthelper
    {
         
        public static FormattedString LabelTextFormating(jobModel temps , int sldrvalue)
        {
            try
            { 
            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Awesome, ", ForegroundColor = Color.Black, Font = Font.SystemFontOfSize(14, FontAttributes.Italic) });
            fs.Spans.Add(new Span { Text = "let’s confirm your job details. You’re applying for a, ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = $"{temps.jobTypeTitle}", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });

            fs.Spans.Add(new Span { Text = " job, in ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = $"{temps.states}", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });

            fs.Spans.Add(new Span { Text = ", for ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = "$", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });
            fs.Spans.Add(new Span { Text = $"{sldrvalue}", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });
            fs.Spans.Add(new Span { Text = "/hr", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });
             
            fs.Spans.Add(new Span { Text = ", on ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = $"{temps.jobSchedules.FirstOrDefault().from.ToString("D")}", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });

            fs.Spans.Add(new Span { Text = ", from ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = $"{  temps.jobSchedules.FirstOrDefault().from.Hour + temps.jobSchedules.FirstOrDefault().from.ToString("tt ")  }", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });

            fs.Spans.Add(new Span { Text = ", to ", ForegroundColor = Color.Black, Font = Font.Default });

            fs.Spans.Add(new Span { Text = $"{ temps.jobSchedules.FirstOrDefault().to.Hour + temps.jobSchedules.FirstOrDefault().to.ToString("tt ") }", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize(14, FontAttributes.Bold) });

            fs.Spans.Add(new Span { Text = ".", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.Default });
             
            return fs;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetailstexthelper.cs", ex);
                logged.LoggAPI();
            }
          return AlertMessages.textformating; 
        }

        public static FormattedString LabelTextFormating()
        {
            try
            {
                var fs = new FormattedString();
                fs.Spans.Add(new Span { Text = "But first, ", ForegroundColor = Color.Black, Font = Font.Default });

                fs.Spans.Add(new Span { Text = "REMEMBER", ForegroundColor = Color.FromHex("#60afdf"), Font = Font.SystemFontOfSize( 14, FontAttributes.Bold) });

                fs.Spans.Add(new Span { Text = ", to get paid you need to show up, on-time, wearing proper work attire and have any requested credentials handy.", ForegroundColor = Color.Black, Font = Font.Default });

                fs.Spans.Add(new Span { Text = " Good Luck", ForegroundColor = Color.Black, Font = Font.SystemFontOfSize(14, FontAttributes.Italic) });

                fs.Spans.Add(new Span { Text = "!!", ForegroundColor = Color.Black, Font = Font.Default });

                return fs;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in jobdetailstexthelper.cs", ex);
                logged.LoggAPI(); 
            }
            return AlertMessages.textformating;
        }

    }
}
