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

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = postTable
                    .OrderBy(x => x.CategoryId)
                    .Select(x => x.CategoryName)
                    .Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach(var category in categories)
                {
                    var count = postTable
                        .Where(x => x.CategoryName == category)
                        .ToList().Count();

                    if (category == null)
                        categoriesCount.Add(string.Empty, count);
                    else
                        categoriesCount.Add(category, count);
                }

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}
