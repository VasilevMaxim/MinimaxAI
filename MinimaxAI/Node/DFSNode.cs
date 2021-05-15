using System.Collections.Generic;
using System.Linq;

namespace MinimaxAI
{
    internal class DFSNode<T> : IDFSNode<T>
    {
        public T Value { get; set; }
        public List<INode<T>> Nodes { get; protected set; }
        public bool IsVisited { get; set; }
        
        public INode<T> FindFirstFree()
        {
            if (Nodes == null || Nodes.Count == 0) return null;
            return Nodes.FirstOrDefault(node => node.IsVisited == false);
        }
        
        public void AddChild(INode<T> node)
        {
            Nodes.Add(node);
        }
    }
}