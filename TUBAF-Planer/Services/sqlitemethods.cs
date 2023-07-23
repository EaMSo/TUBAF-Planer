using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

namespace Modulmethods
{
    public class SQLMethods
    {
        //Name of SQLite Fields for better use
        private const string FieldPrimär = "Primärschlüssel";
        private const string FieldCourses = "Lehrveranstaltung";
        private const string FieldType = "Art";
        private const string FieldObligatory = "Pflicht";
        private const string FieldNotObligatory = "Wahlpflicht";
        private const string FieldLecturer = "Dozenten";
        private const string FieldTurnus = "Turnus";
        private const string FieldWeekday = "Wochentag";
        private const string FieldRoom = "Raum";
        private const string FieldStart = "Beginn";
        private const string FieldEnd = "Ende";

        //Methods for Connecting to the Database and doing a SQL search
        private static List<string> SQLTemplate_Select_LIKE(string Table, string Modulname)
        {
            var path = DBWriting.GetDBPath();
            var primärschlüsselallemodule = new List<string> {};
            using (var connection = new SqliteConnection("Data Source="+path+";Mode=ReadOnly"))
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
        private static string SQLTemplate_Select_Spicific_SingleOutput(string searchstring, string input_Table,string output_Table,string Tablename)
        {
            var path = DBWriting.GetDBPath();
            string primärschlüsselallemodule = "";
            int k = 0;
            try
            {
            using (var connection = new SqliteConnection("Data Source=" + path + ";Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT "+output_Table+" FROM "+ Tablename +" WHERE "+ input_Table +" IS" +ControlChars.Quote+searchstring+ControlChars.Quote;
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
            throw new InvalidDataException("A Primäry Key is more then once in the Table!");
            }
            return primärschlüsselallemodule;
            }
            catch(System.InvalidOperationException)
            {
            return null;
            }
        }
        private static List<string> SQLTemplate_Select_Spicific_MultipleOutputs(string searchstring, string input_Table,string output_Table)
        {
            string path = DBWriting.GetDBPath();
            var selection = new List<string> {};
            using (var connection = new SqliteConnection("Data Source="+path+";Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT "+ output_Table +" FROM Module WHERE "+ input_Table +" IS" +ControlChars.Quote+searchstring+ControlChars.Quote;
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

        public static List<string> GetPrimaryKeyList(string Tablename)//CustomModule oder Module
        {
            var path = DBWriting.GetDBPath();
            var primärschlüsselallemodule = new List<string> { };
            using (var connection = new SqliteConnection("Data Source=" + path + ";Mode=ReadOnly"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM "+Tablename;
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
        public static Array GetAllPflichtCourses(string Modulname, string Tablename)
        {
            string[] modularray = new string[GetAllPflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllPflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLTemplate_Select_Spicific_SingleOutput(Primkey,FieldPrimär,FieldCourses, Tablename);
                k++;
            }
            return modularray.Distinct().ToArray();
        }

        public static Array GetAllWahlpflichtCourses(string Modulname, string Tablename)
        {
            string[] modularray = new string[GetAllWahlpflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllWahlpflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLTemplate_Select_Spicific_SingleOutput(Primkey,FieldPrimär,FieldCourses, Tablename);
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
        internal static string GetTurnus(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldTurnus, Tablename);
        }
        internal static string GetWeekday(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldWeekday, Tablename);
        }
        internal static string GetRoom(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldRoom, Tablename);
        }
        internal static string GetStart(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldStart, Tablename);
        }
        internal static string GetEnd(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldEnd, Tablename);
        }
        internal static string GetCourseName(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldCourses, Tablename);
        }
        internal static string GetLecturerName(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldLecturer, Tablename);
        }
        internal static string GetType(string PrimKey, string Tablename)
        {
           return SQLTemplate_Select_Spicific_SingleOutput(PrimKey,FieldPrimär,FieldType, Tablename);
        }
    }
}