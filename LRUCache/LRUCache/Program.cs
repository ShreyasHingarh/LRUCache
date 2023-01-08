namespace LRUCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LeastRareUtitlized<int, string> LRU = new LeastRareUtitlized<int, string>(5);
            LRU.Insert(1, "a");
            LRU.Insert(2, "b");
            LRU.Insert(3, "c");
            LRU.Insert(4, "d");
            LRU.Insert(5, "e");
            LRU.Insert(6, "f");
            string value = null;
            LRU.TryGetValue(2, out value);
            LRU.Remove(3);
            ;
        }
    }
}