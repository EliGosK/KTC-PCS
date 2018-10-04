#define MODIFY_BY_ITIM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;

namespace Rubik
{
    public static class DataDefine
    {
        public const string DEFAULT_FORMAT_NUMBER = "#,##0.00";
        public const string LOCATION_CLS = "LOCATION_CLS";
        public const string ALLOW_NEGATIVE_CLS = "ALLOW_NEGATIVE";
        public const string TRANS_TYPE = "TRANS_TYPE";
        public const string IN_OUT_CLASS = "IN_OUT_CLASS";
        public const string DATE_FORMAT = "DATE_FORMAT";
        public const string LOT_CONTROL_CLS = "LOT_CONTROL_CLS";
        public const string UM_CLS = "UM_CLS";
        public const string CONSUMPTION_CLS = "CONSUMTION_CLS";
        public const string REF_SLIP_CLS = "REF_SLIP_CLS";
        public const string ITEM_CLS = "ITEM_CLS";
        public const string ITEM_CLS_MINOR04 = "ITEM_CLS_MINOR04";
        public const string OVER_CONSUME_CHK = "OVER_CONSUME_CHK";
        public const string ORDER_PROCESS_CLS = "ORDER_PROCESS_CLS";
        public const string ADJ_SUBTYPE = "ADJ_SUBTYPE";
        public const string SHIFT_CLS = "SHIFT_CLS";
        public const string ISSUE_SUBTYPE = "ISSUE_SUBTYPE";
        public const string OPERATION_TYPE = "OPERATION_TYPE";
        public const string SCREEN_TYPE = "SCREEN_TYPE";
        public const string LOT_NO_FORMAT = "yyyyMMdd";

        public const string CUSTOMER_ORDER_TYPE = "CUST_ORDER_TYPE";
        public const string PRODUCTION_PROCESS = "PRODUCTION_PROCESS";
        public const string KIND_OF_PRODUCT = "KIND_OF_PRODUCT";
        public const string BOI_PROJECT = "BOI_PROJECT";
        public const string PRODUCTION_DI = "PRODUCTION_DI";
        public const string MAT_DI = "MAT_DI";
        public const string ITEM_LEVEL = "ITEM_LEVEL";
        public const string SCREW_KIND = "SCREW_KIND";
        public const string SCREW_HEAD = "SCREW_HEAD";
        public const string SCREW_TYPE = "SCREW_TYPE";
        public const string SCREW_REMARK1 = "SCREW_REMARK1";
        public const string SCREW_REMARK2 = "SCREW_REMARK2";
        public const string HEAT_TREATMENT_TYPE = "HEAT_TREATMENT_TYPE";
        public const string KTC_PLATING = "KTC_PLATING";
        public const string BAKING_TIME = "BAKING_TIME";
        public const string BAKING_TEMP = "BAKING_TEMP";
        public const string OTHER_KIND = "OTHER_KIND";
        public const string OTHER_CONDITION = "OTHER_CONDITION";

        public const string CUSTOMER_ORDER_DATE_FILTER = "CUSTOMER_ORDER_DATE_FILTER";


        //Add by Sansanee K. 20120216 1535
        public const string MACHINE_PROJECT = "MACHINE_PROJECT";
        public const string MACHINE_TYPE = "MACHINE_TYPE";
        public const string MOVE_REASON = "MOVE_REASON";

        public const string BARCODE_SEPARATER = "%";

        public const string LOCATION_INJECTION = "INJ";
        public const string LOCATION_INJECTION_MATERIAL = "INJRM";
        public const string LOCATION_SCRAP = "SCRAPWH";
        public const string LOT_SCRAP = "SCRAP";
        public const string LOT_RESERVE_POSTFIX = "#R";
        public const string LOT_DUMMY = "DUMMY";
        public const string LOT_RECYCLE = "RECYCLE";

        public const string TRAN_SUB_CLS = "TRAN_SUB_CLS";
        //work result cls เป็น sub ของ tran sub class เพราะว่า tran sub cls มันอาจรวมของทุก tran
        public const string WORK_RESULT_CLS = "WORK_RESULT_CLS";

        //ให้ View reference ดู ว่ามันใช้ตรงไหนบ้าง
        public const string LOT_SUPPLIER = "SUPP";


        public const string ORDER_PROCESS_CLS_SUBCONTACT = "SUB";
        public const string TRANSACTION_TABLE_NAME = "TB_INV_TRANS_TR";
        public const string RECEIVE_SLIP_NO = "RECEIVE_SLIP_NO";
        public const string TRANS_ID = "TRAN_ID";
        public const string RECEIVE_REF_NO = "RECEIVE_REF_NO";

        //Add by Sansanee K. 02 June 2011
        public const string PO_TYPE = "PO_TYPE";
        public const string CURRENCY = "CURRENCY";
        public const string VAT_TYPE = "VAT_TYPE";
        public const string TERM_OF_PAYMENT = "TERM_OF_PAYMENT";
        public const string PO_STATUS = "PO_STATUS";

        public const string INVOICE_PATTERN = "INVOICE_PATTERN";

        public static string NO_EXPORT = "NO_EXPORT";
        public static string EXPORT_LAST = "EXPORT_LAST";

        // Add by Pongthorn S. 09 Mar 2012
        public static string CURRENCY_THB = "THB";
        public static string DEFAULT_EXCHANGE_RATE = "1.0000";
        public static string ORDER_TYPE_FORECAST = "FORECAST";
        public static string ORDER_TYPE_FIX = "FIX";
        

        // Add by Pongthorn S. 19 Apr 2012
        // Use for Enable/Disable EVENT for List Screen.
        public static bool ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED = false;
        public static bool ENABLED_AUTO_SEARCH_WHEN_DROPDROWLIST_VALUE_CHANGE = false;
        public static bool ENABLED_AUTO_SEARCH_WHEN_USE_AUTO_COMPLETE = false;
        public static bool ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY = true;

#if MODIFY_BY_ITIM
        public const string ORDER_CONDITION = "ORDER_CONDITION";
        public const string MRP_FLAG = "MRP_FLAG";
        public const string MRP_LOCATION = "MRP_LOCATION";
#endif

        /// <summary>
        /// ใช้สำหรับหน้า Item Dialog เพื่อให้ดูว่า parameter ที่ส่งจาก shipment , receive เป็น supplier , customer 
        /// </summary>
        public enum eDealingType
        {
            Supplier,
            Customer
        }

        public enum eSHIFT_CLS
        {
            A,
            B,
        }

        public enum eOVER_CONSUME_CHK
        {
            DEFAULT = 1
        }
        public enum eITEM_CLS
        {
            FinishGoods = 1,
            WorkInProcess = 2,
            SubMaterial = 3,
            RawMaterial = 4,

        }
        public enum eITEM_CLS_MINOR04
        {
            RawMaterial = 1,
            SubRawMaterial = 2,

        }
        public enum eREF_SLIP_CLS
        {
            PurchseOrder = 1,
            Issue = 2,
            WorkOrder = 3,
            WorkResult = 4,
            Shipment = 5,
        }
        public enum eLOCATION_CLS
        {
            Store = 1,
            Production = 2,
            Customer = 3,
            Vendor = 4,
            CustomerVendor = 5,
        }

        public enum eADJUST_TYPE
        {
            StockTaking = 5
        }

        public enum eEFFECT_STOCK
        {
            In = 1,
            Out = -1,
            None = 0,
        }


        public enum eTRANS_TYPE
        {
            Receiving = 0,
            Receive_Return = 1,
            Issuing = 10,
            Issuing_Return = 11,
            Issue_Consumption = 12,
            WorkResult = 20,
            NGWorkResult = 21,
            ReserveResult = 22,
            Shipment = 30,
            Shipment_Return = 31,
            Consumption = 40,
            Adjustment = 50,
            MovePart = 60,
            MoveConsumption = 61,
            Packing = 70,
            Packing_Consumption = 71,
            Unpack = 80,
            Unpack_Consumption = 81,
        }

        //mapping กับ eTRANS_TYPE เผื่อ check value 
        public class eTRANS_TYPE_string
        {
            public const string Receiving = "00";
            public const string Receive_Return = "01";
            public const string Issuing = "10";
            public const string Issuing_Return = "11";
            public const string Issue_Consumption = "12";
            public const string WorkResult = "20";
            public const string NGWorkResult = "21";
            public const string ReserveResult = "22";
            public const string Shipment = "30";
            public const string Shipment_Return = "31";
            public const string Consumption = "40";
            public const string Adjustment = "50";
            public const string MovePart = "60";
            public const string MoveConsumption = "61";
            public const string Packing = "70";
            public const string Packing_Consumption = "71";
            public const string Unpack = "80";
            public const string Unpack_Consumption = "81";
        }

        //ใช้เพื่อ map เป็น string ตามใน database
        //table TZ_SYS_CONFIG
        public class eSYSTEM_CONFIG
        {


            public class DATA_LIFE
            {
                public static NZString SYS_GROUP_ID = (NZString)"DATA_LIFE";
                public enum SYS_KEY
                {
                    INV_ONHAND,
                    INV_TRANS,
                }
            }


            public class ZZ
            {
                public static NZString SYS_GROUP_ID = (NZString)"ZZ";
                public enum SYS_KEY
                {
                    DEF_LANG,
                }
            }


            public class LOCATION
            {
                public static NZString SYS_GROUP_ID = (NZString)"LOCATION";
                public enum SYS_KEY
                {
                    MINUS_QTY,
                }
            }
            public class TRN020
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN020";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    STORE_LOC,
                }
            }

            public class TRN040
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN040";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }

            public class TRN060
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN060";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }

            public class TRN080
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN080";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    NG_LOC_CD,
                }
            }

            public class TRN100
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN100";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    FROM_LOC
                }
            }


            public class TRN102
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN102";
                public enum SYS_KEY
                {
                    DEFAULT_DATE_FROM,
                    DEFAULT_DATE_TO
                }
            }

            public class TRN120
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN120";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }

            public class TRN160
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN160";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }

            public class TRN170
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN170";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }

            public class TRN190
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN190";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    BEFORE_DATE,
                    AFTER_DATE,
                }
            }

            public class TRN210
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN210";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }


            public class TRN270
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN270";
                public enum SYS_KEY
                {
                    //DEFAULT_DATE,
                    STORE_LOC
                }
            }

            public class TRN271
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN271";
                public enum SYS_KEY
                {
                    DEFAULT_DATE_FROM,
                    DEFAULT_DATE_TO
                }
            }

            public class TRN300
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN300";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                }
            }
            public class TRN320
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN320";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    DEST_LOC,
                    SOURCE_LOC,
                }
            }

            public class TRN330
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN330";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    DEST_LOC,
                    SOURCE_LOC,
                }
            }

            public class TRN350
            {
                public static NZString SYS_GROUP_ID = (NZString)"TRN350";
                public enum SYS_KEY
                {
                    DEFAULT_DATE,
                    ADDRESS_NO,
                    DEFAULT_VAT,
                }
            }

            public class INV060
            {
                public static NZString SYS_GROUP_ID = (NZString)"INV060";
                public enum SYS_KEY
                {
                    WARNING_RECORDS,
                    ERROR_RECORDS,
                }
            }

            public class INV090
            {
                public static NZString SYS_GROUP_ID = (NZString)"INV090";
                public enum SYS_KEY
                {
                    WARNING_RECORDS,
                    ERROR_RECORDS,
                }
            }

            public class STK020
            {
                public static NZString SYS_GROUP_ID = (NZString)"STK020";
                public enum SYS_KEY
                {
                    DEV_VERSION
                }
            }
        }

        public enum eIN_OUT_CLASS
        {
            In = 1,
            Out = 2,
            None = 3,
        }

        public enum eLOT_CONTROL_CLS
        {
            No = 0,
            Yes = 1,
            Partial = 2,
        }

        public enum eCONSUMPTION_CLS
        {
            No = 0,
            Manual = 1,
            Auto = 2,
        }

        public enum eTAGCardType
        {
            FG, WIP, RM
        }

        public enum eALLOW_NEGATIVE
        {
            No = 0,
            Yes = 1,
        }

        public enum eOperationClass
        {
            Add = 0,
            Update = 1,
            Delete = 2,
        }

        public enum eTRAN_SUB_CLS
        {
            RW = 1,
            WR = 0,
        }

        public enum eBOM_STATUS
        {
            ALL,
            SET,
            NO
        }

        // edit by Chatas C. 27 June 2011
        public enum eORDER_PROCESS
        {
            PRO,
            ASSY,
            PAC,
            PUR,
            SUB,
            OTHER,
        };

        /// <summary>
        /// Convert from Enum value to Class Code
        /// </summary>
        /// <param name="enumObject">enum object, such as: eIN_OUT_CLASS.In</param>
        /// <returns>Class code, such as: "01", "02"</returns>
        public static string Convert2ClassCode(object enumObject)
        {
            const string strPattern = "{0:00}";
            if (enumObject.GetType().IsEnum)
                return String.Format(strPattern, (int)enumObject);

            return String.Format(strPattern, Convert.ToInt32(enumObject));
        }

        /// <summary>                
        /// <para>แปลงค่า String Value ของ Enum  กลับคืนให้เป็นตัวแปร Enum เช่น</para>
        /// <para>string strValue = Convert2ClassCode(eIN_OUT_CLASS.In);  //จะได้ค่า "01"</para>
        /// <para>eIN_OUT_CLASS enumValue = ConvertValue2Enum(strValue, eIN_OUT_CLASS);  // จะได้ค่า eIN_OUT_CLASS.In กลับคืน</para>        
        /// </summary>
        /// <typeparam name="T">Enum which need convert to.</typeparam>
        /// <param name="value">StringValue such as: "01", "02"</param>
        /// <returns></returns>
        public static T ConvertValue2Enum<T>(string value)
        {
            Type enumType = typeof(T);
            int iValue = Convert.ToInt32(value);
            return (T)Enum.ToObject(enumType, iValue);
        }


        public class ScreenType
        {
            public const string AdjustmentEntry = "ADJ";
            public const string IssueEntry = "ISS";
            public const string IssueConsumption = "ISSC";
            public const string IssueByOrder = "ISSO";
            public const string ReceivingEntry = "RCV";
            public const string ShipmentEntry = "SHIP";
            public const string WorkResultEntry = "WR";
            public const string MovePartEntry = "MOVE";
            public const string PackingEntry = "PK";
            public const string UnPackingEntry = "UPK";
            public const string ReturnEntry = "RT";
        }
    }

    public enum eItemType
    {
        All,
        SCREW,
        SHAFT,
        WASHER
    }

    public enum eSqlOperator
    {
        /// <summary>
        /// Not specify.
        /// </summary>
        None,
        /// <summary>
        /// [FieldA] > [FieldB]
        /// </summary>
        Great,
        /// <summary>
        /// [FieldA] >= [FieldB]
        /// </summary>
        GreateOrEqual,
        /// <summary>
        /// [FieldA] < [FieldB]
        /// </summary>
        Less,
        /// <summary>
        /// [FieldA] <= [FieldB]
        /// </summary>
        LessOrEqual,
        /// <summary>
        /// [FieldA] = [FieldB]
        /// </summary>
        Equal,
        /// <summary>
        /// [FieldA] <> [FieldB]
        /// </summary>
        NotEqual,
        /// <summary>
        /// [FieldA] IN ('VAL1', 'VAL2')
        /// </summary>
        In,
        /// <summary>
        /// [FieldA] NOT IN ('VAL1', 'VAL2')
        /// </summary>
        NotIn,
        /// <summary>
        /// [FieldA] IS NULL
        /// </summary>
        IsNull,
        /// <summary>
        /// [FieldA] IS NOT NULL
        /// </summary>
        IsNotNull,
    }
    public enum eMonthlyCloseProcess
    {
        ROLLING_UP,
        ROLLING_DOWN
    }




}
