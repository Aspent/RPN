using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    class ExpressionChecker
    {
        public bool Check(string expression)
        {
            const string exprPattern = @"[ ()]";
            var exprRegex = new Regex(exprPattern);
            var str = exprRegex.Replace(expression, "");

            const string bracketPattern = @"[^()]";
            var regex = new Regex(bracketPattern);
            var bracketStr = regex.Replace(expression, "");

            var stack = new Stack<char>();
            foreach (var sym in bracketStr)
            {
                if (sym == '(')
                {
                    stack.Push(sym);
                }
                if (sym == ')')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Error: Incorrect placement of brackets");
                        return false;
                    }
                    
                    stack.Pop();
                }
            }
            if (stack.Count != 0)
            {
                Console.WriteLine("Error: Incorrect placement of brackets");
                return false;
            }


            const string pattern = @"^\d+(([-+*/^]){1}\d+)+$";


            if (!Regex.IsMatch(str, pattern))
            {
                Console.WriteLine("Error: Incorrect expression");
                return false;
            }

            return true;
        }
        
    }
}
