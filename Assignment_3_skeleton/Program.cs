using System;

namespace Assignment_3_skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList linkedList = new SingleLinkedList();

            linkedList.Prepend("Clifford");
            linkedList.Prepend("Odie");
            linkedList.Prepend("Toto");

            Console.WriteLine($"Initial list: ");
            linkedList.Display();

            Console.WriteLine($"\nIs the list empty? : {linkedList.IsEmpty()}");

            Console.WriteLine("\nClear List");
            linkedList.Clear();

            Console.WriteLine($"\nIs the list empty? : {linkedList.IsEmpty()}");

            linkedList.Append("Clifford");
            linkedList.Append("Odie");
            linkedList.Append("Toto");

            Console.WriteLine("\nAppend items to list: ");
            linkedList.Display();

            Console.WriteLine("\nPrepend item to list: ");
            linkedList.Prepend("Benji");
            linkedList.Display();

            Console.WriteLine("\nInsert item into list at Index[2]: ");
            linkedList.Insert("Lassie", 2);
            linkedList.Display();

            Console.WriteLine("\nReplace an item at Index[3]: ");
            linkedList.Replace("Rin Tin Tin", 3);
            linkedList.Display();

            Console.WriteLine($"\nSize of current list: {linkedList.Size()} items");

            Console.WriteLine("\nDelete an item at Index[3]: ");
            linkedList.Delete(3);
            linkedList.Display();

            Console.WriteLine("\nGet an item at Index[2]: ");
            Console.WriteLine(linkedList.Retrieve(2) + "\n");

            linkedList.IndexOf("Clifford");

            Console.WriteLine($"\nCheck list for item: Toto\nItem exists: {linkedList.Contains("Toto")}");
            Console.WriteLine($"\nCheck list for item: Rin Tin Tin \nItem exists: {linkedList.Contains("Rin Tin Tin")}\n");
            linkedList.Display();



            Console.ReadKey();

        }
    }
}
