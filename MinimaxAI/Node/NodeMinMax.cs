using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimaxAI
{
    internal class NodeMinMax<T> : DFSNode<T>, INodeMinMax<T>
    {
        public INodeMinMax<T> Parent { get; set; }
        private readonly int _index;
        
        public NodeMinMax(int index, params INode<T>[] nodes)
        {
            Nodes = nodes == null ? new List<INode<T>>() : nodes.ToList();
            _index = index;
        }
        
        public T GetMaxChild()
        {
            if (Nodes == null || Nodes.Count == 0) return Value;
            return Nodes.Max(node => node.Value);
        }
        
        public T GetMinChild()
        {
            if (Nodes == null || Nodes.Count == 0) return Value;
            return Nodes.Min(node => node.Value);
        }

        public bool IsValueLeftNode(INode<T> node)
        {
            return Nodes.Count > 1 && Nodes[0] != node;
        }
        
        public T GetValueLeftNode(INode<T> current)
        {
            for(int i = 1; i < Nodes.Count; i++)
                if (Nodes[i] == current)
                    return Nodes[i - 1].Value;

            throw new ArgumentException();
        }
        
        public void Debug()
        {
            Console.WriteLine((_index + 1) + ":" + Value);
        }
    }
}