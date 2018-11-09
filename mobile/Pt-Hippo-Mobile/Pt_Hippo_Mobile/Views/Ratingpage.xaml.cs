using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.Rating;
using Pt_Hippo_Mobile.Views.MasterList;
using Xamarin.Forms;
using Pt_Hippo_Mobile.ViewModel;

namespace Pt_Hippo_Mobile.Views
{
    public partial class Ratingpage : ContentPage
    {
		public List<RatingModel> rate;
        RatingCounter api = new RatingCounter();
        public Ratingpage()
        {
            //LoadingIndicatorHelper.Intialize(this);
			rate = new List<RatingModel>();
			InitializeComponent();
            BindingContext = new RatingViewModel(Navigation);
            constants.mysubmits = new List<RatinganswerModel>();

           

        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override void OnAppearing()
        {
            Task.Yield();
           // Api();
        }
     /*   public async void Api()
        {
            await api.Getcounter(URLConfig.Getcounter);
            if (constants.PendingRatingCount < 1)
            {
                norategrid.IsVisible = true;
               // rategrid.IsVisible = false;
                    
               
            }
            else
            {
                norategrid.IsVisible = false;
               // rategrid.IsVisible = true;
                    
            }

        }*/
       /* void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
           // mylist.SelectedItem = null;
        }*/

       
    }
	public class ItemTemplateViewCell : ViewCell
	{

		RatinganswerModel anss = new RatinganswerModel();

		public int ratevalue;
		public int counter = 0;

        Label NameLbl = new Label{Opacity=0.5,TranslationY=7};
        Label IdLbl = new Label{ Opacity = 0.5 };
        Label yes = new Label{ Opacity = 0.5, TranslationX = 5 ,FontSize=13 };
        Label maybe = new Label{ Opacity = 0.5, TranslationX = 10,FontSize=13};
        Label sure = new Label{ Opacity = 0.5, TranslationX = 15 ,FontSize=13 };
        Label no = new Label{ Opacity = 0.5 , TranslationX = 25,FontSize=13};
		StackLayout sLayout = new StackLayout();
		StackLayout sLayout2 = new StackLayout();
		StackLayout layoutyes = new StackLayout();
		StackLayout layoutno = new StackLayout();
		StackLayout layoutmaybe = new StackLayout();
		StackLayout layoutsure = new StackLayout();

        Image image1 = new Image { Source="RadiooUn",WidthRequest=20, HeightRequest=20 , TranslationX=5 };

        Image image2 = new Image { Source = "RadiooUn", WidthRequest = 20, HeightRequest = 20, TranslationX = 10 };
        Image image3 = new Image { Source = "RadiooUn", WidthRequest = 20, HeightRequest = 20, TranslationX = 15 };
        Image image4 = new Image { Source = "RadiooUn", WidthRequest = 20, HeightRequest = 20, TranslationX = 16 };

	

		public ItemTemplateViewCell()
		{
			NameLbl.SetBinding(Label.TextProperty, "Question");
			IdLbl.SetBinding(Label.TextProperty, "Id");
            IdLbl.IsVisible = false;

			yes.Text = "Yes";
			maybe.Text = "May be";
			sure.Text = "Sure";
			no.Text = "No";
			sLayout.Children.Add(NameLbl);
			sLayout.Children.Add(IdLbl);
          
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty,new Binding("Id"));
            image1.GestureRecognizers.Add(tapGestureRecognizer);
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (!(e is TappedEventArgs))
                {
                    return;
                }

                var itemtaped = ((TappedEventArgs)e).Parameter;
         
                //anss = new RatinganswerModel();
                var fileName = ((dynamic)(image1.Source)).File;
                if (fileName == "RadiooUn.png")
                {
                    image1.Source = "RadiooCh.png";
                    image3.Source = "RadiooUn.png";
                    image2.Source = "RadiooUn.png";
                    image4.Source = "RadiooUn.png";
                    ratevalue = 1;
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
                    image1.Source = "RadiooUn.png";
                   
                }

             
            };
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("Id"));
            image2.GestureRecognizers.Add(tapGestureRecognizer2);
            tapGestureRecognizer2.Tapped += (s, e) =>
              {
                  if (!(e is TappedEventArgs))
                  {
                      return;
                  }

                  var itemtaped = ((TappedEventArgs)e).Parameter;
                 
                  //anss = new RatinganswerModel();
                  var fileName = ((dynamic)(image2.Source)).File;
                  if (fileName == "RadiooUn.png")
                  {
                      image2.Source = "RadiooCh.png";
                      image1.Source = "RadiooUn.png";
                      image3.Source = "RadiooUn.png";
                      image4.Source = "RadiooUn.png";
                      ratevalue = 2;
                     
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
                      image2.Source = "RadiooUn.png";

                  }
              };
            var tapGestureRecognizer3= new TapGestureRecognizer();
            tapGestureRecognizer3.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("Id"));
            image3.GestureRecognizers.Add(tapGestureRecognizer3);
            tapGestureRecognizer3.Tapped += (s, e) =>
            {
                if (!(e is TappedEventArgs))
                {
                    return;
                }

                var itemtaped = ((TappedEventArgs)e).Parameter;
               
                //anss = new RatinganswerModel();
                var fileName = ((dynamic)(image3.Source)).File;
                if (fileName == "RadiooUn.png")
                {
                    image3.Source = "RadiooCh.png";
                    image1.Source = "RadiooUn.png";
                    image2.Source = "RadiooUn.png";
                    image4.Source = "RadiooUn.png";
                    ratevalue = 3;
                
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
                    image3.Source = "RadiooUn.png";

                }
            };
            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("Id"));
            image4.GestureRecognizers.Add(tapGestureRecognizer4);
            tapGestureRecognizer4.Tapped += (s, e) =>
            {
                if (!(e is TappedEventArgs))
                {
                    return;
                }

                var itemtaped = ((TappedEventArgs)e).Parameter;

                //anss = new RatinganswerModel();
                var fileName = ((dynamic)(image4.Source)).File;
                if (fileName == "RadiooUn.png")
                {
                    image4.Source = "RadiooCh.png";
                    image1.Source = "RadiooUn.png";
                    image3.Source = "RadiooUn.png";
                    image2.Source = "RadiooUn.png";
                    ratevalue = 4;
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
                    image4.Source = "RadiooUn.png";

                }
            };
          
			sLayout.Orientation = StackOrientation.Vertical;
			sLayout2.Orientation = StackOrientation.Horizontal;
			layoutyes.Orientation = StackOrientation.Horizontal;
            layoutyes.Margin = new Thickness(5, 20, 5, 20);
            layoutyes.Children.Add(image1);
			layoutyes.Children.Add(yes);
			
			layoutmaybe.Orientation = StackOrientation.Horizontal;
			layoutmaybe.Margin = new Thickness(5, 20, 5, 20);
            layoutmaybe.Children.Add(image2);
			layoutmaybe.Children.Add(maybe);
			
			layoutsure.Orientation = StackOrientation.Horizontal;
            layoutsure.Margin = new Thickness(5, 20, 5, 20);
            layoutsure.Children.Add(image3);
			layoutsure.Children.Add(sure);
			
			layoutno.Orientation = StackOrientation.Horizontal;
            layoutno.Margin = new Thickness(5, 20, 5, 20);
            layoutno.Children.Add(image4);
			layoutno.Children.Add(no);
		
			sLayout2.Children.Add(layoutyes);
			sLayout2.Children.Add(layoutsure);
			sLayout2.Children.Add(layoutmaybe);
			sLayout2.Children.Add(layoutno);
			sLayout.Children.Add(sLayout2);
            this.View = sLayout;
		}

       
    }
}
