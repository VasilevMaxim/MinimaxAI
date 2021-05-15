namespace MinimaxAI
{
    internal interface INodeMinMax<T> : IDFSNode<T>, IMinMaxOperations<T>, IDebugNode
    {
        static T Max { get; set;}
        static T Min { get; set; }
        INodeMinMax<T> Parent { get; set; }
        
    }
}