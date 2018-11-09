using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Controls
{
   public class ImageEntry : Entry
    {
        public ImageEntry()
        {
           
            if (Device.RuntimePlatform == Device.Android)
            {
                this.Opacity = 0.5;
            }
            else
            {
                this.HeightRequest = 40;
            }
        }

        public static readonly BindableProperty ImageProperty =

            BindableProperty.Create(nameof(Image), typeof(string), typeof(ImageEntry), string.Empty);



        public static readonly BindableProperty LineColorProperty =

            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(ImageEntry), Color.DarkGray);



        public static readonly BindableProperty ImageHeightProperty =

            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(ImageEntry), 10);



        public static readonly BindableProperty ImageWidthProperty =

            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(ImageEntry), 40);



        public static readonly BindableProperty ImageAlignmentProperty =

            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(ImageEntry), ImageAlignment.Right);



        public Color LineColor

        {

            get { return (Color)GetValue(LineColorProperty); }

            set { SetValue(LineColorProperty, value); }

        }



        public int ImageWidth

        {

            get { return (int)GetValue(ImageWidthProperty); }

            set { SetValue(ImageWidthProperty, value); }

        }



        public int ImageHeight

        {

            get { return (int)GetValue(ImageHeightProperty); }

            set { SetValue(ImageHeightProperty, value); }

        }



        public string Image

        {

            get { return (string)GetValue(ImageProperty); }

            set { SetValue(ImageProperty, value); }

        }



        public ImageAlignment ImageAlignment

        {

            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }

            set { SetValue(ImageAlignmentProperty, value); }

        }

    }



    public enum ImageAlignment

    {

        Left,

        Right

    }

}
