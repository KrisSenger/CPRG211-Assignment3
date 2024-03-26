using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    public class SingleLinkedList : ILinkedListADT
    {
        private Node head;
        private int listSize;

        public SingleLinkedList()
        {
            head = null;
        }
        
        // Checks if the linked list is empty.
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

        // Clear all items in the linked list.
        public void Clear()
        {
            head = null;
            listSize = 0;
        }

        // Append an item to the end of the linked list.

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

        // Prepend an item to the beginning of the linked list 
        public void Prepend(Object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            
            listSize++;
        }

        // Insert an item at a specific index in the linked list 
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

        // Replace an item in the linked list 

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

        // Get the number of items in the linked list 
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

        // Remove an item at an index in the linked list 
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

        // Get an item at an index in the linked list 
        public Object Retrieve(int index)
        {
            if (head == null)
            {
                return new ArgumentNullException("List is empty. Index location does not exist");
            }
            else if (index -1 > listSize || index < 0) 
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

        // Get the index of an item in the linnked list 
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

        // Check if the linked list has an item 
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

        // Reverse the order of teh nodes in the linked list 
        public void Reverse()
        {
            if (head == null || head.Next == null)
            {
                return; // if it is an empty list or there is only one node, there is no need to reverse
            }

            Node previousNode = null;
            Node currentNode = head;
            Node nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode; 
            }

            head = previousNode; 
        }


        public void Display()
        {
            // Start from the new head (previous tail)
            Node currentNode = head;

            // Traverse the list in the reversed order
            while (currentNode != null)
            {
                // Perform operations on the current node
                Console.WriteLine(currentNode.Data + "\n");

                // Move to the next node (towards the new tail)
                currentNode = currentNode.Next;
            }
        }
    }
}
