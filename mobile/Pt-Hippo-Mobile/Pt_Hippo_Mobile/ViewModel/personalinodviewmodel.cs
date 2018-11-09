using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.Model.Upload;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ChangePasswordRest;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.RestClient.ZipCode;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Views;
using Pt_Hippo_Mobile.Vaildation;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class personalinodviewmodel : BaseViewModel
    {
        BasicInfos basicinformations = new BasicInfos();
        Getbasicinfo BasicinfoData = new Getbasicinfo();
        public static bool ReCenterViewToPassword = false;

        ResultImageUpload loadresult = new ResultImageUpload();
        ChangePasswordRestClient CPRCLIENT = new ChangePasswordRestClient();
        Zipcode zc = new Zipcode();
        string old, newpass;
        public string NewPassword
        {
            get { return newpass; }
            set { newpass = value; OnPropertyChangedEventhander(); }
        }
        public string OldPassword
        {
            get { return old; }
            set { old = value; OnPropertyChangedEventhander(); }
        }
        string retype;
        public string Retype
        {
            get { return retype; }
            set { retype = value; OnPropertyChangedEventhander(); }
        }
        private string firstname;

        public string FirstNamelocal
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChangedEventhander();
            }
        }

        private string lastname;

        public string LastNamelocal
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChangedEventhander();
            }
        }
        private string zipcode;

        public string ZipCode
        {
            get { return zipcode; }
            set
            {
                zipcode = value;
                OnPropertyChangedEventhander();
            }
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
       

        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
        }

        private DateTime birthdate;

        public DateTime BirthDate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChangedEventhander();
            }
        }



        private bool ismalelocal;

        public bool IsMale
        {
            get { return ismalelocal; }
            set
            {
                ismalelocal = value;
                OnPropertyChangedEventhander();
            }
        }

        private string email;

        public string Emaillocal
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChangedEventhander();
            }
        }

        private string phone;

        public string Phonelocal
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChangedEventhander();
            }
        }
        List<ImageinfoModel> imageresult;
        public List<ImageinfoModel> ImageResult
        {
            get { return imageresult; }
            set { imageresult = value; OnPropertyChangedEventhander(); }
        }

        EmployeeCurrentData userdata;
        public EmployeeCurrentData Userdata
        {
            get { return userdata; }
            set { userdata = value; OnPropertyChangedEventhander(); }
        }


        public personalinodviewmodel()
        {
            LoadBasicinfo();
            isenabel = true;
        }
        UploadModel photouploadmodel = new UploadModel();
        MediaFile _mediaFile;

        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChangedEventhander(); }
        }

        private async Task<bool> IsPhotorPermissionsGranted()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
                if (status != PermissionStatus.Granted)
                {
                    try
                    {


                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Photos))
                        {
                            MessagingCenter.Send(this, "message", "PTHippo would like to access your Photos to upload your profile picture.");

 
                        }
                       
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Photos });
                        status = results[Permission.Photos];
                        if(status == PermissionStatus.Granted)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in photo Permission on personalinodviewmodel.cs", ex);
                        await logged.LoggAPI();
                    }
                }
                else
                {
                    return true;

                }


            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in personalinodviewmodel.cs", ex);
                await logged.LoggAPI();
            }
            return false;

        }


        public ICommand PickPhoto
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        if(await IsPhotorPermissionsGranted())
                        {
                            isenabel = false;

                            await CrossMedia.Current.Initialize();

                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                return;
                            }

                            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                            if (_mediaFile == null)
                                return;
                            FileImage = _mediaFile.Path;



                            var filename = basicinformations.getfilepath(_mediaFile);
                            filename = Path.GetFileName(filename);
                            var bytearray = basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());

                            // UploadModel photouploadmodel = new UploadModel { IsProfilePic = true };
                            ImageResult = await loadresult.Resultupload(_mediaFile.Path, null, true, DocumentType.Other, true, bytearray, filename, URLConfig.Updatemediafileurl);

                            await basicinformations.UploadMediafile(_mediaFile.Path, null, true, DocumentType.Other, true, bytearray, filename, URLConfig.Updatemediafileurl, "");
                            //await App.Current.MainPage.DisplayAlert("you have Trouble conecting the internet ", "Check your internet Conection", AlertMessages.OkayTitle);
                            MessagingCenter.Send<personalinodviewmodel>(this, "UpdatePersonalInfo");
                            await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.FileUploaded, AlertMessages.OkayTitle);

                        }


                    }


                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in personalinfoviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }

                });

            }

        }


        public async Task LoadBasicinfo()
        {


            try
            {

                    Userdata = UserDataHelper.EmployeeCurrentData;
                    Settings.CurentUserID = Userdata.id;
                    FirstNamelocal = Userdata.firstName;
                    LastNamelocal = Userdata.lastName;
                    Phonelocal = Userdata.mobile;
                    Emaillocal = Userdata.email;
                    IsMale = Userdata.isMale;
                FileImage = constants.uploadsURl + Userdata.profilePicture;
                    ZipCode = Userdata.zipCode;

                    if (Userdata.birthDate.HasValue)
                    {
                        BirthDate = Userdata.birthDate.Value;
                    }
                    else
                    {
                        BirthDate = DateTime.Now;
                    }


                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in personalinfoviewmodel", ex);
                    await logged.LoggAPI();

                }
            
        }
        public ICommand changepasswords
        {
            get
            {

                return new Command(async () =>
                {
                    try
                    {
                        isenabel = false;

                        if (string.IsNullOrEmpty(OldPassword))
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please enter your current password", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(NewPassword))
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please enter your new password", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (string.IsNullOrEmpty(Retype))
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please enter confirm password", AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }

                        if (Retype.Equals(NewPassword) == false)
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Renterpass, AlertMessages.OkayTitle);
                            isenabel = true;
                            return;
                        }
                        ChangePassWord change = new ChangePassWord
                        {
                            newPassword = NewPassword.Trim(),
                            oldPassword = OldPassword.Trim()

                        };

                        ReCenterViewToPassword = true;
                        var succeed = await CPRCLIENT.ChangePasswordAsync(URLConfig.ChangePasswordAsync, change);
                        if (succeed)
                        {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.PasswordChanged, AlertMessages.OkayTitle);
                            Settings.AccessToken = null;
                            await NavigationHelper.INavigator.PushModalAsync(new LoginPage());
                        }

                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in personalinfoviewmodel", ex);
                        await logged.LoggAPI();
                    }
                    finally
                    {
                        isenabel = true;
                    }



                });
            }
        }
        public ICommand PutBasicinfo
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        isenabel = false;


                        if (_mediaFile == null)
                        {

                            bool isFormValid = true;

                            if (string.IsNullOrEmpty(FirstNamelocal) && string.IsNullOrEmpty(LastNamelocal) && string.IsNullOrEmpty(Phonelocal) && string.IsNullOrEmpty(ZipCode) && BirthDate.Date == DateTime.Today.Date && BirthDate == null)
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.AllFieldsAreRequired, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            if (isFormValid && ((string.IsNullOrEmpty(FirstNamelocal))))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.AllFieldsAreRequired, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }


                            if (isFormValid && ((string.IsNullOrEmpty(LastNamelocal))))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.LastNmae, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            if (isFormValid && ((string.IsNullOrEmpty(Phonelocal))))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.mobile, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            else
                            {
                                if (ValidatorsFactory.IsValidPhoneUS(Phonelocal) == false)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Not valid mobile number", AlertMessages.OkayTitle);
                                    isenabel = true;
                                    return;
                                }
                            }

                            if (isFormValid && ((string.IsNullOrEmpty(ZipCode))))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            if (isFormValid && ZipCode.Length < 3)
                            {
                                isFormValid = false;
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.zipcodelength, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }
                            if (isFormValid && (ZipCode.Length > 9))
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.zipcodelength, AlertMessages.OkayTitle);
                                isenabel = true;
                                return;
                            }

                            else
                            {
                                
                                var zipcodevr = await zc.GetZipCode(URLConfig.ZipcodeUrl, ZipCode);
                                if (zipcodevr == null || zipcodevr.city == null || zipcodevr.locationLat == null)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);
                                    isenabel = true;
                                    return;

                                }


                                if (BirthDate >= DateTime.Today.AddYears(-14))
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Birthdate, AlertMessages.OkayTitle);
                                }
                                else

                                {
                                    EmployeeBasicInfo ECD = new EmployeeBasicInfo
                                    {
                                        FirstName = FirstNamelocal,
                                        LastName = LastNamelocal,
                                        Mobile = Phonelocal,
                                        Email = Emaillocal,
                                        IsMale = IsMale,
                                        BirthDate = BirthDate,
                                        ZipCode = ZipCode,
                                        ProfilePicture = Userdata.profilePicture


                                    };
                                    var succed = await basicinformations.PutCurentUserDetailsAsync(URLConfig.Editbasicinfo, ECD);
                                    if (succed)
                                    {
                                        await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                        UserDataHelper.EmployeeCurrentData = await BasicinfoData.GetCurentUserDetailsAsync(URLConfig.UserBasicDataAPI);
                                        await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.AddedMessage, AlertMessages.OkayTitle);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //hena fe bug upload wa zip code kamn
                            if (BirthDate >= DateTime.Now)
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Birthdate, AlertMessages.OkayTitle);
                            }
                            else
                            {
                                EmployeeBasicInfo ECD = new EmployeeBasicInfo
                                {
                                    FirstName = FirstNamelocal,
                                    LastName = LastNamelocal,
                                    Mobile = Phonelocal,
                                    Email = Emaillocal,
                                    IsMale = IsMale,
                                    BirthDate = BirthDate,
                                    ZipCode = ZipCode,
                                    ProfilePicture = ImageResult[0].path


                                };
                                var success = await basicinformations.PutCurentUserDetailsAsync(URLConfig.Editbasicinfo, ECD);

                                if (success)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.EditedMessage, AlertMessages.OkayTitle);

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in personalinfoviewmodel", ex);
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




