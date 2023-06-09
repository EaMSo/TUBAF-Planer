using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
namespace Modulmethods
{
    public class Modul 
    {
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
        return "Modulinfo: \nCoursname: " + coursename + "\nType: " + type + "\nLecturer: " + lecturer + "\nRoom: " + room + "\nTurnus: " + turnus + "\nWeekday: " + weekday + "\nStart: " + start + "\nEnd: " + end;
        }
    }


}