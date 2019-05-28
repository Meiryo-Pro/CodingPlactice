using System;
using System.Collections.Generic;
using System.Text;

class No289
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        
        int total = 0;
        int temp = 0;
        for (int i = 0; i<input.Length; i++)
        {
            if (int.TryParse(input[i].ToString(),out temp))
            {
                total += temp;
            }
        }
        Console.WriteLine(total);
    }
}
