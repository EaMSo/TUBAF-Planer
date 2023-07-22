using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace TUBAFPlaner.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel() 
    {
    }

    [ObservableProperty] //generiert automatisch Code für die Properties
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;

}