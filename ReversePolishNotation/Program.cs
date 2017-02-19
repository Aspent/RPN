using System;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main()
        {   
            var exprChecker = new ExpressionChecker();        
            Console.WriteLine("Enter expression");
            var str = Console.ReadLine();

            while (str != "end")
            {
                if (exprChecker.Check(str))
                {
                    var result = new Translator().Translate(str);
                    Console.WriteLine("Result: {0}", result);
                }
                Console.WriteLine();
                Console.WriteLine("Enter expression");
                str = Console.ReadLine();
            }
        }
    }
}
