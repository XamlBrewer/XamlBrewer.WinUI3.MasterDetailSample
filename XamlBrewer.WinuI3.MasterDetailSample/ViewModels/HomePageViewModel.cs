using Microsoft.UI.Xaml.Input;
using System.Linq;
using XamlBrewer.WinUI3.MasterDetailSample.Models;
using XamlBrewer.WinUI3.ViewModels;

namespace XamlBrewer.WinUI3.MasterDetailSample.ViewModels
{
    public partial class HomePageViewModel : MasterDetailViewModel<Character>
    {
        private XamlUICommand deleteCommand;
        private XamlUICommand duplicateCommand;

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

        public XamlUICommand DuplicateCommand
        {
            get => duplicateCommand;
            set
            {
                SetProperty(ref duplicateCommand, value);
                foreach (var character in Items)
                {
                    character.DuplicateCommand = duplicateCommand;
                }

                duplicateCommand.ExecuteRequested += DuplicateCommand_ExecuteRequested; ;
            }
        }

        public Character NewCharacter => new Character
        {
            Name = "(new)",
            DeleteCommand = DeleteCommand,
            DuplicateCommand = DuplicateCommand
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

        private void DuplicateCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            var toBeDuplicated = Items.FirstOrDefault(c => c.Name == args.Parameter.ToString());
            // ViewModel.Items.Add(toBeDuplicated.Clone());
            AddItem(toBeDuplicated.Clone());
            Items.OrderBy(i => i.Name);
        }
    }
}
