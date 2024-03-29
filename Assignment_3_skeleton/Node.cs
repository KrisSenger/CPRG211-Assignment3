using System;
using System.Runtime.Serialization;

namespace Assignment_3_skeleton
{
    [Serializable]
    [DataContract]
    public class Node
    {
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public Node Next { get; set; }

        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }
}
