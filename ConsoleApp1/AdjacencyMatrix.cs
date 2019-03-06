using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AdjacencyMatrix
    {
        // Guaranteed square matrix
        private bool[,] matrix;
        private int vertexCounter = 0;

        public int VertexCounter
        {
            get { return this.vertexCounter; }
        }

        public AdjacencyMatrix()
        {
            matrix = new bool[4, 4];
        }

        public bool this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        // Adding a new vertex
        public void Add()
        {
            if (vertexCounter < matrix.GetLength(0))
            {
                vertexCounter++;
            }
            else
            {
                bool[,] temp = new bool[vertexCounter * 2, vertexCounter * 2];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        temp[i, k] = matrix[i, k];
                    }
                }
                vertexCounter++;
                matrix = temp;
            }
        }
        /// <summary>
        /// Removes at index
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index < vertexCounter)
            {
                for (int i = index + 1; i < matrix.GetLength(0); i++)
                {
                    for (int k = index + 1; k < matrix.GetLength(1); k++)
                    {
                        matrix[i - 1, k - 1] = matrix[i, k];
                    }
                }
                vertexCounter--;
            }
            else
            {
                System.Console.WriteLine("Invalid index to remove");
            }
        }
        /// <summary>
        /// Returns list of neighbour`s indexes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<int> GetNeighbours(int index)
        {
            List<int> neighbours = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[index, i])
                {
                    neighbours.Add(i);
                }
            }
            return neighbours;
        }

        /// <summary>
        /// Makes vertices be neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetNeighbours(int x, int y)
        {
            matrix[x, y] = matrix[y, x] = true;
        }

        /// <summary>
        /// x,y no longer neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void BreakNeighbourhood(int x, int y)
        {
            matrix[x, y] = matrix[y, x] = false;
        }

        /// <summary>
        /// Displays all the bonds
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < vertexCounter; i++)
            {
                for (int k = 0; k < vertexCounter; k++)
                {
                    if (matrix[i, k])
                    {
                        System.Console.Write(matrix[i, k].ToString() + ' ');
                    }
                    else
                    {
                        System.Console.Write(matrix[i, k].ToString());
                    }
                    System.Console.Write(' ');
                }
                System.Console.Write('\n');
            }
        }
    }
}
