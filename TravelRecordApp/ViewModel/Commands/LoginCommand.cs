using System;
using System.Net.Mail;
using System.Windows.Input;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainViewModel MainViewModel { get; set; }

        public LoginCommand(MainViewModel viewModel)
        {
            MainViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
                return false;

            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                return false;

            if (!Validator.IsValidEmail(user.Email))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Login();
        }
    }
}
