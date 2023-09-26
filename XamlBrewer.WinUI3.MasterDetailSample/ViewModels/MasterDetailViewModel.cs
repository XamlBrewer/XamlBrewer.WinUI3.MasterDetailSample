using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace XamlBrewer.WinUI3.ViewModels
{
    public abstract partial class MasterDetailViewModel<T> : ObservableObject
    {
        private readonly ObservableCollection<T> items = new();

        // Too bad these don't work (yet?).
        // [ObservableProperty]
        // [AlsoNotifyChangeFor(nameof(HasCurrent))]
        private T current;

        // [ObservableProperty]
        // [AlsoNotifyChangeFor(nameof(Items))]
        private string filter;

        public ObservableCollection<T> Items =>
            filter is null
                ? items
                : new ObservableCollection<T>(items.Where(i => ApplyFilter(i, filter)));

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
                var current = Current;

                SetProperty(ref filter, value);
                OnPropertyChanged(nameof(Items));

                if (current is not null && Items.Contains(current))
                {
                    Current = current;
                }
            }
        }

        public bool HasCurrent => current is not null;

        public virtual T AddItem(T item)
        {
            items.Add(item);
            if (filter is not null)
            {
                OnPropertyChanged(nameof(Items));
            }

            return item;
        }

        public virtual T UpdateItem(T item, T original)
        {
            var hasCurrent = HasCurrent;

            var i = items.IndexOf(original);
            items[i] = item; // Raises CollectionChanged.
            
            if (filter is not null)
            {
                OnPropertyChanged(nameof(Items));
            }

            if (hasCurrent && !HasCurrent)
            {
                // Restore Current.
                Current = item;
            }

            return item;
        }

        public virtual void DeleteItem(T item)
        {
            items.Remove(item);

            if (filter is not null)
            {
                OnPropertyChanged(nameof(Items));
            }
        }

        public abstract bool ApplyFilter(T item, string filter);
    }
}
