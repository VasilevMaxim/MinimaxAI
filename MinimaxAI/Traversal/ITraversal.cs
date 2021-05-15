namespace MinimaxAI.Loading
{
    internal interface ITraversal
    {
        ITraversal Start(MinMaxPriority minMaxPriority);
    }
}