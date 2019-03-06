using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NeuronGraph<typename> where typename:IComparable
    {
        private AdjacencyMatrix matrix;
        List<Neuron<typename>> vertexList = new List<Neuron<typename>>();

        public AdjacencyMatrix Matrix
        {
            get { return matrix; }
        }
        public NeuronGraph()
        {
            matrix = new AdjacencyMatrix();
        }

        /// <summary>
        /// Adds an vertex
        /// </summary>
        /// <param name="value"></param>
        public bool AddVertex(typename value)
        {
            if (Find(value) != -1)
            {
                return false;
            }
            else
            {
                Neuron<typename> vertex = new Neuron<typename>(value);
                vertexList.Add(vertex);
                matrix.Add();
                return true;
            }
        }

        /// <summary>
        /// Removes a vertex with given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveVertex(typename value)
        {
            int index = Find(value);
            if (index != -1)
            {
                vertexList.RemoveAt(index);
                matrix.Remove(index);
            }
            else
            {
                System.Console.WriteLine("Vertex not found to remove");
            }
        }

        /// <summary>
        /// Makes vertices be neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MakeNeighbours(typename x, typename y)
        {
            matrix.SetNeighbours(Find(x), Find(y));
        }

        /// <summary>
        /// x,y no longer neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void BreakNeighbourhood(typename x, typename y)
        {
            matrix.BreakNeighbourhood(Find(x), Find(y));
        }
        /// <summary>
        /// Returns index of item with value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int Find(typename value)
        {
            for (int i = 0; i < vertexList.Count; i++)
            {
                if (vertexList[i].Data.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Search in depth
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        public void DepthSearch(typename start, typename finish)
        {
            int startI = Find(start);
            int finishI = Find(finish);
            Stack<int> stack = new Stack<int>();
            if (startI == -1 || finishI == -1)
            {
                System.Console.WriteLine("Wrong start of finish node");
            }
            LinkedList<int> visited = new LinkedList<int>();
            stack.Push(startI);
            visited.InsertFirst(startI);
            for (; ; )
            {
                List<int> neighbours = matrix.GetNeighbours(stack.Peek());
                bool end = true;
                foreach (int i in neighbours)
                {
                    if (!visited.Exist(i))
                    {
                        stack.Push(i);
                        visited.InsertFirst(i);
                        end = false;
                        break;
                    }
                }
                if (end)
                {
                    stack.Pop();
                }
                if (stack.Peek() == finishI)
                {
                    while (!stack.StackEmpty())
                    {
                        System.Console.WriteLine(vertexList[stack.Pop()].Data);
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// Breagth search
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        public void BreadthSearch(typename start, typename finish)
        {
            int startI = Find(start);
            int finishI = Find(finish);

            LinkedList<int> visited = new LinkedList<int>();
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> pre = new Dictionary<int, int>();

            if (startI == -1 || finishI == -1)
            {
                System.Console.WriteLine("Wrong start of finish node");
                return;
            }

            queue.Push(startI);
            visited.InsertFirst(startI);
            pre[startI] = startI;

            while (!queue.QueueEmpty())
            {
                int current = queue.Pop();
                foreach (int i in matrix.GetNeighbours(current))
                {
                    if (!visited.Exist(i))
                    {
                        visited.InsertFirst(i);
                        queue.Push(i);
                        pre[i] = current;
                    }
                }
                if (current == finishI)
                {
                    PrintPath(finishI, pre);
                    break;
                }
            }
        }

        /// <summary>
        /// Prints shortest path
        /// </summary>
        /// <param name="f"></param>
        /// <param name="predecessor"></param>
        private void PrintPath(int f, Dictionary<int, int> predecessor)
        {
            if (predecessor[f] != f)
            {
                PrintPath(predecessor[f], predecessor);
            }
            System.Console.WriteLine(vertexList[f].Data);
        }
    }
}
