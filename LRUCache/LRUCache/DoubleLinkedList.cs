using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class Node<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public Node<TKey, TValue> Previous;
        public Node<TKey, TValue> Next;

        public Node(TKey key, TValue value, Node<TKey, TValue> previous, Node<TKey, TValue> next)
        {
            Key = key;
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
    internal class DoubleLinkedList<TKey, TValue>
{
        public int Count;
        public Node<TKey,TValue> Head;
        public Node<TKey, TValue> Tail;
        public void AddLast(TKey key, TValue value)
        {
            Node<TKey, TValue> nodeToAdd = new Node<TKey, TValue>(key, value,null,null);
            if (Head == null)
            {
                Head = nodeToAdd;
                Tail = Head;
            }
            else
            {
                nodeToAdd.Previous = Tail;
                Tail.Next = nodeToAdd;
                Tail = nodeToAdd;
            }
            Count++;
        }

        public void AddFirst(TKey key, TValue value)
        {
            Node<TKey, TValue> nodeToAdd = new Node<TKey, TValue>(key,value,null,null);
            if (Head == null)
            {
                Head = nodeToAdd;
                Tail = Head;
            }
            else
            {
                Head.Previous = nodeToAdd;
                nodeToAdd.Next = Head;
                Head = nodeToAdd;
            }
            Count++;
        }

        public void AddBefore(Node<TKey, TValue> node, TKey key,TValue value)
        {
            if (node == Head)
            {
                AddFirst(key,value);
                return;
            }

            Node<TKey, TValue> nodeToAdd = new Node<TKey, TValue>(key, value, node.Previous, node);
            node.Previous.Next = nodeToAdd;
            node.Previous = nodeToAdd;
            Count++;
        }
        public void AddAfter(Node<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == Tail)
            {
                AddLast(key,value);
                return;
            }
            Node<TKey, TValue> nodeToAdd = new Node<TKey, TValue>(key,value,node,node.Next);
            node.Next.Previous = nodeToAdd;
            node.Next = nodeToAdd;
            Count++;

        }
        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            Count--;
        }

        public void RemoveLast()
        {
            if (Tail == null)
            {
                return;
            }
            if (Count == 1)
            {
                Tail = null;
                Head = null;
                Count--;
                return;
            }

            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
        }
        public void Remove(TKey key, TValue value)
        {
            if (Head == null || Tail == null || Count == 0)
            {
                return;
            }
            if (Head.Key.Equals(key) && Head.Value.Equals(value))
            {
                RemoveFirst();
                return;
            }
            var node = Search(key, value);
            if (node != null) return;
            var previous = node.Previous;
            previous.Next = node.Next;
            node.Next.Previous = previous;
            node = null;
            Count--;
        }


        public Node<TKey,TValue> Search(TKey key, TValue value)
        {
            // loop through nodes, find value return
            var Node = Head;
            while (Node != null && !Node.Key.Equals(key) && !Node.Value.Equals(value))
            {
                Node = Node.Next;
            }

            return Node;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(TKey key, TValue value)
        {
            return Search(key,value) == null;
        }


        public void Print()
        {
            var temp = Head;

            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
        }
        
    
    }
}
