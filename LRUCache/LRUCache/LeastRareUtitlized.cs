namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Insert(TKey key, TValue value);
    }
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
    //MAKE OWN LINKEDLIST AND Insert

    internal class LeastRareUtitlized<Key, TValue> : ICache<Key, TValue>
    {
        private Dictionary<Key, Node<Key, TValue>> TheSet;
        private LinkedList<Node<Key, TValue>> L;

        public LeastRareUtitlized()
        {
            TheSet = new Dictionary<Key, Node<Key, TValue>>();
            L = new LinkedList<Node<Key, TValue>>();
        }

        public bool TryGetValue(Key key, out TValue value)
        {

        }
        public void Insert(Key key, TValue value)
        {
            Node<Key, TValue> node = new Node<Key, TValue>(key, value, null, null);
            TheSet.Add(key, node);
            
        }
    }
}
