using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.CheckoutandPutCheckin
{
  public  class Checkout_Checkin : RestClient<Checkin_Checkout>
    {
         
        public async Task<bool> PutCheckinoroutAsync(string api, object data)
        {

            var job = await PutAsync(api,null, data);
            return job;
        }
    }
}
