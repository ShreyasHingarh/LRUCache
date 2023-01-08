namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        bool Insert(TKey key, TValue value);
    }
    
    //MAKE OWN LINKEDLIST AND Insert

    internal class LeastRareUtitlized<TKey, TValue> : ICache<TKey, TValue>
    {
        public Dictionary<TKey, Node<TKey, TValue>> TheSet;
        public DoubleLinkedList<TKey, TValue> LinkedList;
        int Cap;
        public LeastRareUtitlized(int cap)
        {
            Cap = cap;
            TheSet = new Dictionary<TKey, Node<TKey, TValue>>();
            LinkedList = new DoubleLinkedList<TKey, TValue>();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            if (!TheSet.ContainsKey(key)) return false;
            Node<TKey,TValue> node = TheSet[key];
            if (node == null) return false;
            
            value = node.Value;
            LinkedList.MoveToHead(node);
            return true;
        }

        
        public bool SetValue(TKey key, TValue newValue)
        {
            if (TheSet.ContainsKey(key)) return false;
            TheSet[key].Value = newValue;
            LinkedList.MoveToHead(TheSet[key]);
            return true;
        }
        public bool Remove(TKey key)
        {
            if (!LinkedList.Remove(TheSet[key])) return false;
            TheSet.Remove(key);
            return true;
        }

        public bool Insert(TKey key, TValue value)
        {
            if (TheSet.ContainsKey(key)) return false;
            Node<TKey, TValue> node = new Node<TKey, TValue>(key, value, null, null);
            TheSet.Add(key, node);
            LinkedList.AddFirst(node);
            if(LinkedList.Count == Cap + 1) 
            {
                TheSet.Remove(LinkedList.Tail.Key);
                LinkedList.RemoveLast();
            }
            return true;
        }

    }
}
