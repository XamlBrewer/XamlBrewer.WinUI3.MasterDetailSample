using System.Windows.Input;

namespace XamlBrewer.WinuI3.Services
{
    public interface IMasterDetail
    {
        ICommand DeleteCommand { get; set; }

        bool ApplyFilter(string filter);
    }
}
