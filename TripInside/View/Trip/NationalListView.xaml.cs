using System;
using System.Collections.Generic;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;
using TripInside.Model;
using System.Threading.Tasks;

namespace TripInside.View.Trip
{
    public partial class NationalListView : ContentPage
    {
        public NationalListView()
        {
            InitializeComponent();

            BindingContext = new NationalListViewModel(this.Navigation);
            tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();
        }

        public NationalInfo SelectedItem { private set; get; }


        public Task PageClosedTask { get { return tcs.Task; } }
        private TaskCompletionSource<bool> tcs { get; set; }

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
            SelectedItem = (NationalInfo)e.SelectedItem;
            Navigation.PopModalAsync(true);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			tcs.SetResult(true);
		}

		public async Task PopAwaitableAsync()
		{
			await Navigation.PopAsync();
			tcs.SetResult(true);
		}
    }
}
