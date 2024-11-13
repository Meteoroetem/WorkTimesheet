using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WorkTimesheet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public CultureInfo cultureInfo = new("en-UK");
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
    public ObservableCollection<Models.WorkDay> WorkDays {get;}

    public MainViewModel(){
        var workDays = new List<Models.WorkDay> {new(new(), new(0,0), new(10,10))};
        WorkDays = new(workDays);
        
    }
    
}