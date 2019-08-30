using System;
using System.Collections.ObjectModel;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }

        public void UpdatePosts()
        {
            var posts = Post.GetAll();

            if (posts != null)
            {
                Posts.Clear();

                foreach (var post in posts)
                    Posts.Add(post);
            }
        }
    }
}
