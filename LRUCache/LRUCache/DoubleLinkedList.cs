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

        public void AddLast(Node<TKey, TValue> nodeToAdd)
        {
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

        public void AddFirst(Node<TKey, TValue> nodeToAdd)
        {
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

        public void AddBefore(Node<TKey, TValue> node, Node<TKey, TValue> nodeToAdd)
        {
            if (node == Head)
            {
                AddFirst(nodeToAdd);
                return;
            }

            node.Previous.Next = nodeToAdd;
            node.Previous = nodeToAdd;
            Count++;
        }
        public void AddAfter(Node<TKey, TValue> node, Node<TKey, TValue> nodeToAdd)
        {
            if (node == Tail)
            {
                AddLast(nodeToAdd);
                return;
            }
            node.Next.Previous = nodeToAdd;
            node.Next = nodeToAdd;
            Count++;

        }
        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
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
            return true;
        }

        public bool RemoveLast()
        {
            if (Tail == null)
            {
                return false;
            }
            if (Count == 1)
            {
                Tail = null;
                Head = null;
                Count--;
                return true;
            }

            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
            return true;
        }
        public bool Remove(Node<TKey, TValue> nodeToAdd)
        {
            if (Head == null || Tail == null || Count == 0)
            {
                return false;
            }
            if (Head.Key.Equals(nodeToAdd.Key) && Head.Value.Equals(nodeToAdd.Value))
            {
                return RemoveFirst();
            }
            if(Tail.Key.Equals(nodeToAdd.Key) && Tail.Value.Equals(nodeToAdd.Value))
            {
                return RemoveLast();
            }
            if (Search(nodeToAdd.Key) == null) return false;
            var previous = nodeToAdd.Previous;
            previous.Next = nodeToAdd.Next;
            nodeToAdd.Next.Previous = previous;
            
            Count--;
            return true;
        }

        public Node<TKey,TValue> Search(TKey key)
        {
            // loop through nodes, find value return
            var Node = Head;
            while (Node != null && !Node.Key.Equals(key))
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

        public bool Contains(TKey key)
        {
            return Search(key) == null;
        }
        public void MoveToHead(Node<TKey,TValue> node)
        {
            if (Head == node) return;
            if(Tail == node)
            {
                Tail = node.Previous;
                
            }
            if(node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            if(node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            node.Previous = null;
            node.Next = Head;
            Head.Previous = node;
            Head = node;
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
