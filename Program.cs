using System;
class Programm
{
    public static void Main()
    {
        var arry = Modulmethods.SQLMETHODS.GetAllPflichtCourses("2.MB");
        foreach(string m in arry)
        {
            System.Console.WriteLine(m);
        }
    }

}


