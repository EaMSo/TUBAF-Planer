using Microsoft.Data.Sqlite;
using System.Collections.Generic;

class Programm
{
    public static List<string> GetData()
    {
    var entries = new List<string>();
    string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
                                 "TUBAF_Planner.db");
    using (var db = new SqliteConnection($"Filename={dbpath}"))
    {
        db.Open();
        var selectCommand = new SqliteCommand
            ("SELECT Text_Entry from MyTable", db);

        SqliteDataReader query = selectCommand.ExecuteReader();

        while (query.Read())
        {
            entries.Add(query.GetString(0));
        }
    }

    return entries;
    }
}

