using Pt_Hippo_Mobile.Model.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Interface
{
    public interface IFilePicker
    {
        Task FilePick(Action<FileInfo> callback);
        byte[] GetAllBytes(string filePath);
    }
}
