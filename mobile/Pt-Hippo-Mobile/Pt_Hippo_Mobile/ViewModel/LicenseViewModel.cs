using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.RestClient.Licences;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class LicenseViewModel : BaseViewModel
    {
        LicensebyDocType UBI = new LicensebyDocType();
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

        private List<FileData> _filedata;

        public List<FileData> FileData
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
        MediaFile _mediaFile;

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

        public ICommand PickFile
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
                            await CrossMedia.Current.Initialize();

                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                return;
                            }

                            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                            if (_mediaFile == null)
                                return;
                            FileImage = _mediaFile.Path;

                            FileNameForDc = basicinformations.getfilepath(_mediaFile);
                            filleNameForDisplay = System.IO.Path.GetFileNameWithoutExtension(FileNameForDc);
                            Filebytearraytoupload = basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());

                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error in licenceviewmodel", ex);
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
        string emptydocid;
        public ICommand Save
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

                            if (_mediaFile == null)
                                return;
                            if (Filebytearraytoupload == null)
                                return;
                            if (string.IsNullOrEmpty(FileNameForDc))
                                return;

                            else
                                //await basicinformations.UploadMediafile(_mediaFile, true,null, true, Filebytearraytoupload, FileNameForDc, URLConfig.Updatemediafileurl , emptydocid , "");
                                await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);

                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error in licenceviewmodel", ex);
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

        public async void SaveEvent(string Doctype, string filetitle)
        {
            try
            {

                if (_mediaFile == null)
                    return;
                if (Filebytearraytoupload == null)
                    return;
                if (string.IsNullOrEmpty(FileNameForDc))
                    return;
                else

                    //await basicinformations.updatemediafile(_mediaFile, false, Doctype, true, Filebytearraytoupload, FileNameForDc, URLConfig.Updatemediafileurl, emptydocid , filetitle);
                    await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in licenceviewmodel", ex);
                await logged.LoggAPI();

            }
        }

        public async void UpdateExistingLicense(string docID, string documenttype, string filetitle)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                try
                {

                    if (_mediaFile == null)
                        return;
                    if (Filebytearraytoupload == null)
                        return;
                    if (string.IsNullOrEmpty(FileNameForDc))
                        return;
                    else
                        //leaks of the DocType So Fetch  it to add befor send it ..
                        //await basicinformations.UploadMediafile(_mediaFile, true, documenttype, true, Filebytearraytoupload, FileNameForDc, URLConfig.Updatemediafileurl , docID , filetitle);
                        await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);

                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("licenceviewmodel.cs ", ex);
                    logged.LoggAPI();
                    //throw new Exception("Error in licenceviewmodel", ex);

                }

            }
            finally
            {
                IsBusy = false;
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

        public LicenseViewModel()
        {
            FileData = new List<Plugin.FilePicker.Abstractions.FileData>();
            FileName = new ObservableCollection<LicencesDocumentModel>();
            UploadedtimeResponse = new uploadeditemresponse();
            LicensesDataListView = new ObservableCollection<licensesModel>();
            Basicinfos = new List<LicencesDocumentModel>();
            SingleFile = new Plugin.FilePicker.Abstractions.FileData();
            //filleNameForDisplay = 
        }

        static int docutype;


        public async void BindingMethod(int doctype)
        {
            docutype = doctype;
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                Basicinfos = await UBI.GetDocByType(URLConfig.getDocumentsByTypeUrl, doctype);

                ObservableCollection<LicencesDocumentModel> CastList = new ObservableCollection<LicencesDocumentModel>(Basicinfos);
                // LicensesDataListView = CastList;
                var Temp = CastList.Where(x => x.documentType == doctype);
                var myObservableCollection = new ObservableCollection<LicencesDocumentModel>(Temp);
                FileName = myObservableCollection;
                foreach (var item in FileName)
                {
                    item.FileName = System.IO.Path.GetFileNameWithoutExtension(item.filePath);
                    item.Dateformated = item.createDate.ToString("d");
                }

            }
            finally
            {
                IsBusy = false;
            }

        }


        private string yourSelectedItem;

        public string YourSelectedItem
        {
            get
            {
                return yourSelectedItem;
            }
            set
            {
                yourSelectedItem = value;
                OnPropertyChangedEventhander();
            }
        }

        public ICommand DeleteL
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

                       var xselection = FileData.Single(x => x.FileName == YourSelectedItem);
                       FileData.Remove(xselection);
                       await App.Current.MainPage.DisplayAlert("", AlertMessages.FileDeleted, AlertMessages.OkayTitle);

                   }
                   finally
                   {

                       IsBusy = false;
                   }


               });

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

  


        public ICommand PickFilepdf
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {


                        var crossFilePicker = Plugin.FilePicker.CrossFilePicker.Current.PickFile();
                        filedata = await crossFilePicker;
                        if (filedata != null)
                        {
                            
                            if (filedata.DataArray != null)
                            { 
                                if (filedata.FileName == null || string.IsNullOrEmpty(filedata.FileName))
                                    filedata.FileName = "Pt_Hipp_Document.pdf";
                                if (filedata.FileName != null)
                                {
                                    await basicinformations.UploadMediafile("C:/Users/Ashraf Naser/Desktop/PT-Hippo/mobile/Pt-Hippo-Mobile/Pt_Hippo_Mobile.UWP/Assets/background_2.png", null, false, DocumentType.Resume, true, filedata.DataArray, filedata.FileName, URLConfig.Updatemediafileurl, null);
                                }
                                return;
                            }
                            return;
                        }
                        return;
                    }
                    catch (Exception ex)
                    {

                        var logged = new LoggedException.LoggedException("LicenseViewModel.cs ", ex);
                        logged.LoggAPI();
                    }
                });

            }

        }
    }
}
