using System;
using System.Collections.Generic;
using TripInside.Service;
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
            // NavigationService.MainNavigation = this.Navigation;
            Application.Current.MainPage = new NavigationPage(new MainAppView()
            {
                BarBackgroundColor = Color.FromHex("#3498DB"),
                BarTextColor = Color.White
            });
		}
    }
}
