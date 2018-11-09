using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Helpers
{
   public class PermissionHelpers
    {
        private async void AskforLocationPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    try
                    {


                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                        {
                            await App.Current.MainPage.DisplayAlert("Need location", "Pt-Hippo need that location", "OK");
                        }

                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                        status = results[Permission.Location];
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in location Permission on App.Xamal.cs", ex);
                        await logged.LoggAPI();
                    }
                }

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in App.Xamal.cs", ex);
                await logged.LoggAPI();
            }
        }


     
    }
}
