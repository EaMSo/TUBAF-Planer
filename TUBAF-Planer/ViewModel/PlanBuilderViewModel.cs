using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modulmethods;
using System.Collections.ObjectModel;
using TUBAF_Planer;


namespace TUBAFPlaner.ViewModel;

public partial class PlanBuilderViewModel : BaseViewModel
{
    [ObservableProperty]
    string coursename;
    [ObservableProperty]
    string lecturer;
    [ObservableProperty]
    string room;
    [ObservableProperty]
    string weekday;
    [ObservableProperty]
    string turnus;
    [ObservableProperty]
    string start;
    [ObservableProperty]
    string end;



    [RelayCommand]
    void CreateCustomModule() 
    {
        string Name = Coursename;
    }
}