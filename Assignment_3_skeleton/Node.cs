using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
