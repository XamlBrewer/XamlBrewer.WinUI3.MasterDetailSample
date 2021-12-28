using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using XamlBrewer.WinUI3.MasterDetailSample.Models;
using XamlBrewer.WinUI3.Models;

namespace XamlBrewer.WinUI3.MasterDetailSample.ViewModels
{
    public partial class HomePageViewModel : MasterDetail<Character>
    {
        public HomePageViewModel()
        {
            // Populate list.
            Character.GettingStarted.ForEach(c => Items.Add(c));
        }

        // [ObservableProperty]
        // private ICommand duplicateCommand;
    }
}
