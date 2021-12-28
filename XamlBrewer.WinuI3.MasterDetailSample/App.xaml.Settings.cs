using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using XamlBrewer.WinUI3.Models;

namespace XamlBrewer.WinUI3.MasterDetailSample
{
    public partial class App : Application
    {
        private const string settingsFile = "settings.xml";

        public Settings Settings { get; set; }

        internal void EnsureSettings()
        {
            try
            {
                var applicationData = ApplicationData.Current.LocalSettings.Values[settingsFile];
                if (applicationData == null)
                {
                    Settings = null;
                }
                else
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    Settings = serializer.Deserialize(new StringReader(applicationData.ToString())) as Settings;
                }
            }
#pragma warning disable 0168
            catch (Exception ex)
#pragma warning restore 0168
            {
                // Unable to read the settings (e.g. broken xml)
                Debugger.Break();
                Settings = null;
                ApplicationData.Current.LocalSettings.Values.Remove(settingsFile);
            }

            if (Settings == null)
            {
                Settings = new Settings()
                {
                    // Default values here ...
                };
            }

            Settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Application reaction here.
        }

        public void SaveSettings()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Settings));
                var stringWriter = new StringWriter();
                serializer.Serialize(stringWriter, Settings);
                var applicationData = stringWriter.ToString();
                ApplicationData.Current.LocalSettings.Values[settingsFile] = applicationData;
            }
#pragma warning disable 0168
            catch (Exception ex)
#pragma warning restore 0168
            {
                Debugger.Break();
            }
        }
    }
}
