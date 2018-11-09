using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Model.skillsModel;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Helpers
{
    public static class SkillsHelper
    {
        public static List<SkillsModel> AllSysytemSkills;


        public static string PreapreSkillsText(SkillCategories category)
        {
            int maxCount = 3;
            if (category == SkillCategories.All)
            {
                maxCount = 1000;
            }

            string selectedText = string.Empty;
            try
            {
                if (RegisterViewModel.EmployeeSkills != null && RegisterViewModel.EmployeeSkills.Count() > 0)
                {
                    var skills = RegisterViewModel.EmployeeSkills.Where(d => d.skillCategoryTitle == category.ToString()).ToList();
                    //dear islam i added this check for all categories since it has to be not selected even if he did select them before and it should not affect in the other scenarios
                    //statrtof the scope
                    if (category == SkillCategories.All)
                    { 
                        skills = RegisterViewModel.EmployeeSkills.ToList();
                    }
                    //end of the Scope      
                    int computerCounter = 1;
                    foreach (var skill in skills)
                    {
                        if (computerCounter <= maxCount)
                        {
                            if (string.IsNullOrEmpty(selectedText))
                            {
                                if (skill.skillTitle == null)
                                {
                                    selectedText = skill.skillTitle;
                                }
                                else
                                    selectedText = skill.skillTitle;
                            }
                            else
                            {
                                if (skill.skillTitle == null)
                                {
                                    selectedText = skill.skillTitle;
                                    selectedText += ", " + skill.skillTitle;
                                }
                                else
                                    selectedText += ", " + skill.skillTitle;
                            }
                        }
                        else
                        {
                            if (!selectedText.ToUpperInvariant().Contains("..."))
                            {
                                selectedText += "...";
                            } 
                        }
                        computerCounter++;
                    }
                }
                if (string.IsNullOrEmpty(selectedText))
                {
                    selectedText = RegisterViewModel.SelectOneText;
                }
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  region Languages ", ex);
                logged.LoggAPI();
            }

            return selectedText;
        }
    }
}
