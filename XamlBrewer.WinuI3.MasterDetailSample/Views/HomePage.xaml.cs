using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System.Linq;

namespace XamlBrewer.WinUI3.MasterDetailSample.Views
{
    public sealed partial class HomePage : Page
    {
        private readonly StandardUICommand deleteCommand = new(StandardUICommandKind.Delete) { Description = "Remove this character" };

        public HomePage()
        {
            InitializeComponent();

            deleteCommand.ExecuteRequested += DeleteCommand_ExecuteRequested;

            foreach (var character in ViewModel.Items)
            {
                character.DeleteCommand = deleteCommand;
                character.DuplicateCommand = DuplicateCommand;
            }
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

        private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            if (args.Parameter is not null)
            {
                var toBeDeleted = ViewModel.Items.FirstOrDefault(c => c.Name == args.Parameter.ToString());
                ViewModel.Items.Remove(toBeDeleted);
            }
        }

        private void DuplicateCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            var toBeDuplicated = ViewModel.Items.FirstOrDefault(c => c.Name == args.Parameter.ToString());
            ViewModel.Items.Add(toBeDuplicated.Clone());
        }
    }
}
