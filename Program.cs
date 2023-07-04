using System;
class Programm
{
    public static void Main()
    {
        /*var arry = Modulmethods.SQLMethods.GetAllPflichtModPrimKey("2.BAI");
        foreach(string m in arry)
        {
            System.Console.WriteLine(m);
        }*/
        var Modul = new Modulmethods.Modul("#SPLUS12AE50");
        System.Console.WriteLine(Modul);
        //System.Console.WriteLine(Modulmethods.SQLMethods.GetCourseName("#SPLUS83BAC2")); 
    }

}


