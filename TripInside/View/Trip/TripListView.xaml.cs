﻿using System;
using System.Collections.Generic;
using TripInside.Models;
using TripInside.Service;
using TripInside.ViewModel.Trip;
using Xamarin.Forms;

namespace TripInside.View.Trip
{
    public partial class TripListView : ContentPage
    {
        public TripListView()
        {
            InitializeComponent();
            BindingContext = new TripListViewModel(this.Navigation);
        }

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            var selectedItem =  (TripInfo)e.Item;
            NavigationService.MainNavigation.PushAsync(new InsideView(selectedItem.Id));
           
            //Navigation. PushAsync(new InsideView());
            //Navigation.PushModalAsync(new NavigationPage(new InsideView())
            //    {
            //        BarBackgroundColor = Color.FromHex("#1ABC9C"),
            //        Title = "새로운 이야기"
            //    }
            //);
        }
    }
}
