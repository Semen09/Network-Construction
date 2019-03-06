using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Represen tree node
    /// </summary>
    /// <typeparam name="typename"></typeparam>
    class TreeNode
    {
        public int ID
        {
            get; set;
        }
        public bool IsRight
        {
            get;set;
        }
        public int Data
        {
            get; set;
        }

        public TreeNode ParentNode
        {
            get;set;
        }

        public TreeNode LeftChild
        {
            get; set;
        }
        public TreeNode RightChild
        {
            get; set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public TreeNode(int value, bool isRight)
        {
            Data = value;
            this.IsRight = isRight;
        }

        public TreeNode(bool isRight, int id)
        {
            Data = 1;
            this.IsRight = isRight;
            this.ID = id;
        }
    }
}
