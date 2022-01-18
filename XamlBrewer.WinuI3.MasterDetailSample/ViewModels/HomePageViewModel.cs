using Microsoft.Toolkit.Mvvm.Input;
using System.Linq;
using System.Windows.Input;
using XamlBrewer.WinUI3.MasterDetailSample.Models;
using XamlBrewer.WinUI3.ViewModels;

namespace XamlBrewer.WinUI3.MasterDetailSample.ViewModels
{
    public partial class HomePageViewModel : MasterDetailViewModel<Character>
    {
        public HomePageViewModel()
        {
            // Populate list.
            Character.GettingStarted.OrderBy(c => c.Name).ToList().ForEach(c => Items.Add(c));
        }

        public ICommand DuplicateCommand => new RelayCommand<string>(DuplicateCommand_Executed);

        public ICommand DeleteCommand => new RelayCommand<string>(DeleteCommand_Executed);

        public Character NewCharacter => new Character
        {
            Name = "(new)"
        };

        public override bool ApplyFilter(Character item, string filter)
        {
            return item.ApplyFilter(filter);
        }

        public override Character UpdateItem(Character item, Character original)
        {
            original.Name = item.Name;
            original.Kind = item.Kind;
            original.Description = item.Description;
            original.ImagePath = item.ImagePath;

            return item;
        }

        private void DeleteCommand_Executed(string parm)
        {
            if (parm is not null)
            {
                var toBeDeleted = Items.FirstOrDefault(c => c.Name == parm);
                Items.Remove(toBeDeleted);
            }
        }

        private void DuplicateCommand_Executed(string parm)
        {
            var toBeDuplicated = Items.FirstOrDefault(c => c.Name == parm);
            Items.Add(toBeDuplicated.Clone());
        }
    }
}
