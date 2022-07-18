using System.Collections.Generic;
using System.Linq;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static List<T> RepeatedDefault<T>(this T item, int count) where T : class => default(T).Repeated(count);

        public static List<T> Repeated<T>(this T item, int count) where T : class => Enumerable.Repeat(item, count).ToList();
    }
}