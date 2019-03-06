using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LinkedList<typename> where typename : IComparable
    {
        // fields, refer to first item of the list
        private Link<typename> first;

        public LinkedList()
        {
            this.first = null;
        }

        // check if empty
        public bool IsEmpty()
        {
            return (this.first == null);
        }

        // insert first
        public void InsertFirst(typename value)
        {
            this.first = new Link<typename>(value)
            {
                Next = this.first
            };
        }

        // delete first
        public void DeleteFirst()
        {
            if (!this.IsEmpty())
            {
                this.first = this.first.Next;
            }
            else
            {
                System.Console.WriteLine("List is already empty!");
                throw new InvalidOperationException("List empty");
            }
        }

        // Removes a node with a value
        public bool RemoveNode(typename value)
        {
            Link<typename> current = this.first;
            Link<typename> previous = this.first;

            while (!current.Data.Equals(value))
            {
                if (current.Next == null)
                {
                    return false;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
            if (current.Equals(first))
            {
                DeleteFirst();
                return true;
            }
            else
            {
                previous = current.Next;
                return true;
            }
        }

        // Returns node
        public Link<typename> Find(typename value)
        {
            Link<typename> current = this.first;

            while (!current.Data.Equals(value))
            {
                if (current.Next == null)
                {
                    return null;
                }
                else
                {
                    current = current.Next;
                }
            }
            return current;
        }
        public bool Exist(typename value)
        {
            Link<typename> current = this.first;

            while (!current.Data.Equals(value))
            {
                if (current.Next == null)
                {
                    return false;
                }
                else
                {
                    current = current.Next;
                }
            }
            return true;
        }
        public Link<typename> GetFirst()
        {
            return this.first;
        }
    }
}
