using Assignment_3_skeleton;

namespace Test_Assignment_3
{
    public class SerializationTests
    {
        private SingleLinkedList users;
        private SingleLinkedList usersReversed;
        private readonly string testFileName = @"..\..\test_users.bin";

        [SetUp]
        public void Setup()
        {
            users = new SingleLinkedList();
            users.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            // set up hardcoded reversed SLL for reverse() test
            usersReversed = new SingleLinkedList();
            usersReversed.Prepend(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            usersReversed.Prepend(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            usersReversed.Prepend(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            usersReversed.Prepend(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
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
                Assert.That(users.GetUserInfo(i).Id, Is.EqualTo(deserializedUsers.GetUserInfo(i).Id));
                Assert.That(users.GetUserInfo(i).Name, Is.EqualTo(deserializedUsers.GetUserInfo(i).Name));
                Assert.That(users.GetUserInfo(i).Email, Is.EqualTo(deserializedUsers.GetUserInfo(i).Email));
                Assert.That(users.GetUserInfo(i).Password, Is.EqualTo(deserializedUsers.GetUserInfo(i).Password));
            }
        }

        [Test]
        public void TestReverse()
        {
            // reverses original users SLL to match the hardcoded usersReversed SLL
            users.Reverse();

            Assert.That(users.GetUserInfo(0).Id, Is.EqualTo(usersReversed.GetUserInfo(0).Id));
            Assert.That(users.GetUserInfo(1).Id, Is.EqualTo(usersReversed.GetUserInfo(1).Id));
            Assert.That(users.GetUserInfo(2).Id, Is.EqualTo(usersReversed.GetUserInfo(2).Id));
            Assert.That(users.GetUserInfo(3).Id, Is.EqualTo(usersReversed.GetUserInfo(3).Id));
        }

    }
}
