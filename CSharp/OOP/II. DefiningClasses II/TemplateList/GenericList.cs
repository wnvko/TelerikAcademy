namespace TemplateList
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 8;
        private const int InitialCount = 0;

        private int capacity;
        private int count;
        private T[] list;

        // Constructors
        public GenericList()
        {
            this.list = new T[InitialCapacity];
            this.capacity = InitialCapacity;
            this.count = InitialCount;
        }

        // Properties
        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        // Indexers
        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Input index out of range.");
                }
                else
                {
                    return this.list[index];
                }
            }
        }

        // Methods
        public void Add(T elementToAdd)
        {
            if (this.Count == this.Capacity)
            {
                this.list = this.ExtendList();
            }

            this.list[this.Count] = elementToAdd;
            this.Count++;
        }

        public void InsertAt(T elementToIsert, int index)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }

            if (this.Count == this.Capacity)
            {
                this.ExtendList();
                this.Add(elementToIsert);
                this.Count++;
                return;
            }

            Array.Copy(this.list, index, this.list, index + 1, this.Count - index);
            this.list[index] = elementToIsert;
            this.Count++;
            return;
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }

            T[] temporaryArray = new T[this.Capacity];
            Array.Copy(this.list, 0, temporaryArray, 0, index);
            Array.Copy(this.list, index + 1, temporaryArray, index, this.Count - index - 1);
            this.list = temporaryArray;
            this.Count--;
        }

        public void ClearAll()
        {
            this.Capacity = InitialCapacity;
            this.Count = InitialCount;
            this.list = new T[InitialCapacity];
        }

        public int FindIndexOf(T elementToFind)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].CompareTo(elementToFind) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public T Min()
        {
            T minValue = this.list[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (minValue.CompareTo(this.list[i]) > 0)
                {
                    minValue = this.list[i];
                }
            }

            return minValue;
        }

        public T Max()
        {
            T maxValue = this.list[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (maxValue.CompareTo(this.list[i]) < 0)
                {
                    maxValue = this.list[i];
                }
            }

            return maxValue;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                output.Append(string.Format("{0}{1}", this.list[i], Environment.NewLine));
            }

            return output.ToString();
        }

        private T[] ExtendList()
        {
            T[] temporaryArray = this.list;
            this.Capacity *= 2;
            T[] list = new T[this.Capacity];
            Array.Copy(temporaryArray, 0, list, 0, this.count);
            return list;
        }
    }
}