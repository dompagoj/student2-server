using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Student2.Utils
{
    public static class ListExtensions
    {
        public static T FirstOr<T>(this IEnumerable<T> list, T alternate)
        {
            Debug.Assert(alternate != null);

            return list.FirstOrDefault() ?? alternate;
        }
    }
}
