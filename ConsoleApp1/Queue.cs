using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Queue<typename> where typename : IComparable
    {
        // fields
        private int maxSize;
        private typename[] queueArray;
        private int front;
        private int rear;
        private int numberOfElements;

        //constructor
        public Queue(int size)
        {
            this.maxSize = size;
            this.queueArray = new typename[size];
            this.front = 0;
            this.rear = -1;
            this.numberOfElements = 0;
        }
        public Queue()
        {
            this.maxSize = 4;
            this.queueArray = new typename[4];
            this.front = 0;
            this.rear = -1;
            this.numberOfElements = 0;
        }

        //push
        public void Push(typename value)
        {
            if (!QueueFull())
            {
                // cycle an queue
                if (this.rear >= maxSize - 1)
                {
                    this.rear = -1;
                }
                this.queueArray[++rear] = value;
                numberOfElements++;
            }
            else
            {
                ExpandArraySize(2);
                if (this.rear >= maxSize - 1)
                {
                    this.rear = -1;
                }
                this.queueArray[++rear] = value;
                numberOfElements++;
            }
        }
        //pop
        public typename Pop()
        {
            if (!QueueEmpty())
            {
                typename temp = this.queueArray[front++];
                if (front == maxSize)
                {
                    front = 0;
                }
                numberOfElements--;
                return temp;
            }
            else
            {
                System.Console.WriteLine("Queue is already empty!");
                throw new InvalidOperationException("The queue is empty");
            }
        }
        // peek
        public typename Peek()
        {
            if (!QueueEmpty())
            {
                return this.queueArray[front];
            }
            else
            {
                System.Console.WriteLine("Queue is already empty!");
                throw new InvalidOperationException("The queue is empty");
            }
        }
        // expands size of array
        public void ExpandArraySize(int multiplier)
        {
            typename[] newArray = new typename[this.queueArray.Length * multiplier];
            int tempCounter = 0;
            foreach (typename value in queueArray)
            {
                newArray[tempCounter] = value;
                tempCounter++;
            }
            queueArray = newArray;
            maxSize *= multiplier;
        }
        //check if the queue is empty
        public bool QueueEmpty()
        {
            return (numberOfElements <= 0);
        }
        //check if the queue is full
        public bool QueueFull()
        {
            return (numberOfElements >= maxSize);
        }
        //display
        public int Size()
        {
            return this.numberOfElements;
        }
    }
}
