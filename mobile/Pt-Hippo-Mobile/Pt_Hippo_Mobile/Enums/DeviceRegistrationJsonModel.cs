using System;
namespace Pt_Hippo_Mobile.Enums
{
    public class DeviceRegistrationJsonModel
    {
        public string Platform { get; set; }
        public string DeviceTokenOrRegistirationId { get; set; }
        public string[] Tags { get; set; }
    } }