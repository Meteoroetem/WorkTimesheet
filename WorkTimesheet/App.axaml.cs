using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using WorkTimesheet.ViewModels;
using WorkTimesheet.Views;
using System.Globalization;

namespace WorkTimesheet;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        CultureInfo.CurrentCulture = new("en-IL");
        CultureInfo.CurrentUICulture = new("en-UK");
        CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss.F";
        CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern = "HH  :  mm:ss.F";
        CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern = "dd MMM yyyy";
        CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd MMM yyyy";
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}