using Pt_Hippo_Mobile.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.RestClient.RegistrationRest;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ZipCode;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Pt_Hippo_Mobile.Model.skillsModel;
using Pt_Hippo_Mobile.Model.BaicInfoModel;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.Views;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.Vaildation;
using Plugin.Media;
using System.IO;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Model.HelperModels;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            try
            {

                IsMaleLocal = new bool();
                Basicinfos = new EmployeeCurrentProfile();
                SkillsListView = new ObservableCollection<SkillsModel>();
                SelectedItem = new jobType();
                isenabel = true;
                isenabelbtn = true;
                if (EmployeeSkills == null)
                {
                    EmployeeSkills = new ObservableCollection<SkillsModel>();
                }
                if (JobType == null)
                {
                    JobType = new List<jobType>();
                }
                if (JobTypeForProfile == null)
                {
                    JobTypeForProfile = new ObservableCollection<jobType>();
                }
                if (RBM == null)
                {
                    RBM = new RegisterBindingModel();
                }


                if (Basicinfos == null)
                {
                    Basicinfos = new EmployeeCurrentProfile();
                }
                GetData();
                typesasync();

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in RegisterViewModel consturctor", ex);
                logged.LoggAPI();
            }

        }
        private List<string> listofyearsexperince;

        public List<string> YearsOfExperince_List
        {
            get { return listofyearsexperince; }
            set { listofyearsexperince = value; OnPropertyChangedEventhander(); }
        }
        string years;
        public string Enteryearsofexperience
        {
            get { return years; }
            set
            {
                years = value;
                OnPropertyChangedEventhander();

            }
        }

        public RegisterViewModel(INavigation navigation)
        {
            try
            {
                this.Navigation = navigation;
                IsMaleLocal = new bool();
                isenabel = true;
                isenabelbtn = true;
                Basicinfos = new EmployeeCurrentProfile();
                SkillsListView = new ObservableCollection<SkillsModel>();
                SelectedItem = new jobType();
                if (EmployeeSkills == null)
                {
                    EmployeeSkills = new ObservableCollection<SkillsModel>();
                }
                if (JobType == null)
                {
                    JobType = new List<jobType>();
                }
                if (JobTypeForProfile == null)
                {
                    JobTypeForProfile = new ObservableCollection<jobType>();
                }
                if (RBM == null)
                {
                    RBM = new RegisterBindingModel();
                }

                if (Basicinfos == null)
                {
                    Basicinfos = new EmployeeCurrentProfile();
                }
                GetData();
                typesasync();

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in RegisterViewModel consturctor", ex);
                logged.LoggAPI();
            }

        }
        public async void typesasync()
        {
            await types();
        }
        UserBasicInfoUpdate UBI = new UserBasicInfoUpdate();
        private bool busy = false;


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


        private ObservableCollection<SkillsModel> myVar;

        public ObservableCollection<SkillsModel> SkillsListView
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public static bool? check { get; set; }
        public static bool? JobTypecheck { get; set; }


        public async void GetData()
        {
            if (string.IsNullOrEmpty(Settings.AccessToken) || string.IsNullOrWhiteSpace(Settings.AccessToken))
                return;
            try
            {

                Basicinfos = EmployeeProfileHelper.EmployeeCurrentProfile;
                var yearstemp = Basicinfos.YearsOfExperience.ToString();
                if (yearstemp != null)
                {
                    Enteryearsofexperience = Basicinfos.YearsOfExperience.ToString();
                }


                //TODO : Overide the null values


                if (Basicinfos == null)
                {
                    return;
                }
                ObservableCollection<SkillsModel> CastList = new ObservableCollection<SkillsModel>(Basicinfos.EmployeeSkills);
                SelectedJobTypeId = EmployeeProfileHelper.EmployeeCurrentProfile.JobTypeId;
                SkillsListView = CastList;

                if (!EmployeeSkills.Any())
                {
                    if (check == null)
                    {
                        EmployeeSkills = CastList;
                        check = false;
                    }
                    else
                    {
                        return;
                    }
                }
                Enteryearsofexperience = Basicinfos.YearsOfExperience.ToString();
                ShowName = Basicinfos.CoverLetter;

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in registerviewmodel", ex);
                await logged.LoggAPI();
            }

        }


        public async Task FillSkillsFromAPI(SkillCategories id)
        {

            try
            {

                SkillsServices skillservicesobject = new SkillsServices();
                if (SkillsHelper.AllSysytemSkills == null || SkillsHelper.AllSysytemSkills.Any() == false)
                {
                    //TODO: to be decided Later
                    SkillsHelper.AllSysytemSkills = await skillservicesobject.GeTskillDetails(URLConfig.GeTskillDetailsurl + "1");
                    //if ( !string.IsNullOrEmpty(SelectedJobTypeId))
                    //{
                    //    SkillsHelper.AllSysytemSkills = await skillservicesobject.GeTskillDetails(URLConfig.GeTskillDetailsurl + SelectedJobTypeId); 
                    //}
                    //else
                    //{
                    //    SkillsHelper.AllSysytemSkills = await skillservicesobject.GeTskillDetails(URLConfig.GeTskillDetailsurl + EmployeeProfileHelper.EmployeeCurrentProfile.JobTypeId);
                    //}
                }
                var observableAll = new ObservableCollection<SkillsModel>(SkillsHelper.AllSysytemSkills);
                var temp = SkillsHelper.AllSysytemSkills.Where(sk => sk.skillCategoryId == ((int)id).ToString());
                var observableForCategory = new ObservableCollection<SkillsModel>(temp);
                if (id == SkillCategories.Languages)
                {
                    Languageskills = observableForCategory;
                }
                else if (id == SkillCategories.ComputerSkills)
                {
                    Computerskills = observableForCategory;
                }
                else if (id == SkillCategories.Other)
                {
                    TechnicalSkills = observableForCategory;
                }
                else if (id == SkillCategories.All)
                {     
                    //other is the Speciality Skills  there is a potional to be changed and Compine other Factors 
                    observableAll = new ObservableCollection<SkillsModel>( observableAll.Where(sc => sc.skillCategoryId == ((int)(SkillCategories.Other)).ToString()));
                    if (observableAll == null)
                    {
                        observableAll = new ObservableCollection<SkillsModel>();
                    }
                    else
                    {
                        AllSkills = observableAll;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in SkillsList function", ex);
                await logged.LoggAPI();
            }




        }
        private ObservableCollection<SkillsModel> vaar;

        public ObservableCollection<SkillsModel> Computerskills
        {
            get { return vaar; }
            set
            {
                vaar = value;
                OnPropertyChangedEventhander();
            }
        }
        private ObservableCollection<SkillsModel> vaaar;

        public ObservableCollection<SkillsModel> TechnicalSkills
        {
            get { return vaaar; }
            set
            {
                vaaar = value;
                OnPropertyChangedEventhander();
            }
        }


        private ObservableCollection<SkillsModel> allskills;

        public ObservableCollection<SkillsModel> AllSkills
        {
            get { return allskills; }
            set
            {
                allskills = value;
                OnPropertyChangedEventhander();
            }
        }


        private ObservableCollection<SkillsModel> vaaaar;

        public ObservableCollection<SkillsModel> Languageskills
        {
            get { return vaaaar; }
            set
            {
                vaaaar = value;
                OnPropertyChangedEventhander();
            }
        }

        public static ObservableCollection<SkillsModel> ExperienceSkills;
        public static ObservableCollection<SkillsModel> EmployeeSkills;
        public static RegisterBindingModel RBM;
        public static string SelectedJobTypeId;
        public static string Computerskillstext;
        public static string SpecialitySkillstext;
        public static string SelectOneText = "Select One";
        public static string LangaugeSkillstext;
        public static string AllSkilssText;


        private ObservableCollection<SkillsModel> varrrr;



        Zipcode zc = new Zipcode();
        public bool Agree;
        public INavigation Navigation { get; set; }



        public bool AgreeOnLicences
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
        RegistrationJobType RJB = new RegistrationJobType();

        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        //public bool isMale { get; set; }
        public string zipCode { get; set; }

        private bool ismale;

        public bool IsMaleLocal
        {
            get { return ismale; }
            set
            {
                ismale = value;
                OnPropertyChangedEventhander();
            }
        }


        public string jobid;
        public string jobTypeId
        {
            get { return jobid; }
            set
            {
                jobid = SelectedItem.id;
                OnPropertyChangedEventhander();
            }
        }

        List<jobType> _jobtype;
        public List<jobType> JobType
        {
            get
            {
                return _jobtype;
            }
            set
            {
                _jobtype = value;
                OnPropertyChangedEventhander();
            }
        }
        static ObservableCollection<jobType> _jobtypeforprofile;
        static public ObservableCollection<jobType> JobTypeForProfile
        {
            get
            {
                return _jobtypeforprofile;
            }
            set
            {
                _jobtypeforprofile = value;
                //   bvm.OnPropertyChangedEventhander();
            }
        }

        ObservableCollection<jobType> _jobtypeNonStatic;
        public ObservableCollection<jobType> JobTypeNonStatic
        {
            get
            {
                return _jobtypeNonStatic;
            }
            set
            {
                _jobtypeNonStatic = value;
                OnPropertyChangedEventhander();
            }
        }

        public async Task types()
        {
            var jobtypevar = await RJB.JOBS(URLConfig.JobTypeurl);

            JobType = jobtypevar;

            if (JobTypeForProfile == null)
            {
                JobTypeForProfile = new ObservableCollection<jobType>();
            }

            if (!JobTypeForProfile.Any())
            {
                if (JobTypecheck == null)
                {
                    JobTypeForProfile = new ObservableCollection<jobType>(jobtypevar);
                    foreach (var item in JobType)
                    {
                        item.imagesource = "RoundCBUN.png";
                        if (!string.IsNullOrEmpty(SelectedJobTypeId))
                        {
                            if (item.id == SelectedJobTypeId)
                            {
                                item.imagesource = "RoundCB.png";
                            }
                        }
                    }
                    JobTypecheck = false;
                }
                else
                {
                    return;
                }
            }

            JobTypeNonStatic = JobTypeForProfile;
        }
        public string Message { get; set; }
        bool isselected;

        jobType slecteditem;

        public jobType SelectedItem
        {
            get { return slecteditem; }
            set
            {
                if (slecteditem != value)
                {
                    slecteditem = value;

                    OnPropertyChangedEventhander();
                }
            }
        }
        private string _yearsofexselecteditem;
        private static string _yearsOfExperience;
        public string YearsOfExperinceSelectedItem
        {
            get
            {
                if (string.IsNullOrEmpty(_yearsOfExperience) == false)
                {
                    return _yearsOfExperience;
                }
                else
                {
                    return _yearsofexselecteditem;
                }

            }
            set { _yearsofexselecteditem = value; _yearsOfExperience = value; OnPropertyChangedEventhander(); }
        }


        public bool agreedOnTerms
        {

            get
            {

                return isselected;

            }
            set
            {

                isselected = value;


                if (!agreedOnTerms)
                {
                    Debug.WriteLine("okay" + agreedOnTerms.ToString());
                }
                else
                {
                    Debug.WriteLine("okay" + agreedOnTerms.ToString());
                }


            }

        }
        private bool enabeleing;

        public bool Enabeled
        {
            get { return enabeleing; }
            set
            {
                enabeleing = value;
                OnPropertyChangedEventhander();
            }
        }

        private string passvar;

        public string ConfirmationPassword
        {
            get { return passvar; }
            set
            {
                passvar = value;
                OnPropertyChangedEventhander();
            }
        }


        public ICommand Done
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        isenabel = false;
                        if (string.IsNullOrEmpty(RegisterViewModel.SelectedJobTypeId))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select your speciality", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (RegisterViewModel.EmployeeSkills == null || RegisterViewModel.EmployeeSkills.Count() == 0)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select your skills", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(RegisterViewModel.Computerskillstext)
                            || RegisterViewModel.Computerskillstext == RegisterViewModel.SelectOneText
                           )
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select your software skills", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(RegisterViewModel.LangaugeSkillstext)
                            || RegisterViewModel.LangaugeSkillstext == RegisterViewModel.SelectOneText
                           )
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select your language(s)", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(RegisterViewModel.SpecialitySkillstext)
                            || RegisterViewModel.SpecialitySkillstext == RegisterViewModel.SelectOneText
                           )
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select your speciality skills", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(Enteryearsofexperience) == false)
                        {

                            int.TryParse(Enteryearsofexperience, out int years);
                            if (years > 0)
                            {
                                RBM.yearsOfExperience = years;
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Invalid years of experience", AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                        }

                        jobTypeId = SelectedItem.id;
                        RBM.employeeProfileSkills = EmployeeSkills.ToList();

                        RBM.maxTravelDistance = 15;
                        RBM.minTravelDistance = 1;
                        var isSuccess = await RJB.RegistrationPostAsync(URLConfig.SignUpEmployeeurl, RBM);
                        if (isSuccess == true)
                        {
                            await App.Current.MainPage.DisplayAlert("Congratulations", AlertMessages.Registration, "Okay");
                            ((App)App.Current).MainPage = new LoginPage();
                        }

                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in registerviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }

                });
            }
        }
        UpdateBasicInfo UBIU = new UpdateBasicInfo();
        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
        }
        private bool _isenablebtn;

        public bool isenabelbtn
        {
            get { return _isenablebtn; }
            set { _isenablebtn = value; OnPropertyChangedEventhander(); }
        }
        public ICommand Submit
        {
            get
            {
                return new Command(async () =>
                {
                    isenabelbtn = false;

                    if (Basicinfos == null)
                    {
                        isenabelbtn = true;
                        return;
                    }
                    if (string.IsNullOrEmpty(Enteryearsofexperience) || string.IsNullOrWhiteSpace(Enteryearsofexperience))
                    {

                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.YearsOfExperinceMessage, AlertMessages.OkayTitle);
                        isenabelbtn = true;
                        return;

                    }

                    if (string.IsNullOrEmpty(Enteryearsofexperience) == false)
                    {

                        int.TryParse(Enteryearsofexperience, out int years);
                        if (years > 0)
                        {
                            RBM.yearsOfExperience = years;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Invalid years of experience", AlertMessages.OkayTitle);
                            isenabelbtn = true;
                            return;
                        }
                    }

                    if (SelectedJobTypeId == null)
                    {
                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.SpecializationMessage, AlertMessages.OkayTitle);
                        isenabelbtn = true;
                        return;
                    }
                    try
                    {

                        if (string.IsNullOrWhiteSpace(SelectedJobTypeId) ||
                            Basicinfos.IsProfessionalInEnglish == null ||
                            string.IsNullOrEmpty(Enteryearsofexperience) ||
                            string.IsNullOrEmpty(basicinfos.CoverLetter) ||
                            Basicinfos.MaxTravelDistance == null ||
                            Basicinfos.MinHourRate == null ||
                            Basicinfos.MaxHourRate == null ||
                            string.IsNullOrEmpty(basicinfos.ZipCode) ||


                            basicinfos.EnableHomeCareAssignment == null)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please fill all fields", AlertMessages.OkayTitle);
                            isenabelbtn = true;
                            return;
                        }

                        EmployeeCurrentProfile B = new EmployeeCurrentProfile
                        {
                            JobTypeId = SelectedJobTypeId,
                            IsProfessionalInEnglish = Basicinfos.IsProfessionalInEnglish,
                            YearsOfExperience = Convert.ToInt32(Enteryearsofexperience),
                            CoverLetter = Basicinfos.CoverLetter,
                            MaxTravelDistance = (int)Basicinfos.MaxTravelDistance,
                            MinTravelDistance = (int)Basicinfos.MinTravelDistance,
                            MinHourRate = (int)Basicinfos.MinHourRate,
                            MaxHourRate = (int)Basicinfos.MaxHourRate,
                            ZipCode = basicinfos.ZipCode,
                            GeneralSkills = basicinfos.GeneralSkills,
                            AfterWorkPhone = basicinfos.AfterWorkPhone,
                            EnableHomeCareAssignment = basicinfos.EnableHomeCareAssignment
                        };

                        var profileUpdated = await UBIU.UpdateBasicInfoAsync(URLConfig.Updatebasicinfos, B);
                        if (profileUpdated)
                        {
                            SkillsServices skillservicesobject = new SkillsServices();
                            var skillsUpdated = await skillservicesobject.PutskillsListAsync(EmployeeSkills.ToList(), URLConfig.PutskillsListAsyncurl);
                            if (skillsUpdated)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                            }
                        }





                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in registerviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabelbtn = true;
                    }



                });

            }
        }
        Plugin.FilePicker.Abstractions.FileData _mediaFile;

        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChangedEventhander(); }
        }

        private bool isBEnabeld;

        public bool IsBEnabeld
        {
            get { return isBEnabeld; }
            set
            {
                isBEnabeld = value;
                OnPropertyChangedEventhander();
            }
        }
        List<ImageinfoModel> imageresult;
        public List<ImageinfoModel> ImageResult
        {
            get { return imageresult; }
            set { imageresult = value; OnPropertyChangedEventhander(); }
        }
        string showfile, documentid;
        private Plugin.FilePicker.Abstractions.FileData _filedata;

        public Plugin.FilePicker.Abstractions.FileData FileData
        {
            get
            {
                return _filedata;
            }
            set
            {
                _filedata = value;
                OnPropertyChangedEventhander();
            }
        }



        public string ShowName
        {
            get { return showfile; }
            set
            {
                showfile = value;
                OnPropertyChangedEventhander();
            }
        }
        public string DocumentId
        {
            get { return documentid; }
            set
            {
                documentid = value;
                OnPropertyChangedEventhander();
            }
        }

        BasicInfos basicinformations = new BasicInfos();
        ResultImageUpload loadresult = new ResultImageUpload();
        public Plugin.FilePicker.Abstractions.FileData filedata = new Plugin.FilePicker.Abstractions.FileData();
        Model.HelperModels.FileInfo iOSFileInfo;
        public ICommand PickPhoto
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        isenabel = false;
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            var action = await App.Current.MainPage.DisplayActionSheet("Upload Resume", "Cancel", null, "Photo Roll", "Files");
                            if (action == "Files")
                            {
                                await DependencyService.Get<Interface.IFilePicker>().FilePick(async (fileinfo) =>
                                {
                                    if (fileinfo == null)
                                    {
                                        //Device.BeginInvokeOnMainThread(async () =>
                                        //{
                                        //    await App.Current.MainPage.DisplayAlert("No File", "No file chosen", "Ok");
                                        //});
                                    }
                                    else if (fileinfo?.Path == null)
                                    {
                                        Device.BeginInvokeOnMainThread(async () =>
                                        {
                                            await App.Current.MainPage.DisplayAlert("Unsupported",
                                                "Application file provider not supported", "Ok");
                                        });
                                    }
                                    else
                                    {
                                        await CrossMedia.Current.Initialize();
                                        var splittedPath = fileinfo.Path.Split('/');
                                        var fullFileName = splittedPath[splittedPath.Length - 1].Trim();
                                        FileImage = fullFileName;
                                        iOSFileInfo = fileinfo;
                                        ImageResult = await loadresult.Resultupload(iOSFileInfo.Path, DocumentId, false, DocumentType.CoverLetter, true, DependencyService.Get<Interface.IFilePicker>().GetAllBytes(iOSFileInfo.Path), FileImage, URLConfig.Updatemediafileurl);
                                        if (ImageResult != null)
                                        {
                                            ShowName = ImageResult[0].path;
                                            Helpers.TextHelper.MaxLength = 20;
                                            basicinfos.CoverLetter = ShowName;
                                            if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                            {

                                                ShowName = TextHelper.TextTrimmer(ShowName);
                                            }

                                            DocumentId = ImageResult[0].id;
                                            await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                                        }
                                    }
                                });
                            }
                            else if (action == "Photo Roll")
                            {
                                isenabel = false;
                                await CrossMedia.Current.Initialize();

                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    return;
                                }

                                var _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                                if (_mediaFile == null)
                                    return;
                                FileImage = _mediaFile.Path;

                                var filename = basicinformations.getfilepath(_mediaFile);
                                filename = Path.GetFileName(filename);
                                var bytearray = basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());
                                iOSFileInfo = new FileInfo();
                                iOSFileInfo.Path = _mediaFile.Path;
                                ImageResult = await loadresult.Resultupload(_mediaFile.Path, DocumentId, false, DocumentType.CoverLetter, true, bytearray, filename, URLConfig.Updatemediafileurl);

                                if (ImageResult != null)
                                {
                                    ShowName = ImageResult[0].path;
                                    Helpers.TextHelper.MaxLength = 20;
                                    basicinfos.CoverLetter = ShowName;
                                    if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                    {

                                        ShowName = TextHelper.TextTrimmer(ShowName);
                                    }
                                    DocumentId = ImageResult[0].id;
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                                }
                            }



                        }
                        else
                        {
                            var crossFilePicker = Plugin.FilePicker.CrossFilePicker.Current.PickFile();
                            filedata = await crossFilePicker;
                            if (filedata != null)
                            {

                                if (filedata.DataArray != null)
                                {
                                    if (filedata.FileName == null || string.IsNullOrEmpty(filedata.FileName))
                                    {
                                        filedata.FileName = "Pt_Hipp_Document.pdf";
                                    }
                                    if (filedata.FileName != null)
                                    {
                                        _mediaFile = filedata;
                                        FileImage = filedata.FileName;
                                        //here i am using fake path cause the library i use dose not get the file Path 
                                        //await basicinformations.UploadMediafile("C:/Users/AshrafNaser/Desktop/PT-Hippo/mobile/Pt-Hippo-Mobile/Pt_Hippo_Mobile.UWP/Assets/background_2.png",
                                        //null, false, DocumentType.Resume, true, filedata.DataArray,
                                        //filedata.FileName, URLConfig.Updatemediafileurl, null);
                                    }

                                }





                                //var filename = basicinformations.getfilepath(_mediaFile);
                                //filename = Path.GetFileName(filename);
                                var bytearray = _mediaFile.DataArray;
                                //basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());
                                ImageResult = await loadresult.Resultupload("C:/Users/Ashraf Naser/Desktop/PT - Hippo/mobile/Pt-Hippo-Mobile/ Pt_Hippo_Mobile.UWP / Assets / background_2.png", DocumentId, false, DocumentType.Resume, true, bytearray, _mediaFile.FileName, URLConfig.Updatemediafileurl);
                                ShowName = ImageResult[0].path;
                                Basicinfos.CoverLetter = ShowName;
                                Helpers.TextHelper.MaxLength = 20;
                                basicinfos.CoverLetter = ShowName;
                                if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                {

                                    ShowName = TextHelper.TextTrimmer(ShowName);
                                }

                                DocumentId = ImageResult[0].id;
                                await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException(" Error in addneexperinceviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }
                });



            }

        }


        public ICommand RegisterCommand
        {

            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        isenabel = false;
                        // jobTypeId = SelectedItem.id;
                        ///nakes a3ml check 3la Picker string.IsNullOrEmpty(ConfirmationPassword) || string.IsNullOrWhiteSpace(ConfirmationPassword) || ConfirmationPassword != Password ||
                        if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(mobile) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(zipCode))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.AllFieldsAreRequired, AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        else
                        {
                            bool isFormValid = true;

                            if (string.IsNullOrEmpty(firstName))
                            {

                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.FirstName, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            if (isFormValid && ((string.IsNullOrEmpty(lastName))))
                            {

                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.LastNmae, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            if (isFormValid && ((string.IsNullOrEmpty(zipCode))))
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);

                                isenabel = true;
                                return;
                            }
                            else
                            {
                                int.TryParse(zipCode, out int zipcode);
                                if (zipcode == 0)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);
                                    isenabel = true;
                                    return;
                                }
                            }


                            if (isFormValid && zipCode.Length < 3)
                            {
                                isFormValid = false;
                                isenabel = true;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.zipcodelength, AlertMessages.OkayTitle);

                                return;
                            }
                            if (isFormValid && zipCode.Length > 9)

                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Maximum length for Zipcode is 9", AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            var zipcodevr = await zc.GetZipCode(URLConfig.ZipcodeUrl, zipCode);
                            if (zipcodevr == null || zipcodevr.city == null || zipcodevr.locationLat == null)
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please enter a valid Zipcode", AlertMessages.OkayTitle);
                                isenabel = true;
                                return;

                            }

                            if (isFormValid && ((string.IsNullOrEmpty(mobile))))
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.mobile, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            else
                            {
                                if (ValidatorsFactory.IsValidPhoneUS(mobile) == false)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Not valid mobile number", AlertMessages.OkayTitle);
                                    isenabel = true;
                                    return;
                                }

                            }





                            if (string.IsNullOrEmpty(email))
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.EnterEmail, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            else
                            {
                                if (EmailValidatorHelper.EmailIsValid(email) == false)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Email address is invalid", AlertMessages.OkayTitle);
                                    isenabel = true;
                                    return;
                                }
                            }

                            if (isFormValid && ((string.IsNullOrEmpty(password))))
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Password is required", AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }



                            if (isFormValid && password.Length < 6)
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.passwordlength, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            else
                            {

                                //RegisterBindingModel model = new RegisterBindingModel
                                //{
                                //    email = email,
                                //    firstName = firstName,
                                //    lastName = lastName,
                                //    userType = 3,
                                //    password = password,
                                //    mobile = mobile,
                                //    zipCode = zipCode,
                                //    agreedOnLicense = agreedOnTerms,
                                //    isMale = IsMaleLocal,
                                //};
                                RBM.email = email;
                                RBM.firstName = firstName;
                                RBM.lastName = lastName;
                                //TODO : Why this Value is hard coded 
                                RBM.userType = 3;
                                RBM.password = password;
                                RBM.mobile = mobile;
                                RBM.zipCode = zipCode;
                                RBM.agreedOnLicense = agreedOnTerms;
                                RBM.isMale = IsMaleLocal;
                                //RBM = model;

                                await Navigation.PushModalAsync(new SignUpPartTwo());
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in registerviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }

                });
            }
        }




    }
}

