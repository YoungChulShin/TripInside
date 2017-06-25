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
    }
}
