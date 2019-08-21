using System;
using System.Collections.Generic;
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

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post
            {
                Experience = experienceEntry.Text
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Post>();
            int rows = conn.Insert(post);
            conn.Close();

            if (rows > 0)
                DisplayAlert("Success", "Experience inserted successfully", "Ok");
            else
                DisplayAlert("Error", "No experience inserted", "Ok");
        }
    }
}
