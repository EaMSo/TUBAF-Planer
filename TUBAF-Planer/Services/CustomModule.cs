using Microsoft.Data.Sqlite;
#nullable enable

namespace Modulmethods
{


    public class CustomModule : Modul
    {
        const string TableName = "CustomModule";
        
        public CustomModule(string Primkey) : base(Primkey, TableName)
        {
            
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

        static public string CreateCustomModule(string Lehrveranstaltung, string Art, string Dozenten, string Turnus, string Raum, string Wochentag, string Beginn, string Ende)
        {
            string Primekey = GetUniquePrimkey();
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO CustomModule (Primärschlüssel, Lehrveranstaltung, Art, Dozenten, Turnus, Raum, Wochentag, Beginn, Ende) VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";
                command.Parameters.AddWithValue("@a", Primekey);
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
            return Primekey;
        }
        static string GetUniquePrimkey()
        {
            List<string> primliste = SQLMethods.GetPrimaryKeyList("CustomModule");
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT COUNT(*) FROM CustomModule";
                int anzahl = Convert.ToInt32(command.ExecuteScalar()); 

                while (primliste.Contains("#"+anzahl))
                {
                    anzahl++;
                }
                return "#"+ anzahl.ToString();
            }
        }
        static public void DeleteModuleByPrimäryKey(string Primärschlüssel)
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM CustomModule WHERE Primärschlüssel = @a";
                command.Parameters.AddWithValue("@a", Primärschlüssel);
                command.ExecuteNonQuery();
            }
        }
        
    }
    }
