using System;
using System.Reflection;
using EVOFramework;
using EVOFramework.Database;

namespace EVOFramework.Data 
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        #region Variables
        private Type m_nzType = typeof(string);
        private Type m_systemType = typeof(string);
        private DataType m_dataType = DataType.Default;
        private string m_strName = String.Empty;
        private int m_iPrecision = 0;
        private int m_iScale = 0;
        private int m_iSize = 0;
        #endregion

        #region Constructor
        public FieldAttribute(Type systemType, Type nzType, DataType dataType, string fieldName) : this(systemType, nzType, dataType, fieldName, 0, 0, 0) { }
        public FieldAttribute(Type systemType, Type nzType, DataType dataType, string fieldName, int precision, int scale, int size)
        {
            this.m_systemType = systemType;
            this.m_nzType = nzType;
            this.m_dataType = dataType;
            this.m_strName = fieldName;
            this.m_iPrecision = precision;
            this.m_iScale = scale;
            this.m_iSize = size;
        }
        #endregion

        #region Properties
        public Type NZType
        {
            get { return m_nzType; }
        }
        public Type SystemType
        {
            get { return m_systemType; }
        }
        public DataType DataType
        {
            get { return m_dataType; }
        }
        public string Name
        {
            get { return m_strName; }
        }
        public int Precision
        {
            get { return m_iPrecision; }
        }
        public int Scale
        {
            get { return m_iScale; }
        }
        public int Size
        {
            get { return m_iSize; }
        }
        #endregion        

        #region Static Method
        /// <summary>
        /// Get field attribute data.
        /// </summary>
        /// <param name="dtoType">Owner DTO.</param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        public static FieldAttribute GetFieldData(Type dtoType, string PropertyName)
        {
            PropertyInfo propInfo =  dtoType.GetProperty(PropertyName);
            if (propInfo == null)
                return null;

            object[] objs = propInfo.GetCustomAttributes(typeof(FieldAttribute), false);
            if (objs == null || objs.Length == 0)
                return null;
            else
                return objs[0] as FieldAttribute;
        }
        #endregion
    }
}
