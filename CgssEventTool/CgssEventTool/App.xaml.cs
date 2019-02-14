using System;
using CgssEventTool.Localization;
using CgssEventTool.Localization.Resources.Layout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CgssEventTool
{
    public partial class App : Application
    {
        public App()
        {
            // Localization
            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Device.RuntimePlatform == Device.Android || 
                Device.RuntimePlatform == Device.iOS)
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                // set the RESX for resource localization
                EventCalculatorPageResources.Culture = ci;

                // set the Thread for locale-aware methods
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }

            InitializeComponent();

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
