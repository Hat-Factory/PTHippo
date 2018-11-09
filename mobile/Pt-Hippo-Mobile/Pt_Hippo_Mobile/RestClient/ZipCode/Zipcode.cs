using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.ZipCodeModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.RestClient.ZipCode
{
   public class Zipcode : RestClient<zipcodemodell>
    {
        public zipcodemodell exzipcode { get; set; }
     
        public Zipcode()
        {
            exzipcode = new zipcodemodell();
            

        }
        public async Task<zipcodemodell> GetZipCode(string apiurl , string id)
        {
            
            try
            {
                exzipcode = await GetAsync(apiurl, id);
                return exzipcode;
                /*if (exzipcode.city != null || exzipcode.locationAddress != null || exzipcode.locationLat != null || exzipcode.locationLong != null || exzipcode.state != null || exzipcode.zipCode != "0" || exzipcode.zipCodeType != null)
                {
                    return exzipcode;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("you entered a not valid zip code",AlertMessages.Zipcode , AlertMessages.OkayTitle);
                    return null;
                }*/

            }
            catch (Exception )
            {

               
                await App.Current.MainPage.DisplayAlert("you entered a not valid zip code", AlertMessages.Zipcode, AlertMessages.OkayTitle);
            }
            return null;
        }
    }
}
