using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class ExtensionsHelper
    {
        public static StringBuilder SubString(this StringBuilder input, int index, int lenght)
        {
            string tempContainer = input.ToString().Substring(index, lenght);

            StringBuilder result = new StringBuilder(tempContainer);
            return result;
        }

        public static T Sum<T>(this IEnumerable<T> collection, Func<T, T, T> add)
        {
            if (collection.Count() > 0)
            {
                IEnumerator<T> index = collection.GetEnumerator();
                index.MoveNext();
                T result = index.Current;

                while (index.MoveNext())
                {
                    result = add(index.Current, result);
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Empty IEnumerable");
            }
        }

        public static T Product<T>(this IEnumerable<T> collection, Func<T, T, T> multiply)
        {
            if (collection.Count() > 0)
            {
                IEnumerator<T> index = collection.GetEnumerator();
                index.MoveNext();
                T result = index.Current;

                while (index.MoveNext())
                {
                    result = multiply(index.Current, result);
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Empty IEnumerable");
            }
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() > 0)
            {
                IEnumerator<T> index = collection.GetEnumerator();
                index.MoveNext();
                T result = index.Current;

                while (index.MoveNext())
                {
                    if (result.CompareTo(index.Current) > 0)
                    {
                        result = index.Current;
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Empty IEnumerable");
            }
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() > 0)
            {
                IEnumerator<T> index = collection.GetEnumerator();
                index.MoveNext();
                T result = index.Current;

                while (index.MoveNext())
                {
                    if (result.CompareTo(index.Current) < 0)
                    {
                        result = index.Current;
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Empty IEnumerable");
            }
        }

        public static T Average<T>(this IEnumerable<T> collection, Func<T, T, T> add, Func<T, int, T> divide)
        {
            if (collection.Count() > 0)
            {
                IEnumerator<T> index = collection.GetEnumerator();
                index.MoveNext();
                T result = index.Current;

                while (index.MoveNext())
                {
                    result = add(index.Current, result);
                }

                result = divide(result, collection.Count());
                return result;
            }
            else
            {
                throw new ArgumentException("Empty IEnumerable");
            }
        }
    }
}
