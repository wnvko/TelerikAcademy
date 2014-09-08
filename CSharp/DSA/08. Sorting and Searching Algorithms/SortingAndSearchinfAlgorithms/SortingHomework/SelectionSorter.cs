namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int minIndex = i;

                for (int j = 0; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) > 0)
                    {
                        T oldMinValue = collection[minIndex];
                        collection[minIndex] = collection[j];
                        collection[j] = oldMinValue;
                    }
                }
            }
        }
    }
}
