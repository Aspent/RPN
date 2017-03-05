using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotation
{
    class Translator
    {
        private readonly Dictionary<string, byte> _priorities = new Dictionary<string, byte>();
        private readonly HashSet<char> _operations = new HashSet<char>(); 

        public Translator()
        {
            _priorities["^"] = 1;
            _priorities["*"] = 2;
            _priorities["/"] = 2;
            _priorities["+"] = 3;
            _priorities["-"] = 3;
            _priorities["("] = 4;

            _operations.Add('^');
            _operations.Add('+');
            _operations.Add('-');
            _operations.Add('*');
            _operations.Add('/');
            _operations.Add('(');
            _operations.Add(')');
        }
        
        public string Translate(string sourceString)
        {
            var str = sourceString.Replace(" ", "");
            var result = new StringBuilder();
            var stack = new Stack<string>();
            var elements = new ExpressionSplitter().Split(str);

            foreach (var t in elements)
            {
                if (t.Length == 1 && _operations.Contains(t[0]))
                {
                    if (t == "(")
                    {
                        stack.Push(t);
                        continue;
                        
                    }
                    if (t == ")")
                    {
                        while (stack.Peek() != "(")
                        {
                            result.Append(stack.Pop() + " ");
                        }
                        stack.Pop();
                        continue;
                    }

                    if (stack.Count == 0)
                    {
                        stack.Push(t);
                        continue;
                    }

                    while (_priorities[stack.Peek()] <= _priorities[t])
                    {
                        if (_priorities[stack.Peek()] == _priorities[t] && _priorities[t] == 1)
                        {
                            break;
                        }
                        result.Append(stack.Pop() + " ");
                        if (stack.Count == 0)
                        {
                            break;
                        }                        
                    }
                    stack.Push(t);
                }
                else
                {
                    result.Append(t + " ");
                }
            }
            while(stack.Count != 0)
            {
                result.Append(stack.Pop() + " ");
            }

            return result.ToString();
        }
    }
}
