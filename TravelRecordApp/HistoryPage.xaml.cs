using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}
