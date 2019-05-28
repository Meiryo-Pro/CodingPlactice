using System;
using System.Collections.Generic;
using System.Text;

class No163
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder(input);

        for(int i = 0; i<input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                sb[i] = char.ToLower(input[i]);
            }
            else if (char.IsLower(input[i]))
            {
                sb[i] = char.ToUpper(input[i]);
            }
        }
        Console.WriteLine(sb);
    }
}
