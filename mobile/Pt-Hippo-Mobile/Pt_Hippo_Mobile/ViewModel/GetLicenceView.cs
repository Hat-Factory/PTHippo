using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Plugin.FilePicker.Abstractions;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.RestClient.Licences;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class GetLicenceView:BaseViewModel
    {
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();
        LicencesData LicenceData = new LicencesData();
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

        private ObservableCollection<licensesModel> myVar;

        public ObservableCollection<licensesModel> LicensesDataListView
        {
            get { return myVar; }
            set
            {
                myVar = value;
                OnPropertyChangedEventhander();
            }
        }


        List<licensesModel> _LicensesModel = new List<licensesModel>();

        public uploadeditemresponse UploadedtimeResponse { get; set; }

       
        private EmployeeCurrentProfile basicinfos;

        public EmployeeCurrentProfile Basicinfos
        {
            get { return basicinfos; }
            set
            {
                basicinfos = value;
                OnPropertyChangedEventhander();
            }
        }

        public GetLicenceView()
        {
           
            UploadedtimeResponse = new uploadeditemresponse();
            LicensesDataListView = new ObservableCollection<licensesModel>();
            Basicinfos = new EmployeeCurrentProfile();
            BindingMethod();
        }

        public async void BindingMethod()
        {
            if (IsBusy)
                return;


            try
            {
                try
                {
                    IsBusy = true;
                    Basicinfos = EmployeeProfileHelper.EmployeeCurrentProfile;
                    if(Basicinfos == null)
                    {
                        return;
                    }
                    ObservableCollection<UplodadedDocumentsModel> CastList = new ObservableCollection<UplodadedDocumentsModel>(Basicinfos.documents);
                    ObservableCollection<licensesModel> castList = new ObservableCollection<licensesModel>(Basicinfos.Licenses);

                       var sortlist  = new ObservableCollection<licensesModel>(castList.OrderByDescending(x => x.createdDate).ToList());
                    LicensesDataListView = sortlist;
                    foreach (var item in LicensesDataListView)
                    {
                        item.expirationDateText = item.expirationDate.Date.ToString("MM/dd/yyyy");
                    }
                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in getlicenceviewmodel", ex);
                    await logged.LoggAPI();
                }
            }
            finally
            {
                IsBusy = false;
            }

        }


      
        private string expirationDate;

        public string ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                expirationDate = value;
                OnPropertyChangedEventhander();
            }
        }


        private int type;

        public int Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChangedEventhander();
            }
        }


        private string licenseNumber;

        public string LicenseNumber
        {
            get { return licenseNumber; }
            set
            {
                licenseNumber = value;
                OnPropertyChangedEventhander();
            }
        }


        private string college;

        public string College
        {
            get { return college; }
            set
            {
                college = value;
                OnPropertyChangedEventhander();
            }
        }

        public string ID { get; set; }

      
    }
}