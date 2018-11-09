using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.skillsModel;
using Pt_Hippo_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Pt_Hippo_Mobile.Views.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillsSignUp : ContentPage
    {
        private SkillCategories _categoryId;
        private ObservableCollection<SkillsModel> _observable;
        private int tapCount;
        public SkillsSignUp(SkillCategories categoryId)
        {
            _categoryId = categoryId;
            InitializeComponent();
            //LoadingIndicatorHelper.Intialize(this);
            RefresData(_categoryId);

            
        }

        private void ConstructSkillsText(ObservableCollection<SkillsModel> observableList)
        {
            int counter = 1;
            int maxCount = 3;
            var currentSkillSet = new ObservableCollection<SkillsModel>();
            if (_categoryId == SkillCategories.All)
            {
                maxCount = 1000;
            }

            if (_categoryId == SkillCategories.All)
            {
                currentSkillSet = RegisterViewModel.ExperienceSkills;
            }
            else
            {
                currentSkillSet = RegisterViewModel.EmployeeSkills;
            }
            if (currentSkillSet == null)
            {
                return;
            }

            string skillsText = string.Empty;
            foreach (var item in observableList)
            {
                if (currentSkillSet.Any(d => d.skillId == item.id))
                {
                    if (counter <= maxCount)
                    {
                        if (string.IsNullOrEmpty(skillsText))
                        {
                            skillsText = item.skillTitle;
                        }
                        else
                        {
                            skillsText += ", " + item.skillTitle;
                        }
                    }
                    else
                    {
                        if (!skillsText.ToUpperInvariant().Contains("..."))
                        {
                            skillsText += "...";
                        }  
                    }

                    counter++;
                }

            }

            if (string.IsNullOrEmpty(skillsText) && _categoryId != SkillCategories.All)
            {
                skillsText = RegisterViewModel.SelectOneText;
            }
            switch (_categoryId)
            {
                case SkillCategories.All:
                    {
                        RegisterViewModel.AllSkilssText = skillsText;
                        break;
                    }
                case SkillCategories.ComputerSkills:
                    RegisterViewModel.Computerskillstext = skillsText;
                    break;
                case SkillCategories.Languages:
                    RegisterViewModel.LangaugeSkillstext = skillsText;
                    break;
                case SkillCategories.Other:
                    RegisterViewModel.SpecialitySkillstext = skillsText;
                    break;
            }

        }
        private void PrepareListSelectionsAndText(ObservableCollection<SkillsModel> observableList)
        {
            _observable = observableList;
         

            try
            {
                foreach (var item in observableList)
                {
                    item.Imaage = "RoundCBUN"; // Not selected
                }

                foreach (var item in observableList)
                {
                    if (RegisterViewModel.EmployeeSkills.Any(d => d.skillId == item.id))
                    {
                        item.Imaage = "RoundCB"; //Selected
                    }
                }
                //dear islam i added this check for all categories since it has to be not selected even if he did select them before and it should not affect in the other scenarios
                //statrtof the scope 
                if (_categoryId == SkillCategories.All)
                {
                    foreach (var itemforall in observableList)
                    {
                        itemforall.Imaage = "RoundCBUN"; // Not selected
                    }
                }               
                //end of the Scope 
                listView1.ItemsSource = observableList;
                ConstructSkillsText(observableList);


                //#region HoldListData

                //if (RegisterViewModel.RBM.employeeProfileSkills != null)
                //{
                //    foreach (var item in RegisterViewModel.RBM.employeeProfileSkills)
                //    {
                //        if (RegisterViewModel.RBM.employeeProfileSkills.Any(d => d.skillId == item.id))
                //        {
                //            item.Imaage = "RoundCB"; //Selected
                //        }
                //    }
                //}


                //#endregion



            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Skills Sign Up Page : ", ex);
                logged.LoggAPI();
            }


        }

        private void SetNavTitle(string title)
        {
            navbartitle.Title = title;
        }
        public async void RefresData(SkillCategories categoryId)
        {
            try
            {
                await ((RegisterViewModel)this.BindingContext).FillSkillsFromAPI(categoryId);
                if (categoryId == SkillCategories.ComputerSkills)
                {
                    PrepareListSelectionsAndText(((RegisterViewModel)this.BindingContext).Computerskills);
                    SetNavTitle("Software Skills");
                }
                else if (categoryId == SkillCategories.Other)
                {
                    PrepareListSelectionsAndText(((RegisterViewModel)this.BindingContext).TechnicalSkills);
                    SetNavTitle("Speciality Skills");
                }
                else if (categoryId == SkillCategories.Languages)
                {
                    PrepareListSelectionsAndText(((RegisterViewModel)this.BindingContext).Languageskills);
                    SetNavTitle("Languages");
                }
                else if (categoryId == SkillCategories.All)
                {
                    PrepareListSelectionsAndText(((RegisterViewModel)this.BindingContext).AllSkills);
                    SetNavTitle(SkillCategories.All.ToString());
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in  Skills Sign Up Page : ", ex);
                await logged.LoggAPI();

            }

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var currentSkillsSet = new ObservableCollection<SkillsModel>();
            if (RegisterViewModel.EmployeeSkills == null)
            {
                RegisterViewModel.EmployeeSkills = new ObservableCollection<SkillsModel>();
            }

            if (_categoryId == SkillCategories.All)
            {
                if (RegisterViewModel.ExperienceSkills == null)
                {
                    RegisterViewModel.ExperienceSkills = new ObservableCollection<SkillsModel>();
                }
                currentSkillsSet = RegisterViewModel.ExperienceSkills;
            }
            else
            {
                currentSkillsSet = RegisterViewModel.EmployeeSkills;
            }

            bool constructText = false;
            try
            {
                var imageSender = (Image)sender;
                if (!(e is TappedEventArgs))
                {
                    return;
                }

                var itemtaped = ((TappedEventArgs)e).Parameter;

               
                string skillTitle = itemtaped.ToString();
                var fileName = ((dynamic)(imageSender.Source)).File;

                if (fileName == "RoundCBUN" || fileName == "RoundCBUN.png")
                {
                    imageSender.Source = "RoundCB.png";

                    var skillSelected = SkillsHelper.AllSysytemSkills.FirstOrDefault(d => d.skillTitle == skillTitle);
                    if (skillSelected != null)
                    {
                        if (currentSkillsSet.Any(d => d.skillId == skillSelected.skillId) == false)
                        {
                            currentSkillsSet.Add(skillSelected);
                            constructText = true;
                            //ConstructSkillsText(_observable);

                        }
                    }
                    else
                    {
                        throw new Exception($"Error no skill found with skill.skillTitle {skillTitle}");
                    }
                }
                else
                {
                    imageSender.Source = "RoundCBUN.png";
                    var itemSelected = currentSkillsSet.FirstOrDefault(d => d.skillTitle == skillTitle);
                    if (itemSelected == null)
                    {
                        return;
                    }
                    if (currentSkillsSet.Any(d => d.skillId == itemSelected.skillId))
                    {
                        currentSkillsSet.Remove(itemSelected);
                        constructText = true;
                        //ConstructSkillsText(_observable);

                    }
                }

                if (constructText)
                {
                    if (_categoryId == SkillCategories.All)
                    {
                        RegisterViewModel.ExperienceSkills = currentSkillsSet;
                    }
                    else
                    {
                        RegisterViewModel.EmployeeSkills = currentSkillsSet;
                    }

                    ConstructSkillsText(_observable);
                }

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in  Skills Sign Up Page Select and Deselect : ", ex);
                logged.LoggAPI();
            }
        }
    }
}