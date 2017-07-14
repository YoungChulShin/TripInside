using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TripInside.ViewModel.Trip
{
    public class TripInsideViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public TripInsideViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public ICommand MoveBack
        {
            get
            {
                return new Command(async () =>
                {
                    await _navigation.PopModalAsync();
                });
            }
        }
    }
}
