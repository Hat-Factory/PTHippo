using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.Upload;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Pt_Hippo_Mobile.RestClient.ZipCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class UploadPhotoViewModel : INotifyPropertyChanged
    {
        

        BasicInfos basicinformations = new BasicInfos();
        Getbasicinfo BasicinfoData = new Getbasicinfo();
        Zipcode zc = new Zipcode();
        private string zipcode;

        public string ZipCode
        {
            get { return zipcode; }
            set
            {
                zipcode = value;
                OnPropertyChanged();
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
        private bool isBEnabeld;

        public bool IsBEnabeld
        {
            get { return isBEnabeld; }
            set
            {
                isBEnabeld = value;
                OnPropertyChanged();
            }
        }


        private DateTime birthdate;

        public DateTime BirthDate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChanged();
            }
        }

        private string firstname;

        public string FirstNamelocal
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }

        private string lastname;

        public string LastNamelocal
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }

        private bool IsMale;

        public bool isMaleLocal
        {
            get { return IsMale; }
            set
            {
                IsMale = value;
                OnPropertyChanged();
            }
        }


        private string email;

        public string Emaillocal
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string phone;

        public string Phonelocal
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        private int select;

        public int Selectt
        {
            get { return select; }
            set
            {
                select = value;
                OnPropertyChanged();
            }
        }



        public UploadPhotoViewModel()
        {
            IsBEnabeld = false;
            BindingMethod();

            FileImage = "avatar.png";
        }

        UploadModel photouploadmodel = new UploadModel();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string fileimage;

        public string FileImage
        {
            get { return fileimage; }

            set
            { fileimage = value; OnPropertyChanged(); }
        }



        MediaFile _mediaFile;



        public ICommand PickPhoto
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
                            isBEnabeld = true;
                            var filename = basicinformations.getfilepath(_mediaFile);
                            var bytearray = basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());
                            await basicinformations.UploadMediafile(_mediaFile.Path,null, true, DocumentType.Other, true, bytearray, filename, URLConfig.Updatemediafileurl  , null);
                            await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);
                        }
                        finally
                        {

                            
                            IsBusy = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in uploadphotoviewmodel", ex);
                        await logged.LoggAPI();
                    }
                   
                   
                });

            }

        }




     
        //Local Refer to the local vars not the one comming from the Api !
        public async void BindingMethod()
        {
            if (IsBusy)
                return;


            try
            {
                IsBusy = true;
                try
                {
                    var data = UserDataHelper.EmployeeCurrentData;
                    Settings.CurentUserID = data.id;
                    FirstNamelocal = data.firstName;
                    LastNamelocal = data.lastName;
                    Phonelocal = data.mobile;
                    Emaillocal = data.email;
                    isMaleLocal = data.isMale;
                    ZipCode = data.zipCode;
                    if (data.birthDate.HasValue)
                    {
                        BirthDate = data.birthDate.Value;
                    }
                    else
                    {
                        BirthDate = DateTime.Now;
                    }

                    if (isMaleLocal == true)
                    {
                        Selectt = 0;
                    }
                    else
                    {
                        Selectt = 1;
                    }
                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in uploadphotoviewmodel", ex);
                    await logged.LoggAPI();
                }

            }
            finally
            {
                IsBusy = false;
            }


        }
        string docid;

        //TODO : Delet this at the end
        public ICommand PutBasicinfo
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
                            //var zipcodevr = await zc.GetZipCode(URLConfig.ZipcodeUrl, ZipCode);

                            var filename = basicinformations.getfilepath(_mediaFile);
                            var bytearray = basicinformations.GetImageStreamAsBytes(_mediaFile.GetStream());

                            //EmployeeCurrentData ECD = new EmployeeCurrentData
                            //{
                            //    firstName = FirstNamelocal,
                            //    lastName = LastNamelocal,
                            //    mobile = Phonelocal,
                            //    email = Emaillocal,
                            //    isMale = isMaleLocal,
                            //    birthDate = BirthDate,
                            //    zipCode = ZipCode,

                            //};

                            //UploadModel photouploadmodel = new UploadModel { IsProfilePic = true };
                            //await basicinformations.updatemediafile(_mediaFile, true, "5", true, bytearray, filename, URLConfig.Updatemediafileurl , docid);
                            //await App.Current.MainPage.DisplayAlert("you have Trouble conecting the internet ", "Check your internet Conection", AlertMessages.OkayTitle);
                            await App.Current.MainPage.DisplayAlert("", AlertMessages.FileUploaded, AlertMessages.OkayTitle);

                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error in uploadphotoviewmodel", ex);
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
