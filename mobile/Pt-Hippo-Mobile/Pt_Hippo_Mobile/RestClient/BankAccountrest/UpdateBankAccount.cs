using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model;

namespace Pt_Hippo_Mobile.RestClient.BankAccountrest
{
   public class UpdateBankAccount : RestClient<BankAccount>
    {
        public async Task<bool> UpdateBankAccountAsync(string api, object data)
        {
            var job = await PutAsync(api,null, data);
            return job;
        }
    }
}
