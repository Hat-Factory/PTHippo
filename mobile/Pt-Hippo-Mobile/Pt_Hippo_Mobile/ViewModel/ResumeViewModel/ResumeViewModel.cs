using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.RestClient.ResumesRest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.ViewModel.ResumeViewModel
{
   public class ResumeViewModel : BaseViewModel
    {
        ResumesrestClient RC = new ResumesrestClient();
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();

      
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
        private List<Resume> myVar;

        public List<Resume> ResumesList
        {
            get { return myVar; }
            set
            {
                myVar = value;
                OnPropertyChangedEventhander();
            }
        }

        private ObservableCollection<Resume> resumeview;

        public ObservableCollection<Resume> ResumeViewList
        {
            get { return resumeview; }
            set
            {
                resumeview = value;
                OnPropertyChangedEventhander();
            }
        }


        private Resume RVar;

        public Resume ResumesElements
        {
            get { return RVar; }
            set
            {
                RVar = value;

                OnPropertyChangedEventhander();
            }
        }
        public ResumeViewModel()
        {
            ResumesElements = new Resume();
            ResumesList = new List<Resume>();
            Basicinfos = new EmployeeCurrentProfile();
            ResumeViewList = new ObservableCollection<Resume>();
            GetData();
        }

        public async void GetData()
        {
            try
            {

                Basicinfos = EmployeeProfileHelper.EmployeeCurrentProfile;
                if (Basicinfos == null)
                {
                    return;
                }
                ObservableCollection<Resume> CastList = new ObservableCollection<Resume>(Basicinfos.Resumes);
                foreach (var item in CastList)
                {
                    item.doing = TextHelper.TextTrimmer(item.doing);


                }
                var sortlist = new ObservableCollection<Resume>(CastList.OrderByDescending(x => x.createdDate).ToList());
                ResumeViewList = sortlist;
                foreach (var item in ResumeViewList)
                {
                    var start = Convert.ToDateTime(item.startDate);
                    var end = string.IsNullOrEmpty(item.endDate)
                        ? DateTime.MinValue
                        : Convert.ToDateTime(item.endDate);
                    string endText = end == DateTime.MinValue ? "Current" : end.Date.ToString("MM/dd/yyyy");

                    item.startEndDatesText = " From: " + start.Date.ToString("MM/dd/yyyy") + " To: " + endText;
                    //item.expirationDate.Date.ToString("MM/dd/yyyy");
                    //"From: 13/11/2017 To: 01/11/2019",

                }
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in resumeviewmodel", ex);
                await logged.LoggAPI();
            }
            
           
           
        }
      
        public ICommand LoadData
        {
            get
            {
                return new Command(() =>
                   
                {
                   
                        GetData();
                       

                });

            }

        }

    }
}
