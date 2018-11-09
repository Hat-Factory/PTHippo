using Pt_Hippo_Mobile.Interface;
using Pt_Hippo_Mobile.iOS.ImplementedInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Model.HelperModels;
using System.Threading.Tasks;
using UIKit;
using MobileCoreServices;
using Foundation;

[assembly: Dependency(typeof(FilePicker))]

namespace Pt_Hippo_Mobile.iOS.ImplementedInterfaces
{
    public class FilePicker : IFilePicker
    {
        #region Computed Properties
        /// <summary>
        /// Returns the delegate of the current running application
        /// </summary>
        /// <value>The this app.</value>
        public AppDelegate ThisApp
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }
        #endregion

        Action<FileInfo> _callback;

        public async Task FilePick(Action<FileInfo> callback)
        {
            _callback = callback;

            var allowedUTIs = new string[]
            {
                UTType.PDF,
                UTType.PlainText,
                UTType.RTF,
                UTType.PNG,
                UTType.Text,
                UTType.Image,
                UTType.UTF8PlainText,
                "org.openxmlformats.wordprocessingml.document"
            };

            var pickerMenu = new UIDocumentPickerViewController(allowedUTIs, UIDocumentPickerMode.Import);

            pickerMenu.WasCancelled += (s, e) => { callback(null); };

            pickerMenu.DidPickDocument += (s, e) =>
            {
                Picker_DidPickDocument(s, e.Url);
            };

            //TODO: UnComment the Followings 
            pickerMenu.DidPickDocumentAtUrls += (s, e) =>
            {
                foreach (var Url in e.Urls)
               {
                    Picker_DidPickDocument(s, Url);
                }
           };
            //TODO: UnComment the Followings 

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(pickerMenu, true, null);
        }
        private void Picker_DidPickDocument(object controller, NSUrl url, bool dispose = true)
        {
            var newNSUrl = CopyToDocumentsFolder(url);
            string mime = newNSUrl.PathExtension;

            _callback?.Invoke(new FileInfo { Path = newNSUrl.Path, MimeType = mime });
        }

        public byte[] GetAllBytes(string filePath)
        {
            return System.IO.File.ReadAllBytes(filePath);
        }

        public NSUrl CopyToDocumentsFolder(NSUrl srcPath)
        {
            NSError copyError;

            var defaultManager = NSFileManager.DefaultManager;
            var destPath = defaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0];
            //destPath.Append(srcPath.LastPathComponent, false); // this is not working so i've used the following line.
            destPath = new NSUrl(destPath.Path + '/' + srcPath.LastPathComponent, false);
            defaultManager.Copy(srcPath, destPath, out copyError);

            NSError removeError;
            if (copyError != null)
            {
                defaultManager.Remove(destPath, out removeError);
                defaultManager.Copy(srcPath, destPath, out copyError);
            }

            return destPath;
        }
    }
}
