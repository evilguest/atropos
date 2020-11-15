using System;
using System.Collections.Generic;
using System.Text;

namespace Atropos.Tests
{
    public static class TestHelper
    {
        public static long LongSum(this IEnumerable<int> range)
        {
            long s = 0;
            foreach (var i in range)
                s += i;
            return s;
        }
    }
}
