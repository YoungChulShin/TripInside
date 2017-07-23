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
        public CreateInsideView()
        {
            InitializeComponent();
            BindingContext = new CreateInsideViewModel(this.Navigation);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("이미지 동작", "취소", null, "사진 찍기", "사진 가져오기");

            if (action == "사진 가져오기")
            {
                var result = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
            }
        }
    }
}
