using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfProps = 5;
            Tree tree = new Tree();
            VectorGenerator vg = new VectorGenerator();
            NeuronGraph<int> neurons = new NeuronGraph<int>();

            /****************
             * Very important, below we are instantiating neurons as input level and
             * their indexes are equal to the indexes of features they presenting
             *****************/
             for(int i = 0; i < numberOfProps; i++)
            {
                neurons.AddVertex(neurons.Matrix.VertexCounter);
            }


            float[] weights = new float[numberOfProps];
            // Initializing
            for(int i = 0; i < weights.Length; i++)
            {
                weights[i] = 0.1f;
            }

            for(int i = 0; i < 100; i++)
            {
                List<bool> input = vg.CreateVector(numberOfProps);
                float[] tempWeights = weights;
                for(int k = 0; k < weights.Length; k++)
                {
                    tempWeights[k] = Func(input, weights, k);
                }
                weights = tempWeights;
            }
            foreach(float f in weights)
            {
                Console.WriteLine(f);
            }


            // Simple loop of vectors input
            /*List<bool> t;
            for (int i = 0; i < 0; i++)
            {
                // Vectror processing by tree
                tree.Add(vg.CreateVector(numberOfProps));
                // Checks for activated vertices
                t = tree.CheckOver(tree.Root);
                // Then creating a new Neuron if activated
                if (t != null)
                {
                    Console.WriteLine("Start");
                    foreach (bool k in t)
                    {
                        Console.WriteLine(Convert.ToInt32(k));
                    }
                    Console.WriteLine("End");
                    int currentIndex = neurons.Matrix.VertexCounter;
                    neurons.AddVertex(currentIndex);
                    // Inherits from features
                    for(int counter = 0; counter < t.Count; counter++)
                    {
                        neurons.MakeNeighbours(currentIndex, counter);
                    }
                }
            }
            //neurons.Matrix.Display();
            bool[,] ttmm = some();
            for (int i = 0; i < 28; i++)
            {
                List<bool> tmp = new List<bool>();
                for(int k = 0; k<8; k++)
                {
                    tmp.Add(ttmm[k, i]);
                }
                // Vectroe processing by tree
                tree.Add(tmp);
                // Checks for activated vertices
                t = tree.CheckOver(tree.Root);
                // Then creating a new Neuron if activated
                if (t != null)
                {
                    Console.WriteLine("Start");
                    foreach (bool k in t)
                    {
                        Console.WriteLine(Convert.ToInt32(k));
                    }
                    Console.WriteLine("End");
                    int currentIndex = neurons.Matrix.VertexCounter;
                    neurons.AddVertex(currentIndex);
                    // Inherits from features
                    for (int counter = 0; counter < t.Count; counter++)
                    {
                        neurons.MakeNeighbours(currentIndex, counter);
                    }
                }
            }*/


        }

        /// <summary>
        /// Creating a equialent matrix
        /// </summary>
        /// <returns></returns>
        public static bool[,] some()
        {
            bool[,] temp = new bool[8, 8];
            VectorGenerator vg = new VectorGenerator();

            for (int i = 0; i < 8; i++)
            {
                int c = 0;
                foreach (bool k in vg.CreateVector(4))
                {
                    temp[c, i] = k;
                    c++;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                // columns
                for (int k = 0; k < 8; k++)
                {
                    Console.Write(Convert.ToInt32(temp[i, k]).ToString() + " ");
                }
                Console.Write('\n');
            }
            bool[,] ttm = new bool[8, 28];
            int ctr = 0;
            for (int i = 0; i < 8; i++)
            {
                // columns
                for (int k = 0; k < 8; k++)
                {
                    for (int y = k + 1; y < 8; y++)
                    {
                        ttm[i, ctr] = temp[i, k] == temp[i, y];
                        ctr++;
                    }
                }
                ctr = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 28; k++)
                {
                    Console.Write(Convert.ToInt32(ttm[i, k]).ToString() + " ");
                }
                Console.Write('\n');
            }
            return ttm;
        }

        public static float Sum(float[] vector)
        {
            float sum = 0;
            foreach(float f in vector)
            {
                sum += f;
            }
            return sum;
        }
        /// <summary>
        /// Calculates new weight
        /// </summary>
        /// <param name="input"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static float Func(List<bool> input, float[] weights, int index)
        {
            float constant = 1f / (weights.Length) * 0f;
            float first = Convert.ToInt32(input[index]) * (1 - Sum(weights)) + constant * weights[index] * (Convert.ToInt32(input[index]) - 1);
            float[] temp = new float[weights.Length];
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = Convert.ToInt32(input[i]) * weights[i];
            }
            float second = Sum(temp);
            return second * first;
        }
    }
}
