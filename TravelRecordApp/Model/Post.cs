using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string experience;
        [MaxLength(250)]
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }

        private string venueName;
        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanged(nameof(VenueName));
            }
        }

        private string categoryId;
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private int distance;
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        private DateTimeOffset createdAt;
        public DateTimeOffset CreatedAt
        {
            get { return createdAt; }
            set
            {
                createdAt = value;
                OnPropertyChanged(nameof(createdAt));
            }
        }

        private DateTimeOffset lastUpdate;
        public DateTimeOffset LastUpdate
        {
            get { return lastUpdate; }
            set
            {
                lastUpdate = value;
                OnPropertyChanged(nameof(LastUpdate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Post> GetAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                return conn.Table<Post>().ToList();
            }
        }

        public static int Insert(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                post.CreatedAt = DateTimeOffset.Now;
                post.lastUpdate = DateTimeOffset.Now;

                conn.CreateTable<Post>();
                return conn.Insert(post);
            }
        }

        public static int Update(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                post.LastUpdate = DateTimeOffset.Now;

                conn.CreateTable<Post>();
                return conn.Update(post);
            }
        }

        public static int Delete(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                return conn.Delete(post);
            }
        }

        public static Dictionary<string, int> GetCategoriesCount(List<Post> posts)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var categories = posts
                    .OrderBy(x => x.CategoryId)
                    .Select(x => x.CategoryName)
                    .Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach (var category in categories)
                {
                    var count = posts
                        .Where(x => x.CategoryName == category)
                        .ToList().Count();

                    if (category == null)
                        categoriesCount.Add(string.Empty, count);
                    else
                        categoriesCount.Add(category, count);
                }

                return categoriesCount;
            }
        }
    }
}
