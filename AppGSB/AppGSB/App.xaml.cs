using AppGSB.ClassesMetier;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppGSB
{
    public partial class App : Application
    {
        public static GstWebServices GstWS { get; set; }
        public static string LocalHost { get; set; }

        public App()
        {
            InitializeComponent();
            GstWS = new GstWebServices();
            LocalHost = "http://localhost/bts2/WSGSB/";
            // LocalHost = "http://thomas.sio19ingetis.lan/PPE4_GSB/WSGSB/";

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
