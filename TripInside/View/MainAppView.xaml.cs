using System;
using System.Collections.Generic;
using TripInside.View.Setting;
using TripInside.View.Trip;
using Xamarin.Forms;

namespace TripInside.View
{
    public partial class MainAppView : TabbedPage
    {
        public MainAppView()
        {
            InitializeComponent();

            Children.Add(new NavigationPage(new TripListView()) { Title = "여행 기록"  });
            Children.Add(new NavigationPage(new SettingView()) { Title = "설정" });
        }
    }
}
