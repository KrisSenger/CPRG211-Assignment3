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
        private SingleLinkedList users;
        private readonly string testFileName = @"..\..\test_users.bin";

        [SetUp]
        public void Setup()
        {
            users = new SingleLinkedList();
            users.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
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

            int userCount = users.Size();
            int deserializedUserCount = deserializedUsers.Size();
            Assert.That(userCount, Is.EqualTo(deserializedUserCount));

            for (int i = 0; i < userCount; i++)
            {
                Assert.That(users.Retrieve(i).ToString(), Is.EqualTo(deserializedUsers.Retrieve(i).ToString()));
                Assert.AreEqual(users.GetUserInfo(i).Id, deserializedUsers.GetUserInfo(i).Id);
                Assert.AreEqual(users.GetUserInfo(i).Name, deserializedUsers.GetUserInfo(i).Name);
                Assert.AreEqual(users.GetUserInfo(i).Email, deserializedUsers.GetUserInfo(i).Email);
                Assert.AreEqual(users.GetUserInfo(i).Password, deserializedUsers.GetUserInfo(i).Password);
            }
        }

    }
}
