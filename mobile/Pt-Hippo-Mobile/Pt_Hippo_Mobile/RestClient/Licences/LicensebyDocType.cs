using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.licensesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
   public class LicensebyDocType : RestClient<LicencesDocumentModel>
    {
        public async Task<List<LicencesDocumentModel>> GetDocByType(string apiurl, int doctypeid)
        {
            var DocTypeByList = await GetListOptionalId(apiurl, doctypeid.ToString());
            return DocTypeByList;
        }
    }
}
