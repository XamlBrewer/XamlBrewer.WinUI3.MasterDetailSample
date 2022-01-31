using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
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

            Items.CollectionChanged += Items_CollectionChanged;
        }

        public ICommand DuplicateCommand => new RelayCommand<string>(DuplicateCommand_Executed);

        public ICommand DeleteCommand => new RelayCommand<string>(DeleteCommand_Executed);

        public override bool ApplyFilter(Character item, string filter)
        {
            return item.ApplyFilter(filter);
        }

        public override Character UpdateItem(Character item, Character original)
        {
            // Does not raise CollectionChanged.
            return original.UpdateFrom(item);
        }

        private void DeleteCommand_Executed(string parm)
        {
            if (parm is not null)
            {
                var toBeDeleted = Items.FirstOrDefault(c => c.Name == parm);

                // Not OK when a filter is applied.
                // Items.Remove(toBeDeleted);

                DeleteItem(toBeDeleted);
            }
        }

        private void DuplicateCommand_Executed(string parm)
        {
            var toBeDuplicated = Items.FirstOrDefault(c => c.Name == parm);
            var clone = toBeDuplicated.Clone();
            // Items.Add(clone);
            AddItem(clone);
            if (Items.Contains(clone))
            {
                Current = clone;
            }
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine($"Collection changed: {e.Action}.");
        }
    }
}
