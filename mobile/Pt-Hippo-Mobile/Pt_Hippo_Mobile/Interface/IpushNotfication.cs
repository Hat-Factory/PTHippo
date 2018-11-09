using System;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Interface
{
    public interface IpushNotfication
    {
		Tuple<bool, string> IsNotificationsSupported();

		string GetCurrentToken();

        Task RegisterToAzure(string tag);

        Task UnRegisterToAzure();
    }
}
