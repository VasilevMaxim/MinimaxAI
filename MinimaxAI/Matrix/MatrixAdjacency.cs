using System.Collections.Generic;
using System.Linq;

namespace MinimaxAI.Loading
{
    internal class MatrixAdjacency : IMatrixAdjacency
    {
        public int CountKey => _matchings.Count;
        public int CountAll => GetCountAll();
        public int[] this[int key] => _matchings[key];
        public int this[int key, int key2] => _matchings[key][key2];
        
        private Dictionary<int, int[]> _matchings = new Dictionary<int, int[]>();
        
        public void Add(int key, int[] values)
        {
            _matchings.Add(key, values);
        }

        public bool ContainsKey(int value)
        {
            return _matchings.ContainsKey(value);
        }

        private int GetCountAll()
        {
            return _matchings.SelectMany(mathching => mathching.Value).Max();
        }
    }
}