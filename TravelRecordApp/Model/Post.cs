using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public int Distance { get; set; }

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
                conn.CreateTable<Post>();
                return conn.Insert(post);
            }
        }

        public static int Update(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
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
