using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.Model.skillsModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;

using Pt_Hippo_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class SkillsViewModel : BaseViewModel
    {
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();
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
        public SkillsViewModel()
        {

            Basicinfos = new EmployeeCurrentProfile();
            SkillsListView = new ObservableCollection<SkillsModel>();
            GetData();
        }

        private ObservableCollection<SkillsModel> myVar;

        public ObservableCollection<SkillsModel> SkillsListView
        {
            get { return myVar; }
            set { myVar = value; }
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
                    Basicinfos = await UBI.GetCurentUserDetailsAsync(URLConfig.CurrentEmployeeProfileAPI);
                    ObservableCollection<SkillsModel> CastList = new ObservableCollection<SkillsModel>(Basicinfos.EmployeeSkills);
                    SkillsListView = CastList;
                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in skillsviewmodel", ex);
                    await logged.LoggAPI();
                }
                

                

            }
            finally
            {

                IsBusy = false;
            }
          


    }
    SkillsServices skillservicesobject = new SkillsServices();

        public async Task SkillsList(string id)
        {
            //if (IsBusy)
            //    return;


            try
            {
                IsBusy = true;

                try
                {
                    var sklist = await skillservicesobject.GeTskillDetails(URLConfig.GeTskillDetailsurl);

                    if (id == "1")
                    {
                        var temp = sklist.Where(sk => sk.skillCategory == id);
                        var myObservableCollection = new ObservableCollection<SkillsModel>(temp);
                        Languageskills = myObservableCollection;
                        Languageskillss = Languageskills;
                    }
                    else if (id == "2")
                    {
                        var temp = sklist.Where(sk => sk.skillCategory == id);
                        var myObservableCollection = new ObservableCollection<SkillsModel>(temp);
                        Computerskills = myObservableCollection;
                        compskills = Computerskills;
                        Computerskillss = Computerskills;
                    }
                    else if (id == "10")
                    {
                        var temp = sklist.Where(sk => sk.skillCategory == id);
                        var myObservableCollection = new ObservableCollection<SkillsModel>(temp);
                        technicalSkills = myObservableCollection;
                        technicalSkillss = technicalSkills;
                    }
                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in skillsviewmodel", ex);
                    await logged.LoggAPI();
                }
               

            }
            finally
            {
                IsBusy = false;
            }



        }
        private ObservableCollection<SkillsModel> vaar;

        public ObservableCollection<SkillsModel> Computerskillss
        {
            get { return vaar; }
            set
            {
                vaar = value;
                OnPropertyChangedEventhander();
            }
        }
        private ObservableCollection<SkillsModel> vaaar;

        public ObservableCollection<SkillsModel> technicalSkillss
        {
            get { return vaaar; }
            set
            {
                vaaar = value;
                OnPropertyChangedEventhander();
            }
        }
        private ObservableCollection<SkillsModel> vaaaar;

        public ObservableCollection<SkillsModel> Languageskillss
        {
            get { return vaaaar; }
            set
            {
                vaaaar = value;
                OnPropertyChangedEventhander();
            }
        }

        public ObservableCollection<SkillsModel> AllSkillss = new ObservableCollection<SkillsModel>();
        public ObservableCollection<SkillsModel> Languageskills = new ObservableCollection<SkillsModel>();
        public ObservableCollection<SkillsModel> technicalSkills = new ObservableCollection<SkillsModel>();
        public ObservableCollection<SkillsModel> Computerskills = new ObservableCollection<SkillsModel>();


        public ObservableCollection<SkillsModel> compskills { get; set; }
       
        public List<SkillsModel> _updateSkillss = new List<SkillsModel>() { };
 
        public ICommand EdietCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //SkillsListView.(_updateSkillss);
                    if (IsBusy)
                        return;


                    try
                    {
                        IsBusy = true;
                        try
                        {
                            var xlist = SkillsListView.Union(_updateSkillss).ToList();
                            await skillservicesobject.PutskillsListAsync(xlist, URLConfig.PutskillsListAsyncurl);
                            await App.Current.MainPage.DisplayAlert("", AlertMessages.EditedMessage, "OK");
                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error in skillsviewmodel", ex);
                            await logged.LoggAPI();
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

