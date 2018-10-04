using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Collections;
using System.Text;

namespace EVOFramework.Database
{
    public interface IDataTypeConverter
    {       
        /// <summary>
        /// แปลงเข้าสู่ DataType ของแต่ละ Provider
        /// ซึ่งแต่ละ Provider จะมี Index of enum แต่ไม่เหมือนกัน
        /// </summary>
        /// <param name="dataType">Custom DataType</param>
        /// <returns>index of enum DataType ของแต่ละ Provider</returns>
        int ConvertToProvider(DataType dataType);

    }   
}
