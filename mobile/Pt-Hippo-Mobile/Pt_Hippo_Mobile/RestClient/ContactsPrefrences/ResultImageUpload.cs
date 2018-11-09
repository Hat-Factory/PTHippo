using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.ContactsPrefrences
{
    public class ResultImageUpload : RestClient<ImageinfoModel>
    {
        public async Task<List<ImageinfoModel>> Resultupload(string path,string documentId, bool IsProfilePic, DocumentType documentType, bool IsEmployee, byte[] bytearray, string fileName, string url, string Title = null)
        {

            var docuemnt = await UploadMediafile(path,documentId, IsProfilePic, documentType, IsEmployee, bytearray, fileName, url,Title);
            return docuemnt;
        }
    }
}
