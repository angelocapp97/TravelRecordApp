using System;
namespace TravelRecordApp.Helpers
{
    public class Constants
    {
        public const string CLIENT_ID = "UQ5DHGMLDBHP2LMB0QB3VTTZBGN40SNF4GQPIGH4VXFNH2NO";
        public const string CLIENT_SECRET = "SKK0WTTQEV34ZBRDD4RKGBVKYCOPBX25LVVH4IE4ZFXIT2FG";

        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id=" + CLIENT_ID + "&client_secret=" + CLIENT_SECRET + "&v={2}";
    }
}
