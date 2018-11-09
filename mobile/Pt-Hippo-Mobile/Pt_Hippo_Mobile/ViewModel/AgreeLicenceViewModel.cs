using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Pt_Hippo_Mobile.ViewModel
{
    class AgreeLicenceViewModel : BaseViewModel
    {

        //ApiServices apiservice = new ApiServices();
        public bool Agree;
        public INavigation Navigation { get; set; }
        public AgreeLicenceViewModel(INavigation nav)
        {
            this.Navigation = nav;
        }
        public AgreeLicenceViewModel()
        {

        }
        
        public  bool AgreeOnLicences
        {
            get
            {
                return Agree;
            }
            set
            {
                Agree = value;
          
                if (!AgreeOnLicences)
                {
                    Debug.WriteLine("okay" + AgreeOnLicences.ToString());

                   
                    OnPropertyChangedEventhander();
                   
                }
                else
                {
                    Debug.WriteLine("okay" + AgreeOnLicences.ToString());
                }





            }
        }
        public ICommand logout
        {
            get 
            {
                return new Command( () =>
                {
                    Settings.AccessToken = null;
                    Settings.Username = null;
                });
            }
        }
        public ICommand ContinueCommand
        {
          
            get
            {
                return new Command(async () =>

                {
                    
                   
                    if(!AgreeOnLicences)
                    {
                        Debug.WriteLine("okay" + AgreeOnLicences.ToString());
                        Toast.LongMessage("please agree on llicence and check the checkbox");

                    }
                    else
                    {
                        Debug.WriteLine("okay" + AgreeOnLicences.ToString());
                       // await Navigation.PushModalAsync(new NavigationPage(new Views.MyPage()));
                        //PutAgreeonlicencessAsync
                    }

                    

                });
            }
        }
    }
}
