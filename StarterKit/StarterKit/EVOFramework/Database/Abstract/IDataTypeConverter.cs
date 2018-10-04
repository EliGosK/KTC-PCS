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
        /// �ŧ������ DataType �ͧ���� Provider
        /// ������� Provider ���� Index of enum ���������͹�ѹ
        /// </summary>
        /// <param name="dataType">Custom DataType</param>
        /// <returns>index of enum DataType �ͧ���� Provider</returns>
        int ConvertToProvider(DataType dataType);

    }   
}
