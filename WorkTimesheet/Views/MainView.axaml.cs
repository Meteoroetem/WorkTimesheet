using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using WorkTimesheet.ViewModels;
using System.Globalization;

namespace WorkTimesheet.Views;

public partial class MainView : UserControl
{

    public MainView()
    {
        InitializeComponent();
    }

    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        var buttonContent = ((Button)sender).Content ?? "";

        if(buttonContent.ToString() == "Clock in"){
            ((MainViewModel)DataContext!).ClockIn();
            ((Button)sender).Content = "Clock out";
            timerPanel.IsVisible = true;
        }
        else{
            ((MainViewModel)DataContext!).ClockOut();
            ((Button)sender).Content = "Clock in";
            timerPanel.IsVisible = false;

        }
    }
}