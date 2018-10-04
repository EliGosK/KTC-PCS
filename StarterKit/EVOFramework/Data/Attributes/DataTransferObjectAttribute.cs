using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Data
{
    /// <summary>
    /// Meta-data about DataTransferObject class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DataTransferObjectAttribute : Attribute
    {
        private readonly string m_tableName;        
        private readonly Type m_typeOfEnumColumns;

        public DataTransferObjectAttribute(string tableName, Type typeOfEnumColumns) {
            m_tableName = tableName;            
            m_typeOfEnumColumns = typeOfEnumColumns;
        }

        /// <summary>
        /// Table name which mapping from.
        /// </summary>
        public string TableName {
            get { return m_tableName; }
        }        

        /// <summary>
        /// Type of enum columns on DTO.
        /// </summary>
        public Type TypeOfEnumColumns {
            get { return m_typeOfEnumColumns; }
        }
    }
}
