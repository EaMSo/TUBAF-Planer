using System.Reflection;
using Xunit;
using Modulmethods;
using Xunit.Abstractions;

namespace ModulMethodsTests
{
    public class ModulTests
    {
        private readonly ITestOutputHelper _output;
        
        public ModulTests(ITestOutputHelper output)
        {
            this._output = output;
        }
        [Fact]
        public void TestModulConstructor()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fullpath = Path.Combine(path, @"Resources\Database\TUFreibergModule.db");
            _output.WriteLine(fullpath);
            string primaryKey = "#SPLUSCB0264";
            Modul modul = new Modul(primaryKey);
          
            Assert.Equal("Modulinfo: \nCoursname: (Basics of) Coatings Technology\nType: Vorlesung\nLecturer: Wüstefeld, Christina\nRoom: MET-2065\nTurnus: wöchentlich\nWeekday: Dienstag\nStart: 09:45\nEnd: 11:15", modul.ToString());
        }
    }
}