
namespace Modulmethods
{
    public class DBWriting
    {
        //If it doesn't exist copy the database from the app package to the local folder for the user
        public static string GetDBPath()
        {

            string databaseName = "TUFreibergModule.db";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            if (File.Exists(databasePath))
            {
                return databasePath;
            }
            Task<Stream> task = FileSystem.OpenAppPackageFileAsync($"Resources/Raw/{databaseName}");
            var stream = task.Result;
            using MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            File.WriteAllBytes(databasePath, memoryStream.ToArray());
            return databasePath;
        }
    }
}
