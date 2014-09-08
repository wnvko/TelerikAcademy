namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            List<T> toSort = collection.ToList();
            collection = Sorting(toSort);
        }

        private List<T> Sorting(List<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }
            else
            {
                List<T> left = new List<T>();
                List<T> right = new List<T>();

                int mid = collection.Count / 2;
                left.AddRange(collection.TakeWhile((c, index) => index < mid));
                right.AddRange(collection.SkipWhile((c, index) => index < mid));

                left = Sorting(left);
                right = Sorting(right);

                return Merge(left, right);
            }

        }

        private List<T> Merge(List<T> left, List<T> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            List<T> result = new List<T>();
            while (left.Count > leftIndex || right.Count > rightIndex)
            {
                if (left.Count > leftIndex && right.Count > rightIndex)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (left.Count > leftIndex)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (right.Count > rightIndex)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }
    }
}
