using Plugin.Media.Abstractions;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.RestClient.ContactsPrefrences
{
   public class BasicInfos : RestClient<ImageinfoModel>
    {


        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public string getfilepath(MediaFile _mediaFile)
        {
            string fileName = Path.GetFileName(_mediaFile.Path);
            return fileName;
        }

        


        public async Task<bool> PutCurentUserDetailsAsync(string api,object data)
        {

            var job = await PutAsync(api,null,data);
            return job;
        }
       
    }
}
