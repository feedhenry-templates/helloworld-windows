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
        public bool Enabled { get; set; }

        public MainPage()
        {
            InitializeComponent();

            DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Enabled = await FHClient.Init();
            FirePropertyChanged("Enabled");
        }

        private async void SayHello(object sender, RoutedEventArgs e)
        {
            Response.Text = "Calling Cloud.....";
            FirePropertyChanged("Response");
            var response = await FH.Cloud("hello", "GET", null, new Dictionary<string, string>() {{"hello", HelloTo.Text}});
            if (response.Error == null)
            {
                Response.Text = (string) response.GetResponseAsDictionary()["msg"];
                FirePropertyChanged("Response");
            }
            else
            {
                await new MessageDialog(response.Error.Message).ShowAsync();
            }
        }

        private void FirePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}