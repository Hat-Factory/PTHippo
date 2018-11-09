using System;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class HelpersIntializer
    {
       public static void IntialilizeAllHelpers()
        {
            LicenseHelper.StatesList = null;
            LicenseHelper.LicenceTypes = null;
            EmployeeProfileHelper.EmployeeCurrentProfile = null;
            JobDetailsHelper.JobModel = null;
            JobListHelper.SearchJobsModel = null;
            JobListHelper.AppliedJobsModel = null;
            JobListHelper.CurrentPage = 1;
            JobListHelper.IntialzieList();
            JobsCounterHelper.Intialize();
            personalinfohelper.images = null;
            SkillsHelper.AllSysytemSkills = null;
            UserDataHelper.EmployeeCurrentData = null;
            RegisterViewModel.SpecialitySkillstext = RegisterViewModel.SelectOneText;
            RegisterViewModel.Computerskillstext = RegisterViewModel.SelectOneText;
            RegisterViewModel.LangaugeSkillstext = RegisterViewModel.SelectOneText;
            RegisterViewModel.EmployeeSkills = null;
            RegisterViewModel.ExperienceSkills = null;
            RegisterViewModel.AllSkilssText = RegisterViewModel.SelectOneText;
            RegisterViewModel.JobTypeForProfile = null;
            RegisterViewModel.check = null;
            RegisterViewModel.RBM = null;
            RegisterViewModel.SelectedJobTypeId = null;
            RegisterViewModel.JobTypecheck = null;
            if(RegisterViewModel.RBM !=null)
            {
                RegisterViewModel.RBM.agreedOnLicense = false; 
            }
            constants.AgreedOnTOSAndPrivacy = false;

        }
    }
}
