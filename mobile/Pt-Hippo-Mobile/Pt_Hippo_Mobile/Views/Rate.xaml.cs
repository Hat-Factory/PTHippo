using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Rating;
using Pt_Hippo_Mobile.ViewModel;
using Pt_Hippo_Mobile.Views.jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;

namespace Pt_Hippo_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rate : ContentPage
    {
        RatingCounter api = new RatingCounter();


        public int ratevalue;
        public Rate()
        {
            InitializeComponent();
            BindingContext = new RatingViewModel(Navigation);
            constants.mysubmits = new List<RatinganswerModel>();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        protected override async void OnAppearing()
        {
            await Task.Yield();
            try
            {
                Api();
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in Rate.Xamal.cs", ex);
                await logged.LoggAPI();
            }
        }
        public async void Api()
        {
            await api.Getcounter(URLConfig.Getcounter);
            if (constants.PendingRatingCount < 1)
            {
                norategrid.IsVisible = true;
                rategrid.IsVisible = false;
                Qgrid.IsVisible = false;

            }
            else
            {
                rategrid.IsVisible = true;
                Qgrid.IsVisible = true;
                norategrid.IsVisible = false;

            }
        }
        private async void gr_Tapped(object sender, EventArgs e)
        {
            var page = new NewJobDetail(((RatingViewModel)this.BindingContext).Id);
            NavigationPage.SetHasNavigationBar(page, false);
            await Navigation.PushModalAsync(page);
        }



        private void answerone(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(image1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                image1.Source = "RadiooCh.png";
                image2.Source = "RadiooUn.png";
                image3.Source = "RadiooUn.png";
                image4.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);

            }
            else
            {

            }
        }

        private void answertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(image2.Source)).File;
            if (fileName == "RadiooUn.png")
            {

                image1.Source = "RadiooUn.png";
                image2.Source = "RadiooCh.png";
                image3.Source = "RadiooUn.png";
                image4.Source = "RadiooUn.png";

                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);
            }
            else
            {

            }
        }

        private void answerthree(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(image3.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                image1.Source = "RadiooUn.png";
                image2.Source = "RadiooUn.png";
                image3.Source = "RadiooCh.png";
                image4.Source = "RadiooUn.png";
                ratevalue = 3;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {


            }
        }

        private void answerfour(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(image4.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                image1.Source = "RadiooUn.png";
                image2.Source = "RadiooUn.png";
                image3.Source = "RadiooUn.png";
                image4.Source = "RadiooCh.png";
                ratevalue = 4;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qtwoanswerone(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(im1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                im1.Source = "RadiooCh.png";
                im2.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qtwoanswertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(im2.Source)).File;
            if (fileName == "RadiooUn.png")
            {

                im1.Source = "RadiooUn.png";
                im2.Source = "RadiooCh.png";
                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);

            }
            else
            {

            }
        }

        private void Qthreeanswerone(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(ima1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                ima1.Source = "RadiooCh.png";
                ima2.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                else
                {
                    constants.mysubmits.Add(anss);
                }



            }
            else
            {

            }
        }

        private void Qthreeanswertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(ima2.Source)).File;
            if (fileName == "RadiooUn.png")
            {

                ima1.Source = "RadiooUn.png";
                ima2.Source = "RadiooCh.png";
                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);

            }
            else
            {
            }
        }














        private void Qfouranswerone(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imag1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imag1.Source = "RadiooCh.png";
                imag2.Source = "RadiooUn.png";
                imag3.Source = "RadiooUn.png";
                imag4.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qfoureanswertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imag2.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imag1.Source = "RadiooUn.png";
                imag2.Source = "RadiooCh.png";
                imag3.Source = "RadiooUn.png";
                imag4.Source = "RadiooUn.png";
                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qfouranswerthree(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imag3.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imag1.Source = "RadiooUn.png";
                imag2.Source = "RadiooUn.png";
                imag3.Source = "RadiooCh.png";
                imag4.Source = "RadiooUn.png";
                ratevalue = 3;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {


            }
        }

        private void Qfoureanswerfouer(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imag4.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imag1.Source = "RadiooUn.png";
                imag2.Source = "RadiooUn.png";
                imag3.Source = "RadiooUn.png";
                imag4.Source = "RadiooCh.png";
                ratevalue = 4;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }



        private void Qfiveanswerone(object sender, EventArgs e)
        {

            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(iimag1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                iimag1.Source = "RadiooCh.png";
                iimag2.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {


            }
        }


        private void Qfiveanswertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(iimag2.Source)).File;
            if (fileName == "RadiooUn.png")
            {

                iimag1.Source = "RadiooUn.png";
                iimag2.Source = "RadiooCh.png";
                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);

            }
            else
            {
            }
        }

        private void Qsixanswerone(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imagnew.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imagnew.Source = "RadiooCh.png";
                imagnew1.Source = "RadiooUn.png";
                imagnew2.Source = "RadiooUn.png";
                imagnew3.Source = "RadiooUn.png";
                ratevalue = 1;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qsixanswertwo(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imagnew1.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imagnew.Source = "RadiooUn.png";
                imagnew1.Source = "RadiooCh.png";
                imagnew2.Source = "RadiooUn.png";
                imagnew3.Source = "RadiooUn.png";
                ratevalue = 2;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qsixanswerthree(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imagnew2.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imagnew.Source = "RadiooUn.png";
                imagnew1.Source = "RadiooUn.png";
                imagnew2.Source = "RadiooCh.png";
                imagnew3.Source = "RadiooUn.png";
                ratevalue = 3;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }

        private void Qsixanswerfouer(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs))
            {
                return;
            }

            var itemtaped = ((TappedEventArgs)e).Parameter;
            var fileName = ((dynamic)(imagnew3.Source)).File;
            if (fileName == "RadiooUn.png")
            {
                imagnew.Source = "RadiooUn.png";
                imagnew1.Source = "RadiooUn.png";
                imagnew2.Source = "RadiooUn.png";
                imagnew3.Source = "RadiooCh.png";
                ratevalue = 4;
                RatinganswerModel anss = new RatinganswerModel();
                anss.RatingQuestionId = itemtaped.ToString();
                anss.RateValue = ratevalue;
                var oldQuestionAnser = constants.mysubmits.Find(d => d.RatingQuestionId == anss.RatingQuestionId);

                if (oldQuestionAnser != null)
                {
                    constants.mysubmits.Remove(oldQuestionAnser);

                }
                constants.mysubmits.Add(anss);


            }
            else
            {

            }
        }
    }
}