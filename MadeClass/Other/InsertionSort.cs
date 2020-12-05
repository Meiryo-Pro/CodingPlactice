using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Other
{
    class InsertionSort
    {
        private const int ListCount = 10;
        public static void Main(string[] args)
        {
            var insertionSort = new InsertionSort();
            var list = new List<int>(ListCount);
            for (var i = 1; i <= ListCount; i++)
            {
                list.Add(i);
            }

            var randomList = new List<int>(list.OrderBy(i => Guid.NewGuid()).ToList<int>());
            LinkedList<int> sortedList = insertionSort.Sort(randomList);

            Console.WriteLine("----------------");
            Console.WriteLine("ソート後");
            insertionSort.Display(sortedList);
        }

        public LinkedList<int> Sort(List<int> randomList)
        {
            Console.WriteLine("ソート前");
            Display(randomList);
            Console.WriteLine("----------------");
            Console.WriteLine("ソート中");

            var list = new LinkedList<int>(randomList);
            for (var node = list.First; node.Next != null; node = node.Next)
            {
                while (node.Value > node.Next.Value)
                {
                    var temp = node.Next.Value;
                    list.Remove(node.Next);
                    list.AddBefore(node, temp);

                    if (node.Previous.Previous != null)
                    {
                        node = node.Previous.Previous;
                    }
                    Display(list);
                }
            }

            return list;
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
