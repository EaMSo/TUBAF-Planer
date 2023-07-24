

using System.Security.AccessControl;

namespace Modulmethods
{
    public class FullmoduleList
    {
        public static List<Modul> GetFullmoduleList()
        {
            List<Modul> fullmodulelist = new List<Modul>();
            List<string> primaryKeyList = SQLMethods.GetPrimaryKeyList("Module");
            foreach (string primaryKey in primaryKeyList)
            {
                Modul modul = new Modul(primaryKey);
                fullmodulelist.Add(modul);
            }
            return fullmodulelist;
        }

        public static List<CustomModule> GetFullCustomList()
        {
            List<CustomModule> fullmodulelist = new ();
            List<string> primaryKeyList = SQLMethods.GetPrimaryKeyList("CustomModule");
            foreach (string primaryKey in primaryKeyList)
            {
                CustomModule modul = new CustomModule(primaryKey);
                fullmodulelist.Add(modul);
            }
            return fullmodulelist;
        }
    }
}
