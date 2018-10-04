using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CommonLib
{
    public class CompareUtil
    {
        public static IComparer CompareDecimal()
        {
            return (IComparer)new SortDecimal();
        }

        private class SortDecimal : IComparer
        {
            int IComparer.Compare(object value1, object value2)
            {
                Decimal d1 = 0;
                Decimal d2 = 0;
                Boolean ConvertValue1 = Decimal.TryParse(value1.ToString(), out d1);
                Boolean ConvertValue2 = Decimal.TryParse(value2.ToString(), out d2);

                if (ConvertValue1 && ConvertValue2) return Decimal.Compare(d1, d2);
                else return new CaseInsensitiveComparer().Compare(value1, value2);
            }
        }

    }
}
