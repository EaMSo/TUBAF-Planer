using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
