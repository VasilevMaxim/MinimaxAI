using MinimaxAI.Loading;

namespace MinimaxAI
{
    internal class Tree<T>
    {
        public INodeMinMax<T> Head { get; private set; }
        private INodeMinMax<T>[] _list;
        public void Load(MatrixAdjacency matrix, T[] values)
        {
            _list = new INodeMinMax<T>[matrix.CountAll + 1];
            for (int i = 0; i < _list.Length; i++)
                _list[i] = new NodeMinMax<T>(i);

            for (int i = 0; i < matrix.CountKey; i++)
            {
                if (matrix.ContainsKey(i) == true)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        _list[matrix[i][j]].Parent = _list[i];
                        _list[i].AddChild(_list[matrix[i][j]]);
                    }
                }
            }
            Head = _list[0];

            for (int i = _list.Length - values.Length, j = 0; i < _list.Length; i++, j++)
                _list[i].Value = values[j];
        }

        public void ResetVisited()
        {
            foreach (var node in _list)
            {
                node.IsVisited = false;
            }
        }
    }
}