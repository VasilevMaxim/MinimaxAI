using System.Collections.Generic;

namespace MinimaxAI.Loading
{
    internal class DFSDebug<T> : ITraversal
    {
        private int _depth;
        private Stack<INodeMinMax<T>> _stack;
        private readonly Tree<T> _tree;
        private MinMaxPriority _minMaxPriority;

        public DFSDebug(Tree<T> tree)
        {
            _tree = tree;
        }
        
        public ITraversal Start(MinMaxPriority minMaxPriority)
        { 
            _minMaxPriority = minMaxPriority;
            _depth = 0;
            _stack = new Stack<INodeMinMax<T>>();
            _stack.Push(_tree.Head); 
            _tree.ResetVisited();
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
                
                next.Debug();
                next.IsVisited = true;
                if (_stack.Count > 0)
                    Traversal(_stack.Peek());
            }
        }
    }
}