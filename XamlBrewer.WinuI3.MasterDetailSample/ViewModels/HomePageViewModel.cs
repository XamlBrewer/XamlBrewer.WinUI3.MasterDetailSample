using XamlBrewer.WinUI3.MasterDetailSample.Models;
using XamlBrewer.WinUI3.ViewModels;

namespace XamlBrewer.WinUI3.MasterDetailSample.ViewModels
{
    public partial class HomePageViewModel : MasterDetailViewModel<Character>
    {
        public HomePageViewModel()
        {
            // Populate list.
            Character.GettingStarted.ForEach(c => Items.Add(c));
        }
    }
}
