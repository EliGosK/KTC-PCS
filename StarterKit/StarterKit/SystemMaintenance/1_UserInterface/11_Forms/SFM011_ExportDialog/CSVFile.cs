using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SystemMaintenance.Forms
{
    /// <summary>
    /// CSVFile Class
    /// </summary>
    public class CSVFile
    {
        protected string m_strPath;
        protected string m_strFileName;
        protected Encoding m_encoding = Encoding.ASCII;

        public delegate void WriteLineHandler();

        /// <summary>
        /// Occur when write for each line.
        /// </summary>
        public event WriteLineHandler WriteLine;

        /// <summary>
        /// Sign enum
        /// </summary>
        public enum Sign
        {
            WithDBQuote,
            WithOutDBQuote
        }

        /// <summary>
        /// CSVFile Default Constructor
        /// </summary>
        public CSVFile()
        {
            this.m_strPath = string.Empty;
            this.m_strFileName = string.Empty;
        }

        /// <summary>
        /// CSVFile Constructor
        /// </summary>
        /// <param name="strPath">Path</param>
        /// <param name="strFileName">File Name</param>
        public CSVFile(string strPath, string strFileName)
        {
            this.m_strPath = strPath;
            this.m_strFileName = strFileName;
        }

        /// <summary>
        /// CSVFile Constructor
        /// </summary>
        /// <param name="strPath">Path</param>
        /// <param name="strFileName">File Name</param>
        public CSVFile(string strPath, string strFileName, Encoding encoding)
        {
            this.m_strPath = strPath;
            this.m_strFileName = strFileName;
            this.m_encoding = encoding;
        }

        /// <summary>
        /// Check Reading or Writing File Property
        /// </summary>
        public virtual bool IsFoundFile
        {
            get
            {
                try
                {
                    return File.Exists(this.m_strPath + this.m_strFileName + ".csv");
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Read Method
        /// </summary>
        /// <returns>DataTable</returns>
        public virtual DataTable Read()
        {
            //รับค่าไฟล์ csv,txt
            string strConnStr, strSql;
            OleDbConnection conn;
            OleDbCommand command;
            strConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + this.m_strPath + " ;Extended Properties='text;HDR=No;FMT=Delimited'";
            strSql = "select * from " + this.m_strFileName + "";
            conn = new OleDbConnection(strConnStr);
            command = new OleDbCommand(strSql, conn);
            conn.Open();

            // อ่านไฟล์ที่รับมาแล้วนำมาเก็บไว้ใน dataset  
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                da.Fill(ds);
            }
            catch
            {
                return dt;
            }

            //นับจำนวน row และ column
            int iColumn = ds.Tables[0].Columns.Count;
            int iRow = ds.Tables[0].Rows.Count;

            //นำข้อความแต่ละบรรทัดไปเก็บไว้ใน array
            StreamReader rd = new StreamReader(this.m_strPath + this.m_strFileName);
            string[] strLines = rd.ReadToEnd().Split('\n');
            rd.Close();

            //สร้าง dataset เพื่อแสดงไฟล์ csv

            SetColumn(strLines, iRow, iColumn, dt);

            return dt;
        }

        /// <summary>
        /// Set Column Method
        /// </summary>
        /// <param name="strLines">CSV Data</param>
        /// <param name="iRow">Row number</param>
        /// <param name="iColumn">Column number</param>
        /// <param name="dt">DataTable Instance</param>
        protected virtual void SetColumn(string[] strLines, int iRow, int iColumn, DataTable dt)
        {
            int inf = 0;
            int inc = 0;

            //สร้าง column
            for (int j = 0; j < iColumn; j++)
            {
                dt.Columns.Add(j.ToString());
            }

            //สร้าง row
            for (int i = 0; i < iRow; i++)
            {
                DataRow newddRow = dt.NewRow();
                dt.Rows.Add(newddRow);

                //วน loop เพื่อรับค่าแต่ละ column
                for (int j = 0; j < iColumn; j++)
                {

                    //เช็คว่าตัวแรกเป็น , หรือไม่ 
                    if (strLines[i].IndexOf(',') == 0)
                    {
                        dt.Rows[i][j] = "";
                        strLines[i] = strLines[i].Substring(1);
                    }
                    else
                    {
                        inf = strLines[i].IndexOf('"', 1);
                        inc = strLines[i].IndexOf(',', inf + 1);

                        //เช็คว่าตัวแรกเป็น " หรือไม่
                        if (strLines[i].IndexOf('"') == 0)
                        {
                            //เช็คว่าตัวที่ 2,3  เป็น " หรือไม่
                            if (strLines[i].IndexOf('"', 1) == 1 && strLines[i].IndexOf('"', 2) == 2)
                            {
                                //เช็คว่ามี " ตัวต่อไปหรือไม่
                                if (inf != -1)
                                {
                                    //เช็คว่ามี , หรือไม่
                                    if (inc != -1)
                                    {
                                        dt.Rows[i][j] = strLines[i].Substring(inf + 1, inc - inf - 3);
                                        strLines[i] = strLines[i].Substring(inc + 1);
                                    }
                                    else
                                    {
                                        dt.Rows[i][j] = strLines[i];
                                        break;
                                    }
                                }
                                else
                                {
                                    dt.Rows[i][j] = strLines[i].Substring(1);
                                    break;
                                }
                            }

                            //เช็คว่าตัวที่ต่อจาก " เป็น " หรือไม่
                            else if (strLines[i].IndexOf('"', inf + 1) == inf + 1 && strLines[i].IndexOf('"', inf + 2) == inf + 2)
                            {
                                if (inf != -1)
                                {
                                    if (inc != -1)
                                    {
                                        dt.Rows[i][j] = strLines[i].Substring(1, inf - 1) + strLines[i].Substring(inf + 1, inc - inf - 2);
                                        strLines[i] = strLines[i].Substring(inc + 1);
                                    }
                                    else
                                    {
                                        dt.Rows[i][j] = strLines[i];
                                        break;
                                    }
                                }
                                else
                                {
                                    dt.Rows[i][j] = strLines[i].Substring(1);
                                    break;
                                }
                            }
                            else
                            {
                                if (inf != -1)
                                {
                                    if (inc != -1)
                                    {
                                        dt.Rows[i][j] = strLines[i].Substring(1, inf - 1) + strLines[i].Substring(inf + 1, inc - inf - 1);
                                        strLines[i] = strLines[i].Substring(inc + 1);
                                    }
                                    else
                                    {
                                        dt.Rows[i][j] = strLines[i];
                                        break;
                                    }
                                }
                                else
                                {
                                    dt.Rows[i][j] = strLines[i].Substring(1);
                                    break;
                                }
                            }
                        }

                        //เช็คว่ามี , หรือไม่
                        else if (strLines[i].IndexOf(',') == -1)
                        {
                            dt.Rows[i][j] = strLines[i];
                            strLines[i] = strLines[i].Substring(strLines[i].IndexOf(',') + 1);
                            break;
                        }
                        else
                        {
                            dt.Rows[i][j] = strLines[i].Substring(0, strLines[i].IndexOf(','));
                            strLines[i] = strLines[i].Substring(strLines[i].IndexOf(',') + 1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="sign">With Double Quote or Without Double Qoute</param>
        /// <param name="dtWrite">Input Data (DataTable Instance)</param>
        /// <param name="bIsAppened">Append data</param>
        public virtual void Write(Sign sign, string seperator, DataTable dtWrite, bool bIncludeHeader, bool bIsAppened)
        {

            int iRow = dtWrite.Rows.Count;
            int iCol = dtWrite.Columns.Count;
            string[] co = new string[iRow * iCol];
            int c = 0;

            StreamWriter wri = new StreamWriter(Path.Combine(this.m_strPath, this.m_strFileName), bIsAppened, m_encoding);

            if (bIncludeHeader)
            {
                //Write Header Column
                for (int g = 0; g < iCol; g++)
                {
                    if (sign == Sign.WithOutDBQuote)
                    {
                        if (g == iCol - 1)
                        {
                            wri.Write(dtWrite.Columns[g]);
                        }
                        else if (g != iCol)
                        {
                            wri.Write(dtWrite.Columns[g] + seperator);
                        }
                        else
                        {
                            wri.Write('"' + dtWrite.Columns[g].ToString() + '"' + seperator);
                        }
                    }
                    else if (sign == Sign.WithDBQuote)
                    {
                        if (g == iCol - 1)
                        {
                            wri.Write('"' + dtWrite.Columns[g].ToString() + '"');
                        }
                        else
                        {
                            wri.Write('"' + dtWrite.Columns[g].ToString() + '"' + seperator);
                        }
                    }
                }

                //Line Feed
                wri.WriteLine();
            }

            //Loop for write each row
            for (int i = 0; i < iRow; i++)
            {
                for (int j = 0; j < iCol; j++)
                {
                    co[c] = dtWrite.Rows[i][j].ToString();
                    if (j == iCol - 1 && sign == Sign.WithOutDBQuote)
                    {
                        wri.Write(co[c]);
                    }
                    else if (j == iCol - 1 && sign == Sign.WithDBQuote)
                    {
                        co[c] = co[c].Replace("\"", "\"\"");
                        wri.Write('"' + co[c] + '"');
                    }
                    else if (j != iCol && sign == Sign.WithOutDBQuote)
                    {
                        wri.Write(co[c] + seperator);
                    }
                    else
                    {
                        co[c] = co[c].Replace("\"", "\"\"");
                        wri.Write('"' + co[c] + '"' + seperator);
                    }
                    c++;
                }

                //Fire event
                if (WriteLine != null)
                    WriteLine();

                wri.WriteLine();
            }
            wri.Close();
        }

        #region Add new by ASSI.Teerayut

        private void _WriteLine(StreamWriter sw, Sign sign, string seperator, string[] objParameters)
        {
            int iCol = objParameters.Length;
            for (int i = 0; i < iCol; i++)
            {
                if (sign == Sign.WithOutDBQuote)
                {
                    if (i == iCol - 1)
                    {
                        sw.Write(objParameters[i]);
                    }
                    else if (i != iCol)
                    {
                        sw.Write(objParameters[i] + seperator);
                    }
                    else
                    {
                        sw.Write('"' + objParameters[i] + '"' + seperator);
                    }
                }
                else if (sign == Sign.WithDBQuote)
                {
                    if (i == iCol - 1)
                    {
                        sw.Write('"' + objParameters[i] + '"');
                    }
                    else
                    {
                        sw.Write('"' + objParameters[i] + '"' + seperator);
                    }
                }
            }
        }

        public virtual void WriteSpread(Sign sign, string seperator, bool bIncludeHeader, FarPoint.Win.Spread.FpSpread spread)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(this.m_strPath, this.m_strFileName), false, m_encoding);

            //Check and write header line.
            if (bIncludeHeader)
            {
                string[] strColsHeader = new string[spread.ActiveSheet.ColumnCount];
                for (int i = 0; i < spread.ActiveSheet.ColumnCount; i++)
                {
                    strColsHeader[i] = spread.ActiveSheet.Columns[i].Label;
                }
                _WriteLine(sw, sign, seperator, strColsHeader);
                sw.WriteLine();
            }

            for (int i = 0; i < spread.ActiveSheet.RowCount; i++)
            {

                //modify by Bunyapat L. on 29 Jun 2011
                //export เฉพาะ row ที่แสดงผลเท่านั้น
                if (spread.ActiveSheet.GetRowVisible(i))
                {
                    string[] strCols = new string[spread.ActiveSheet.ColumnCount];
                    for (int j = 0; j < spread.ActiveSheet.ColumnCount; j++)
                    {
                        strCols[j] = spread.ActiveSheet.Cells[i, j].Text;
                    }

                    _WriteLine(sw, sign, seperator, strCols);
                    sw.WriteLine();
                }

                //Fire event
                if (WriteLine != null)
                    WriteLine();
            }

            sw.Close();
        }
        #endregion
    }
}
