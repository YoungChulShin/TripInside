using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class TripInsideView : ContentPage
    {
        public TripInsideView()
        {
            InitializeComponent();
            BindingContext = new TripInsideViewModel(this.Navigation);
        }
    }
}
