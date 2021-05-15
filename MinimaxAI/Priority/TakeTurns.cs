namespace MinimaxAI.Loading
{
    internal class TakeTurns : MinMaxPriority
    {
        private readonly PriorityType _first;

        public TakeTurns(PriorityType first)
        {
            _first = first;
        }
        
        public override PriorityType GetPriority(int depth)
        {
            var even = depth % 2 == 0;
            if (_first == PriorityType.MIN)
                return even ? PriorityType.MAX : PriorityType.MIN;
            
            return even ? PriorityType.MIN : PriorityType.MAX;
        }
    }
}