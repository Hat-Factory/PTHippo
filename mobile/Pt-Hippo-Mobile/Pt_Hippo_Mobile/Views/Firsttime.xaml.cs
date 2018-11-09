using System;
using System.Collections.Generic;
using Pt_Hippo_Mobile.Helpers;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.Views
{
    public partial class Firsttime : ContentPage
    {
        public Firsttime()
        {
            LoadingIndicatorHelper.Intialize(this);
            this.Navigation.PushModalAsync(new TermOfUsePage());
            InitializeComponent();

        }
    }
}
