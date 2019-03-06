using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Neuron<typename>
    {
        public typename Data
        {
            get; set;
        }

        public Neuron(typename value)
        {
            Data = value;
        }
    }
}
