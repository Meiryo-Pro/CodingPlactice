using System;

public class No46
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int answer = 0;
        int result = 0;

        result = b % a;
        if(result > 0)
        {
            answer = b / a + 1;
        }
        else
        {
            answer = b / a;
        }
        Console.WriteLine(answer);
    }
}
