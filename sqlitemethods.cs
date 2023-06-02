using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

    public class SQLMETHODS
    {
        public static List<string> GetAllWahlpflichtModPrimKey(string Modulname)
        {
            var path = Directory.GetCurrentDirectory();
            var primärschlüsselallemodule = new List<string> {};
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Module WHERE Wahlpflicht LIKE"+ ControlChars.Quote+"%"+Modulname+"%"+ControlChars.Quote;
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
        public static List<string> GetAllPflichtModPrimKey(string Modulname)
        {
            var path = Directory.GetCurrentDirectory();
            var primärschlüsselallemodule = new List<string> {};
            using (var connection = new SqliteConnection("Data Source="+path+"/TUFreibergModule.db;Mode=ReadOnly"))
            {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Module WHERE Pflicht LIKE"+ ControlChars.Quote+"%"+Modulname+"%"+ControlChars.Quote;
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
}