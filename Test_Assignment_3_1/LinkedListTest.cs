using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment_3_1
{
    internal class LinkedListTest
    {
        private SingleLinkedList sll;

        [SetUp]
        public void SetUp()
        {
            sll = new SingleLinkedList();
        }

        [TearDown] public void TearDown()
        {
            sll.Clear();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.True(sll.IsEmpty());
        }

        [Test]
        public void TestPrepend()
        {
            sll.Prepend("First!");
            Assert.That(sll.Retrieve(0), Is.EqualTo("First!"));
        }

        [Test]
        public void TestAppend()
        {
            sll.Append("First!");
            sll.Append("Last!");
            Assert.That(sll.Retrieve(1), Is.EqualTo("Last!"));
        }

        [Test]
        public void TestInsert()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Insert("Middle!", 1);
            sll.Insert("Middle1!", 1);
            Assert.That(sll.Retrieve(1), Is.EqualTo("Middle1!"));
        }

        [Test]
        public void TestReplace()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            Assert.That(sll.Retrieve(1), Is.EqualTo("Replaced!"));
        }

        [Test]
        public void TestDelete()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            sll.Delete(1);
            Assert.That(sll.Retrieve(1), Is.EqualTo("Last!"));
        }

        [Test]
        public void TestRetrieve()
        {
            sll.Append("First!");
            sll.Append("Last!");
            sll.Insert("ReplaceMe!", 1);
            sll.Replace("Replaced!", 1);
            sll.Delete(1);
            Assert.That(sll.Retrieve(0), Is.EqualTo("First!"));
        }

        [Test]
        public void TestGetArray()
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
