using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modulmethods;
using System.Collections.ObjectModel;
using System.Reflection;
using TUBAF_Planer;



namespace TUBAFPlaner.ViewModel;

public partial class PlanBuilderViewModel : BaseViewModel
{
    [ObservableProperty]
    string ecoursename; //Properties der Entry Felder
    [ObservableProperty]
    string electurer;
    [ObservableProperty]
    string eroom;
    [ObservableProperty]
    string eweekday;
    [ObservableProperty]
    string eturnus;
    [ObservableProperty]
    string estart;
    [ObservableProperty]
    string eend;
    public ObservableCollection<Modul> Module { get; set; }
    public ObservableCollection<Modul> CustomModule { get; set; }
    public ObservableCollection<Modul> SelectedModules { get; set; }
    [ObservableProperty]
    Modul currentModule;

    public PlanBuilderViewModel() 
    {
        this.Module = new();
        this.SelectedModules = new();
    }

    [RelayCommand]
    void LoadModules()
    {
        Task.Run(() =>
        {
            if (IsBusy)
            {
                return;
            }

            if(Module.Count > 0)
            {
                Module.Clear();
            }


            IsBusy = true;

            List<Modul> fullmodules = FullmoduleList.GetFullmoduleList();

            foreach (Modul mod in fullmodules)
            {
                Module.Add(mod);
            }
            
                IsBusy = false;
        });
    }

    [RelayCommand]
    public void DisplayModule(Modul modul)
    {
        Ecoursename = modul.Coursename;
        Electurer = modul.Lecturer;
        Eroom = modul.Room;
        Eweekday = modul.Weekday;
        Eturnus = modul.Turnus;
        Estart = modul.Start;
        Eend = modul.End;
        CurrentModule = modul;
    }


    [RelayCommand]
    void CreateCustomModule() 
    {
        string test = Ecoursename;
        // to do CustomModule CModule = CreateCustomModule();
    }

    [RelayCommand]
    public void AddModuleToSelectedList()
    {
        SelectedModules.Add(CurrentModule);
    }
}