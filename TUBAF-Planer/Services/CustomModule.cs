using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulmethods
{
    class CustomModule
    {
        const string TableName = "CustomModule";

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

        public CustomModule(string Primkey)
        {
            
            //if(SQLMethods.GetRoom(Primkey) != null)
            //throw new ArgumentNullException("Modul hat keinen Raum!");
            this.coursename = SQLMethods.GetCourseName(Primkey, TableName);
            if (SQLMethods.GetTurnus(Primkey, TableName) != null)
            {
                this.turnus = SQLMethods.GetTurnus(Primkey, TableName);
            }
            else
            {
                this.turnus = "wöchentlich";
            }
            this.type = SQLMethods.GetType(Primkey, TableName);
            this.weekday = SQLMethods.GetWeekday(Primkey, TableName);
            this.lecturer = SQLMethods.GetLecturerName(Primkey, TableName);
            this.room = SQLMethods.GetRoom(Primkey, TableName);
            this.start = SQLMethods.GetStart(Primkey, TableName);
            this.end = SQLMethods.GetEnd(Primkey, TableName);
        }

        public static void CreateTable()
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS CustomModule (Primärschlüssel TEXT PRIMARY KEY, Lehrveranstaltung TEXT, Art TEXT, Dozenten TEXT, Turnus TEXT, Raum Text, Wochentag TEXT, Beginn TEXT, Ende TEXT)";
                command.ExecuteNonQuery();
            }
        }

        static string CreateCustomModule(string Lehrveranstaltung, string Art, string Dozenten, string Turnus, string Raum, string Wochentag, string Beginn, string Ende)
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO CustomModule (Primärschlüssel, Lehrveranstaltung, Art, Dozenten, Turnus, Raum, Wochentag, Beginn, Ende) VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";
                command.Parameters.AddWithValue("@a", GetUniquePrimkey());
                command.Parameters.AddWithValue("@b", Lehrveranstaltung);
                command.Parameters.AddWithValue("@c", Art);
                command.Parameters.AddWithValue("@d", Dozenten);
                command.Parameters.AddWithValue("@e", Turnus);
                command.Parameters.AddWithValue("@f", Raum);
                command.Parameters.AddWithValue("@g", Wochentag);
                command.Parameters.AddWithValue("@h", Beginn);
                command.Parameters.AddWithValue("@i", Ende);

                command.ExecuteNonQuery();
            }
            return GetUniquePrimkey();
        }
        static string GetUniquePrimkey()
        {
            List<string> primliste = SQLMethods.GetPrimaryKeyList("CustomModule");
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM CustomModule";
                int anzahl = Convert.ToInt32(command.ExecuteScalar());
                while (primliste.Contains("#"+anzahl))
                {
                    anzahl++;
                }
                return "#"+ anzahl.ToString();
            }
        }
        static void DeleteModuleByPrimäryKey(string Primärschlüssel)
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM CustomModule WHERE Primärschlüssel = @a";
                command.Parameters.AddWithValue("@a", Primärschlüssel);
                command.ExecuteNonQuery();
            }
        }
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
        public string Size
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
                uint i = 0;
                switch (this.weekday)
                {
                    case "Montag":
                        i = 0;
                        break;
                    case "Dienstag":
                        i = 2;
                        break;
                    case "Mittwoch":
                        i = 4;
                        break;
                    case "Donnerstag":
                        i = 6;
                        break;
                    case "Freitag":
                        i = 8;
                        break;
                    case "Samstag":
                        i = 10;
                        break;
                    case "Sonntag":
                        i = 12;
                        break;
                    default: throw new Exception("Wochentag ist nicht in Datenbank enthalten");
                }
                if (this.turnus == "ungerade Woche")
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
                if (this.Start == null)
                {
                    return "100";
                }
                string[] Time = this.Start.Split(':');
                uint StartTime = Convert.ToUInt32(Time[0]) * 60 + Convert.ToUInt32(Time[1]);
                if (StartTime < EarliestStartTime || StartTime > LatestEndTime)
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
