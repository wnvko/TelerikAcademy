using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
{
    private const int StartCapacity = 16;
    private const float MaxLoadFactor = 0.75f;
    private float currentLoad;
    private int capacity;
    private int count;
    private LinkedList<KeyValuePair<K, V>>[] theTable;

    public HashTable() : this(StartCapacity) { }

    public HashTable(int capacity) : this(capacity, MaxLoadFactor) { }

    public HashTable(int capacity, float load)
    {
        this.capacity = capacity;

        if (load > MaxLoadFactor)
        {
            load = MaxLoadFactor;
        }

        this.currentLoad = load;
        this.theTable = new LinkedList<KeyValuePair<K, V>>[capacity];
    }

    public void Add(K key, V value)
    {
        int possition = GetHashPossition(key);

        if (this.theTable[possition] == null)
        {
            this.theTable[possition] = new LinkedList<KeyValuePair<K, V>>();
        }

        if (this.theTable[possition].Any(p => p.Key.Equals(key)))
        {
            throw new ArgumentException(string.Format("HashTable already contains key {0}", key));
        }

        KeyValuePair<K, V> newValue = new KeyValuePair<K, V>(key, value);
        this.theTable[possition].AddLast(newValue);
        this.count++;

        if (this.capacity * this.currentLoad <= this.count)
        {
            this.ResizeCapacity();
        }
    }

    /// <summary>
    /// Searches the HashTable for a KyeValue pair with Kye equals to key.
    /// If found returns the value if not throws exception.
    /// </summary>
    /// <param name="key">The key to look up in the HashTable</param>
    /// <returns>The value of found by kye pair or exception if not found</returns>
    public V Find(K key)
    {
        try
        {
            int possition = GetHashPossition(key);
            if (this.theTable[possition] == null)
            {
                return default(V);
            }

            return this.theTable[possition].First(p => p.Key.Equals(key)).Value;
        }
        catch (Exception e)
        {
            throw new ArgumentException(string.Format("HashTable does not contain key {0}", key));
        }
    }

    public void Remove(K key)
    {
        if (!this.ContainsKey(key))
        {
            throw new ArgumentException(string.Format("HashTable does not contain key {0}", key));
        }

        int possition = GetHashPossition(key);
        V valueToRemove = this.Find(key);
        KeyValuePair<K, V> pairToRemove = new KeyValuePair<K, V>(key, valueToRemove);
        this.theTable[possition].Remove(pairToRemove);
    }

    public int Count()
    {
        return count;
    }

    public void Clear()
    {
        if (this.theTable != null)
        {
            this.theTable = new LinkedList<KeyValuePair<K, V>>[StartCapacity];
        }

        this.count = 0;
    }

    public V this[K key]
    {
        get
        {
            return this.Find(key);
        }
        set
        {
            if (this.ContainsKey(key))
            {
                this.Remove(key);
            }

            this.Add(key, value);
        }
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        foreach (var valueList in this.theTable)
        {
            if (valueList == null)
            {
                continue;
            }

            foreach (var pair in valueList)
            {
                yield return pair;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public bool ContainsKey(K key)
    {
        int possition = GetHashPossition(key);

        if (this.theTable[possition] == null)
        {
            return false;
        }

        return this.theTable[possition].Any(p => p.Key.Equals(key));
    }

    public bool ContainsValue(V value)
    {
        bool containsValue = false;
        foreach (var valueList in this.theTable)
        {
            if (valueList == null)
            {
                containsValue = false;
                continue;
            }

            if (valueList.Any(p => p.Value.Equals(value)))
            {
                containsValue = true;
                return containsValue;
            }
        }

        return containsValue;
    }

    private void ResizeCapacity()
    {
        LinkedList<KeyValuePair<K, V>>[] currentValues = this.theTable;
        this.capacity *= 2;
        this.theTable = new LinkedList<KeyValuePair<K, V>>[this.capacity];
        this.count = 0;

        foreach (var valueList in currentValues)
        {
            if (valueList == null)
            {
                continue;
            }


            foreach (var pair in valueList)
            {
                this.Add(pair.Key, pair.Value);
            }
        }
    }

    private int GetHashPossition(K key)
    {
        int keyHash = key.GetHashCode();
        int possition = Math.Abs(keyHash % this.capacity);
        return possition;
    }
}