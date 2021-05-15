using System.Collections;
using System.Collections.Generic;

namespace MinimaxAI.Loading
{
    internal class DFS<T> : ITraversal
    {
        private int _depth;
        private Stack<INodeMinMax<T>> _stack;
        private readonly Tree<T> _tree;
        private MinMaxPriority _minMaxPriority;
        
        public DFS(Tree<T> tree)
        {
            _tree = tree;
        }
        
        public ITraversal Start(MinMaxPriority minMaxPriority)
        { 
            _minMaxPriority = minMaxPriority;
            
            _tree.ResetVisited();
            _depth = 0;
            _stack = new Stack<INodeMinMax<T>>();
            _stack.Push(_tree.Head); 
            
            Traversal(_tree.Head);
            
            return this;
        }
        
        private void Traversal(INodeMinMax<T> node)
        {
            if (node == null) return;
            INodeMinMax<T> next = node.FindFirstFree() as INodeMinMax<T>;
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
                
                next.Debug();
                next.IsVisited = true;
                if (_stack.Count > 0)
                    Traversal(_stack.Peek());
            }
        }
    }
}