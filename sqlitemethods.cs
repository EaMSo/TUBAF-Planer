using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
namespace Modulmethods
{
    public class SQLMETHODS
    {
        //Name of SQLite Fields for better use
        private const string FieldPrimär = "Primärschlüssel";
        private const string FieldCourses = "Lehrveranstaltung";
        private const string FieldObligatory = "Pflicht";
        private const string FieldNotObligatory = "Wahlpflicht";
        private const string FieldTurnus = "Turnus";
        private const string FieldWeekday = "Wochentag";
        private const string FieldRoom = "Raum";
        private const string FieldStart = "Beginn";
        private const string FieldEnd = "Ende";

        //Methods for Connecting to the Database and doing a SQL search
        private static List<string> SQLTemplate_Select_LIKE(string Table, string Modulname)
        {
            var path = Directory.GetCurrentDirectory();
            var primärschlüsselallemodule = new List<string> {};
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Module WHERE " +Table+ " LIKE"+ ControlChars.Quote+"%"+Modulname+"%"+ControlChars.Quote;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                var Key = reader.GetString(0);
                primärschlüsselallemodule.Add(Key);
                }
                
            }
            }
            return primärschlüsselallemodule;
        }
        private static string SQLTemplate_Select_Spicific_SingleOutput(string searchstring, string input_Table,string output_Table)
        {
            var path = Directory.GetCurrentDirectory();
            string primärschlüsselallemodule = "";
            int k = 0;
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT "+output_Table+" FROM Module WHERE "+ input_Table +" IS" +ControlChars.Quote+searchstring+ControlChars.Quote;
            using var reader = command.ExecuteReader();
            while (reader.Read())
                {
                var Key = reader.GetString(0);
                primärschlüsselallemodule = Key;
                k++;
                }
            }
            if(k!=1)
            {
            throw new MyException("A Primäry Key is more then once in the Table!");;
            }
            return primärschlüsselallemodule;
        }
        private static List<string> SQLTemplate_Select_Spicific_MultipleOutputs(string searchstring, string input_Table,string output_Table)
        {
            var selection = new List<string> {};
            var path = Directory.GetCurrentDirectory();
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT "+output_Table+" FROM Module WHERE "+ input_Table +" IS" +ControlChars.Quote+searchstring+ControlChars.Quote;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                var Key = reader.GetString(0);
                selection.Add(Key);
                }
                
            }
            }
            return selection;
        }
        /*Returns a list of all Primary Keys for the Pflicht Modules of a string which is 
        Combined of the Semester and the short form of the course Example: 2.BAI for second Semester Bachlor of Applied Informatics*/
        private static List<string> GetAllPflichtModPrimKey(string Modulname)
        {
            return SQLTemplate_Select_LIKE(FieldObligatory, Modulname);
        }
        //same like the above but for Wahlpflichmodules
        private static List<string> GetAllWahlpflichtModPrimKey(string Modulname)
        {
            return SQLTemplate_Select_LIKE(FieldNotObligatory, Modulname);
        }
        //same Input like the above but gives back the names of the courses
        public static Array GetAllPflichtCourses(string Modulname)
        {
            string[] modularray = new string[GetAllPflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllPflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLTemplate_Select_Spicific_SingleOutput(Primkey,FieldPrimär,FieldCourses);
                k++;
            }
            return modularray.Distinct().ToArray();
        }
        //
        public static Array GetAllWahlpflichtCourses(string Modulname)
        {
            string[] modularray = new string[GetAllWahlpflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllWahlpflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLTemplate_Select_Spicific_SingleOutput(Primkey,FieldPrimär,FieldCourses);
                k++;
            }
            return modularray.Distinct().ToArray();
        }
        //input is the name of he course and gives back all Primary Keys for this course
        private static List<string> GetCoursPrim(string Coursbezeichnung)
        {
           return SQLTemplate_Select_Spicific_MultipleOutputs(Coursbezeichnung,FieldCourses,FieldPrimär);
        }
        //GetsDifferentvaluesfromPrimaryKeys
        private static string GetTurnus(string PrimKey)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldTurnus);
        }
        private static string GetWeekday(string PrimKey)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldWeekday);
        }
        private static string GetRoom(string PrimKey)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldRoom);
        }
        private static string GetStart(string PrimKey)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldStart);
        }
        private static string GetEnd(string PrimKey)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldEnd);
        }
    }
}