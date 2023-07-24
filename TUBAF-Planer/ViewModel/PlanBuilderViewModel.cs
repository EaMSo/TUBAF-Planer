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
    //Check if the Coursname is to long (max 50 characters)
    bool CheckForCoursname()
    {
        if (Ecoursename.Length > 50)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //Check if the Type is valid
    bool CheckForType()
    {
        if(Etype == "Vorlesung" || Etype == "Übung" || Etype == "Praktikum" || Etype == "Seminar" || Etype == "Kolloquium" || Etype == "Blockkurs")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the Lecturer is to long (max 50 characters)
    bool CheckForLecturer()
    {
        if (Electurer.Length > 50)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //Check if the Room is to long (max 50 characters)
    bool CheckForRoom()
    {
        if (Eroom.Length > 50)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //Check if the Weekday is valid
    bool CheckForWeekday()
    {
        if (Eweekday == "Montag" || Eweekday == "Dienstag" || Eweekday == "Mittwoch" || Eweekday == "Donnerstag" || Eweekday == "Freitag" || Eweekday == "Samstag" || Eweekday == "Sonntag")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the Turnus is valid
    bool CheckforTurnus()
    {
        if (Eturnus == "wöchentlich" || Eturnus == "ungrade Woche" || Eturnus == "grade Woche")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the Start and End time is valid
    bool IsTimeValid()
    {
        // Define the expected time format
        string timeFormat = "H:mm";
        // Parse the start and end times into DateTime objects using the specified format
        if (DateTime.TryParseExact(Estart, timeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime startTimeObj) &&
            DateTime.TryParseExact(Eend, timeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime endTimeObj))
        {
            if (startTimeObj < endTimeObj)
            {
                return true;
            }
        }
        return false; // Invalid time range/ format
    }
}