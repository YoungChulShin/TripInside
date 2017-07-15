using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class TripListView : ContentPage
    {
        public TripListView()
        {
            InitializeComponent();
            BindingContext = new TripListViewModel(this.Navigation);
        }

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            //Navigation.PushModalAsync(new CreateInsideView());
            Navigation.PushModalAsync(new InsideView());
        }
    }
}
