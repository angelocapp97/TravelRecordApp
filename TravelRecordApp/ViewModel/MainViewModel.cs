using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;

                User = new User
                {
                    Email = Email,
                    Password = Password
                };

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

                User = new User
                {
                    Email = Email,
                    Password = Password
                };

                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginCommand LoginCommand { get; set; }

        public MainViewModel()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Login()
        {
            var canLogin = User.Login(User);

            if (canLogin)
                await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login error", "Check your credentials and try again", "Ok");
                User.Password = string.Empty;
            }
        }
    }
}
