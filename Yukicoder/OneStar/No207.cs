using System;
using System.Collections.Generic;

class No207
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int loopCount = b - a;

        for (int i = 0; i <= loopCount; i++)
        {
            int answer = a + i;
            string str = answer.ToString();
            if ((answer % 3 == 0) || (str.IndexOf("3") >= 0))
            {
                Console.WriteLine(answer);
            }
        }
    }
}
