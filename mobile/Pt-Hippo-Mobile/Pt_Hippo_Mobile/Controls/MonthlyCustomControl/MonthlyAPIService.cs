using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Controls.MonthlyCustomControl
{
    public class MonthlyAPIService : RestClient<Dictionary<int,List<string>>>
    {
        public async Task<Dictionary<int,List<string>>> GetMonthlyCalenderAPI(string apiurl)
        {
            var monthlyData = await GetAsync(apiurl, null);
            return monthlyData;
        }
    }
}
