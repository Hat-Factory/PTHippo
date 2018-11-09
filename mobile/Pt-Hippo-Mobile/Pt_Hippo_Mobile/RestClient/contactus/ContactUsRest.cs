using System;
using System.Threading.Tasks;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.contactus
{
    public class ContactUsRest : RestClient<contactusmodel>
    {
		public async Task<bool> Postcontacts(string api, object data)
		{
            var conatcus = await Post(api, data);
            return conatcus != null ? true : false;
		}
    }
}
