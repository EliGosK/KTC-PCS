using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace EVOFramework.Data
{
    /// <summary>
    /// Data Transfer Object.
    /// </summary>
    public interface IDataTransferObject
    {
        /// <summary>
        /// Indexing to get/set property value.
        /// </summary>
        /// <param name="propertyName">Property Name. (Case-sensitive)</param>
        /// <returns></returns>
        NZBaseObject this[string propertyName] { get; set; }

        /// <summary>
        /// Return the Table's name mapping.
        /// </summary>
        [Browsable(false)]
        string TableName { get; }

        /// <summary>
        /// Create empty DataTable object with schema.
        /// </summary>
        /// <returns>True if create DataTable finish. Otherwise return false.</returns>
        bool CreateDataTableSchema(out DataTable dataTable);

        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has primary key, return null value.
        /// </remarks>
        [Browsable(false)]
        MapKeyValue<string, List<string>> PrimaryKey { get; }

        /// <summary>
        /// Return list or array's unique key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping not has unique key, return null value.
        /// </remarks>
        [Browsable(false)]
        Map<string, List<string>> UniqueKeys { get; }

        /// <summary>
        /// Get field attribute that declare over property
        /// </summary>
        /// <param name="PropertyName">Specific property name want to get field attribute.</param>
        /// <returns>Return null if not found.</returns>
        FieldAttribute GetFieldAttribute(string PropertyName);

        /// <summary>
        /// Field count.
        /// </summary>
        [Browsable(false)]
        int FieldCount { get; }

        /// <summary>
        /// Check all property that mark FieldNotNull attribute.
        /// </summary>
        /// <returns>Return list of property name which incorrect. If validate has pass it will return empty or null list.</returns>
        List<string> ValidateFieldNotNull();
    }
}
