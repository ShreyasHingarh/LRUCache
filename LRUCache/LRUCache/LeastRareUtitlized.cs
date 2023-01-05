namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Insert(TKey key, TValue value);
    }
    
    //MAKE OWN LINKEDLIST AND Insert

    internal class LeastRareUtitlized<Key, TValue> : ICache<Key, TValue>
    {
        private Dictionary<Key, Node<Key, TValue>> TheSet;
        private DoubleLinkedList<Key,TValue> LinkedList;
        public LeastRareUtitlized()
        {
            TheSet = new Dictionary<Key, Node<Key, TValue>>();
            LinkedList = new DoubleLinkedList<Key, TValue>();
        }

        public bool TryGetValue(Key key, out TValue value)
        {

        }

        public void Set()
        {

        }
        public void Modifiy()
        {

        }
        public void Remove()
        {

        }

        public void Insert(Key key, TValue value)
        {
            Node<Key, TValue> node = new Node<Key, TValue>(key, value, null, null);
            TheSet.Add(key, node);
            
        }
    }
}
