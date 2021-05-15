namespace MinimaxAI
{
    internal interface IMinMaxOperations<T> 
    {
        T GetMaxChild();
        T GetMinChild();
        T GetValueLeftNode(INode<T> current);
        bool IsValueLeftNode(INode<T> node);
    }

}