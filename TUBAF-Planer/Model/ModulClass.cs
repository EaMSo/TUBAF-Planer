using CommunityToolkit.Mvvm.Input;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

#nullable enable
namespace Modulmethods
{
    public partial class Modul 
    {
        public const uint EarliestStartTime = 450; // entspricht 7:30
        public const uint LatestEndTime = 1170; // 19:30
        public const uint TableHeight = 800; // Höhe der Plantabelle
        private string coursename;
        private string? turnus;
        private string type;
        private string weekday;
        private string lecturer;
        private string? room;
        private string? start;
        private string? end;

        public Modul(string Primkey)
        {
            //if(SQLMethods.GetRoom(Primkey) != null)
            //throw new ArgumentNullException("Modul hat keinen Raum!");
            this.coursename = SQLMethods.GetCourseName(Primkey);
            if(SQLMethods.GetTurnus(Primkey)!= null)
            {
            this.turnus = SQLMethods.GetTurnus(Primkey);
            }
            else
            {
               this.turnus = "wöchentlich";
            }
            this.type = SQLMethods.GetType(Primkey);
            this.weekday = SQLMethods.GetWeekday(Primkey);
            this.lecturer = SQLMethods.GetLecturerName(Primkey);
            this.room = SQLMethods.GetRoom(Primkey);
            this.start = SQLMethods.GetStart(Primkey);
            this.end = SQLMethods.GetEnd(Primkey);

        }
        public override string ToString()
        {
        return "Modulinfo: \nCoursname: " + coursename + "\nType: " + type + "\nLecturer: " + lecturer + "\nRoom: " + room + "\nTurnus: " + turnus + "\nWeekday: " + weekday + "\nStart: " + start + "\nEnd: " + end +"\nRowStart" + TimeRowStart;
        }
        //get funktion für alle Attribute
        
        public string Coursename
        {
            get
            {
                return coursename;
            }
        }
        public string? Turnus
        {
            get
            {
                return turnus;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public string Weekday
        {
            get
            {
                return weekday;
            }
        }
        public string Lecturer
        {
            get
            {
                return lecturer;
            }
        }
        public string? Room
        {
            get
            {
                return room;
            }
        }
        public string? Start
        {
            get
            {
                return start;
            }
        }
        public string? End
        {
            get
            {
                return end;
            }
        }
        public string Size //todo
        {
            get
            {
                return "60";
            }
        }
        public string DayColumn //Modul in die richtige SPalte einordnen
        {
            get
            {
                uint i=0;
                switch (this.weekday)
                {
                    case "Montag":
                        i=0;
                        break;
                    case "Dienstag":
                        i=2;
                        break;
                    case "Mittwoch":
                        i=4;
                        break;
                    case "Donnerstag":
                        i=6;
                        break;
                    case "Freitag":
                        i=8;
                        break;
                    case "Samstag":
                        i=10;
                        break;
                    case "Sonntag":
                        i=12;
                        break;
                    default: throw new Exception("Wochentag ist nicht in Datenbank enthalten"); 
                }
                if(this.turnus == "ungerade Woche")
                {
                    i++;
                }
                return i.ToString();
            }
        }
        public string TurnusColumnSpan
        {
            get
            {
                switch (this.turnus)
                {
                    case "wöchentlich":
                        return "2";
                    case "ungerade Woche":
                        return "1";
                    case "gerade Woche":
                        return "1";
                    default: throw new Exception("Turnus ist nicht zulässig");
                }
            }
        }
        public string TimeRowStart
        {
            get
            {
                uint TimeDiff = LatestEndTime - EarliestStartTime;
                if(this.Start == null)
                {
                    return "100";
                }
                string[] Time = this.Start.Split(':');
                uint StartTime = Convert.ToUInt32(Time[0]) * 60 + Convert.ToUInt32(Time[1]);
                if(StartTime < EarliestStartTime || StartTime > LatestEndTime  )
                {
                    throw new Exception("Zeit außerhalb der zugelassenen Grenzen");
                }
                StartTime = StartTime - EarliestStartTime;
                return Convert.ToString(Math.Round(StartTime * ((double)TableHeight / TimeDiff),
                                           MidpointRounding.ToEven));
                
            }
        }
    }


}
