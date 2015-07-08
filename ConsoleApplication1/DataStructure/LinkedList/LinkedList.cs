using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DataStructure.LinkedList
{
    class LinkedList
    {
    }



    public class Node
    {
        public Node(int value, Node node)
        {
            Value = value;
            Next = node;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    public class NodeClient
    {
        public void PrepareData()
        {
            Node third = new Node(7,null);
            Node second = new Node(6,third);
            Node first = new Node(5,second);

            Print(first);

        }
        public void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }



        public void Process()
        {
            PrepareData();
            //
            // Create a new linked list object instance.
            //
            LinkedList<string> linked = new LinkedList<string>();
            //
            // Use AddLast method to add elements at the end.
            // Use AddFirst method to add element at the start.
            //
            linked.AddLast("cat");
            linked.AddLast("dog");
            linked.AddLast("man");
            linked.AddFirst("first");
            
            //
            // Loop through the linked list with the foreach-loop.
            //
            foreach (var item in linked)
            {
                Console.WriteLine(item);
            }
        }

    }
}
