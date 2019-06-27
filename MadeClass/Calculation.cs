using System;
using System.Collections.Generic;
using System.Text;

class Calculation
{
    static void Main(string[] args)
    {
        var list = new List<int>();
        list.Add(4);
        list.Add(10);
        list.Add(13);
        list.Add(2);
        list.Add(5);
        Console.WriteLine(Lcm(list));
    }

    /// <summary>
    /// 2つの数の最小公倍数を求める
    /// Gcdメソッドに依存。
    /// </summary>
    /// <returns>最小公倍数</returns>
    public static int Lcm(int a, int b)
    {
        return a * b / Gcd(a, b);
    }

    /// <summary>
    /// 2つの数の最大公約数を求める
    /// </summary>
    /// <returns>最大公約数</returns>
    public static int Gcd(int a, int b)
    {
        var r = 0;
        //大きさ比べて入れ替え
        if (a < b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        r = a % b;
        while (r > 0)
        {
            a = b;
            b = r;
            r = a % b;
        }
        return b;
    }

    /// <summary>
    /// 複数の数の最小公倍数を求める
    /// Gcdメソッドに依存
    /// </summary>
    /// <returns>最小公倍数</returns>
    public static int Lcm(List<int> list)
    {
        var a = 0;
        var b = 0;
        var stack = new Stack<int>();
        var loopCount = 0;
        var lcm = 0;

        foreach (var val in list)
        {
            stack.Push(val);
        }

        loopCount = stack.Count;

        for (var i = 0; i < loopCount - 1; i++)
        {
            if (i == 0)
            {
                a = stack.Pop();
                b = stack.Pop();
            }
            else if (i > 0)
            {
                a = lcm;
                b = stack.Pop();
            }

            lcm = a * b / Gcd(a, b);
        }
        return lcm;
    }

    /// <summary>
    /// 複数の数の最大公約数を求める
    /// </summary>
    /// <returns>最大公約数</returns>
    public static int Gcd(List<int> list)
    {
        var a = 0;
        var b = 0;
        var r = 0;
        var stack = new Stack<int>();
        var loopCount = 0;

        foreach (var val in list)
        {
            stack.Push(val);
        }

        loopCount = stack.Count;
        for (var i = 0; i < loopCount - 1; i++)
        {
            if (i == 0)
            {
                a = stack.Pop();
                b = stack.Pop();
            }
            else if (i > 0)
            {
                a = b;
                b = stack.Pop();
            }

            //大きさ比べて入れ替え
            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            r = a % b;

            while (r > 0)
            {
                a = b;
                b = r;
                r = a % b;
            }
        }
        return b;
    }
}
