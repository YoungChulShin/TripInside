using System;
using System.Collections.Generic;
using TripInside.Service;
using TripInside.View.Setting;
using TripInside.View.Trip;
using Xamarin.Forms;

namespace TripInside.View
{
    public partial class MainAppView : TabbedPage
    {
        public MainAppView()
        {
            //NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            NavigationService.MainNavigation = Navigation;

            Children.Add(new TripListView() { Title = "여행 기록" });
            Children.Add(new SettingView() { Title = "설정" });

            //Children.Add(new NavigationPage(new TripListView()) { Title = "여행 기록"  });
            //Children.Add(new NavigationPage(new SettingView()) { Title = "설정" });
        }
    }
}
