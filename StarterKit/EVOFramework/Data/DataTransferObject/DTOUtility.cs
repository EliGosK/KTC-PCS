using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EVOFramework.Data
{
    public static class DTOUtility
    {
        #region " Parse / Format between DataTable and DTO "
        /// <summary>
        /// Convert DataTransferObject to DataTable. It will copy value in property that declare FieldAttribute to new DataTable.
        /// </summary>
        /// <typeparam name="T">Type of IDataTransferObject</typeparam>
        /// <param name="list">List of DTO which will convert.</param>
        /// <returns>Return null if cannot convert.</returns>
        public static DataTable ConvertListToDataTable<T>(List<T> list) where T : IDataTransferObject
        {
            // Create object given DTO.
            Type typeOfDTO = typeof(T);
            object instance = Activator.CreateInstance(typeOfDTO);
            IDataTransferObject dto = (IDataTransferObject)instance;

            // Create schema of DataTable
            DataTable dataTable = null;
            bool bResult = dto.CreateDataTableSchema(out dataTable);
            if (bResult == false || dataTable == null)
            {
                return null;
            }

            // Dump rows.
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    DataRow row = dataTable.NewRow();

                    // Copy column.
                    for (int iCol = 0; iCol < dataTable.Columns.Count; iCol++)
                    {

                        if (list[i][dataTable.Columns[iCol].ColumnName] == null)
                        {
                            throw new Exception("Please declare " + dataTable.Columns[iCol].ColumnName + " in DTO " + typeOfDTO.Name);
                        }

                        row[iCol] = list[i][dataTable.Columns[iCol].ColumnName].Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Convert DataTable to DataTransferObject. It will copy value on DataTable to each field on DTO.
        /// </summary>
        /// <typeparam name="T">Type of IDataTransferObject which convert to.</typeparam>
        /// <param name="dataTable">Source DataTable.</param>
        /// <returns>List of DTO.</returns>
        public static List<T> ConvertDataTableToList<T>(DataTable dataTable) where T : IDataTransferObject
        {
            List<T> list = new List<T>();
            if (dataTable == null)
                return list;

            DataColumnCollection columns = dataTable.Columns;



            for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
            {
                IDataTransferObject dtoInstance = (IDataTransferObject)Activator.CreateInstance(typeof(T));

                for (int i = 0; i < columns.Count; i++)
                {
                    try
                    {
                        //dto = null => did not declare properts
                        if (dtoInstance[columns[i].ColumnName] == null)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("Property name: {0} does not declare in class {1}",columns[i].ColumnName,typeof(T).FullName));
                            continue;
                        }

                        // Copy value from dataTable to DTO.
                        if (dataTable.Rows[iRow].RowState == DataRowState.Deleted)
                            dtoInstance[columns[i].ColumnName].Value = dataTable.Rows[iRow][i, DataRowVersion.Original];
                        else
                            dtoInstance[columns[i].ColumnName].Value = dataTable.Rows[iRow][i];
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err.Message + ", " + err.Source);
                    }
                }

                list.Add((T)dtoInstance);
            }
            return list;
        }

        /// <summary>
        /// Convert DataRow object to DTO object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ConvertDataRowToDTO<T>(DataRow row) where T : IDataTransferObject
        {
            DataColumnCollection columns = row.Table.Columns;
            IDataTransferObject dtoInstance = (IDataTransferObject)Activator.CreateInstance(typeof(T));
            for (int i = 0; i < columns.Count; i++)
            {
                try
                {
                    // Copy value from dataTable to DTO.
                    dtoInstance[columns[i].ColumnName].Value = row[i];
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err.Message + ", Column: " + columns[i].ColumnName);
                }
            }

            return (T)dtoInstance;
        }
        #endregion

        /// <summary>
        /// Read attribute DataTransferObject of class.
        /// </summary>
        /// <param name="typeOfDTOClass">Type of DTO Class.</param>
        /// <returns>Return null if cannot found attribute.</returns>
        public static DataTransferObjectAttribute ReadDTOAttribute(Type typeOfDTOClass)
        {
            object[] objs = typeOfDTOClass.GetCustomAttributes(typeof(DataTransferObjectAttribute), false);
            if (objs.Length <= 0)
            {
                return null;
            }

            return objs[0] as DataTransferObjectAttribute;
        }
        /// <summary>
        /// Read TableName on DataTransferObject attribute of the given DTO Class.
        /// </summary>
        /// <param name="typeOfDTOClass">Type of DTO Class.</param>
        /// <returns></returns>
        public static string ReadTableName(Type typeOfDTOClass)
        {
            DataTransferObjectAttribute attr = ReadDTOAttribute(typeOfDTOClass);
            if (attr != null)
                return attr.TableName;

            return String.Empty;
        }
    }
}
