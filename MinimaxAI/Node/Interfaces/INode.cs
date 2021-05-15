using System.Collections.Generic;

namespace MinimaxAI
{
    internal interface INode<T>
    {
        T Value { get; set; }
        List<INode<T>> Nodes { get; }
        bool IsVisited { get; set; }
    }
}