using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace XamlBrewer.WinUI3.MasterDetailSample.Views
{
    public sealed partial class HomePage : Page
    {
        private readonly StandardUICommand deleteCommand = new(StandardUICommandKind.Delete) { Description = "Remove this character" };

        public HomePage()
        {
            InitializeComponent();

            ViewModel.DeleteCommand = deleteCommand;
            ViewModel.DuplicateCommand = DuplicateCommand;
        }

        private void ListViewItem_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType is PointerDeviceType.Mouse or PointerDeviceType.Pen)
            {
                VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
            }
        }

        private void ListViewItem_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.Filter = args.QueryText;
        }
    }
}
