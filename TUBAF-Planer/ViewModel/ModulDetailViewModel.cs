using CommunityToolkit.Mvvm.ComponentModel;
using TUBAFPlaner.ViewModel;

namespace TUBAFPlaner.ViewModel;

[QueryProperty("Modul", "Modul")]
public partial class ModulDetailViewModel : BaseViewModel
{
    public ModulDetailViewModel() 
    { 

    }

    [ObservableProperty]
    Modulmethods.Modul modul;
}