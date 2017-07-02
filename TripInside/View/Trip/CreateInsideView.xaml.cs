using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class CreateInsideView : ContentPage
    {
        public CreateInsideView()
        {
            InitializeComponent();
            BindingContext = new CreateInsideViewModel(this.Navigation);
        }
    }
}
