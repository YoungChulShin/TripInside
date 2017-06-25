using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class CreateTripView : ContentPage
    {
        public CreateTripView()
        {
            InitializeComponent();
            BindingContext = new CreateTripViewModel(this.Navigation);
        }
    }
}
