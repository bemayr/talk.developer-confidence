using System;
using System.Collections.Generic;

namespace ExpressionsAllTheWay
{
    class Program
    {
        static void Main(string[] args)
        {
            IfThenElseStatement(true);
            LoopStatement();
        }

        public static void IfThenElseStatement(bool aBool)
        {
            int result;

            if (aBool)
            {
                result = 42;
                Console.WriteLine("result={0}", result);
            }
        }

        public static void LoopStatement()
        {
            var numbers = new List<int> { 1, 2, 3 };
            int sum = 0;

            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine("sum={0}", sum);
        }
    }
}