using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.RestClient.ZipCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.ViewModel.Basicinfoupdatevm
{
    class UpdateBasicInfoViewModel : BaseViewModel
    {

        UpdateBasicInfo UBIU = new UpdateBasicInfo();
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();
        Zipcode zc = new Zipcode();

        bool IsConnected { get; }

        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private basictest basicinfos;

        public basictest Basicinfos
        {
            get { return basicinfos; }
            set
            {
                basicinfos = value;
                OnPropertyChangedEventhander();
            }
        }
        public UpdateBasicInfoViewModel()
        {
            Basicinfos = new basictest();
            GetData();

            //basicinfos
            //MaxHourRate = (int)basicinfos.maxHourRate;
            //MinhourRate = (int)basicinfos.minHourRate;
        }
        
        public async void GetData()
        {
            if (IsBusy)
                return;


            try
            {
                IsBusy = true;
              
                try
                {
                    Basicinfos = await UBI.GetCurentUserDetailsAsync(URLConfig.Currentuserapiurl);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
              

            }
            finally
            {
             
                IsBusy = false;
            }
           
        }

        public ICommand Submit
        {
            get
            {
                return new Command(async () =>
                {
                    if (IsBusy)
                        return;


                    try
                    {
                        IsBusy = true;
                        try
                        {
                            var zipcodevr = await zc.GetZipCode(URLConfig.ZipcodeUrl, basicinfos.zipCode);
                            if (zipcodevr !=null)
                            {
                                BasicInfo B = new BasicInfo
                                {

                                    jobTypeId = basicinfos.jobTypeId,
                                    isProfessionalInEnglish = Basicinfos.isProfessionalInEnglish,
                                    yearsOfExperience = (int)Basicinfos.yearsOfExperience,
                                    coverLetter = Basicinfos.coverLetter,
                                    maxTravelDistance = (int)Basicinfos.maxTravelDistance,
                                    minTravelDistance = (int)Basicinfos.minTravelDistance,
                                    minHourRate = (int)Basicinfos.minHourRate,
                                    maxHourRate = (int)Basicinfos.maxHourRate,
                                    zipCode = basicinfos.zipCode,
                                    generalSkills = basicinfos.generalSkills,
                                    afterWorkPhone = basicinfos.afterWorkPhone,
                                };

                                await UBIU.UpdateBasicInfoAsync(URLConfig.Updatebasicinfos, B);
                                await App.Current.MainPage.DisplayAlert("",AlertMessages.EditedMessage , "OK");
                            }
                            else
                            {
                                return;
                            }
                            
                            
                        }
                        catch (Exception ex)
                        {
                            throw  new Exception("Error in updatebasicinfoviewmodel",ex);
                          
                        }
                       

                    }
                    finally
                    {
                        
                        IsBusy = false;
                    }
                  
                });

            }
        }
    }
}
