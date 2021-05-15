using System;
using System.Linq;

namespace MinimaxAI.Loading
{
    internal class ParserMatrixAdjacency : IParserMatrixAdjacency
    {
        private readonly string _separatorMain;
        private readonly string _separatorsValues;

        public ParserMatrixAdjacency(string separatorMain, 
                                     string separatorsValues)
        {
            _separatorMain = separatorMain;
            _separatorsValues = separatorsValues;
        }

        public IMatrixAdjacency Parse(string text)
        {
            var matrix = new MatrixAdjacency();
            var lines = text.Split(Environment.NewLine).ToList();
            lines.ForEach(line =>
            {
                var pair = line.Split(_separatorMain);
                var values = pair[1].Split(_separatorsValues)
                                    .Select(value => int.Parse(value) - 1)
                                    .ToArray();
                matrix.Add(int.Parse(pair[0]) - 1, values);
            });

            return matrix;
        }
    }
}