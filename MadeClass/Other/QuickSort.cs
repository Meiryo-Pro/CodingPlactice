using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Other
{
    class QuickSort
    {
        private const int ListCount = 10;
        public static void Main(string[] args)
        {
            var q = new QuickSort();
            var list = new List<int>(ListCount);
            for (var i = 1; i <= ListCount; i++)
            {
                list.Add(i);
            }

            list = list.OrderBy(i => Guid.NewGuid()).ToList<int>();
            Console.WriteLine("ソート前");
            q.Display(list);
            Console.WriteLine("----------------");
            Console.WriteLine("交換中");

            q.Sort(list, 0, list.Count - 1);

            Console.WriteLine("----------------");
            Console.WriteLine("ソート後");
            q.Display(list);
        }

        public void Sort(List<int> list, int left, int right)
        {
            
            if(left >= right)
            {
                return;
            }

            var l = left;
            var r = right - 1;
            var pivot = list[right];

            while (true)
            {
                while (list[l] < pivot)
                {
                    l++;
                }

                while (l < r && pivot < list[r])
                {
                    r--;
                }

                if (l >= r)
                {
                    break;
                }

                Swap(list, l, r);
                Display(list);
            }

            Swap(list, l, right);
            Display(list);

            Sort(list, left, l - 1);
            Sort(list, l + 1, right);
        }

        public void Swap(List<int> list, int left, int right)
        {
            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }

        public void Display(ICollection<int> list)
        {
            foreach (var v in list)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }

    }
}