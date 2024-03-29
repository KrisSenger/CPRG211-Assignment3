using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    [KnownType(typeof(SingleLinkedList))]
    [KnownType(typeof(Node))]
    [KnownType(typeof(User))]
    [Serializable]
    [DataContract]
    public class SingleLinkedList : ILinkedListADT
    {
        [DataMember]
        private Node head;
        [DataMember]
        private int listSize;

        public SingleLinkedList()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            head = null;
            listSize = 0;
        }

        public void Append(Object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                listSize++;
                return;
            }

            Node currentNode = head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            listSize++;
        }

        public void Prepend(Object data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            listSize++;
        }

        public void Insert(Object data, int index)
        {
            if (head == null)
            {
                throw new ArgumentNullException("List is empty. Index location does not exist");
            }
            else if (index > listSize -1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index location is invalid");
            }

            Node newNode = new Node(data);
            Node currentNode = head;

            for (int i = 0; i < index-1; i++)
            {
                currentNode = currentNode.Next;
            }

            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
            listSize++;
        }

        public void Replace(Object data, int index)
        {
            if (head == null)
            {
                throw new ArgumentNullException("List is empty. Index location does not exist");
            }
            else if (index > listSize - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index location is invalid");
            }

            Node newNode = new Node(data);
            Node currentNode = head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Data = newNode.Data;
        }

        public int Size()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                return listSize;
            }
        }

        public void Delete(int nodeToDelete)
        {
            if (head == null)
            {
                throw new ArgumentNullException("List is empty. Index location does not exist");
            }

            Node previousNode = null;
            Node currentNode = head;
            int index = 0;
            while (currentNode != null) 
            { 

                if (index == nodeToDelete) 
                { 
                    previousNode.Next = currentNode.Next;
                    listSize--;
                    return;
                }
                index++;
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException("Node with the requested data could not be found");
        }

        public Object Retrieve(int index)
        {
            if (head == null)
            {
                return new ArgumentNullException("List is empty. Index location does not exist");
            }
            else if (index - 1 > listSize || index < 0)
            {
                return new IndexOutOfRangeException("Index location is out of range of the list.");
            }

            Node currentNode = head;

            for ( int i = 0; i < index; i++ ) 
            {
                currentNode = currentNode.Next;
            }

            var value = currentNode.Data;
            return value;
        }

        public int IndexOf(Object data)
        {
            if (head == null)
            {
                new ArgumentNullException("List is empty. Data does not exist");
                return -1;
            }

            int index = 0;
            Node currentNode = head;
            while( currentNode != null ) 
            {
                
                
                if ( currentNode.Data.Equals(data))
                {
                    Console.WriteLine($"Index location of Data: {data} is Index: {index}");
                }
                index++;
                currentNode = currentNode.Next;

            }

            return index;
        }

        public bool Contains(Object data)
        {
            if (head == null)
            {
                new ArgumentNullException("List is empty. Data does not exist");
                return false;
            }

            bool exists = false;
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data == data)
                {
                    exists = true;
                }
                currentNode = currentNode.Next;
            }
            return exists;

        }

        public void Display()
        {
            // Iterate or traverse through the SLL
            Node currentNode = head;
            while (currentNode != null)
            {
                // Perform operations on the current node
                Console.Write(currentNode.Data + "\n");

                // Move to the next node
                currentNode = currentNode.Next;
            }
        }

        public Object[] GetArray()
        {
            Object[] nodeArray = new Object[listSize];
            if (head == null)
            {
                return nodeArray;
            }

            int index = 0;
            Node currentNode = head;
            while (currentNode != null && index < listSize)
            {
                nodeArray[index] = currentNode.Data;
                index++;
                currentNode = currentNode.Next;
            }
            return nodeArray;
        }
    }
}
