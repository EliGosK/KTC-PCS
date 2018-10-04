using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace EVOFramework.Data
{
    /// <summary>
    /// Base abstract class of DataTransferObject.
    /// </summary>        
    [Serializable()]
    public abstract class AbstractDTO : IDataTransferObject, ICloneable
    {        

        #region Indexer

        /// <summary>
        /// Indexing to get/set property value.
        /// </summary>
        /// <param name="propertyName">PropertyName or FieldName</param>
        /// <returns>If not found the given property name string will return null value. Otherwise return NZBaseObject.</returns>
        public NZBaseObject this[string propertyName]
        {
            get { return Helper.GetPropertyValue(this, propertyName) as NZBaseObject; }
            set { Helper.SetPropertyValue(this, propertyName, value); }
        }
        #endregion

        #region IDataTransferObject Members
        /// <summary>
        /// Return the Table's name mapping.
        /// </summary>        
        [Browsable(false)]
        public virtual string TableName {
            get {
                object[] obj = this.GetType().GetCustomAttributes(typeof (DataTransferObjectAttribute), true);
                if (obj != null && obj.Length > 0)
                    return ( (DataTransferObjectAttribute) obj[0] ).TableName;

                return String.Empty;
            }
        }
                
        /// <summary>
        /// Create empty DataTable object with schema.
        /// </summary>
        /// <returns>True if create DataTable finish. Otherwise return false.</returns>
        public bool CreateDataTableSchema(out DataTable dataTable) {
            //= Findout enum column
            dataTable = new DataTable(TableName);

            List<string> columns = FindAllFieldColumns();
            if (columns == null)
                return false;

            for (int i=0; i<columns.Count; i++) {
                FieldAttribute fieldAttr = this.GetFieldAttribute(columns[i]);
                if (fieldAttr != null)
                    dataTable.Columns.Add(columns[i], fieldAttr.SystemType);
                else
                    dataTable.Columns.Add(columns[i]);
            }

            // Add constraint Primary Key
            if (PrimaryKey != null) {
                List<DataColumn> dataColumns = new List<DataColumn>();
                for (int i=0; i<PrimaryKey.Value.Count; i++) {
                    dataColumns.Add(dataTable.Columns[PrimaryKey.Value[i]]);                    
                }

                dataTable.Constraints.Add(PrimaryKey.Key, dataColumns.ToArray(), true);                
            }

            // Add constraint Unique Key
            if (UniqueKeys != null && UniqueKeys.Count > 0) {

                for (int i=0; i<UniqueKeys.Count; i++) {
                    List<DataColumn> dataColumns = new List<DataColumn>();

                    for (int j = 0; j < UniqueKeys[i].Value.Count; j++) {
                        dataColumns.Add(dataTable.Columns[UniqueKeys[i].Value[j]]);
                    }

                    dataTable.Constraints.Add(UniqueKeys[i].Key, dataColumns.ToArray(), false);
                }                
            }

            return true;
        }

        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has primary key, return null value.
        /// </remarks>
        public virtual MapKeyValue<string, List<string>> PrimaryKey
        {
            get { return null; }
        }

        /// <summary>
        /// Return list or array's unique key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has unique key, return null value.
        /// </remarks>
        public virtual Map<string, List<string>> UniqueKeys
        {
            get { return null; }
        }

        /// <summary>
        /// Field count. It read from number of enum columns.
        /// </summary>    
        [Browsable(false)]
        public int FieldCount
        {
            get {
                DataTransferObjectAttribute attr = (DataTransferObjectAttribute) this.GetType().GetCustomAttributes(typeof (DataTransferObjectAttribute), false)[0];
                try {
                    return Enum.GetNames(attr.TypeOfEnumColumns).Length;                                
                } catch {
                    return 0;
                }                
            }
        }

        /// <summary>
        /// Check all property that mark FieldNotNull attribute.
        /// </summary>
        /// <returns>Return list of property name which incorrect. If validate has pass it will return empty or null list.</returns>
        public List<string> ValidateFieldNotNull()
        {
            List<string> listError = new List<string>();

            PropertyInfo[] props = this.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++) {
                object[] objs = props[i].GetCustomAttributes(typeof (FieldNotNullAttribute), false);
                if (objs == null || objs.Length < 1)
                    continue;

                NZBaseObject baseObject = props[i].GetValue(this, null) as NZBaseObject;
                if (baseObject == null)
                    continue;

                if (baseObject.IsNull) {
                    listError.Add(props[i].Name);
                }
            }

            return listError;
        }
        #endregion

        #region Get FieldAttribute data.

        /// <summary>
        /// Get field attribute that declare over property
        /// </summary>
        /// <param name="PropertyName">Specific property name want to get field attribute.</param>
        /// <returns>Return null if not found.</returns>
        public FieldAttribute GetFieldAttribute(string PropertyName)
        {
            return FieldAttribute.GetFieldData(this.GetType(), PropertyName);
        }
        #endregion

        /// <summary>
        /// Get DataTransferObject attribute which declare on class.
        /// </summary>
        protected DataTransferObjectAttribute DTOAttribute {
            get {
                object[] objs = this.GetType().GetCustomAttributes(typeof (DataTransferObjectAttribute), false);
                if (objs == null || objs.Length <= 0)
                    return null;
                return objs[0] as DataTransferObjectAttribute;
            }    
        }

        private List<string> FindAllFieldColumns()
        {
            Type enumType = this.DTOAttribute.TypeOfEnumColumns;
            if (enumType == null)
                return null;

            string[] names = Enum.GetNames(enumType);
            List<string> list = new List<string>();
            list.AddRange(names);
            return list;
        }

        #region Implementation of ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        /// <summary>
        /// Clone object to new object
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }

        #endregion
    }
}
