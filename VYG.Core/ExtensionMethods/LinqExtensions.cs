using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYG.Core.ExtensionMethods
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> IntersectBy<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector)
        {
            var secondKeys = new HashSet<TKey>(second.Select(keySelector));
            return first.Where(x => secondKeys.Contains(keySelector(x)));
        }


        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source)
        {
            return source.GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .SelectMany(g => g);
        }
    }
}
