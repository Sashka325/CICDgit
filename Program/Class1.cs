using System;
using System.Collections.Generic;

namespace ListOperationsLib
{
    public class ListOperations
    {
        public static bool AddUnique<T>(List<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "List cannot be null");

            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            }
            return false;
        }

        public static int RemoveAllOccurrences<T>(List<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "List cannot be null");

            return list.RemoveAll(x => EqualityComparer<T>.Default.Equals(x, item));
        }

        public static int FindIndex<T>(List<T> list, Predicate<T> match)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "List cannot be null");
            if (match == null)
                throw new ArgumentNullException(nameof(match), "Match predicate cannot be null");

            return list.FindIndex(match);
        }

        public static List<T> GetDistinct<T>(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "List cannot be null");

            return new List<T>(new HashSet<T>(list));
        }
    }
}
