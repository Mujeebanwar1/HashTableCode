using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hashtable
{
    internal class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValuePair<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
               
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int positoin = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedlist = GetLinkedList(positoin);
            bool itemFound = false;
            KeyValuePair<K, V> founditem = default(KeyValuePair<K, V>);
            foreach (KeyValuePair<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    founditem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(founditem);
            }

        }
        protected LinkedList<KeyValuePair<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<K, V>> linkedlist = items[position];

            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValuePair<K, V>>();
                items[position] = linkedlist;

            }
            return linkedlist;
        }

    }
    public struct keyvalue<K, V>
    {
        public K key { get; set; }
        public V value { get; set; }
    }
}
