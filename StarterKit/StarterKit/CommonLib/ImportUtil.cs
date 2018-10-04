using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace CommonLib {
    public class ImportUtil 
    {
        /// <summary>
        /// Imports Data from Microsoft Excel File.
        /// </summary>
        /// <param name="FileName">Filename from which data need to import</param>
        /// <param name="IncludeHeader">File contain header at first row</param>
        /// <returns>List of DataTables, based on the number of sheets</returns>
        public static DataTable ImportExcel(string FileName, bool IncludeHeader, int SheetIndex) 
        {
            List<DataTable> _dataTables = new List<DataTable>();
            string _ConnectionString = string.Empty;
            string _Extension = Path.GetExtension(FileName);
            string _IncludeHeader = IncludeHeader ? "Yes" : "No";

            //Checking for the extentions, if XLS connect using Jet OleDB
            if (_Extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase)) {
                _ConnectionString =
                    "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX=1\"";
            }
            //Use ACE OleDb
            else if (_Extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase)) {
                _ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX=1\"";
            }

            DataTable dataTable = null;
            using (OleDbConnection oleDbConnection = new OleDbConnection(string.Format(_ConnectionString, FileName, _IncludeHeader))) {
                oleDbConnection.Open();

                //Getting the meta data information.
                //This DataTable will return the details of Sheets in the Excel File.
                DataTable dbSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);

                foreach (DataRow item in dbSchema.Rows) {
                    //reading data from excel to Data Table
                    using (OleDbCommand oleDbCommand = new OleDbCommand()) {
                        oleDbCommand.Connection = oleDbConnection;
                        oleDbCommand.CommandText = string.Format("SELECT * FROM [{0}]", item["TABLE_NAME"].ToString());
                        using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter()) {
                            oleDbDataAdapter.SelectCommand = oleDbCommand;
                            dataTable = new DataTable(item["TABLE_NAME"].ToString());
                            oleDbDataAdapter.Fill(dataTable);
                            _dataTables.Add(dataTable);
                        }
                    }
                }
            }
            return _dataTables[SheetIndex];
        }

    }
}
