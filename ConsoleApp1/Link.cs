using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // an item of list actually
    class Link<typename>
    {

        // data property
        public typename Data { get; set; }
        // next link property
        public Link<typename> Next { get; set; }

        // constructor
        public Link(typename value)
        {
            this.Data = value;
        }
    }
}
