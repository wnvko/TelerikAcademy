using System.Collections.Generic;

public class HashedSet<T> : IEnumerable<T>
{
    private HashTable<T, int> theset;

    public HashedSet()
    {
        this.theset = new HashTable<T, int>();
    }

    public void Add(T value)
    {
        this.theset.Add(value, 0);
    }

    public bool Find(T value)
    {
        return this.theset.ContainsKey(value);
    }

    public void Remove(T value)
    {
        this.theset.Remove(value);
    }

    public int Count()
    {
        return this.theset.Count();
    }

    public void Clear()
    {
        this.theset.Clear();
    }

    public HashedSet<T> Union(HashedSet<T> otherSet)
    {
        HashedSet<T> union = new HashedSet<T>();

        foreach (var value in this)
        {
            union.Add(value);
        }

        foreach (var value in otherSet)
        {
            if (this.theset.ContainsKey(value))
            {
                continue;
            }

            union.Add(value);
        }

        return union;
    }

    public HashedSet<T> Intersect(HashedSet<T> otherSet)
    {
        HashedSet<T> intersect = new HashedSet<T>();
        foreach (var value in otherSet)
        {
            if (this.theset.ContainsKey(value))
            {
                intersect.Add(value);
            }
        }

        return intersect;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var pair in this.theset)
        {
            yield return pair.Key;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
