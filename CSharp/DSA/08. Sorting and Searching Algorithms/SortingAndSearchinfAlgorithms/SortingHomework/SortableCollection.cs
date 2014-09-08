namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T element in this.Items)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return LookIn(0, this.Items.Count - 1, item);
        }

        private bool LookIn(int left, int right, T item)
        {
            if (left >= right)
            {
                return false;
            }

            int possition = (left + right) / 2;
            if (Items[possition].CompareTo(item) == 0)
            {
                return true;
            }
            else if (Items[possition].CompareTo(item) < 0)
            {
                LookIn(0, possition - 1, item);
            }
            else
            {
                LookIn(possition + 1, this.Items.Count - 1, item);
            }

            return false;
        }

        public void Shuffle()
        {
            Console.WriteLine("Dont use this at home!");
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}