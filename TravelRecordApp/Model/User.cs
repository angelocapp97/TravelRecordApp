using System;
using System.ComponentModel;

namespace TravelRecordApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static bool Login(User user)
        {
            bool isEmailEmpty = string.IsNullOrWhiteSpace(user.Email);
            bool isPasswordEmpty = string.IsNullOrWhiteSpace(user.Password);

            return !isEmailEmpty && !isPasswordEmpty;
        }
    }
}
