using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionsAllTheWay
{
    public class Solution
    {
        public void IfThenElseExpression(bool aBool)
        {
            int result = aBool ? 42 : 0;
            Console.WriteLine("result={0}", result);
        }

        public void LoopStatementForEach()
        {
            var numbers = new List<int> { 1, 2, 3 };
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine("sum={0}", sum);
        }

        public void LoopExpressionAggregate()
        {
            var numbers = new List<int> { 1, 2, 3 };

            var sum = numbers.Aggregate(0, (sumSoFar, i) => sumSoFar + i);

            Console.WriteLine("sum={0}", sum);
        }

        public void LoopExpressionSum()
        {
            var numbers = new List<int> { 1, 2, 3 };

            var sum = numbers.Sum();

            Console.WriteLine("sum={0}", sum);
        }
    }
}
