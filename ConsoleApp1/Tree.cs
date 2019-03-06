using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Represent tree
    /// </summary>
    class Tree
    {
        private TreeNode root;
        private int size = 0;
        private int triggerValue = 4;
        private List<int> alreadyActivated = new List<int>();

        public TreeNode Root
        {
            get { return this.root; }
        }

        public Tree()
        {
            root = new TreeNode(true, -1);
        }

        /// <summary>
        /// Applies a vector to the tree
        /// </summary>
        /// <param name="vector"></param>
        public void Add(List<bool> vector)
        {
            TreeNode current = this.root;
            foreach (bool value in vector)
            {
                if (value)
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = new TreeNode(true, size++);
                        current.RightChild.ParentNode = current;
                    }
                    else
                    {
                        current.RightChild.Data++;
                    }
                    current = current.RightChild;
                }
                else
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = new TreeNode(false, size++);
                        current.LeftChild.ParentNode = current;
                    }
                    else
                    {
                        current.LeftChild.Data++;
                    }
                    current = current.LeftChild;
                }
            }
        }

        /// <summary>
        /// Returns vector way to a node with big value
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public List<bool> CheckOver(TreeNode currentTreeNode)
        {
            List<bool> temp;
            if(currentTreeNode != null)
            {
                if(currentTreeNode.Data >= triggerValue)
                {
                    if (!alreadyActivated.Contains(currentTreeNode.ID))
                    {
                        alreadyActivated.Add(currentTreeNode.ID);
                        return GetWay(currentTreeNode);
                    }
                }
                temp = CheckOver(currentTreeNode.LeftChild);
                if(temp != null)
                {
                    return temp;
                }
                temp = CheckOver(currentTreeNode.RightChild);
                if(temp != null)
                {
                    return temp;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns vector way of a node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<bool> GetWay(TreeNode node)
        {
            List<bool> temp = new List<bool>();
            if (node != null)
            {
                while (node != this.root)
                {
                    temp.Add(node.IsRight);
                    node = node.ParentNode;
                }
            }
            else
            {
                return null;
            }
            return temp;
        }
    }
}
