using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Jobs;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.jobs;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Pt_Hippo_Mobile.Resolvers;
using System.Collections.ObjectModel;
using Pt_Hippo_Mobile.Model.jobs;
using System.Collections.Generic;

namespace Pt_Hippo_Mobile.Views.JobListings
{

    public partial class JobListing : ContentPage
    {
        public static bool IsCurrentListSaved = false;
        // TODO : Write Comments 
        private bool _userTapped;
        private bool _userTapped1;
        public List<string> imagenames { get; set; }
        public static bool istoopen = true;
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public JobListing()
        {
            InitializeComponent();
            cooloring.BackgroundColor = new Color(0, 0, 0, 0.46);
            if (Device.RuntimePlatform == Device.iOS)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    MainCarouselView.Margin = new Thickness(0, 20, 0, 0);
                }
                imagenames = new List<string>
                {
                    "iosCV.png" , "iosCV2.png" ,  "iosCV3.png" ,  "iosCV4.png", "iosCV5.png"  ,"iosCV6.png"
                };
            }
            else
            {
                imagenames = new List<string>
                {
                    "DroidCV.png" , "DroidCV2.png" , "DroidCV3.png" , "DroidCV4.png" , "DroidCV5.png" ,  "DroidCV6.png"
                };
            }

            MainCarouselView.ItemsSource = imagenames;
            if (Device.RuntimePlatform == Device.iOS)
            {
                if (App.ft)
                {
                    cooloring.IsVisible = true;
                    App.ft = false;
                }
                else
                {
                    if (crv == false)
                    {
                        cooloring.IsVisible = false;
                        App.ft = false;
                        crv = true;
                    }
                }
            }
            else
            {
                if (App.ft)
                {
                    cooloring.IsVisible = true;
                    App.ft = false;
                }
                else
                {
                    if (crv == false)
                    {
                        cooloring.Children.Remove(MainCarouselView);
                        maincv.Children.Remove(cooloring);
                        App.ft = false;
                        crv = true;
                    }
                }
            }
            NavigationPage.SetHasNavigationBar(this, false);

            var jobsearchViewModel = new JobSearchviewModel();

            CurrentJobsLayout.BindingContext = jobsearchViewModel;
            FilterGrid.BindingContext = jobsearchViewModel;
            namegrid.BindingContext = jobsearchViewModel;

            RangeSlider.LowerValue = (int)10.00f;
            fromvalue.Text = "$" + RangeSlider.LowerValue.ToString();

            RangeSlider.UpperValue = (int)60.00f;
            tovalue.Text = "$" + RangeSlider.UpperValue.ToString();
            startDate.Date = DateTime.Now;
            endDate.Date = DateTime.Now;
            /* MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
             iMyJobstap.Source = "MyJobsi.png";
             MyJobstapLabel.TextColor = Color.White;*/
          

        }


        private async Task LoadJobs()
        {
            await JobsListResolver.LoadJobsListSearch("null", "null", DateTime.MinValue, DateTime.MinValue, 0, 0);
            await JobsListResolver.LoadSavedJobs();
            await JobsListResolver.LoadAppliedJobs();

            // MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
        }
        public bool crv { get; set; }



        protected override async void OnAppearing()
        {
            try
            {
                // await LoadJobs();
               
                //JobListHelper.ExpireTimerEnabled = false;
                await Task.Yield();
                LoadingIndicatorHelper.Intialize(this);


                if (JobListHelper.IsApplied)
                {
                    //Refresh Applied List
                    int oldCount = JobsCounterHelper.NoOfAppliedJobs;
                    await ((AppliedJobsViewModel)AppliedJobsLayout.BindingContext).BindData(true);
                    int newCount = oldCount + 1;
                    JobsCounterHelper.NoOfAppliedJobs = newCount;
                    JobsCounterHelper._noOfAppliedJobsText = JobsCounterHelper.NoOfAppliedJobsText();
                    ((JobSearchviewModel)namegrid.BindingContext).Applied = JobsCounterHelper.NoOfAppliedJobsText();

                    ChangeToApplied(null, null);
                    JobListHelper.IsSearching = false;
                    JobListHelper.IsSaved = false;


                }
                //else if (JobListHelper.IsSearching)
                //{
                //    JobListHelper.IsApplied = false;
                //    JobLissearchtaptHelper.IsSaved = false;
                //    .BackgroundColor = Color.FromHex("#87c8ee");
                //    isearchtap.Source = "Magnifier.png";
                //    searchtapLabel.TextColor = Color.White;
                //    MyJobstap.BackgroundColor = Color.White;
                //    iMyJobstap.Source = "MyJobsi.png";
                //    MyJobstapLabel.TextColor = Color.DimGray;
                //    ChangeToCurrent(null, null);

                //}
                else if (JobListHelper.IsSaved)
                {
                    JobListHelper.IsSearching = false;
                    JobListHelper.IsSaved = false;
                    ChangeToSaved(null, null);

                }


                if (constants.SearchView)
                {
                    constants.SearchView = false;

                    //if (FilterGrid.IsVisible)
                    //{

                    //    FilterGrid.FadeTo(0);
                    //    FilterGrid.IsVisible = false;

                    //    searchtap.BackgroundColor = Color.White;
                    //    isearchtap.Source = "Magnifier.png";
                    //    searchtapLabel.TextColor = Color.DimGray;
                    //    //gray color 
                    //}
                    //else
                    //{
                        FilterGrid.IsVisible = true;
                        CurrentJobsLayout.IsVisible = false;
                        namegrid.IsVisible = false;
                        FilterGrid.FadeTo(1);
                        searchtap.BackgroundColor = Color.FromHex("#87c8ee");
                        isearchtap.Source = "Magnifieri.png";
                        searchtapLabel.TextColor = Color.White;
                        MyJobstap.BackgroundColor = Color.White;
                        iMyJobstap.Source = "MyJobs.png";
                        MyJobstapLabel.TextColor = Color.DimGray;

                    //}
                }
                else
                {
                    MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
                    iMyJobstap.Source = "MyJobsi.png";
                    MyJobstapLabel.TextColor = Color.White;
                    CurrentJobsLayout.IsVisible = true;

                }

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("error in joblisting.xaml.cs", ex);
                await logged.LoggAPI();
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            SavedJobsLayout.TranslationX = Width;
            AppliedJobsLayout.TranslationX = Width * 2;
            if (JobListHelper.IsSaved)
            {
                ChangeToSaved(null, null);
            }
        }

        private async void ChangeToCurrent(object sender, EventArgs e)
        {
            //TODO:SEARCH
            JobListHelper.IsSaved = false;
            JobListHelper.IsSearching = false;
            JobListHelper.IsApplied = false;

            await Task.WhenAll(UnderlineBoxView.TranslateTo(0, 0), CurrentJobsLayout.TranslateTo(0, 0), SavedJobsLayout.TranslateTo(Width, 0), AppliedJobsLayout.TranslateTo(Width * 2, 0)
                );
            MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
            iMyJobstap.Source = "MyJobsi.png";
            MyJobstapLabel.TextColor = Color.White;
        }

        private async void ChangeToSaved(object sender, EventArgs e)
        {
            //TODO:SEARCH 
            JobListHelper.IsSaved = true;
            JobListHelper.IsApplied = false;
            JobListHelper.IsSearching = false;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width, 0),
                    CurrentJobsLayout.TranslateTo(-Width, 0),
                    SavedJobsLayout.TranslateTo(0, 0),
                    AppliedJobsLayout.TranslateTo(Width, 0)

                );
            //MyJobstap.BackgroundColor = Color.White;
            //MyJobstapLabel.TextColor = Color.DimGray;
            //iMyJobstap.Source = "MyJobs.png";

        }

        private async void ChangeToApplied(object sender, EventArgs e)
        {
            //TODO:SEARCH 
            JobListHelper.IsSaved = false;
            JobListHelper.IsSearching = false;
            JobListHelper.IsApplied = true;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width * 2, 0),
                    CurrentJobsLayout.TranslateTo(-Width * 2, 0),
                    SavedJobsLayout.TranslateTo(-Width, 0),
                    AppliedJobsLayout.TranslateTo(0, 0)

                );
            //MyJobstap.BackgroundColor = Color.White;
            //MyJobstapLabel.TextColor = Color.DimGray;
            //iMyJobstap.Source = "MyJobs.png";
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            CurrentJobsList.IsEnabled = false;
            try
            {
                CurrentJobsList.IsEnabled = false;
                if (!(e is TappedEventArgs))
                {
                    return;
                }
                var item = ((TappedEventArgs)e).Parameter;
                //Show loading idicator here please
                //JobsServices js = new JobsServices();
                //JobDetailsHelper.JobModel = await js.GeTJobDetails(URLConfig.getjobdetailsapiurl, item.ToString());               
                //var page = new jobdetails(item.ToString());
                var page = new NewJobDetail(item.ToString());
                NavigationPage.SetHasNavigationBar(page, false);
                await Navigation.PushModalAsync(page);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("error in joblisting.xaml.cs", ex);
                await logged.LoggAPI();

            }
            CurrentJobsList.IsEnabled = true;
        }




        private async void RangeSlider_LowerValueChanged(object sender, EventArgs e)
        {
            try
            {
                var castedRSLV = (int)RangeSlider.LowerValue;
                fromvalue.Text = "$" + castedRSLV.ToString();
                //TODO :  Object reference not set to an instance of an object
                //((JobSearchviewModel)this.BindingContext).minhourrate = (double)castedRSLV;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                await logged.LoggAPI();
            }

        }

        private void RangeSlider_UpperValueChanged(object sender, EventArgs e)
        {
            try
            {
                var CASTEDrsuv = (int)RangeSlider.UpperValue;
                tovalue.Text = "$" + CASTEDrsuv.ToString();
                //TODO :  Object reference not set to an instance of an object
                //((JobSearchviewModel)this.BindingContext).maxhourate = (double)CASTEDrsuv;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                logged.LoggAPI();

            }


        }

        private void startDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {

                //TODO :  Object reference not set to an instance of an object   , Moved To Xamal 

                //var expdate = e.NewDate.ToString();
                //((JobSearchviewModel)this.BindingContext).startdate = e.NewDate;
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                logged.LoggAPI();

            }

        }

        private void endDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                //TODO :  Object reference not set to an instance of an object  , Moved To Xamal
                //var expdate = e.NewDate.ToString();
                //((JobSearchviewModel)this.BindingContext).enddate = e.NewDate; 
            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                logged.LoggAPI();

            }

        }

        private void CurrentJobsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CurrentJobsList.SelectedItem = null;

        }

        private void SavedJobsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SavedJobsList.SelectedItem = null;

        }

        private void AppliedJobsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AppliedJobsList.SelectedItem = null;
        }





        private void CurrentJobsList_LoadMore(object sender, EventArgs e)
        {
            //LoadingIndicatorHelper.AddProgressDisplay();
            //((JobSearchviewModel)CurrentJobsLayout.BindingContext).BindData();
            //LoadingIndicatorHelper.HideIndicator();

            //LoadingIndicatorHelper.HideIndicator();

        }




        public async void closeClearSearchViewafterSearch(object sender, EventArgs e)
        {
            try
            {
                JobListHelper.IsSearching = false;
                JobListHelper.IntialzieList();
                clear.IsEnabled = false;
                search.IsEnabled = false;
                await ((JobSearchviewModel)CurrentJobsLayout.BindingContext).BindData(true, true);
                // ChangeToCurrent(null, null);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                await FilterGrid.FadeTo(0);
                FilterGrid.IsVisible = false;
                searchtap.BackgroundColor = Color.White;
                isearchtap.Source = "Magnifier.png";
                searchtapLabel.TextColor = Color.DimGray;
                MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
                iMyJobstap.Source = "MyJobsi.png";
                MyJobstapLabel.TextColor = Color.White;
                search.IsEnabled = true;
                clear.IsEnabled = true;
            }

        }

        public async void closeSearchViewafterSearch(object sender, EventArgs e)
        {
            try
            {
                if (startDate.Date >= endDate.Date)
                {
                    await DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.comparedate, "Ok");
                    return;
                }
                else
                {
                    JobListHelper.IsSearching = true;
                    search.IsEnabled = false;
                    clear.IsEnabled = false;

                    await ((JobSearchviewModel)CurrentJobsLayout.BindingContext).BindData(true);
                    MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
                    iMyJobstap.Source = "MyJobsi.png";
                    MyJobstapLabel.TextColor = Color.White;
                    searchtap.BackgroundColor = Color.White;
                    isearchtap.Source = "Magnifier.png";
                    searchtapLabel.TextColor = Color.DimGray;
                    await FilterGrid.FadeTo(0);
                    search.IsEnabled = true;
                    clear.IsEnabled = true;
                    FilterGrid.IsVisible = false;
                    constants.SearchView = false;
                    namegrid.IsVisible = true;
                    CurrentJobsLayout.IsVisible = true;
                    ChangeToCurrent(null, null);
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                logged.LoggAPI();
            }
            //finally
            //{

            //    await FilterGrid.FadeTo(0);
            //    search.IsEnabled = true;
            //    clear.IsEnabled = true;
            //    FilterGrid.IsVisible = false;
            //    constants.SearchView = false;
            //    namegrid.IsVisible = true;
            //    CurrentJobsLayout.IsVisible = true;
            //    DisplayAlert(AlertMessages.ErrorTitle, "!!!!!!!!!!!1", "Ok");
            //}

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

            try
            {
                if (_userTapped1)
                    return;
                _userTapped1 = true;
                selectgridtabs.IsEnabled = false;
                if (FilterGrid.IsVisible)
                {
                    constants.SearchView = false;
                    await FilterGrid.FadeTo(0);
                    FilterGrid.IsVisible = false;
                    searchtap.BackgroundColor = Color.White;
                    isearchtap.Source = "Magnifier.png";
                    searchtapLabel.TextColor = Color.DimGray;

                    //
                    MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
                    iMyJobstap.Source = "MyJobsi.png";
                    MyJobstapLabel.TextColor = Color.White;
                    namegrid.IsVisible = true; 
                    CurrentJobsLayout.IsVisible = true;
                    //gray color 
                }
                else
                {
                    FilterGrid.IsVisible = true;
                    await FilterGrid.FadeTo(1);
                    searchtap.BackgroundColor = Color.FromHex("#87c8ee");
                    isearchtap.Source = "Magnifieri.png";
                    searchtapLabel.TextColor = Color.White;
                    MyJobstap.BackgroundColor = Color.White;
                    iMyJobstap.Source = "MyJobs.png";
                    MyJobstapLabel.TextColor = Color.DimGray;
                    //blue color
                }

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to load jobs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                _userTapped1 = false;
                selectgridtabs.IsEnabled = true;
            }

        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
           
            //TODO: Load the Data 
            if (_userTapped)
                return;
            _userTapped = true;
            selectgridtabs.IsEnabled = false;
            try
            {

                 JobListHelper.IsSearching = false;

                CurrentJobsList.IsVisible = true;
                namegrid.IsVisible = true;
                MyJobstap.BackgroundColor = Color.FromHex("#87c8ee");
                iMyJobstap.Source = "MyJobsi.png";
                MyJobstapLabel.TextColor = Color.White;
                FilterGrid.IsVisible = false;
                constants.SearchView = false;
                searchtap.BackgroundColor = Color.White;
                isearchtap.Source = "Magnifier.png";
                searchtapLabel.TextColor = Color.DimGray;

                await ((JobSearchviewModel)CurrentJobsLayout.BindingContext).BindData(true);

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error while trying to load jobs", ex);
                await logged.LoggAPI();
            }
            finally
            {
                _userTapped = false;
                selectgridtabs.IsEnabled = true;

            }


        }


        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            //bottom taps navigate to the jobitem sheet
            var page = new jobtimesheet();
            timesheettext.IsEnabled = false;
            selectgridtabs.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            timesheettext.IsEnabled = true;
            selectgridtabs.IsEnabled = true;
            //await Navigation.PushModalAsync(new jobtimesheet());
            //here 
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var page = new ChooseMytimes();
            Availabilitytext.IsEnabled = false;
            selectgridtabs.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushAsync(page);
            Availabilitytext.IsEnabled = true;
            selectgridtabs.IsEnabled = true;
            //bottom taps navigate to the schadual
            //await Navigation.PushAsync(new ChooseMytimes());
        }

        private async void imagetaps_Tapped(object sender, EventArgs e)
        {

            try
            {

                //To be deleted
                int oldCount = JobsCounterHelper.NoOFSavedJobs;
                Unsavedjob apidelete = new Unsavedjob();
                JobSavedRestClient apisaved = new JobSavedRestClient();
                var image = (Image)sender;
                var id = (TappedEventArgs)e;
                var jobIsSaved = JobListHelper.SearchJobsModel.result.Any(d => d.Id == id.Parameter.ToString() && d.isSaved == true);

                var titlejob = JobListHelper.SearchJobsModel.result.Where(i => i.Id == id.Parameter.ToString()).First();
                if (jobIsSaved)
                {
                    var Delete = await DisplayAlert("Confirmation Message", AlertMessages.unsavedjob + " " + titlejob.JobType + ") ?", "Yes", "Cancel");

                    if (Delete == true)
                    {
                        try
                        {

                            var unsaved = await apidelete.deleteData(id.Parameter.ToString(), URLConfig.Unsavedjob);
                            if (unsaved)
                            {
                                //image.Source = "emptystar";

                                var job = JobListHelper.SearchJobsModel.result.Where(i => i.Id == id.Parameter.ToString()).First();
                                var Saved_job = JobListHelper.SavedJobsModel.Where(i => i.Id == id.Parameter.ToString()).First();

                                job.isSaved = false;

                                job.Image = "emptystar";

                                var index = JobListHelper.SearchJobsModel.result.IndexOf(job);
                                var Saved_index = JobListHelper.SavedJobsModel.IndexOf(Saved_job);
                                var searchObsIndex = ((JobSearchviewModel)namegrid.BindingContext).JobSearchBindcast.IndexOf(job);
                                if (index != -1 && Saved_index != -1 && searchObsIndex != -1)
                                {
                                    //we don't need to call the api each time I remove the saved Job 
                                    // await((savedjobsViewModel)SavedJobsLayout.BindingContext).BindData(true);   

                                    JobListHelper.SearchJobsModel.result[index] = job;
                                    JobListHelper.SavedJobsModel[Saved_index] = Saved_job;

                                    ((JobSearchviewModel)namegrid.BindingContext).JobSearchBindcast[searchObsIndex] = job;


                                    ((savedjobsViewModel)SavedJobsLayout.BindingContext).JobSearchBindcast.Remove(Saved_job);

                                    JobsCounterHelper.NoOFSavedJobs = ((savedjobsViewModel)SavedJobsLayout.BindingContext).JobSearchBindcast.Count();
                                    JobsCounterHelper._noOFSavedJobsText = JobsCounterHelper.NoOFSavedJobsText();
                                    ((JobSearchviewModel)namegrid.BindingContext).Saved = JobsCounterHelper.NoOFSavedJobsText();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error while trying to save job", ex);
                            await logged.LoggAPI();
                        }
                    }
                }
                else
                {
                    var answer = await DisplayAlert("Confirmation Message", AlertMessages.savedjob + " " + titlejob.JobType + ") ?", "Yes", "Cancel");

                    if (answer == true)
                    {
                        try
                        {

                            var succed = await apisaved.PostSaveJob(URLConfig.SaveJobsUrl, id.Parameter.ToString());
                            if (succed)
                            {
                                //image.Source = "star";
                                var job = JobListHelper.SearchJobsModel.result.Where(i => i.Id == id.Parameter.ToString()).First();

                                job.Image = "star";
                                job.isSaved = true;
                                var index = JobListHelper.SearchJobsModel.result.IndexOf(job);

                                if (index != -1)
                                {
                                    await ((savedjobsViewModel)SavedJobsLayout.BindingContext).BindData(true);
                                    JobListHelper.SearchJobsModel.result[index] = job;
                                    JobsCounterHelper._noOFSavedJobsText = JobsCounterHelper.NoOFSavedJobsText();
                                    ((JobSearchviewModel)namegrid.BindingContext).Saved = JobsCounterHelper.NoOFSavedJobsText();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            var logged = new LoggedException.LoggedException("Error while trying to save job", ex);
                            await logged.LoggAPI();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                await logged.LoggAPI();

            }
        }

        private async void SkippComaand(object sender, EventArgs e)
        {
            await cooloring.FadeTo(0);
            cooloring.IsVisible = false;
            await mainGrid.FadeTo(1);
            mainGrid.IsVisible = true;
        }

        private async void NextSliderImage(object sender, EventArgs e)
        {
            try
            {
                int imagenameslistcount = imagenames.Count();
                if (MainCarouselView.Position == imagenameslistcount - 1)
                {
                    //NextButton.IsEnabled = false;
                    SkipButton.Text = "Finish";
                    //MainCarouselView.IsEnabled = false;
                    return;
                }
                else
                {
                    MainCarouselView.Position += 1;
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                await logged.LoggAPI();
            }

        }

        private void MainCarouselView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                int imagenameslistcount = imagenames.Count();
                if (MainCarouselView.Position == imagenameslistcount - 1)
                {
                    //NextButton.IsEnabled = false;
                    SkipButton.Text = "Finish";
                    //MainCarouselView.IsEnabled = false;
                    return;
                }
                else
                {
                    SkipButton.Text = "Skip";
                }
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in joblistingtapedimage.xaml.cs", ex);
                logged.LoggAPI();
            }

        }
    }
}