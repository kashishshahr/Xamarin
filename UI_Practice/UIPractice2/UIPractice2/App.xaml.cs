﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIPractice2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new loginCodeBehind();
            MainPage = new NavigationPage( new Page1());
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
