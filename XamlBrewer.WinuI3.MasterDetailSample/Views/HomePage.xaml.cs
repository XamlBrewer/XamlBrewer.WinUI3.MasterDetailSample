using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand NewCommand => new AsyncRelayCommand(OpenNewDialog);

        public ICommand EditCommand => new AsyncRelayCommand(OpenEditDialog);

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

        private async Task OpenNewDialog()
        {
            EditDialog.Title = "New Character";
            EditDialog.DataContext = ViewModel.NewCharacter;
            await EditDialog.ShowAsync();
        }

        private async Task OpenEditDialog()
        {
            EditDialog.Title = "Edit Character";
            var clone = ViewModel.Current.Clone();
            clone.Name = ViewModel.Current.Name;
            EditDialog.DataContext = clone;
            await EditDialog.ShowAsync();
        }
    }
}
