using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
        }

        void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            int rows = Post.Update(selectedPost);

            if (rows > 0)
                DisplayAlert("Success", "Experience updated successfully", "Ok");
            else
                DisplayAlert("Error", "No experience updated", "Ok");
        }

        void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int rows = Post.Delete(selectedPost);

            if (rows > 0)
                DisplayAlert("Success", "Experience deleted successfully", "Ok");
            else
                DisplayAlert("Error", "No experience deleted", "Ok");
        }
    }
}
