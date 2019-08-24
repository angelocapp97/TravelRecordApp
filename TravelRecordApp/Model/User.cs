using System;
using System.ComponentModel;

namespace TravelRecordApp.Model
{
    public class User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public static bool Login(User user)
        {
            if (user.Email == "asd@asd" && user.Password == "asdasd")
                return true;

            return false;
        }
    }
}
