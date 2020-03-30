using APP_FITNESS.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FITNESS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginViews());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
