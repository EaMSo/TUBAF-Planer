using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace TUBAFPlaner.ViewModel;

public partial class PlanViewModel : BaseViewModel
{
    public ObservableCollection<Modulmethods.Modul> Modules { get; } = new();
    public PlanViewModel() 
    {
        
    }

    

    [RelayCommand]
    async Task GoToPlanDetailsAsync(Modulmethods.Modul modul)
    {
        if(modul is null)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(TUBAF_Planer.View.ModulDetailPage)}", true,
            new Dictionary<string, object>
            {
                {"Modul", modul }
            });
    }
}