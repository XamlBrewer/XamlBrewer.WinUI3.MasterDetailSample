using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace XamlBrewer.WinUI3.Models
{
    public partial class MasterDetail<T> : ObservableObject
    {
        private ObservableCollection<T> items = new ObservableCollection<T>();

        // Too bad these don't work (yet?).
        // [ObservableProperty]
        // [AlsoNotifyChangeFor(nameof(HasCurrent))]
        private T current;

        public T Current
        {
            get => current;
            set
            {
                SetProperty(ref current, value);
                OnPropertyChanged(nameof(HasCurrent));
            }
        }

        public ObservableCollection<T> Items => items;

        public bool HasCurrent => current is not null;
    }
}
