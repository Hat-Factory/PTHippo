using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.RestClient.ResumesRest;
using Xamarin.Forms;
using Pt_Hippo_Mobile.LoggedException;
using Pt_Hippo_Mobile.Model.HelperModels;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class AddNewExperience : BaseViewModel
    {
        string wheres, jobtitle, descreption, id, show, documentid;
        DateTime from, to;
        Updateresume apiupdate = new Updateresume();
        bool currentdate;
        BasicInfos basicinformations = new BasicInfos();
        addnewexp newexp = new addnewexp();
        Resume exp = new Resume();
        ResultImageUpload loadresult = new ResultImageUpload();
        public string Whereplace
        {
            get { return wheres; }
            set { wheres = value; }
        }
        public string DocumentId
        {
            get { return documentid; }
            set { documentid = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }
        public string Description
        {
            get { return descreption; }
            set { descreption = value; }
        }
        public string Nameshow
        {
            get { return show; }
            set { show = value; OnPropertyChangedEventhander(); }
        }
        public DateTime Fromtimes
        {
            get { return from; }
            set { from = value; OnPropertyChangedEventhander(); }
        }
        public DateTime Totimes
        {
            get { return to; }
            set { to = value; OnPropertyChangedEventhander(); }
        }
        public bool Current
        {
            get { return currentdate; }
            set { currentdate = value; OnPropertyChangedEventhander(); }
        }
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
        public INavigation Navigation { get; set; }

        List<ImageinfoModel> imageresult;
        public List<ImageinfoModel> ImageResult
        {
            get { return imageresult; }
            set { imageresult = value; OnPropertyChangedEventhander(); }
        }
        Plugin.FilePicker.Abstractions.FileData _mediaFile;

        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChangedEventhander(); }
        }


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

        private string showfile;
        public string ShowName
        {
            get { return showfile; }
            set
            {
                showfile = value;
                OnPropertyChangedEventhander();
            }
        }
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
                        await CrossMedia.Current.Initialize();

                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            var action = await App.Current.MainPage.DisplayActionSheet("Upload License", "Cancel", null, "Photo Roll", "Files");
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
                                        isenabel = true;
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
                                        var splittedPath = fileinfo.Path.Split('/');
                                        var fullFileName = splittedPath[splittedPath.Length - 1].Trim();
                                        FileImage = fullFileName;
                                        iOSFileInfo = fileinfo;
                                        ImageResult = await loadresult.Resultupload(iOSFileInfo.Path, DocumentId, false, DocumentType.CoverLetter, true, DependencyService.Get<Interface.IFilePicker>().GetAllBytes(iOSFileInfo.Path), FileImage, URLConfig.Updatemediafileurl);
                                        if (ImageResult != null)
                                        {
                                            Nameshow = ImageResult[0].path;
                                            Helpers.TextHelper.MaxLength = 20;

                                            if (Nameshow.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                            {

                                                Nameshow = TextHelper.TextTrimmer(Nameshow);
                                            }
                                            DocumentId = ImageResult[0].id;
                                            await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                                        }
                                    }
                                });
                            }
                            else if(action == "Photo Roll")
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
                                ImageResult = await loadresult.Resultupload(_mediaFile.Path, DocumentId, false, DocumentType.License, true, bytearray, filename, URLConfig.Updatemediafileurl);

                                if (ImageResult != null)
                                {
                                    Nameshow = ImageResult[0].path;
                                    Helpers.TextHelper.MaxLength = 20;

                                    if (Nameshow.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                    {

                                        Nameshow = TextHelper.TextTrimmer(Nameshow);
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
                                    }

                                }


                            

                            isenabel = true;

                            var bytearray = _mediaFile.DataArray;

                            ImageResult = await loadresult.Resultupload("C:/Users/Ashraf Naser/Desktop/PT-Hippo/mobile/Pt-Hippo-Mobile/ Pt_Hippo_Mobile.UWP/Assets/background_2.png", DocumentId, false, DocumentType.Resume, true, bytearray, _mediaFile.FileName, URLConfig.Updatemediafileurl);
                            if (ImageResult != null)
                            {
                                Nameshow = ImageResult[0].path;
                                Helpers.TextHelper.MaxLength = 20;

                                if (Nameshow.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                {

                                    Nameshow = TextHelper.TextTrimmer(Nameshow);
                                }
                                DocumentId = ImageResult[0].id;
                                await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                            }
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


        public void bindlistdata()
        {

            foreach (var item in constants.expirenceitem)
            {

                Whereplace = item.workLocation;
                Fromtimes = Convert.ToDateTime(item.startDate);
                Totimes = Convert.ToDateTime(item.endDate);
                Jobtitle = item.@as;
                Description = item.doing;
                Id = item.id;
                Current = item.isCurrentWork;
                DocumentId = item.documentId;
                Nameshow = item.originalFileName;
                Helpers.TextHelper.MaxLength = 20;

                if (Nameshow != null && Nameshow.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                {

                    Nameshow = TextHelper.TextTrimmer(Nameshow);
                }

            }

            if (Current)
            {
                Totimes = DateTime.MinValue;
            }
        }
        public AddNewExperience()
        {

        }
        public AddNewExperience(INavigation nav)
        {
            this.Navigation = nav;
            isenabel = true;
            isenabelbtn = true;
            bindlistdata();
        }
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
        public ICommand SaveExp
        {

            get

            {

                return new Command(async () =>
                {

                    try
                    {

                        isenabel = false;
                        bool isFormValid = true;
                        if (isFormValid && ((string.IsNullOrEmpty(Whereplace))))

                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Where is required", AlertMessages.OkayTitle);
                            return;
                        }
                        if (isFormValid && ((string.IsNullOrEmpty(Jobtitle))))

                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Job Title is required", AlertMessages.OkayTitle);
                            return;
                        }
                        if (isFormValid && ((string.IsNullOrEmpty(Description))))

                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Job Description is required", AlertMessages.OkayTitle);
                            return;
                        }
                        if (isFormValid && Fromtimes == null || Fromtimes.Date >= DateTime.Today.Date)

                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Inavlid From Date", AlertMessages.OkayTitle);
                            return;
                        }
                        if ((isFormValid && Totimes == null || Totimes.Date >= DateTime.Today.Date) && Current == false)
                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Inavlid To Date", AlertMessages.OkayTitle);
                            return;
                        }

                        if ((Fromtimes == null || Fromtimes == DateTime.MinValue))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select From Date", AlertMessages.OkayTitle);
                            return;
                        }

                        if ((Totimes == null || Totimes == DateTime.MinValue) && Current == false)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please select To Date", AlertMessages.OkayTitle);
                            return;
                        }

                        if (Totimes.Date <= Fromtimes.Date && Current == false)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "To Date must be greater than From Date", AlertMessages.OkayTitle);
                            return;
                        }



                        if (Id == null)
                        {
                       
                            exp = new Resume
                            {
                                workLocation = Whereplace,
                                startDate = Fromtimes.ToString("MM/dd/yy"),
                                endDate = Totimes.ToString("MM/dd/yy"),
                                isCurrentWork = Current,
                                @as = Jobtitle,
                                doing = Description,
                                originalFileName = FileImage,
                                documentId = DocumentId

                            };

                            var succed = await newexp.AddnewExp(URLConfig.AddExp, exp);
                            if (succed != null)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                                Id = succed.id;
                                await Navigation.PopAsync();

                            }

                        }
                        else
                        {
                            DateTime end = Totimes;
                            if (Current)
                            {
                                end = DateTime.MinValue;
                            }

                            exp = new Resume
                            {
                                id = Id,
                                workLocation = Whereplace,
                                startDate = Fromtimes.ToString(),
                                endDate = end.ToString(),
                                isCurrentWork = Current,
                                @as = Jobtitle,
                                doing = Description,
                                originalFileName = Nameshow,
                                documentId = DocumentId

                            };

                            var succed = await apiupdate.Updatespecficresume(URLConfig.UpdateResume, exp);
                            if (succed != null && succed == true)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                                await Navigation.PopAsync();

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in addnewexperinceviewmodel", ex);
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
