using System;
using System.Collections.Generic;
using System.Text;

class No548
{
    static void Main(string[] args)
    {
        bool failureFlag = false;
        string tiles = "abcdefghijklm";
        int[] tilesCount = new int[13];
        string input = Console.ReadLine();
        int pairCount = 0;

        for (int i = 0; i<13; i++)
        {
            tilesCount[i] = CountTile(input, tiles[i]);

            if (tilesCount[i] == 2)
            {
                pairCount++;
            }

            if(tilesCount[i] == -1 || pairCount >= 2)
            {
                failureFlag = true;
            }
        }


        if (failureFlag == true)
        {
            Console.WriteLine("Impossible");
        }
        else 
        {
            int index = Array.IndexOf(tilesCount, 0);

            //十三面待ちの場合
            if (index == -1)
            {
                foreach(char s in tiles)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine(tiles[index]);
            }
            
        }

    }

    public static int CountTile(string input, char c)
    {
        int temp;
        temp = input.Length - input.Replace(c.ToString(), "").Length;
        
        if(temp > 2)
        {
            temp = - 1;
        }

        return temp;
    }
}
