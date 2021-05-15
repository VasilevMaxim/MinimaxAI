namespace MinimaxAI
{
    internal interface IDFSNode<T> : INode<T>
    {
        INode<T> FindFirstFree();
        void AddChild(INode<T> node);
    }
}