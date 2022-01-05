using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Input;
using System.Linq;
using System.Windows.Input;
using XamlBrewer.WinUI3.MasterDetailSample.Models;
using XamlBrewer.WinUI3.ViewModels;

namespace XamlBrewer.WinUI3.MasterDetailSample.ViewModels
{
    public partial class HomePageViewModel : MasterDetailViewModel<Character>
    {
        private XamlUICommand deleteCommand;

        public HomePageViewModel()
        {
            // Populate list.
            Character.GettingStarted.OrderBy(c => c.Name).ToList().ForEach(c => Items.Add(c));
        }

        public XamlUICommand DeleteCommand
        {
            get => deleteCommand;
            set
            {
                SetProperty(ref deleteCommand, value);
                foreach (var character in Items)
                {
                    character.DeleteCommand = deleteCommand;
                }

                deleteCommand.ExecuteRequested += DeleteCommand_ExecuteRequested;
            }
        }

        public ICommand DuplicateCommand => new RelayCommand<string>(DuplicateCommand_Executed);

        public Character NewCharacter => new Character
        {
            Name = "(new)",
            DeleteCommand = DeleteCommand
        };

        private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            if (args.Parameter is not null)
            {
                var toBeDeleted = Items.FirstOrDefault(c => c.Name == args.Parameter.ToString());
                // Items.Remove(toBeDeleted);
                RemoveItem(toBeDeleted);
            }
        }

        private void DuplicateCommand_Executed(string parm)
        {
            var toBeDuplicated = Items.FirstOrDefault(c => c.Name == parm);
            // ViewModel.Items.Add(toBeDuplicated.Clone());
            AddItem(toBeDuplicated.Clone());
            Items.OrderBy(i => i.Name);
        }
    }
}
