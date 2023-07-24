


namespace Modulmethods
{
    public class Modul
    {
        const string Tablename = "Module";

        public const int EarliestStartTime = 450; // entspricht 7:30
        public const int LatestEndTime = 1170; // 19:30
        public const int TableHeight = 800; // Höhe der Plantabelle
        protected string coursename;
        protected string turnus;
        protected string type;
        protected string weekday;
        protected string lecturer;
        protected string room;
        protected string start;
        protected string end;

        public Modul(string Primkey, string Tablename = Tablename)
        {
            this.coursename = SQLMethods.GetCourseName(Primkey, Tablename);
            if(SQLMethods.GetTurnus(Primkey, Tablename) != null)
            {
            this.turnus = SQLMethods.GetTurnus(Primkey, Tablename);
            }
            else
            {
               this.turnus = "wöchentlich";
            }

            this.type = SQLMethods.GetType(Primkey, Tablename);
            this.weekday = SQLMethods.GetWeekday(Primkey, Tablename);
            this.lecturer = SQLMethods.GetLecturerName(Primkey, Tablename);
            if (SQLMethods.GetRoom(Primkey, Tablename) != null)
            {
                this.room = SQLMethods.GetRoom(Primkey, Tablename);
            }
            else
            {
                this.room = "unbekannter Raum";
            }
            if (SQLMethods.GetStart(Primkey, Tablename) != null)
            {
                this.start = SQLMethods.GetStart(Primkey, Tablename);
            }
            else
            {
                this.start = "";
            }
            if (SQLMethods.GetEnd(Primkey, Tablename) != null)
            {
                this.end = SQLMethods.GetEnd(Primkey, Tablename);
            }
            else
            {
                this.end = "";
            }


        }
        public Modul(string Coursename, string Type,string Room, string Lecturer, string Weekday, string Turnus, string Start, string End)
        {
            this.coursename = Coursename;
            this.type = Type;
            this.room = Room;
            this.lecturer = Lecturer;
            this.weekday = Weekday;
            this.turnus = Turnus;
            this.start = Start;
            this.end = End;
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
        public string Turnus
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
        public string Room
        {
            get
            {
                return room;
            }
        }
        public string Start
        {
            get
            {
                return start;
            }
        }
        public string End
        {
            get
            {
                return end;
            }
        }
        public string Size
        {
            get
            {
                int TimeDiff = LatestEndTime - EarliestStartTime;
                int StartTimeDiff = GetTime(End) - GetTime(Start);
                return Convert.ToString(Math.Round(StartTimeDiff * ((double)TableHeight / TimeDiff), MidpointRounding.ToEven));
            }
        }
        public string Farbe
        {
            get
            {
                switch (type)
                {
                    case "Übung":
                        return "#00EE76";
                    case "Vorlesung":
                        return "Aqua";
                    case "Seminar":
                        return "#1E90FF";
                    case "Praktikum":
                        return "#FF0000";
                    case "Blockkurs":
                        return "#DAA520";
                    case "Kolloquium":
                        return "#EEAEEE";
                    default:
                        return "#8B008B";
                }
            }
        }
        public static int GetTime(string Time)
        {
            
            string[] Spaltzeit = Time.Split(':');
            int StartTime = Convert.ToInt32(Spaltzeit[0]) * 60 + Convert.ToInt32(Spaltzeit[1]);
            return StartTime;
        }
        public string DayColumn //Modul in die richtige Spalte einordnen
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
                int TimeDiff = LatestEndTime - EarliestStartTime;
                if(this.Start == null)
                {
                    return "100";
                }
                string[] Time = this.Start.Split(':');
                int StartTime = Convert.ToInt32(Time[0]) * 60 + Convert.ToInt32(Time[1]);
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
