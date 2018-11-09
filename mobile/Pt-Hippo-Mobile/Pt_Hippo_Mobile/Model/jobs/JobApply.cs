using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Model.jobs
{
    public class JobApplicantSchedule
    {
        public string jobApplicantId { get; set; }

        public string jobId { get; set; }
        public DateTime clockIn { get; set; }               
        public DateTime clockOut { get; set; }
        public int payment { get; set; }
        public int approvedHrs { get; set; }
        public DateTime approvalTime { get; set; }
        public int clockInLat { get; set; }
        public int clockInLong { get; set; }
        public int clockOutLat { get; set; }
        public int clockOutLong { get; set; }
        public int unApprovedHrs { get; set; }
        public string jobScheduleId { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }

  

    public class JobApply
    {
        public string id { get; set; }
        public DateTime expireDate { get; set; }
        public string employeePicture { get; set; }
        public string employeeName { get; set; }
        public string applicantId { get; set; }
        public string jobRefrence { get; set; }
        public int matchingPercentage { get; set; }
        public int desiredHRRate { get; set; }
        public string verifiedItems { get; set; }
        public string facilityName { get; set; }
        public bool isWorkedWithEmployerBefore { get; set; }
        public int rating { get; set; }
        public string employeeProfileId { get; set; }
        public string employeeInfo { get; set; }
        public string employerProfileId { get; set; }
        public string jobId { get; set; }
        public bool isPratiallyApplied { get; set; }
        public DateTime appliedDate { get; set; }
        public int requestedHrRate { get; set; }
        public int status { get; set; }
        public bool isPaid { get; set; }
        public string name { get; set; }
        public int rate { get; set; }
        public List<JobSchedule> jobApplicantSchedules { get; set; }
        public List<JobSchedule> jobSchedules { get; set; }
    }
}
