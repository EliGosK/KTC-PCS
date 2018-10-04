using System;
using System.Data.OracleClient;
using System.Collections;
using System.Text;

namespace EVOFramework.Database
{
    internal sealed class OracleDataTypeConverter : IDataTypeConverter
    {
        #region IDataTypeConverter Members

        public int ConvertToProvider(DataType dataType)
        {            
            switch (dataType)
            {
                case DataType.Default:
                    return -1;
                case DataType.Boolean:
                    return (int)OracleType.Byte;
                case DataType.Byte:
                    return (int)OracleType.Byte;
                case DataType.Binary:
                    return (int)OracleType.Raw;
                case DataType.DateTime:
                    return (int)OracleType.DateTime;
                case DataType.Number:
                    return (int)OracleType.Number;
                case DataType.Decimal:
                    return (int)OracleType.Number;
                case DataType.Double:
                    return (int)OracleType.Double;
                case DataType.Single:
                    return (int)OracleType.Double;
                case DataType.Guid:
                    return (int)OracleType.Raw;
                case DataType.Raw:
                    return (int)OracleType.Raw;
                case DataType.Int16:
                    return (int)OracleType.Int16;
                case DataType.Int32:
                    return (int)OracleType.Int32;
                case DataType.Int64:
                    return (int)OracleType.Number;
                case DataType.Object:
                    return (int)OracleType.Blob;
                case DataType.Char:
                    return (int)OracleType.Char;
                case DataType.NChar:
                    return (int)OracleType.NChar;
                case DataType.VarChar:
                    return (int)OracleType.VarChar;
                case DataType.NVarChar:
                    return (int)OracleType.NVarChar;
                case DataType.Cursor:
                    return (int)OracleType.Cursor;
                default:
                    throw new ApplicationException("Invalid DataType");
            }            
        }
       
        #endregion
    }
}
