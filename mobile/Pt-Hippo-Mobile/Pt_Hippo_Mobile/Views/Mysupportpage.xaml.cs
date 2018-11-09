using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Xamarin.Forms;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Views
{



    public partial class Mysupportpage : ContentPage
    {
        ObservableCollection<FAQmodel> faq;
        FAQmodel data = new FAQmodel();
        public List<string> imagenames { get; set; }
        public Mysupportpage()
        {
            try
            {
                LoadingIndicatorHelper.Intialize(this);
                InitializeComponent();
                cooloring.BindingContext = new List<string>();
                cooloring.BackgroundColor = new Color(0, 0, 0, 0.46);

                if (Device.RuntimePlatform == Device.iOS)
                {

                    MainCarouselView.Margin = new Thickness(0, 20, 0, 0);

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
                how.Text = "click the below to start your tour how it works!";
                faq = new ObservableCollection<FAQmodel>
            {
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."},
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."},
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."},
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."},
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."},
                new FAQmodel{  image="category",name="Denise Clark", date=DateTime.Now.ToString("MM-dd-yy"),question="Hello I want to hire you could you please tell me more about your experiance as a waiter."}
            };

                //faqlist.ItemsSource = faq;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Mysupportpage.xaml.cs", ex);
                logged.LoggAPI();
            }

        }

        protected override async void OnAppearing()
        {
            try
            {
                await Task.Yield();
                cooloring.Children.Remove(MainCarouselView);
                maincv.Children.Remove(cooloring);
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Mysupportpage.xaml.cs", ex);
                logged.LoggAPI();
            }
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            contactusview.TranslationX = Width;
            howitworkview.TranslationX = Width * 2;

            if (contactusviewmodel.ReCenterViewToContactUs)
            {
                clickedcontactus(null, null);
            }

        }

        async void clickFAQ(object sender, System.EventArgs e)
        {
            contactusviewmodel.ReCenterViewToContactUs = true;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(0, 0),
                    FAQS.TranslateTo(0, 0),
                    contactusview.TranslateTo(Width, 0),
                    howitworkview.TranslateTo(Width * 2, 0)
                );
        }

        async void clickedcontactus(object sender, System.EventArgs e)
        {
            contactusviewmodel.ReCenterViewToContactUs = true;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width, 0),
                   FAQS.TranslateTo(-Width, 0),
                   contactusview.TranslateTo(0, 0),
                   howitworkview.TranslateTo(Width, 0)
                );
        }

        async void clicked_how_it_work(object sender, System.EventArgs e)
        {
            contactusviewmodel.ReCenterViewToContactUs = false;
            await Task.WhenAll(
                    UnderlineBoxView.TranslateTo(UnderlineBoxView.Width * 2, 0),
                  FAQS.TranslateTo(-Width * 2, 0),
                  contactusview.TranslateTo(-Width, 0),
                  howitworkview.TranslateTo(0, 0)
                );
        }

        void sendmail(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:" + "pthippony@gmail.com"));
        }

        async void taketour(object sender, System.EventArgs e)
        {
            //channel pthippo
            //Device.OpenUri(new Uri("vnd.youtube:channel/UCBPWpSC0ShqFFLpEostEPpg/videos"));
            //Device.OpenUri(new Uri("vnd.youtube://user/watch?v=FtUIa9LaN64&t=21s"));
            //imagenames = new List<string>
            //{
            //    "i1.jpg","i2.jpg","i3.jpg","i4.jpg","i5.jpg" , "i6.jpg"
            //};
            //MainCarouselView.ItemsSource = imagenames;
            cooloring.BackgroundColor = new Color(0, 0, 0, 0.46);
            maincv.Children.Add(cooloring);
            cooloring.Children.Add(MainCarouselView);
            cooloring.IsVisible = true;
            await cooloring.FadeTo(1);

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //faqlist.SelectedItem = null;
        }

        private void openlink(object sender, EventArgs e)
        {

            Device.OpenUri(new Uri("http://www.pthippo.com/terms"));
        }

        private void openlink1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.pthippo.com/terms"));
        }

        private void openlink2(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.pthippo.com/faq"));
        }

        private async void SkippComaand(object sender, EventArgs e)
        {
            await cooloring.FadeTo(0);
            cooloring.IsVisible = false;
            contactusviewmodel.ReCenterViewToContactUs = false;
            await Task.WhenAll(
                UnderlineBoxView.TranslateTo(UnderlineBoxView.Width * 2, 0),
                FAQS.TranslateTo(-Width * 2, 0),
                contactusview.TranslateTo(-Width, 0),
                howitworkview.TranslateTo(0, 0)
            );
            //await mainGrid.FadeTo(1);
            //mainGrid.IsVisible = true;
        }

        private void MainCarouselView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                int imagenameslistcount = imagenames.Count;
                if (MainCarouselView.Position == imagenameslistcount - 1)
                {

                    SkipButton.Text = "Finish";

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
