using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TripInside.View
{
    public partial class MainLoadingView : ContentPage
    {
        public MainLoadingView()
        {
            InitializeComponent();
        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
            Application.Current.MainPage = new MainAppView();
		}
    }
}
