using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq; 
using System.Windows.Input;
using Pt_Hippo_Mobile.Enums; 
using Pt_Hippo_Mobile.RestClient.ContactsPrefrences;
using Plugin.FilePicker.Abstractions; 
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.RestClient; 
using Xamarin.Forms;
namespace Pt_Hippo_Mobile.ViewModel.UploadFile
{
    public class UploadFileViewModel : BaseViewModel
    {
        BasicInfos basicinformations = new BasicInfos();
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

        private ObservableCollection<UplodadedDocumentsModel> filename;
        public ObservableCollection<UplodadedDocumentsModel> FileName
        {
            get { return filename; }
            set { filename = value; OnPropertyChangedEventhander(); }
        }
        public FileData filedata = new FileData();
        public ICommand PickFile
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
                            if (FileData != null)
                            {
                                FileData.Add(filedata);
                                var testdataarraylocalvar = FileData.FirstOrDefault().DataArray; 
                            }
                            if (FileData.FirstOrDefault().DataArray != null)
                            {
                                if (FileData.FirstOrDefault().FileName != null)
                                {
                                    await basicinformations.UploadMediafile("C:UsersashrafDesktopPTHPT-HippomobilePt-Hippo-Mobile", null, false, DocumentType.Resume, true, FileData.FirstOrDefault().DataArray, FileData.FirstOrDefault().FileName, URLConfig.Updatemediafileurl, null);
                                }
                            }
                        }
                        return;
                    }
                    catch (Exception ex)
                    {

                        var logged = new LoggedException.LoggedException("UploadFileViewModel.cs ", ex);
                        logged.LoggAPI();
                    }
                });

            }

        }

        public UploadFileViewModel()
        {
            FileData = new List<Plugin.FilePicker.Abstractions.FileData>();
            UploadedtimeResponse = new uploadeditemresponse();
        }
    }
}
