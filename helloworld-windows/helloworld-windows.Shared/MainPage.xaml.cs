/**
 * Copyright Red Hat, Inc, and individual contributors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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