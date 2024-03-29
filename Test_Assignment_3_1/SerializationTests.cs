using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment_3
{
    public class SerializationTests
    {
        public SingleLinkedList users = new SingleLinkedList();
        
        private readonly string testFileName = @"..\..\test_users.bin";

        [SetUp]
        public void Setup()
        {
            users.Append((new User(1, "Joe Blow", "jblow@gmail.com", "password")));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            users.Clear();
        }

        //Tests the object was serialized.
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            SingleLinkedList deserializedUsers = (SingleLinkedList)SerializationHelper.DeserializeUsers(testFileName);
            Assert.That(deserializedUsers.Size(), Is.EqualTo(users.Size()));
            //Assert.That(deserializedUsers.Size(), Is.EqualTo(users.Size()));
            //for (int i = 0; i < users.Size(); i++)
            //{
            //    Assert.That(deserializedUsers.Retrieve(i), Is.EqualTo(users.Retrieve(i)));
            //    Assert.AreEqual(users.Retrieve(i).Name, deserializedUsers.Retrieve(i).Name);
            //    Assert.AreEqual(users.Retrieve(i).Email, deserializedUsers.Retrieve(i).Email);
            //    Assert.AreEqual(users[i].Password, deserializedUsers[i].Password);
            //}
        }

    }
}
