using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WorkTimesheet.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<Models.WorkDay> WorkDays {get;}
    [ObservableProperty] TimeSpan enterTime;
    [ObservableProperty] TimeSpan timeElapsed;
    DispatcherTimer timer = new();

    public void ClockIn(){
        EnterTime = new(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes,DateTime.Now.TimeOfDay.Seconds);
        timer.Tick += new EventHandler(DispatcherTickHandler);
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Start();
        System.Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern);
    }

    internal void ClockOut(){
        WorkDays.Add(new(new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day), EnterTime, new(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds)));
        timer.Stop();
    }

    public MainViewModel(){
        WorkDays = new();
    }
    public void DispatcherTickHandler(object? sender, EventArgs e){
        TimeElapsed = DateTime.Now.TimeOfDay - EnterTime;
        TimeElapsed = new(TimeElapsed.Hours, TimeElapsed.Minutes, TimeElapsed.Seconds);
    }
}