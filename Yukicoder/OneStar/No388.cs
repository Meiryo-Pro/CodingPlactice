using System;

public class No388
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int s = int.Parse(input[0]);
        int f = int.Parse(input[1]);

        Console.WriteLine(s/f+1);
    }
}
