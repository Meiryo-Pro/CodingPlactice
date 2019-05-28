using System;
using System.Collections.Generic;
using System.Text;

class No143
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int K = int.Parse(input[0]);
        int N = int.Parse(input[1]);
        int F = int.Parse(input[2]);
        int sum = 0;
        int beans = K * N;
        int totalBeanConsumption = 0;
        string[] familyAges = Console.ReadLine().Split(' ');

        foreach (string s in familyAges)
        {
            totalBeanConsumption += int.Parse(s);
        }

        if (beans < totalBeanConsumption)
        {
            sum = -1;
        }
        else
        {
            sum = beans - totalBeanConsumption;
        }

        Console.WriteLine(sum);
    }
}
