using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment_3_1
{
    public class LinkedListTest
    {
        private SingleLinkedList sll;

        [SetUp]
        public void Setup()
        {
            sll = new SingleLinkedList();
        }
        [TearDown]
        public void TearDown()
        {
            sll.Clear();
        }
        [Test]
        public void EmptyListTest()
        {
            Assert.True(sll.IsEmpty());
        }

        [Test]
        public void PrependTest()
        {
            sll.Prepend("First!");
            Assert.That(sll.Retrieve(0), Is.EqualTo("First!"));
        }

        [Test]
        public void AppendTest()
        {
            sll.Append("First!");
            sll.Append("Last!");
            Assert.That(sll.Retrieve(1), Is.EqualTo("Last!"));
        }

        [Test]
        public void InsertTest()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Append("Candy!");
            sll.Append("Pears!");
            sll.Insert("Apples!", 3);
            sll.Insert("Bananas!", 0);
            Assert.That(sll.Retrieve(3), Is.EqualTo("Candy!"));
        }

        [Test]
        public void ReplaceTest()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Append("Candy!");
            sll.Append("Pears!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            Assert.That(sll.Retrieve(1), Is.EqualTo("Replaced!"));
        }

        [Test]
        public void DeleteTest()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Append("Candy!");
            sll.Append("Pears!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            sll.Delete(2);
            Assert.That(sll.Retrieve(2), Is.EqualTo("Candy!"));
        }

        [Test]
        public void RetrieveTest()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Append("Candy!");
            sll.Append("Pears!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            Assert.That(sll.Retrieve(0), Is.EqualTo("First!"));
        }

        [Test]
        public void ArrayTest()
        {
            Object[] expectedArray = new Object[3];
            expectedArray[0] = "First!";
            expectedArray[1] = "Replaced!";
            expectedArray[2] = "Last!";

            sll.Append("First!");
            sll.Append("Last!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            Assert.That(sll.GetArray(), Is.EqualTo(expectedArray));
        }
    }
}
