using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripInside.View.Trip
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateInsideCameraView : ContentPage
    {
        public CreateInsideCameraView(List<Image> images, int index)
        {
            InitializeComponent();
            BindingContext = new CreateInsideCameraViewModel(this.Navigation, images, index);
        }
    }
}