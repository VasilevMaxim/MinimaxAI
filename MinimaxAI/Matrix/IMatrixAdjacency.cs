namespace MinimaxAI.Loading
{
    internal interface IMatrixAdjacency
    {
        int[] this[int key] { get; }

        void Add(int key, int[] values);
    }
}