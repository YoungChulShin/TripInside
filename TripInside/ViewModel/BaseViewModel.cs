using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TripInside.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual void OnAppearing()
        {

        }
        public virtual void OnDisappearing()
        {

        }
    }
}
