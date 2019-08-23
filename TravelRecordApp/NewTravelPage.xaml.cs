using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post
                {
                    Experience = experienceEntry.Text,
                    VenueName = selectedVenue.name,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name
                };

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
