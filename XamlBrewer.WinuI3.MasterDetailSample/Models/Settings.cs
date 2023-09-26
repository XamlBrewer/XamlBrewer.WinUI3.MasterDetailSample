using CommunityToolkit.Mvvm.ComponentModel;

namespace XamlBrewer.WinUI3.Models
{
    public partial class Settings : ObservableObject
    {
        [ObservableProperty]
        private bool isLightTheme;

        public Settings()
        {
            // Required for serialization.
        }
    }
}