// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Pt_Hippo_Mobile.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = "yes";

        #endregion

        public static string IsFirstTime
        {
            get
            {
                return AppSettings.GetValueOrDefault("isFirstTime", null);
            }
            set
            {
                AppSettings.AddOrUpdateValue("isFirstTime", value);
            }
        }

        public static string ratingcount
        {
            get
            {
                return AppSettings.GetValueOrDefault("counter", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("counter", value);
            }
        }

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }
		public static string FirstName
		{
			get
			{
				return AppSettings.GetValueOrDefault("FirstName", "");
			}
			set
			{
				AppSettings.AddOrUpdateValue("FirstName", value);
			}
		}
		public static string LastName
		{
			get
			{
				return AppSettings.GetValueOrDefault("LastName", "");
			}
			set
			{
				AppSettings.AddOrUpdateValue("LastName", value);
			}
		}
        public static string profileimage
		{
			get
			{
				return AppSettings.GetValueOrDefault("profileimage", "");
			}
			set
			{
				AppSettings.AddOrUpdateValue("profileimage", value);
			}
		}

        public static string CurentUserID
        {
            get
            {
                return AppSettings.GetValueOrDefault("id", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("id", value);
            }
        }
        public static string EmployeeProfileId
        {
            get
            {
                return AppSettings.GetValueOrDefault("EmployeeProfileId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("EmployeeProfileId", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }
        public static string Currents
        {
            get
            {
                return AppSettings.GetValueOrDefault("Currents", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Currents", value);
            }
        }

        public static string Saveds
        {
            get
            {
                return AppSettings.GetValueOrDefault("Saveds", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Saveds", value);
            }
        }

        public static string Apllieds
        {
            get
            {
                return AppSettings.GetValueOrDefault("Apllieds", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Apllieds", "");
            }
        }
        public static bool isFirstLogin
        {
            get
            {
                return AppSettings.GetValueOrDefault("isFirstLogin", true);
            }
            set
            {
                AppSettings.AddOrUpdateValue("isFirstLogin", value);
            }
        }


        public static DateTime AccessTokenExpiration
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpiration",
                    DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpiration", value);
            }

        }
        public static string TOS
        {
            get
            {
                return AppSettings.GetValueOrDefault("TOS", "" );
            }
            set
            {
                AppSettings.AddOrUpdateValue("TOS", value);
            }
        }

        public static string GeneralSettings
		{
			get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);

			set => AppSettings.AddOrUpdateValue(SettingsKey, value);

		}

	}
}