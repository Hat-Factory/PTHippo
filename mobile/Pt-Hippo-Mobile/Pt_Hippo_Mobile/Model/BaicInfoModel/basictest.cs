using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.skillsModel;
using Pt_Hippo_Mobile.Model.licensesModel;

namespace Pt_Hippo_Mobile.Model.BaicInfoModel
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isMale { get; set; }
        public string profilePicture { get; set; }
    }

    public class BankAccount
    {
        public string bankName { get; set; }
        public double accountNumber { get; set; }
        public string routingNumber { get; set; }
        public string employeeProfileId { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }

    public class EmployeeScheduel
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public bool isAvailableFullDay { get; set; }
        public double dayOfWeek { get; set; }
        public object specificDate { get; set; }
        public string employeeProfileId { get; set; }
    }

    public class License
    {
        public object licenseId { get; set; }
        public string id { get; set; }
        public DateTime expirationDate { get; set; }
        public double type { get; set; }
        public string licenseNumber { get; set; }
        public string college { get; set; }
        public string employeeProfileId { get; set; }
        public double status { get; set; }
        public string documentId { get; set; }
    }

    public class Document
    {
        public string id { get; set; }
        public object title { get; set; }
        public string filePath { get; set; }
        public object employerProfileId { get; set; }
        public string employeeProfileId { get; set; }
        public double documentType { get; set; }
        public object link { get; set; }
        public bool isDocumentVerified { get; set; }
        public object employeeOrEmployerName { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string workLocation { get; set; }
        public string @as { get; set; }
        public string doing { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string employeeProfileId { get; set; }
        public bool isCurrentWork { get; set; }
       
    }

   
}
