using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var postTable = conn.Table<Post>().ToList();

            var posts = Post.GetAll();

            categoriesListView.ItemsSource = Post.GetCategoriesCount(posts);

            postCountLabel.Text = posts.Count.ToString();
        }
    }
}
