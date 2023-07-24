using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Modulmethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using TUBAF_Planer.Model;


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
    public ObservableCollection<CustomModule> CustomModules { get; set; }
    public ObservableCollection<Modul> SelectedModules { get; set; }
    [ObservableProperty]
    Modul currentModule;

    public ObservableCollection<Modul> Plan { get; set; }

    public PlanBuilderViewModel() 
    {
        this.Module = new();
        this.SelectedModules = new();
        this.CustomModules = new();
        this.Plan = new();
        this.ecoursename = string.Empty;
        this.etype = string.Empty;
        this.electurer = string.Empty;
        this.eroom = string.Empty;
        this.eweekday = string.Empty;
        this.eturnus = string.Empty;
        this.estart = string.Empty;
        this.eend = string.Empty;
    }


    [RelayCommand]
    async Task GoToPlanDetailsAsync(Modul modul)
    {
        if (modul is null)
        {
            return;
        }
        await Shell.Current.GoToAsync($"{nameof(TUBAF_Planer.View.ModulDetailPage)}", true,
            new Dictionary<string, object>
            {
                {"Modul", modul}
            });
    }

    [RelayCommand]
    public void LoadModules()
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

            if (CustomModules.Count > 0)
            {
                CustomModules.Clear();
            }


            IsBusy = true;

            /*
            List<Modul> fullmodules = FullmoduleList.GetFullmoduleList();

            foreach (Modul mod in fullmodules)
            {
                Module.Add(mod);
            }
            */
            
            List<CustomModule> customModules = FullmoduleList.GetFullCustomList();

            foreach (CustomModule mod in customModules)
            {
                CustomModules.Add(mod);
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

        //nötig, um Moduldetails anzuzeigen
        CurrentModule = new Modul(modul.Coursename, modul.Type, modul.Room, modul.Lecturer, modul.Weekday, modul.Turnus, modul.Start, modul.End);
        

        IsBusy = false;
    }

 
    [RelayCommand]
    async void CreateCustomModule() 
    {
        if (!ECheckForCoursname())
        {
            await Shell.Current.DisplayAlert("Fehler", "Kursname hat falsche Länge", "OK");
            return;
        }
        if (!ECheckForType())
        {
            await Shell.Current.DisplayAlert("Fehler", "Typ ist falsch\n Zugleassen: Vorlesung, Übung, Praktikum, Seminar, Kolloquium, Blockkurs ", "OK");
            return;
        }
        if (!ECheckForLecturer())
        {
            await Shell.Current.DisplayAlert("Fehler", "Dozenten ist zu lang", "OK");
            return;
        }
        if (!ECheckForRoom())
        {
            await Shell.Current.DisplayAlert("Fehler", "Raum ist zu lang", "OK");
            return;
        }
        if (!ECheckForWeekday())
        {
            await Shell.Current.DisplayAlert("Fehler", "Wochentag ist falsch", "OK");
            return;
        }
        if (!ECheckforTurnus())
        {
            await Shell.Current.DisplayAlert("Fehler", "Turnus ist falsch\n Zugelassen: wöchentlich, ungerade Woche, gerade Woche", "OK");
            return;
        }
        if (!EIsTimeValid())
        {
            await Shell.Current.DisplayAlert("Fehler", "Zeitformat / Zeitspanne flasch", "OK");
            return;
        }
        if (!ECheckForTimeBounds())
        {
            await Shell.Current.DisplayAlert("Fehler", "Zeit muss zwischen 7:30 und 19:30 liegen", "OK");
            return;
        }
        if(!ECheckForExistingModule())
        {
            await Shell.Current.DisplayAlert("Fehler", "Custom Modul mit diesem Name existiert bereits", "OK");
            return;
        }

        IsBusy = true;
        string key = CustomModule.CreateCustomModule(Ecoursename, Etype, Electurer, Eturnus, Eroom, Eweekday, Estart, Eend);
        CustomModule New = new CustomModule(key); 
        CustomModules.Add(new CustomModule(key));
        CurrentModule = new Modul(New.Coursename, New.Type, New.Room, New.Lecturer, New.Weekday, New.Turnus, New.Start, New.End);
        IsBusy = false;
    }

    [RelayCommand]
    void DeleteCustomModule()
    {
        CustomModule.DeleteModule(CurrentModule.Coursename);
        List<CustomModule> list = new();
        foreach (CustomModule modul in CustomModules)
        {
            if (modul.Coursename == CurrentModule.Coursename)
            { 
                list.Add(modul);
            }
        }
        //zweite Schleife, da man in der oberen nicht Entfernen kann
        foreach (CustomModule modul in list)
        {
            CustomModules.Remove(modul);
        }
        
    }


    [RelayCommand]
    public async void AddModuleToSelectedList()
    {   
        if(!CheckForCoursname())
        {
            await Shell.Current.DisplayAlert("Fehler", "Kursname hat falsche Länge", "OK");
            return;
        }
        if(!CheckForType())
        {
            await Shell.Current.DisplayAlert("Fehler", "Typ ist falsch\n Zugleassen: Vorlesung, Übung, Praktikum, Seminar, Kolloquium, Blockkurs ", "OK");
            return;
        }
        if(!CheckForLecturer())
        {
            await Shell.Current.DisplayAlert("Fehler", "Dozenten ist zu lang", "OK");
            return;
        }
        if(!CheckForRoom())
        {
            await Shell.Current.DisplayAlert("Fehler", "Raum ist zu lang", "OK");
            return;
        }
        if(!CheckForWeekday())
        {
            await Shell.Current.DisplayAlert("Fehler", "Wochentag ist falsch", "OK");
            return;
        }
        if (!CheckforTurnus())
        {
            await Shell.Current.DisplayAlert("Fehler", "Turnus ist falsch\n Zugelassen: wöchentlich, ungerade Woche, gerade Woche", "OK");
            return;
        }
        if(!IsTimeValid())
        {
            await Shell.Current.DisplayAlert("Fehler", "Zeitformat / Zeitspanne flasch", "OK");
            return;
        }
        if(!CheckForTimeBounds())
        {
            await Shell.Current.DisplayAlert("Fehler", "Zeit muss zwischen 7:30 und 19:30 liegen", "OK");
            return;
        }
        if ( Moduloverlapping.AnotherModuleIsAtSameTime(CurrentModule, SelectedModules, out string OverlapName) )
        {
            await Shell.Current.DisplayAlert("Fehler", "Modul hat Überschneidung mit " + OverlapName, "OK");
            return;
        }
        SelectedModules.Add(CurrentModule);
    }

    [RelayCommand]
    void RemoveFromSelectedList()
    {
        if(!SelectedModules.Contains(CurrentModule))
        {
            return;
        }
        SelectedModules.Remove(CurrentModule);
    }

    [RelayCommand]
    public void GeneratePlan()
    {
        Plan.Clear();
        foreach (var module in SelectedModules) 
        {
            Plan.Add(module);
        }
    }


    //Check if the Coursname is to long (max 50 characters)
    bool CheckForCoursname()
    {
        if (CurrentModule.Coursename.Length > 50 || CurrentModule.Coursename.Length < 1)
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
        if(CurrentModule.Type == "Vorlesung" || CurrentModule.Type == "Übung" || CurrentModule.Type == "Praktikum" || CurrentModule.Type == "Seminar" || CurrentModule.Type == "Kolloquium" || CurrentModule.Type == "Blockkurs")
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
        if (CurrentModule.Lecturer.Length > 50)
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
        if (CurrentModule.Room.Length > 50)
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
        if (CurrentModule.Weekday == "Montag" || CurrentModule.Weekday == "Dienstag" || CurrentModule.Weekday == "Mittwoch" || CurrentModule.Weekday == "Donnerstag" || CurrentModule.Weekday == "Freitag" || CurrentModule.Weekday == "Samstag" || CurrentModule.Weekday == "Sonntag")
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
        if (CurrentModule.Turnus == "wöchentlich" || CurrentModule.Turnus == "ungerade Woche" || CurrentModule.Turnus == "gerade Woche")
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
        if (DateTime.TryParseExact(CurrentModule.Start, timeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime startTimeObj) &&
            DateTime.TryParseExact(CurrentModule.End, timeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime endTimeObj))
        {
            if (startTimeObj < endTimeObj)
            {
                return true;
            }
        }
        return false; // Invalid time range/ format
    }
    bool CheckForTimeBounds()
    {
        if(Modul.GetTime(CurrentModule.Start) >= Modul.EarliestStartTime && Modul.GetTime(CurrentModule.End) <= Modul.LatestEndTime)
        {
            return true;
        }
        return false;
    }




    //nochmal Test für Entry

    //Check if the Coursname is to long (max 50 characters)
    bool ECheckForCoursname()
    {
        if (Ecoursename.Length > 50 || Ecoursename.Length <1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //Check if the Type is valid
    bool ECheckForType()
    {
        if (Etype == "Vorlesung" || Etype == "Übung" || Etype == "Praktikum" || Etype == "Seminar" || Etype == "Kolloquium" || Etype == "Blockkurs")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the Lecturer is to long (max 50 characters)
    bool ECheckForLecturer()
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
    bool ECheckForRoom()
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
    bool ECheckForWeekday()
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
    bool ECheckforTurnus()
    {
        if (Eturnus == "wöchentlich" || Eturnus == "ungerade Woche" || Eturnus == "gerade Woche")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the Start and End time is valid
    bool EIsTimeValid()
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
    bool ECheckForTimeBounds()
    {
        if (Modul.GetTime(Estart) >= Modul.EarliestStartTime && Modul.GetTime(Eend) <= Modul.LatestEndTime)
        {
            return true;
        }
        return false;
    }
    bool ECheckForExistingModule()
    {
        foreach(CustomModule modul in CustomModules)
        {
            if(modul.Coursename == Ecoursename)
            {
                return false;
            }
        }
        return true;
    }
}