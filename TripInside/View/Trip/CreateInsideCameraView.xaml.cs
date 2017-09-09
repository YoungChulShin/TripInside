using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripInside.Models;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripInside.View.Trip
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateInsideCameraView : ContentPage
    {
        private CreateInsideCameraViewModel _createInsideCameraViewModel;
        public CreateInsideCameraView(List<CameraGallery> cameraGalley)
        {
            InitializeComponent();

            _createInsideCameraViewModel = new CreateInsideCameraViewModel(this.Navigation, cameraGalley);
            BindingContext = _createInsideCameraViewModel;
            //BindingContext = new CreateInsideCameraViewModel(this.Navigation, images, index);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _createInsideCameraViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _createInsideCameraViewModel.OnDisappearing();
        }
    }
}