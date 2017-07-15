using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("이미지 동작", "취소", null, "사진 찍기", "사진 가져오기");
            string aa = action.ToString();
        }

        private async Task SelectPicture()
        {
            ImageSource imageSource = null;
            var _mediaPicker = DependencyService.Get<IMediaPicker>();
            try
            {
                var mediaFile = await this._mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });
                imageSource = ImageSource.FromStream(() => mediaFile.Source);
            }
            catch (System.Exception ex)
            {

            }

        }
    }
}
