using System;

public class No264
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        const string DREW = "Drew";
        const string WON = "Won";
        const string LOST = "Lost";
        string result;

        if (n == k)
        {
            result = DREW;
        }
        else if ((n == 0 && k == 1) || (n == 1 && k == 2) || (n == 2 && k == 0))
        {
            result = WON;
        }
        else
        {
            result = LOST;
        }

        Console.WriteLine(result);
    }
}
