using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class SavePostCommand : ICommand
    {
        NewTravelViewModel ViewModel;

        public SavePostCommand(NewTravelViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post == null)
                return false;

            if (string.IsNullOrWhiteSpace(post.Experience))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SavePost();
        }
    }
}
