using System;
using System.Collections.Generic;

namespace TDHelper
{
    class VersionComparer : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            Version xVersion = new Version(x);
            Version yVersion = new Version(y);

            return xVersion.CompareTo(yVersion);
        }
    }
}
