using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (prefix.Length < 1) return -1;
            if (right - left < 2) return right-1;
            int i = (int)(left / 2.0 + right / 2.0);
            if (string.Compare(prefix, phrases[i], StringComparison.OrdinalIgnoreCase) < 0 || phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                right = i;
            }
            else left = i;
            return GetLeftBorderIndex(phrases,prefix,left,right);
        }
    }
}
