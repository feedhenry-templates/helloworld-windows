using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using FHSDKPortable;
using System;
using Windows.UI.Popups;
using FHSDK;

namespace helloworld_windows
{
    /// <summary>
    ///     This is a basic App that can take in your name, send it to a cloud app and display the response.
    /// </summary>
    public sealed partial class MainPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            InitializeComponent();

            DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await FHClient.Init();
        }

        private async void SayHello(object sender, RoutedEventArgs e)
        {
            Response.Text = "Calling Cloud.....";
            FirePropertyChanged();
            var response = FH.Cloud("hello", "GET", null, new Dictionary<string, string>() {{"hello", HelloTo.Text}});
            if (!response.IsFaulted)
            {
                Response.Text = response.Result.RawResponse;
                FirePropertyChanged();
            }
            else
            {
                await new MessageDialog(response.Exception.Message).ShowAsync();
            }
        }

        private void FirePropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Response"));
            }
        }
    }
}