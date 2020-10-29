using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.MathPuzzle
{
    class Q1
    {
        public static void Main(string[] args)
        {
            bool isFound = false;
            var i = 11;

            while (!isFound)
            {
                var binaryNumber = Convert.ToString(i, 2);
                var reverseBinaryNumber = new string(binaryNumber.Reverse().ToArray());
                if(binaryNumber == reverseBinaryNumber)
                {
                    var octalNumber = Convert.ToString(i, 8);
                    var reverseOctalNumber = new string(octalNumber.Reverse().ToArray());
                    
                    if(octalNumber == reverseOctalNumber)
                    {
                        var decimalNumber = i.ToString();
                        var reverseDecimalNumber = new string(decimalNumber.Reverse().ToArray());

                        if(decimalNumber == reverseDecimalNumber)
                        {
                            isFound = true;
                            break;
                        }
                    }
                }
                i++;
            }
            Console.WriteLine(i);
        }
    }
}
