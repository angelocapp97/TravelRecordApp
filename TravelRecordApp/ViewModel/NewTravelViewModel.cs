using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Plugin.Geolocator;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelViewModel : INotifyPropertyChanged
    {
        private Post post;
        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged(nameof(Post));
            }
        }

        private string experience;
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                InitializePost();
                OnPropertyChanged(nameof(Experience));
            }
        }

        private Venue selectedVenue;
        public Venue SelectedVenue
        {
            get { return selectedVenue; }
            set
            {
                selectedVenue = value;
                InitializePost();
                OnPropertyChanged(nameof(SelectedVenue));
            }
        }

        private List<Venue> venues;
        public List<Venue> Venues
        {
            get { return venues; }
            set
            {
                venues = value;
                OnPropertyChanged(nameof(Venues));
            }
        }

        public SavePostCommand SavePostCommand { get; set; }

        public NewTravelViewModel()
        {
            Post = new Post();
            SavePostCommand = new SavePostCommand(this);

            InitializeVenueList();
        }

        private async void InitializeVenueList()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            Venues = await Venue.GetVenues(position.Latitude, position.Longitude);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InitializePost()
        {
            Post = new Post { Experience = Experience };

            if (SelectedVenue != null)
            {
                Post.VenueName = SelectedVenue.name;
                Post.Latitude = SelectedVenue.location.lat;
                Post.Longitude = SelectedVenue.location.lng;
                Post.Address = SelectedVenue.location.address;
                Post.Distance = SelectedVenue.location.distance;

                var firstCategory = SelectedVenue.categories.FirstOrDefault();
                if (firstCategory != null)
                {
                    Post.CategoryId = firstCategory.id;
                    Post.CategoryName = firstCategory.name;
                }
            }
        }

        public async void SavePost()
        {
            var rows = Post.Insert(Post);

            if (rows > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Experience inserted successfully", "Ok");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No experience inserted", "Ok");
        }
    }
}
