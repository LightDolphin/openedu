using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            //IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
            if (prefix.Length < 1) return -1;
            int i;
            right--;
            while (right - left > 2)
            {
                i = (int)(left / 2.0 + right / 2.0);
                if (string.Compare(prefix, phrases[i], StringComparison.OrdinalIgnoreCase) < 0 || phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    left = i;
                }
                else right = i;
            }
            return left + 1;
        }
    }
}