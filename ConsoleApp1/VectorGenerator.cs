using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class VectorGenerator
    {
        Random rand = new Random();
        public List<bool> CreateVector(int size)
        {
            List<bool> temp = new List<bool>();
            for(int i = 0; i < size; i++)
            {
                if(i == 2)
                {
                    temp.Add(rand.Next(100) <= 90);
                }
                else if (i == 3)
                {
                    temp.Add(rand.Next(100) <= 90);
                }
                else if (i == 7)
                {
                    temp.Add(rand.Next(100) <= 90);
                }
                else if (i == 9)
                {
                    temp.Add(rand.Next(100) <= 10);
                }
                else
                {
                    temp.Add(rand.Next(100) <= 10);
                }
            }
            return temp;
        }
    }
}
