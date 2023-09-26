using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using XamlBrewer.WinUI3.MasterDetailSample.Models;

namespace XamlBrewer.WinUI3.MasterDetailSample.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;

            base.OnNavigatingFrom(e);
        }

        public ICommand NewCommand => new AsyncRelayCommand(OpenNewDialog);

        public ICommand EditCommand => new AsyncRelayCommand(OpenEditDialog);

        private ICommand UpdateCommand => new RelayCommand(Update);

        private ICommand InsertCommand => new RelayCommand(Insert);

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Current" && ViewModel.HasCurrent)
            {
                CharacterListView.ScrollIntoView(ViewModel.Current);
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

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.Filter = args.QueryText;
        }

        private async Task OpenNewDialog()
        {
            EditDialog.Title = "New Character";
            EditDialog.PrimaryButtonText = "Insert";
            EditDialog.PrimaryButtonCommand = InsertCommand;
            EditDialog.DataContext = new Character();
            await EditDialog.ShowAsync();
        }

        private async Task OpenEditDialog()
        {
            EditDialog.Title = "Edit Character";
            EditDialog.PrimaryButtonText = "Update";
            EditDialog.PrimaryButtonCommand = UpdateCommand;
            var clone = ViewModel.Current.Clone();
            clone.Name = ViewModel.Current.Name;
            EditDialog.DataContext = clone;
            await EditDialog.ShowAsync();
        }

        private void Update()
        {
            ViewModel.UpdateItem(EditDialog.DataContext as Character, ViewModel.Current);
        }

        private void Insert()
        {
            // Does not work when filter is active:
            // ViewModel.Items.Add(EditDialog.DataContext as Character);

            var character = ViewModel.AddItem(EditDialog.DataContext as Character);
            if (ViewModel.Items.Contains(character))
            {
                ViewModel.Current = character;
            }
        }
    }
}
