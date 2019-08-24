using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        User user;
        public MainPage()
        {
            InitializeComponent();

            user = new User();
            containerStackLayout.BindingContext = user;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var canLogin = User.Login(user);

            if (canLogin)
                Navigation.PushAsync(new HomePage());
            else
            {
                DisplayAlert("Login error", "Check your credentials and try again", "Ok");
                user.Password = string.Empty;
            }
                
        }
    }
}
