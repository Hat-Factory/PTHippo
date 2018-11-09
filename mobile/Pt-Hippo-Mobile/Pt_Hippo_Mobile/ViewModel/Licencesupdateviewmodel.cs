using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Licences;
using Xamarin.Forms;
using System.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using System.IO;
using Plugin.FilePicker;
using Pt_Hippo_Mobile.Model.HelperModels;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class Licencesupdateviewmodel : BaseViewModel
    {
        AddLicence apiadd = new AddLicence();
        licensesModel DATA;
        BasicInfos basicinformations = new BasicInfos();
        Updatelicence updated = new Updatelicence();
        string licencetitle, licencenumber, state, collage, statename, documentid, showfile;
        DateTime expiredate;
        ResultImageUpload loadresult = new ResultImageUpload();
        public static statemodel _selectedState;
        public static licencetype _selectedlicencetype;

        public Licencesupdateviewmodel()
        {
            _selectedState = null;
            //_selectedlicencetype = null;
            filedata = new Plugin.FilePicker.Abstractions.FileData();
            if (SelectedLicenseType == null)
            {
                SelectedLicenseType = new licencetype();
            }



        }

        private string id;
        public DateTime Expiredate
        {
            get { return expiredate; }
            set
            {
                expiredate = value;
                OnPropertyChangedEventhander();
            }
        }
        public string LicenceTitle
        {
            get { return licencetitle; }
            set
            {
                if (licencetitle != value && value != null)
                {
                    licencetitle = value;
                    OnPropertyChangedEventhander();
                }

            }
        }


        public string Licencenumber
        {
            get { return licencenumber; }
            set
            {
                licencenumber = value;
                OnPropertyChangedEventhander();
            }
        }
        public string Collage
        {
            get { return collage; }
            set
            {
                collage = value;
                OnPropertyChangedEventhander();
            }
        }
        public string SateName
        {
            get { return statename; }
            set
            {
                statename = value;
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
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChangedEventhander();
            }
        }

        public Licencesupdateviewmodel(INavigation nav)
        {
            this.Navigation = nav;
            isenabel = true;
            isenabelbtn = true;

            LicenceTypees = Pt_Hippo_Mobile.Helpers.LicenseHelper.LicenceTypes;
            StatesList = Pt_Hippo_Mobile.Helpers.LicenseHelper.StatesList;
            bindlistdata();
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
        Plugin.FilePicker.Abstractions.FileData _mediaFile;

        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChangedEventhander(); }
        }

        List<ImageinfoModel> imageresult;
        public List<ImageinfoModel> ImageResult
        {
            get { return imageresult; }
            set { imageresult = value; OnPropertyChangedEventhander(); }
        }

        private Plugin.FilePicker.Abstractions.FileData _filedata;
        public Plugin.FilePicker.Abstractions.FileData filedata
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

        Model.HelperModels.FileInfo iOSFileInfo;


        public INavigation Navigation { get; set; }

        public void bindlistdata()
        {

            foreach (var item in constants.licencesitem)
            {
                Id = item.id;
                DocumentId = item.DocumentId;
                Licencenumber = item.licenseNumber;
                Collage = item.college;
                SateName = item.state;
                LicenceTitle = item.typeText;
                Expiredate = Convert.ToDateTime(item.expirationDate);
                SelectedState = StatesList.FirstOrDefault(q => q.stateAbb == item.state);
                SelectedLicenseType = LicenceTypees.FirstOrDefault(q => q.title == item.typeText);
                ShowName = item.originalFileName;
                // DocumentId = item.documentId;
            }
        }


        List<licencetype> licenceTypes;
        public List<licencetype> LicenceTypees
        {
            get
            {
                return licenceTypes;

            }
            set
            {
                licenceTypes = value;

                OnPropertyChangedEventhander();
            }
        }
        List<statemodel> states;
        public List<statemodel> StatesList
        {
            get
            {
                return states;

            }
            set
            {
                states = value;

                OnPropertyChangedEventhander();
            }
        }


        public string Message { get; set; }
        //bool isselected;

        public static licencetype SelectedLicenseType
        {
            get { return _selectedlicencetype; }
            set
            {
                if (_selectedlicencetype != value && value != null)
                {
                    _selectedlicencetype = value;

                    //OnPropertyChangedEventhander();
                }
            }
        }

        public statemodel SelectedState
        {
            get { return _selectedState; }
            set
            {
                if (_selectedState != value && value != null)
                {
                    _selectedState = value;

                    OnPropertyChangedEventhander();
                }
            }
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
                                            await App.Current.MainPage.DisplayAlert("Unsupported", "Application file provider not supported", "Ok");
                                        });
                                    }
                                    else
                                    {
                                        var splittedPath = fileinfo.Path.Split('/');
                                        var fullFileName = splittedPath[splittedPath.Length - 1].Trim();
                                        FileImage = fullFileName;
                                        iOSFileInfo = fileinfo;
                                        ImageResult = await loadresult.Resultupload(iOSFileInfo.Path, DocumentId, false, DocumentType.License, true, DependencyService.Get<Interface.IFilePicker>().GetAllBytes(iOSFileInfo.Path), FileImage, URLConfig.Updatemediafileurl);
                                        if (ImageResult != null)
                                        {
                                            ShowName = ImageResult[0].path;
                                            Helpers.TextHelper.MaxLength = 20;

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
                                //iOSFileInfo.MimeType = _mediaFile.AlbumPath;
                                ImageResult = await loadresult.Resultupload(_mediaFile.Path, DocumentId, false, DocumentType.License, true, bytearray, filename, URLConfig.Updatemediafileurl);

                                if (ImageResult != null)
                                {
                                    ShowName = ImageResult[0].path;
                                    Helpers.TextHelper.MaxLength = 20;

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

                                    }

                                }





                                var filename = _mediaFile.FileName;
                                //Path.GetFileName(filename);
                                var bytearray = _mediaFile.DataArray;
                                //basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());
                                //fake path sorry 

                                ImageResult = await loadresult.Resultupload("C:/Users/Ashraf Naser/Desktop/PT - Hippo/mobile/Pt-Hippo-Mobile/ Pt_Hippo_Mobile.UWP / Assets / background_2.png", DocumentId, false,
                                    DocumentType.License, true, bytearray, filename, URLConfig.Updatemediafileurl);
                                if (ImageResult != null)
                                {
                                    ShowName = ImageResult[0].path;
                                    Helpers.TextHelper.MaxLength = 20;

                                    if (ShowName.Length > Helpers.TextHelper.MaxLength) //If it is more than the character restriction
                                    {
                                        ShowName = TextHelper.TextTrimmer(ShowName);
                                    }
                                    DocumentId = ImageResult[0].id;
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.FileUploaded,
                                        AlertMessages.OkayTitle);
                                }

                            }
                        }
                    }
                    catch (Exception e)
                    {

                        var logged = new LoggedException.LoggedException("Error in liceneviewmodel", e);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }
                });

            }

        }
        public ICommand SaveData
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {

                        isenabelbtn = false;


                        bool isFormValid = true;

                        // satrt validation
                        if (isFormValid && SelectedLicenseType == null)
                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "License is required", AlertMessages.OkayTitle);
                            return;
                        }

                        if (isFormValid && ((string.IsNullOrEmpty(Licencenumber))))
                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "License Number is required", AlertMessages.OkayTitle);
                            return;
                        }

                        //if (isFormValid && SelectedState == null)
                        //{
                        //    isFormValid = false;
                        //    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "State is required", AlertMessages.OkayTitle);
                        //    return;
                        //}
                        if (String.IsNullOrEmpty(SateName) || String.IsNullOrWhiteSpace(SateName))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Statenull, AlertMessages.OkayTitle);
                            return;
                        }
                        else
                        {
                            var tempstatename = StatesList.Where(x => x.stateAbb == SateName);
                            if (tempstatename != null)
                            {
                                var tempsecond = tempstatename.FirstOrDefault(s => s.stateAbb == statename);
                                if (tempsecond != null)
                                {
                                    if (!string.IsNullOrEmpty(tempsecond.stateAbb))
                                    {
                                        SateName = tempsecond.stateAbb;
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                        return;
                                    }
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                    return;
                                }

                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                return;
                            }
                        }
                        if (isFormValid && Expiredate == null)
                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Expire Date is required", AlertMessages.OkayTitle);
                            return;
                        }

                        if (isFormValid && ((string.IsNullOrEmpty(Collage))))
                        {
                            isFormValid = false;
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Collage Name is required", AlertMessages.OkayTitle);
                            return;
                        }

                        if (DocumentId == null)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Uploadfile, AlertMessages.OkayTitle);
                            return;
                        }
                        // end validation
                        //add new one 
                        if (Id == null)
                        {
                            if ((Device.RuntimePlatform == Device.Android && _mediaFile == null) || (Device.RuntimePlatform == Device.iOS && iOSFileInfo == null))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Uploadfile, AlertMessages.OkayTitle);
                                return;
                            }

                            if (String.IsNullOrEmpty(SateName) || String.IsNullOrWhiteSpace(SateName))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Statenull, AlertMessages.OkayTitle);
                                return;
                            }
                            else
                            {
                                var tempstatename = StatesList.Where(x => x.stateAbb == SateName);
                                if (tempstatename != null)
                                {
                                    var tempsecond = tempstatename.FirstOrDefault(s => s.stateAbb == statename);
                                    if (tempsecond != null)
                                    {
                                        if (!string.IsNullOrEmpty(tempsecond.stateAbb))
                                        {
                                            SateName = tempsecond.stateAbb;
                                        }
                                        else
                                        {
                                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                        return;
                                    }

                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                    return;
                                }
                            }
                            LicenceTitle = SelectedLicenseType.title;

                            DATA = new licensesModel
                            {
                                id = null,
                                licenseNumber = Licencenumber,
                                state = SateName,
                                expirationDate = Expiredate,
                                college = Collage,
                                DocumentId = ImageResult[0].id,
                                type = Convert.ToInt16(SelectedLicenseType.id),
                                originalFileName = ImageResult[0].path

                            };
                            var succed = await apiadd.Addnewlicence(URLConfig.Addlicence, DATA);
                            if (succed != null)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                                await Navigation.PopAsync();
                                Id = succed.id;
                            }
                        }
                        //edite existing
                        else
                        {
                            if (String.IsNullOrEmpty(SateName) || String.IsNullOrWhiteSpace(SateName))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Statenull, AlertMessages.OkayTitle);
                                return;
                            }
                            else
                            {
                                var tempstatename = StatesList.Where(x => x.stateAbb == SateName);
                                if (tempstatename != null)
                                {
                                    var tempsecond = tempstatename.FirstOrDefault(s => s.stateAbb == statename);
                                    if (tempsecond != null)
                                    {
                                        if (!string.IsNullOrEmpty(tempsecond.stateAbb))
                                        {
                                            SateName = tempsecond.stateAbb;
                                        }
                                        else
                                        {
                                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                        return;
                                    }

                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                    return;
                                }
                            }
                            LicenceTitle = SelectedLicenseType.title;

                            DATA = new licensesModel
                            {
                                id = Id,
                                licenseNumber = Licencenumber,
                                state = SateName,
                                expirationDate = Expiredate,
                                college = Collage,
                                DocumentId = DocumentId,
                                type = Convert.ToInt16(SelectedLicenseType.id),
                                //TODO : CHECK HTIS LATER ON 
                                originalFileName = ShowName
                            };

                            var succeds = await updated.Updatespecficlicence(URLConfig.UpdateLicence, id, DATA);
                            if (succeds)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                                await Navigation.PopAsync();
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in licenceupdateviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabelbtn = true;
                    }
                });
            }
        }

    }
}
