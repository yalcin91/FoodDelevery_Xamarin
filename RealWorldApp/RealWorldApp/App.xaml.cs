﻿using RealWorldApp.Pages;

using System;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var accesToken =  Preferences.Get("accesToken", string.Empty);
            if (string.IsNullOrEmpty(accesToken))
            {
                MainPage = new NavigationPage(new SignupPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
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
