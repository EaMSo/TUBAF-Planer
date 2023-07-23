using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modulmethods;
using System.Collections.ObjectModel;


namespace TUBAFPlaner.ViewModel;

public partial class PlanBuilderViewModel : BaseViewModel
{
    [ObservableProperty]
    string ecoursename; //Properties der Entry Felder
    [ObservableProperty]
    string etype;
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
    public ObservableCollection<Modul> CustomModules { get; set; }
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
        IsBusy = true;

        Ecoursename = modul.Coursename;
        Etype = modul.Type;
        Electurer = modul.Lecturer;
        Eroom = modul.Room;
        Eweekday = modul.Weekday;
        Eturnus = modul.Turnus;
        Estart = modul.Start;
        Eend = modul.End;
        CurrentModule = modul;

        IsBusy = false;
    }


    [RelayCommand]
    void CreateCustomModule() 
    {
        IsBusy = true;
        string key = CustomModule.CreateCustomModule(Ecoursename, Etype, Electurer, Eturnus, Eroom, Eweekday, Estart, Eend);

        // to do 

        IsBusy = false;
    }

    [RelayCommand]
    public void AddModuleToSelectedList()
    {
        SelectedModules.Add(CurrentModule);
    }

    bool CheckForType()
    {
        //Etype;
        return true;
    }
}