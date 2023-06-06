using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

    public class SQLMETHODS
    {
        private static List<string> SQLITETEMPLATE(string Table, string Modulname)
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
        private static string SQLITETEMPLATEPRIMEKEYS(string Primkey, string Table)
        {
            var path = Directory.GetCurrentDirectory();
            string[] primärschlüsselallemodule = new string[1];
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT "+Table+" FROM Module WHERE Primärschlüssel IS" +ControlChars.Quote+Primkey+ControlChars.Quote;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                var Key = reader.GetString(0);
                primärschlüsselallemodule[0]= Key;
                }
                
            }
            }
            return primärschlüsselallemodule[0];
        }
        private static List<string> GetAllPflichtModPrimKey(string Modulname)
        {
            return SQLITETEMPLATE("Pflicht", Modulname);
        }
        private static List<string> GetAllWahlpflichtModPrimKey(string Modulname)
        {
            return SQLITETEMPLATE("Wahlpflicht", Modulname);
        }
        public static Array GetAllPflichtCourses(string Modulname)
        {
            string[] modularray = new string[GetAllPflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllPflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLITETEMPLATEPRIMEKEYS(Primkey, "Lehrveranstaltung");
                k++;
            }
            return modularray.Distinct().ToArray();
        }
        public static Array GetAllWahlpflichtCourses(string Modulname)
        {
            string[] modularray = new string[GetAllWahlpflichtModPrimKey(Modulname).Count];
            int k = 0;
            foreach(string Primkey in GetAllWahlpflichtModPrimKey(Modulname))
            {
                modularray[k] = SQLITETEMPLATEPRIMEKEYS(Primkey, "Lehrveranstaltung");
                k++;
            }
            return modularray.Distinct().ToArray();
        }
}