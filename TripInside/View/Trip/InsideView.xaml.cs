using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class InsideView : ContentPage
    {
        public InsideView(int tripID)
        {
            InitializeComponent();
            BindingContext = new InsideViewModel(this.Navigation, tripID);
        }
    }
}
