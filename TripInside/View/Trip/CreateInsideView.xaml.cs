using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripInside.DependencyServices;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class CreateInsideView : ContentPage
    {
        CreateInsideViewModel _viewModel;
        public CreateInsideView(int tripID = 0)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            _viewModel = new CreateInsideViewModel(this.Navigation, tripID);
            BindingContext = _viewModel;
            //BindingContext = new CreateInsideViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.OnDisappearing();
        }
    }
}
