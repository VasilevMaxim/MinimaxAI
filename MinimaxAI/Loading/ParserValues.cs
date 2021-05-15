using System.Linq;

namespace MinimaxAI.Loading
{
    internal class ParserValues
    {
        private readonly string _separators;

        public ParserValues(string separators)
        {
            _separators = separators;
        }
        
        public int[] Parse(string text)
        {
            return text.Split(_separators)
                       .Select(int.Parse)
                       .ToArray();
        }
    }
}