using System.Reflection;
using Xunit;
using Modulmethods;

namespace ModulMethodsTests
{
    public class ModulTests
    {
        [Fact]
        public void TestModulConstructor()
        {
            string primaryKey = "#SPLUSCB0264";
            Modul modul = new Modul(primaryKey);
            Assert.Equal("Modulinfo: \nCoursname: (Basics of) Coatings Technology\nType: Vorlesung\nLecturer: Wüstefeld, Christina\nRoom: MET-2065\nTurnus: wöchentlich\nWeekday: Dienstag\nStart: 09:45\nEnd: 11:15", modul.ToString());
        }
    }
}