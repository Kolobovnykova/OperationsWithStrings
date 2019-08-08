using System;
using System.Collections.Generic;

namespace OperationsWithStrings
{
    public class LinkedListsTasks
    {
        // Singly linked list
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }

        public class MyLinkedList
        {
            public MyLinkedList(params int[] nodes)
            {
                HeadNode = new Node(nodes[0]);
                for (int i = 1; i < nodes.Length; i++)
                {
                    AppendToTail(nodes[i]);
                }
            }

            public Node HeadNode { get; set; }

            public void AppendToTail(int data)
            {
                var newEnd = new Node(data);
                Node node = HeadNode;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newEnd;
            }

            public Node DeleteNode(int data)
            {
                var node = HeadNode;

                if (node.Data == data)
                {
                    return HeadNode.Next;
                }

                while (node.Next != null)
                {
                    if (node.Next.Data == data)
                    {
                        node.Next = node.Next.Next;
                        return HeadNode;
                    }

                    node = node.Next;
                }

                return HeadNode;
            }

            public void Print()
            {
                Console.WriteLine("Linked List:");
                Node node = HeadNode;

                while (node != null)
                {
                    Console.Write(node.Data + " -> ");
                    node = node.Next;
                }
            }
        }

        // 2.1 Remove Duplicates: Write code to remove duplicates from an unsorted linked list.
        public static void RemoveDuplicates(MyLinkedList list)
        {
            Node node = list.HeadNode;
            // O(n) With auxiliary space O(n)
            HashSet<int> hashSet = new HashSet<int> { node.Data };

            while (node.Next != null)
            {
                if (hashSet.Contains(node.Next.Data))
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    hashSet.Add(node.Next.Data);
                    node = node.Next;
                }
            }
        }
    }
}
