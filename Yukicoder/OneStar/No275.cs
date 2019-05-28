using System;
using System.Collections.Generic;
using System.Text;

class No275
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        float answer = 0;
        float[] floatInput = new float[input.Length];

        for(int i = 0; i<input.Length; i++)
        {
            floatInput[i] = float.Parse(input[i]);
        }

        Array.Sort(floatInput);

        if(n % 2  == 0)
        {
            answer = (((floatInput[n / 2 - 1]) + floatInput[n / 2]) / 2); 
        }
        else
        {
            answer = floatInput[n/2];
        }
        Console.WriteLine("{0:F1}", answer);
    }
}
