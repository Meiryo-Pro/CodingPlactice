using System;
using System.Collections.Generic;
using System.Text;

namespace Test.MathPuzzle
{
    class Q3
    {
        public static void Main()
        {
            var q = new Q3();
            var cards = new Dictionary<int, bool>();
            for (var i = 1; i <= 100; i++)
            {
                cards.Add(i, false);
            }

            for (var i = 2; i <= 100; i++)
            {
                q.Calc(i, cards);
            }

            for (var i = 1; i <= 100; i++)
            {
                if (cards[i] == false)
                {
                    Console.WriteLine(i);
                }
            }

        }

        public void Calc(int num, Dictionary<int, bool> cards)
        {
            for (var i = num; i <= 100; i += num)
            {
                if (cards[i])
                {
                    cards[i] = false;
                }
                else
                {
                    cards[i] = true;
                }

            }
        }
    }
}
