namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Sorting(collection, 0, collection.Count - 1);
        }

        private void Sorting(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            else
            {
                int pivotIndex = GetPivotPoint(collection, start, end);
                Sorting(collection, start, pivotIndex - 1);
                Sorting(collection, pivotIndex + 1, end);
            }
        }

        private int GetPivotPoint(IList<T> collection, int start, int end)
        {
            int pivotIndex = ChoosePivot(start, end);
            T pivot = collection[pivotIndex];
            Swap(collection, pivotIndex, end);
            int storeIndex = start;
            for (int i = start; i < end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(collection, storeIndex, end);
            return storeIndex;
        }

        private int ChoosePivot(int start, int end)
        {
            return (start + end) / 2;
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T oldFirst = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldFirst;
        }
    }
}
