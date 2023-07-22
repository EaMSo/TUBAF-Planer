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
    async Task GetModuleListAsync() //mach liste
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            if(Modules.Count > 0)
            {
                Modules.Clear();    
            }


            var modules = new List<Modulmethods.Modul>()
            {
                new Modulmethods.Modul("#SPLUSCB0264")
            };

            foreach (var mod in modules)
            {
                Modules.Add(mod);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
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