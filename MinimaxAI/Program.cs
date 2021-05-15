using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MinimaxAI.Loading;

namespace MinimaxAI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ILoadable loader = new LoaderDefault();
            IParserMatrixAdjacency parser = new ParserMatrixAdjacency(":", " ");
            var parserValues = new ParserValues(" ");
            
            IMatrixAdjacency matrixAdjacency = parser.Parse(loader.Load(args[0]));
            int[] values = parserValues.Parse(loader.Load(args[1]));

            MatrixAdjacency mat = (MatrixAdjacency) matrixAdjacency;
            Tree<int> tree = new Tree<int>();
            tree.Load(mat, values);
            
            INodeMinMax<int>.Min = int.MinValue;
            INodeMinMax<int>.Max = int.MaxValue;

            MinMaxPriority priority = new TakeTurns(PriorityType.MAX);
            DFS<int> dfs = new DFS<int>(tree);
            dfs.Start(priority);
            
            Console.WriteLine("   ");

            MinMaxPruning<int> dfs2 = new MinMaxPruning<int>(tree);
            dfs2.Start(priority);
            
            Console.WriteLine("   ");
            
            DFSDebug<int> dfsDebug = new DFSDebug<int>(tree);
            dfsDebug.Start(priority);
        }
    }
}
