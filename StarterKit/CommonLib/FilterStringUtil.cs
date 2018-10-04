using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CommonLib
{
    public class FilterStringUtil
    {
        public static string GetFilterstring(Type enumType, string strKeyword)
        {
            string[] colNames = Enum.GetNames(enumType);
            string filterString = string.Empty;

            for (int i = 0; i < colNames.Length; i++)
            {
                filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], strKeyword);
                if (i != colNames.Length - 1)
                    filterString += " OR ";
            }

            return filterString;
        }


        public static string GetFilterstring(DataTable dt, string strKeyword)
        {

            string filterString = string.Empty;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", dt.Columns[i].ColumnName, strKeyword);
                if (i != dt.Columns.Count - 1)
                    filterString += " OR ";
            }

            return filterString;
        }
    }
}
