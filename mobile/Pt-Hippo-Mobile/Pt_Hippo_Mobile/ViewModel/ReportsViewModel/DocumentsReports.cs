using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.RestClient.Licences;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using System.IO;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Model.HelperModels;

namespace Pt_Hippo_Mobile.ViewModel.ReportsViewModel
{
    class DocumentsReports : BaseViewModel
    {
        ResultImageUpload loadresult = new ResultImageUpload();
        LicensebyDocType UBI = new LicensebyDocType();
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
        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
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

        public INavigation Navigation { get; set; }

        List<licensesModel> _LicensesModel = new List<licensesModel>();

        public uploadeditemresponse UploadedtimeResponse { get; set; }

        private FileData _filedata;

        public FileData FileData
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


        private FileData singlefile;

        public FileData SingleFile
        {
            get
            {
                return singlefile;
            }
            set
            {
                singlefile = value;
                OnPropertyChangedEventhander();
            }
        }

        private ObservableCollection<LicencesDocumentModel> filename;
        public ObservableCollection<LicencesDocumentModel> FileName
        {
            get { return filename; }
            set { filename = value; OnPropertyChangedEventhander(); }
        }
        public FileData filedata = new FileData();
        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChangedEventhander(); }
        }
        FileData _mediaFile;
        Model.HelperModels.FileInfo iOSFileInfo;


        BasicInfos basicinformations = new BasicInfos();
        private string filenamefordoc;

        public string FileNameForDc
        {
            get { return filenamefordoc; }
            set
            {
                filenamefordoc = value;
                OnPropertyChangedEventhander();
            }
        }


        private string fllnamefdisplay;

        public string filleNameForDisplay
        {
            get { return fllnamefdisplay; }
            set
            {
                fllnamefdisplay = value;
                OnPropertyChangedEventhander();
            }
        }


        private byte[] filenametoupload;

        public byte[] Filebytearraytoupload
        {
            get { return filenametoupload; }
            set { filenametoupload = value; }
        }



        List<ImageinfoModel> imageresult;
        public List<ImageinfoModel> ImageResult
        {
            get { return imageresult; }
            set { imageresult = value; OnPropertyChangedEventhander(); }
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
        public string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChangedEventhander(); }
        }

        DocumentType doctype;
        public DocumentType DocTypes
        {
            get { return doctype; }
            set { doctype = value; OnPropertyChangedEventhander(); }
        }
        string documentid;
        public string DocumentId
        {
            get { return documentid; }
            set
            {
                documentid = value;
                OnPropertyChangedEventhander();
            }
        }
        private string _showname;

        public string ShowName
        {
            get { return _showname; }
            set
            {
                _showname = value;
                OnPropertyChangedEventhander();
            }
        }

        public ICommand PickPhoto
        {
            get
            {
                return new Command(async () =>
                {
                    string filename;
                    try
                    {
                        isenabel = false;

                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            string UiActionShettTitle = "Upload"; 
                            if (constants.CurrentDocumentType == DocumentType.initial)
                            {
                                UiActionShettTitle = " Upload Medical Report ";

                            }
                            else if (constants.CurrentDocumentType == DocumentType.MedicalReports)
                            {
                                UiActionShettTitle = " Upload Medical Report ";
                            }
                            else if (constants.CurrentDocumentType == DocumentType.LiabilityInsurance)
                            {
                                UiActionShettTitle = " Upload Liability Insurance ";
                            }
                            else if (constants.CurrentDocumentType == DocumentType.BackgroundCheck)
                            {
                                UiActionShettTitle = " Upload Background Check ";
                            }
                            var action = await App.Current.MainPage.DisplayActionSheet(UiActionShettTitle, "Cancel", null, "Photo Roll", "Files");
                            if (action == "Files")
                            {
                                await DependencyService.Get<Interface.IFilePicker>().FilePick((fileinfo) =>
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
                                        ShowName = FileImage;
                                        Helpers.TextHelper.MaxLength = 20;

                                        if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                        {

                                            ShowName = TextHelper.TextTrimmer(ShowName);
                                        }
                                        iOSFileInfo = fileinfo;
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
                                filename = basicinformations.getfilepath(_mediaFile);
                                filename = Path.GetFileName(filename); 
                                iOSFileInfo = new FileInfo();
                                iOSFileInfo.Path = _mediaFile.Path;
                                FileImage = filename;
                                ShowName = filename;
                                 Helpers.TextHelper.MaxLength = 20; 
                                    if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                    { 
                                        ShowName = TextHelper.TextTrimmer(ShowName);
                                    } 
                            }
                            
                        }

                        else if (Device.RuntimePlatform == Device.Android)
                        {

                            var crossFilePicker = Plugin.FilePicker.CrossFilePicker.Current.PickFile();
                            string name = filedata.FileName;
                            filedata = await crossFilePicker;
                            if (filedata != null)
                            {
                                if (filedata.DataArray != null)
                                {
                                    if (filedata.FileName == null || string.IsNullOrEmpty(filedata.FileName))
                                        filedata.FileName = "Pt_Hipp_Document.pdf";
                                    if (filedata.FileName != null)
                                    {
                                        _mediaFile = filedata;
                                        FileImage = filedata.FileName;
                                        ShowName = FileImage;
                                        Helpers.TextHelper.MaxLength = 20;

                                        if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                        {

                                            ShowName = TextHelper.TextTrimmer(ShowName);
                                        }

                                    }

                                }

                            }
                            isenabel = true;
                        }
                    }
                    catch (Exception e)
                    {
                        var logged = new LoggedException.LoggedException("Error in Documentreport", e);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }
                });

            }

        }
        public ICommand save_edit
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        isenabel = false;
                        byte[] bytearray = null;
                        if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle,
                                "Add file title ", AlertMessages.OkayTitle);
                            return;
                        }
                        if (string.IsNullOrEmpty(Title) == false && Title.Length > 50)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle,
                                "Maximum title length is 50", AlertMessages.OkayTitle);
                            return;
                        }
                       
                        string filepath = string.Empty;

                        if (DocumentId == null)
                        {
                            if ((Device.RuntimePlatform == Device.Android && _mediaFile == null) || (Device.RuntimePlatform == Device.iOS && iOSFileInfo == null))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Uploadfile, AlertMessages.OkayTitle);

                                return;

                            }

                            DocTypes = constants.CurrentDocumentType;

                            if (Device.RuntimePlatform == Device.Android)
                            {
                                if (_mediaFile != null)
                                {
                                    //TODO:fake path 
                                    filepath = "C:/Users/Ashraf Naser/Desktop/PT - Hippo/mobile/Pt-Hippo-Mobile/ Pt_Hippo_Mobile.UWP / Assets / background_2.png";
                                    bytearray = _mediaFile.DataArray;
                                    //basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());
                                }

                            }
                            else if (Device.RuntimePlatform == Device.iOS)
                            {
                                if (iOSFileInfo != null)
                                {
                                    filepath = iOSFileInfo.Path;
                                    bytearray = DependencyService.Get<Interface.IFilePicker>()
                                        .GetAllBytes(iOSFileInfo.Path); 
                                }

                            }
                            ImageResult = await loadresult.Resultupload(filepath, DocumentId, false, DocTypes, true,
                                bytearray, FileImage, URLConfig.Updatemediafileurl, Title);
                            if (ImageResult != null)
                            {
                                DocumentId = ImageResult[0].id;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.Success,
                                    AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                                await Navigation.PopAsync();
                            }

                        }
                        else
                        {


                            if (Device.RuntimePlatform == Device.Android)
                            {
                                if (_mediaFile != null)
                                {
                                    //TODO:fake path 
                                    filepath = "C:/ Users / Ashraf Naser / Desktop / PT - Hippo / mobile / Pt - Hippo - Mobile / Pt_Hippo_Mobile.UWP / Assets / background_2.png";
                                    bytearray = _mediaFile.DataArray;
                                }
                            }
                            else if (Device.RuntimePlatform == Device.iOS)
                            {
                                if (iOSFileInfo != null)
                                {
                                    filepath = iOSFileInfo.Path;
                                    bytearray = DependencyService.Get<Interface.IFilePicker>()
                                        .GetAllBytes(iOSFileInfo.Path);
                                }

                            }

                            ImageResult = await loadresult.Resultupload(filepath, DocumentId, false, DocTypes, true,
                                bytearray, FileImage, URLConfig.Updatemediafileurl, Title);
                            if (ImageResult != null)
                            {
                                DocumentId = ImageResult[0].id;
                                await App.Current.MainPage.DisplayAlert("", AlertMessages.EditedMessage,
                                    AlertMessages.OkayTitle);
                                await Navigation.PopAsync();
                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException(" Error in documentreportsviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }


                });

            }
        }





        private List<LicencesDocumentModel> basicinfos;

        public List<LicencesDocumentModel> Basicinfos
        {
            get { return basicinfos; }
            set
            {
                basicinfos = value;
                OnPropertyChangedEventhander();
            }
        }
        public DocumentsReports(INavigation nav)
        {
            this.Navigation = nav;
            isenabel = true;
            reciveddata();
            FileData = new Plugin.FilePicker.Abstractions.FileData();
            FileName = new ObservableCollection<LicencesDocumentModel>();
            UploadedtimeResponse = new uploadeditemresponse();
            LicensesDataListView = new ObservableCollection<licensesModel>();
            Basicinfos = new List<LicencesDocumentModel>();
            SingleFile = new Plugin.FilePicker.Abstractions.FileData();


        }
        public DocumentsReports()
        {


        }

        string date;
        public string creationdate
        {
            get { return date; }
            set { date = value; OnPropertyChangedEventhander(); }
        }
        public void reciveddata()
        {
            foreach (var item in constants.backgroundchecklist)
            {
                Title = item.title;
                DocumentId = item.id;
                FileImage = item.originalFileName;
                ShowName = FileImage;
                Helpers.TextHelper.MaxLength = 20;

                if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                {

                    ShowName = TextHelper.TextTrimmer(ShowName);
                }
                creationdate = item.createDate.ToString();
                DocTypes = (DocumentType)item.documentType;
            }

        }
        static int docutype;


        public async void BindingMethod(int doctype)
        {
            docutype = doctype;

            try
            {

                Basicinfos = await UBI.GetDocByType(URLConfig.getDocumentsByTypeUrl, doctype);

                ObservableCollection<LicencesDocumentModel> CastList = new ObservableCollection<LicencesDocumentModel>(Basicinfos);
                var Temp = CastList.Where(x => x.documentType == doctype);
                var myObservableCollection = new ObservableCollection<LicencesDocumentModel>(Temp);
                var sortinglist = new ObservableCollection<LicencesDocumentModel>(myObservableCollection.OrderByDescending(x => x.createDate).ToList());
                FileName = sortinglist;
                foreach (var item in FileName)
                {
                    item.FileName = System.IO.Path.GetFileNameWithoutExtension(item.filePath);
                    item.Dateformated = item.createDate.ToString("d");
                    // item.title= TextHelper.TextTrimmer(item.title);
                    // DocumentId = item.id;
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException(" Error in documentreportsviewmodel", ex);
                await logged.LoggAPI();
            }


        }

    }
}
