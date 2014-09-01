using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
{
    private List<KeyValuePair<TPriority, TValue>> baseHeap;
    private IComparer<TPriority> comparer;

    public PriorityQueue()
        : this(Comparer<TPriority>.Default)
    {
    }

    public PriorityQueue(int capacity)
        : this(capacity, Comparer<TPriority>.Default)
    {
    }

    public PriorityQueue(int capacity, IComparer<TPriority> comparer)
    {
        if (comparer == null)
        {
            throw new ArgumentNullException();
        }

        this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(capacity);
        this.comparer = comparer;
    }

    public PriorityQueue(IComparer<TPriority> comparer)
    {
        if (comparer == null)
        {
            throw new ArgumentNullException();
        }

        this.baseHeap = new List<KeyValuePair<TPriority, TValue>>();
        this.comparer = comparer;
    }

    public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
        : this(data, Comparer<TPriority>.Default)
    {
    }

    public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
    {
        if (data == null || comparer == null)
        {
            throw new ArgumentNullException();
        }

        this.comparer = comparer;
        this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);

        for (int pos = (this.baseHeap.Count / 2) - 1; pos >= 0; pos--)
        {
            this.HeapifyFromBeginningToEnd(pos);
        }
    }

    public bool IsEmpty
    {
        get
        {
            return this.baseHeap.Count == 0;
        }
    }

    public int Count
    {
        get
        {
            return this.baseHeap.Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public void Add(KeyValuePair<TPriority, TValue> item)
    {
        this.Enqueue(item.Key, item.Value);
    }

    public void Enqueue(TPriority priority, TValue value)
    {
        this.Insert(priority, value);
    }

    public void Clear()
    {
        this.baseHeap.Clear();
    }

    public bool Contains(KeyValuePair<TPriority, TValue> item)
    {
        return this.baseHeap.Contains(item);
    }

    public KeyValuePair<TPriority, TValue> Dequeue()
    {
        if (!this.IsEmpty)
        {
            KeyValuePair<TPriority, TValue> result = this.baseHeap[0];
            this.DeleteRoot();
            return result;
        }
        else
        {
            throw new InvalidOperationException("Priority queue is empty");
        }
    }

    public TValue DequeueValue()
    {
        return this.Dequeue().Value;
    }

    public KeyValuePair<TPriority, TValue> Peek()
    {
        if (!this.IsEmpty)
        {
            return this.baseHeap[0];
        }
        else
        {
            throw new InvalidOperationException("Priority queue is empty");
        }
    }

    public TValue PeekValue()
    {
        return this.Peek().Value;
    }

    public bool Remove(KeyValuePair<TPriority, TValue> item)
    {
        int elementIdx = this.baseHeap.IndexOf(item);
        if (elementIdx < 0)
        {
            return false;
        }

        this.baseHeap[elementIdx] = this.baseHeap[this.baseHeap.Count - 1];
        this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

        int newPos = this.HeapifyFromEndToBeginning(elementIdx);
        if (newPos == elementIdx)
        {
            this.HeapifyFromBeginningToEnd(elementIdx);
        }

        return true;
    }

    public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> firstPriorityQueue, PriorityQueue<TPriority, TValue> secondPriorityQueue)
    {
        if (firstPriorityQueue == null || secondPriorityQueue == null)
        {
            throw new ArgumentNullException("Cannot merge null queues!");
        }

        if (firstPriorityQueue.comparer != secondPriorityQueue.comparer)
        {
            throw new InvalidOperationException("Priority queues to be merged must have equal comparers");
        }

        return MergeQueues(firstPriorityQueue, secondPriorityQueue, firstPriorityQueue.comparer);
    }

    public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> firstPriorityQueue, PriorityQueue<TPriority, TValue> secondPriorityQueue, IComparer<TPriority> comparer)
    {
        if (firstPriorityQueue == null || secondPriorityQueue == null || comparer == null)
        {
            throw new ArgumentNullException("Cannot merge null queues!");
        }

        PriorityQueue<TPriority, TValue> mergedQueue = new PriorityQueue<TPriority, TValue>(firstPriorityQueue.Count + secondPriorityQueue.Count, firstPriorityQueue.comparer);
        mergedQueue.baseHeap.AddRange(firstPriorityQueue.baseHeap);
        mergedQueue.baseHeap.AddRange(secondPriorityQueue.baseHeap);

        for (int pos = mergedQueue.baseHeap.Count / 2 - 1; pos >= 0; pos--)
        {
            mergedQueue.HeapifyFromBeginningToEnd(pos);
        }

        return mergedQueue;
    }

    public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
    {
        this.baseHeap.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
    {
        return this.baseHeap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Insert(TPriority priority, TValue value)
    {
        KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
        this.baseHeap.Add(val);

        this.HeapifyFromEndToBeginning(this.baseHeap.Count - 1);
    }

    private int HeapifyFromEndToBeginning(int pos)
    {
        if (pos >= this.baseHeap.Count)
        {
            return -1;
        }

        while (pos > 0)
        {
            int parentPos = (pos - 1) / 2;
            if (this.comparer.Compare(this.baseHeap[parentPos].Key, this.baseHeap[pos].Key) > 0)
            {
                this.ExchangeElements(parentPos, pos);
                pos = parentPos;
            }
            else
            {
                break;
            }
        }

        return pos;
    }

    private void ExchangeElements(int first, int second)
    {
        KeyValuePair<TPriority, TValue> val = this.baseHeap[first];
        this.baseHeap[first] = this.baseHeap[second];
        this.baseHeap[second] = val;
    }

    private void DeleteRoot()
    {
        if (this.baseHeap.Count <= 1)
        {
            this.baseHeap.Clear();
            return;
        }

        this.baseHeap[0] = this.baseHeap[this.baseHeap.Count - 1];
        this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

        this.HeapifyFromBeginningToEnd(0);
    }

    private void HeapifyFromBeginningToEnd(int pos)
    {
        if (pos >= this.baseHeap.Count)
        {
            return;
        }

        while (true)
        {
            int smallest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;
            if (left < this.baseHeap.Count && this.comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[left].Key) > 0)
            {
                smallest = left;
            }

            if (right < this.baseHeap.Count && this.comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[right].Key) > 0)
            {
                smallest = right;
            }

            if (smallest != pos)
            {
                this.ExchangeElements(smallest, pos);
                pos = smallest;
            }
            else
            {
                break;
            }
        }
    }
}
