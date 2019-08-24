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

        Post post;
        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = new NewTravelViewModel();
            BindingContext = viewModel;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    post = new Post();
        //    containerStackLayout.BindingContext = post;

        //    var locator = CrossGeolocator.Current;
        //    var position = await locator.GetPositionAsync();

        //    var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
        //    venueListView.ItemsSource = venues;
        //}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                post.VenueName = selectedVenue.name;
                post.Latitude = selectedVenue.location.lat;
                post.Longitude = selectedVenue.location.lng;
                post.Address = selectedVenue.location.address;
                post.Distance = selectedVenue.location.distance;
                post.CategoryId = firstCategory.id;
                post.CategoryName = firstCategory.name;

                var rows = Post.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success", "Experience inserted successfully", "Ok");
                else
                    DisplayAlert("Error", "No experience inserted", "Ok");
            }
            catch(NullReferenceException nre)
            {

            }
            catch(Exception ex)
            {

            }
        }
    }
}
