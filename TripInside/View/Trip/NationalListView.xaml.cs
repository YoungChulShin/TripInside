using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;
using System.Threading.Tasks;
using TripInside.Models;

namespace TripInside.View.Trip
{
    public partial class NationalListView : ContentPage
    {
        public NationalListView()
        {
            InitializeComponent();

            BindingContext = new NationalListViewModel(this.Navigation);
        }

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
            MessagingCenter.Send<CreateTripView, NationalInfo>(new CreateTripView(), "SelectNation", (e.SelectedItem as NationalInfo));
            Navigation.PopModalAsync(true);
		}
    }
}
