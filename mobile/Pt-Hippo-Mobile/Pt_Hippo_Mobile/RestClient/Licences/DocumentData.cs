using Plugin.RestClient;
using Pt_Hippo_Mobile.Model.licensesModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.RestClient.Licences
{
   public class DocumentData : RestClient<UplodadedDocumentsModel>
    {
        public async Task<ObservableCollection<UplodadedDocumentsModel>> GetDocumentLicencesData(string url)
        {
            var job = await GetObservableCollectionAsync(url);
            return job;
        }
    }
}
