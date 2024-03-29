using System.IO;
using System.Runtime.Serialization;

namespace Assignment_3_skeleton
{
    public static class SerializationHelper
    {
        public static void SerializeUsers(SingleLinkedList users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SingleLinkedList));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        public static SingleLinkedList DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SingleLinkedList));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SingleLinkedList)serializer.ReadObject(stream);
            }
        }
    }
}
