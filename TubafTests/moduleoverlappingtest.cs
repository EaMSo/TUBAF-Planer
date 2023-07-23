using System;
using System.Collections.Generic;
using Xunit;

namespace TubafTests
{
    // Mockmodul is Tested here
    public class ModulTests
    {
        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnTrue_WhenOverlapExists()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "wöchentlich");
            var modulList = new List<Modul>
        {
            new Modul(2, "Monday", "09:00", "11:00", "wöchentlich"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.True(result);
        }

        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnFalse_WhenNoOverlapExists()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "wöchentlich");
            var modulList = new List<Modul>
        {
            new Modul(2, "Tuesday", "09:00", "11:00", "wöchentlich"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.False(result);
        }
        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnTrue_WhenOverlapExistsWithUngradeWoche()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "ungrade woche");

            var modulList = new List<Modul>
        {
            new Modul(2, "Monday", "09:00", "11:00", "wöchentlich"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.True(result);
        }

        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnFalse_WhenNoOverlapExistsWithUngradeWoche()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "ungrade woche");

            var modulList = new List<Modul>
        {
            new Modul(2, "Tuesday", "09:00", "11:00", "wöchentlich"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.False(result);
        }

        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnTrue_WhenOverlapExistsWithGradeWoche()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "grade woche");

            var modulList = new List<Modul>
        {
            new Modul(2, "Monday", "09:00", "11:00", "grade woche"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.True(result);
        }

        [Fact]
        public void AnotherModuleIsAtSameTime_ShouldReturnFalse_WhenNoOverlapExistsWithGradeWoche()
        {
            var testModul = new Modul(1, "Monday", "08:00", "10:00", "grade woche");

            var modulList = new List<Modul>
        {
            new Modul(2, "Tuesday", "09:00", "11:00", "grade woche"),
        };
            var result = Modul.AnotherModuleIsAtSameTime(testModul, modulList);
            Assert.False(result);    
        }
    }
}