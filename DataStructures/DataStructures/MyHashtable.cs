using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures 
{
    class MyHashtable<K,V> where K : IComparable
    {
        private const int defaultSize = 200;
        private V[] _values;
        private K[] _keys;

        private Hashtable _table;
        private Dictionary<string, string> _dict;

        public MyHashtable()
        {
            _values = new V[defaultSize];
            _keys = new K[defaultSize];
        }

        public void Add(K key, V value)
        {
            int hash = Hash(key);
            int insertLoc = hash;
            if (_values[insertLoc] != null)
            {
                insertLoc++;
                while (_values[insertLoc] != null && insertLoc != hash)
                {
                    insertLoc++;
                    insertLoc = insertLoc % defaultSize;
                }

                if (insertLoc != hash)
                {
                    _values[insertLoc] = value;
                    _keys[insertLoc] = key;
                }
                else
                {
                    throw new InvalidOperationException("hashtable too small");
                }
            }
            else
            {
                _values[insertLoc] = value;
                _keys[insertLoc] = key;
            }

        }

        private int FindKeyLocation(K key, int startPos)
        {
            int insertLoc = startPos;
            while (_values[insertLoc] != null && insertLoc != startPos)
            {
                insertLoc++;
                insertLoc = insertLoc % defaultSize;
            }
            return insertLoc;
        }
        
        public int Hash(K key)
        {
            if (key is string)
            {
                char[] chs = key.ToString().ToCharArray();
                int hash = 0;
                foreach(char ch in chs)
                {
                    hash += ch;
                }
                return hash % defaultSize;
            }
            return -1;
        }

        public void Remove()
        {
        }
        
        public bool ContainsKey(K key)
        {
            int hash = Hash(key);
            int insertLoc = hash;
            if(_keys[insertLoc].CompareTo(key) == 0)
                return true;
            insertLoc++;
            while (_keys[insertLoc].CompareTo(key) != 0 && insertLoc != hash)
            {
                insertLoc++;
                insertLoc = insertLoc % defaultSize;
            }
            return (_keys[insertLoc].CompareTo(key) == 0);
        }

        public bool ContainsValue(V value)
        {
            return false;
        }

        public V this[K key]
        {
            get
            {
                int hash = Hash(key);
                int insertLoc = hash;
                if (_keys[insertLoc].CompareTo(key) == 0)
                    return _values[insertLoc];
                insertLoc++;
                while (_keys[insertLoc].CompareTo(key) != 0 && insertLoc != hash)
                {
                    insertLoc++;
                    insertLoc = insertLoc % defaultSize;
                }
                return _values[insertLoc];
            }
        }
    }
}
