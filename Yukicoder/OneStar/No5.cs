using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

class No5
{
    static int L = 0;
    static int N = 0;
    static string[] W;
    static int[] IW;
    static void Main(string[] args)
    {

        int L = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        string[] W = Console.ReadLine().Split(' ');
        int[] IW = new int[W.Length];
        int count = 0;

        for (int i = 0; i < W.Length; i++)
        {
            IW[i] = int.Parse(W[i]);
        }
        Array.Sort(IW);

        for (int i = 0; i < W.Length; i++)
        {
            L -= IW[i];
            if (L < 0)
            {
                break;
            }
            else
            {
                count++;
            }
        }
        Console.WriteLine(count);

    }

}
