using System;
class Programm
{
    public static void Main()
    {
        /*var arry = Modulmethods.SQLMethods.GetAllPflichtCourses("2.MB");
        foreach(string m in arry)
        {
            System.Console.WriteLine(m);
        }*/
        var Modul = new Modulmethods.Modul("#SPLUS68B195");
        System.Console.WriteLine(Modul);
    }

}


