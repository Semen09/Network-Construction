using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // stack realisation
    class Stack<typename>// where typename:IComparable
    {
        // fields
        private int maxSize;
        private typename[] stackArray;
        private int topIndex;
        // constructor
        public Stack(int size)
        {
            this.topIndex = -1;
            this.maxSize = size;
            this.stackArray = new typename[size];
        }
        public Stack()
        {
            this.topIndex = -1;
            this.maxSize = 4;
            this.stackArray = new typename[4];
        }
        // push
        public void Push(typename value)
        {
            if (!StackFull())
            {
                this.stackArray[++topIndex] = value;
            }
            else
            {
                ExpandArraySize(2);
                this.stackArray[++topIndex] = value;
            }
        }
        // pop
        public typename Pop()
        {
            if (!this.StackEmpty())
            {
                return this.stackArray[topIndex--];
            }
            else
            {
                System.Console.WriteLine("Stack is already empty!");
                throw new InvalidOperationException("The stack is empty");
            }
        }
        // peek
        public typename Peek()
        {
            if (!this.StackEmpty())
            {
                return this.stackArray[topIndex];
            }
            else
            {
                System.Console.WriteLine("Stack is already empty!");
                throw new InvalidOperationException("The stack is empty");
            }
        }

        // expands size of array
        public void ExpandArraySize(int multiplier)
        {
            typename[] newArray = new typename[this.stackArray.Length * multiplier];
            int tempCounter = 0;
            foreach (typename value in stackArray)
            {
                newArray[tempCounter] = value;
                tempCounter++;
            }
            stackArray = newArray;
            maxSize *= multiplier;
        }
        /// <summary>
        /// Checks if stack has a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsInside(typename value)
        {
            foreach (typename t in stackArray)
            {
                if (t.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        // check if stack is full
        public bool StackFull()
        {
            return (topIndex + 1 >= maxSize);
        }

        // check if stack is empty
        public bool StackEmpty()
        {
            return (topIndex < 0);
        }

        // Displays Stack
        public void Display()
        {
            for (int i = 0; i <= topIndex; i++)
            {
                System.Console.WriteLine(this.stackArray[i]);
            }
        }
    }
}
