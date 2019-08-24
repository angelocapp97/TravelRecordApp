using System;
using TravelRecordApp.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class HomeViewModel
    {
        public NavigationCommand NavigationCommand { get; set; }

        public HomeViewModel()
        {
            NavigationCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
