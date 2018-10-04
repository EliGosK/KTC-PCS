using System;
using System.Data;

namespace EVOFramework.Database
{
    internal sealed class SqlDataTypeConverter : IDataTypeConverter
    {
        #region IDataTypeConverter Members

        /// <summary>
        /// Convert data type to each provider database's data type.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>        
        /// <exception cref="NotSupportedException">DataType.Cursor doesn't supported.</exception>
        /// <exception cref="ArgumentException">Invalid DataType</exception>
        public int ConvertToProvider(DataType dataType)
        {
            switch (dataType)
            {            
                case DataType.Default:
                    return -1;
                case DataType.Boolean:
                    return (int) SqlDbType.Bit;
                case DataType.Byte:
                    return (int) SqlDbType.TinyInt;
                case DataType.Binary:
                    return (int) SqlDbType.VarBinary;
                case DataType.DateTime:
                    return (int) SqlDbType.DateTime;
                case DataType.Number:
                    return (int) SqlDbType.Decimal;
                case DataType.Decimal:
                    return (int) SqlDbType.Decimal;
                case DataType.Double:
                    return (int) SqlDbType.Float;
                case DataType.Single:
                    return (int) SqlDbType.Real;
                case DataType.Guid:
                    return (int) SqlDbType.UniqueIdentifier;
                case DataType.Raw:
                    return (int) SqlDbType.Variant;
                case DataType.Int16:
                    return (int) SqlDbType.SmallInt;
                case DataType.Int32:
                    return (int) SqlDbType.Int;
                case DataType.Int64:
                    return (int) SqlDbType.BigInt;
                case DataType.Object:
                    return (int) SqlDbType.Variant;
                case DataType.Char:
                    return (int) SqlDbType.Char;
                case DataType.NChar:
                    return (int) SqlDbType.NChar;
                case DataType.VarChar:
                    return (int) SqlDbType.VarChar;
                case DataType.NVarChar:
                    return (int) SqlDbType.NVarChar;
                case DataType.Cursor:
                    throw new NotSupportedException("DataType.Cursor doesn't supported.");
                default:
                    throw new ArgumentException("Invalid DataType");
            }
        }

        #endregion
    }
}
