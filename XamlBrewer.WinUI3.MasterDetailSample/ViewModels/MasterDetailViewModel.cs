using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace XamlBrewer.WinUI3.ViewModels
{
    public abstract partial class MasterDetailViewModel<T> : ObservableObject
    {
        private ObservableCollection<T> items = new ObservableCollection<T>();

        // Too bad these don't work (yet?).
        // [ObservableProperty]
        // [AlsoNotifyChangeFor(nameof(HasCurrent))]
        private T current;

        // [ObservableProperty]
        // [AlsoNotifyChangeFor(nameof(Items))]
        private string filter;

        public T Current
        {
            get => current;
            set
            {
                SetProperty(ref current, value);
                OnPropertyChanged(nameof(HasCurrent));
            }
        }

        public string Filter
        {
            get => filter;
            set
            {
                SetProperty(ref filter, value);
                OnPropertyChanged(nameof(Items));
            }
        }

        public ObservableCollection<T> Items =>
            filter is null
                ? items
                : new ObservableCollection<T>(items.Where(i => ApplyFilter(i, filter)));

        public bool HasCurrent => current is not null;

        public virtual T UpdateItem(T item, T original)
        {
            var i = items.IndexOf(original);
            items[i] = item;
            OnPropertyChanged(nameof(Items));

            return item;
        }

        public abstract bool ApplyFilter(T item, string filter);
    }
}
