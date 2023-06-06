using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
namespace Modulmethods
{
    class Modul 
    {
        private string coursename;
        private string? turnus;
        private string weekday;
        private string room;
        private string start;
        private string end;
        public Modul(string Primkey)
        {
            this.coursename = SQLMethods.GetCourseName(Primkey);
            if(SQLMethods.GetTurnus(Primkey)!= null)
            {
            this.turnus = SQLMethods.GetTurnus(Primkey);
            }
            else
            {
               this.turnus = "wöchentlich";
            }
            this.weekday = SQLMethods.GetWeekday(Primkey);
            this.room = SQLMethods.GetRoom(Primkey);
            this.start = SQLMethods.GetStart(Primkey);
            this.end = SQLMethods.GetEnd(Primkey);
            
        }
        public override string ToString()
        {
        return "Modulinfos: \nCoursname: " + coursename + "\nTurnus: " + turnus + "\nWeekday: " + weekday + "\nRoom: " + room + "\nStart: " + start + "\nEnd: " + end;
        }
    }


}