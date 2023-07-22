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

        static void CreateCustomModule(string Lehrveranstaltung, string Art, string Dozenten, string Turnus, string Raum, string Wochentag, string Beginn, string Ende)
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO CustomModule (Primärschlüssel, Lehrveranstaltung, Art, Dozenten, Turnus, Raum, Wochentag, Beginn, Ende) VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";
                command.Parameters.AddWithValue("@a", "#"+GetEntryCount());
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
        }
        static int GetEntryCount()
        {
            var connection = new SqliteConnection($"Data Source={DBWriting.GetDBPath()}");
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM CustomModule";
                return Convert.ToInt32(command.ExecuteScalar());
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
    }
}
