using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        NewTravelViewModel viewModel;

        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = new NewTravelViewModel();
            BindingContext = viewModel;
        }
    }
}
