using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExoticRose
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new Mapa());
            MainPage = new NavigationPage(new Camara());
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
