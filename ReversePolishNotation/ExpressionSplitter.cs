using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    class ExpressionSplitter
    {
        private readonly HashSet<char> _operations = new HashSet<char>();

        public ExpressionSplitter()
        {
            _operations.Add('^');
            _operations.Add('+');
            _operations.Add('-');
            _operations.Add('*');
            _operations.Add('/');
            _operations.Add('(');
            _operations.Add(')');
        }

        public List<string> Split(string sourceString)
        {
            var result = new List<string>();

            const string pattern = @"(^[-]?\d+(\.\d+)?)|([*/^+(-]{1}[-]?\d+(\.\d+)?)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(sourceString);

            for (var i = 0; i < sourceString.Length; i++)
            {

                var found = false;
                foreach (Match t in matches)
                {
                    if (i == 0 && i == t.Index)
                    {
                        result.Add(sourceString.Substring(0, t.Length));
                        found = true;
                        i += t.Length - 1;
                        break;
                    }
                    if (i == t.Index)
                    {
                        found = true;
                        if (_operations.Contains(sourceString[i]))
                        {
                            result.Add(sourceString.Substring(i, 1));
                            result.Add(sourceString.Substring(i + 1, t.Length - 1));
                        }
                        else
                        {
                            result.Add(sourceString.Substring(i, t.Length));
                        }

                        i += t.Length - 1;
                        break;
                    }
                }
                if (found)
                {
                    continue;
                }
                result.Add(sourceString.Substring(i, 1));
            }

            return result;
        }
    }
}
