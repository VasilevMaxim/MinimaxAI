using System;
using System.Collections.Generic;
using MinimaxAI.Loading;

namespace MinimaxAI
{
    internal class MinMaxPruning<T> : ITraversal where T : struct, IComparable<T>
    {
        private Stack<INodeMinMax<T>> _stack = new Stack<INodeMinMax<T>>();
        
        private int _depth;
        private readonly Tree<T> _tree;
        private MinMaxPriority _minMaxPriority;
        
        public MinMaxPruning(Tree<T> tree)
        {
            _tree = tree;
        }

        public ITraversal Start(MinMaxPriority minMaxPriority)
        { 
            _minMaxPriority = minMaxPriority;
            _depth = 0;
            _stack.Push(_tree.Head); 
            _tree.ResetVisited();
            Traversal(_tree.Head);
           
            return this;
        }
        
        public void Traversal(INodeMinMax<T> nodeMinMax)
        {
            if (nodeMinMax == null) return;
            INodeMinMax<T> next = nodeMinMax.FindFirstFree() as INodeMinMax<T>;
            if (next != null)
            {
                _stack.Push(next);
                _depth++; 
                Traversal(next);
            }
            else
            {
                next = _stack.Pop();
                _depth--;
                
                next.Value = _minMaxPriority.GetPriority(_depth) == PriorityType.MIN ? next.GetMinChild() : next.GetMaxChild();
                
                Pruning(next);
                next.Debug();
                next.IsVisited = true;
                if (_stack.Count > 0)
                    Traversal(_stack.Peek());
            }
        }

        private void Pruning(INodeMinMax<T> node)
        {
            if (node.Parent == null) return;
            if (node.Parent.IsValueLeftNode(node) == false) return;;
            
            var priority = _minMaxPriority.GetPriority(_depth);
            var pastLeft = node.Parent.GetValueLeftNode(node);
            
            int index = 0;
            for (index = 0; index < node.Nodes.Count; index++)
            {
                if (priority == PriorityType.MIN && node.Nodes[index].Value.CompareTo(pastLeft) > 0 ||
                    priority == PriorityType.MAX && node.Nodes[index].Value.CompareTo(pastLeft) < 0)
                {
                    break;
                }
            }

            index++;

            for (; index < node.Nodes.Count; index++)
                node.Nodes[index].Value = priority == PriorityType.MIN ? 
                    INodeMinMax<T>.Max : 
                    INodeMinMax<T>.Min;
        }

    }
}