using CommunityToolkit.Mvvm.ComponentModel;

namespace WorkTimesheet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
