using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemMaintenance
{
    public static class DataDefine
    {
        //ถ้าเปิดให้ auto arrange icon จะไม่มี work flow line 
        public const bool AUTO_ARRANGE_ICON = true;
        public const int ICON_PER_ROW = 4;


        public const string LOCATION_CLS = "LOCATION_CLS";
        public const string ITEM_CLS = "ITEM_CLS";
        public const string TRANS_TYPE = "TRANS_TYPE";
        public const string IN_OUT_CLASS = "IN_OUT_CLASS";
        public const string DATE_FORMAT = "DATE_FORMAT";
        public const string PROGRAM_DATE = "2010/09/09";

        // Add by Pongthorn S. @ 2012-05-21
        public const string MASTER_NO_FIELD_NAME = "M/N";
    }
}
