using System;
namespace TravelRecordApp.Model
{
    public class User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public static bool Login(User user)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(user.Email);
            bool isPasswordEmpty = string.IsNullOrEmpty(user.Password);

            return !isEmailEmpty && !isPasswordEmpty;
        }
    }
}
