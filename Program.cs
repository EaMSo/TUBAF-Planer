using System;
class Programm
{
    public static void Main()
    {
        var arry = SQLMETHODS.GetAllPflichtModPrimKey("2.Mm");
        foreach(string m in arry)
        {
            System.Console.WriteLine(m);
        }
        
    }

}


