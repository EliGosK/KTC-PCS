using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;

namespace CommonLib
{
    public class ExportUtil
    {
        private static bool UseVS2010ToBuild = true;



        public enum ExcelFormat
        {
            ACCOUNT_FORMAT,
            CURRENCY_FORMAT,
            TEXT_FORMAT,
            DATE_FORMAT,
            GENERAL_FORMAT,
            NUMBER_FORMAT,
            INTEGER_FORMAT
        }

        private static string[] m_Format;

        public static string[] Format
        {
            get { return m_Format; }
        }

        static ExportUtil()
        {
            m_Format = new string[7];

            m_Format[(int)ExcelFormat.ACCOUNT_FORMAT] = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
            m_Format[(int)ExcelFormat.CURRENCY_FORMAT] = "$#,##0.00_);($#,##0.00)";
            m_Format[(int)ExcelFormat.TEXT_FORMAT] = "@";
            m_Format[(int)ExcelFormat.DATE_FORMAT] = "dd/mmm/yyyy hh:mm";
            m_Format[(int)ExcelFormat.GENERAL_FORMAT] = "General";
            m_Format[(int)ExcelFormat.NUMBER_FORMAT] = "#,##0.0000";
            m_Format[(int)ExcelFormat.INTEGER_FORMAT] = "#,##0";
        }


        //private const string
        //    ACCOUNT_FORMAT = ,
        //    CURRENCY_FORMAT = ,
        //    TEXT_FORMAT = ,
        //    DATE_FORMAT = ,
        //    GENERAL_FORMAT = ,
        //    NUMBER_FORMAT =,
        //    INTEGER_FORMAT = ;

        public static void Export(DataSet dataSet, string templatePath, string outputPath)
        {
            if (templatePath == string.Empty || templatePath == null)
            {
                Export(dataSet, outputPath, m_Format);
            }
            else
            {
                Export(dataSet, templatePath, outputPath, m_Format);
            }

        }

        public static void Export(DataSet dataSet, string outputPath)
        {
            Export(dataSet, outputPath, m_Format);
        }


        /// <summary>
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="outputPath"></param>
        /// <param name="FormatValue">parameter สำหรับเก็บ format ต่างๆ โดยดึงจาก ExportUtil.Format แล้วค่อยมา set</param>
        public static void Export(DataSet dataSet, string outputPath, string[] FormatValue)
        {
            try
            {
                // Create the Excel Application object
                Application excelApp = new Application();

                // Create a new Excel Workbook
                Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);



                int sheetIndex = 0;

                // Copy each DataTable
                foreach (System.Data.DataTable dt in dataSet.Tables)
                {

                    // Copy the DataTable to an object array
                    object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

                    // Copy the column names to the first row of the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        rawData[0, col] = dt.Columns[col].ColumnName;
                    }

                    // Copy the values to the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                        }
                    }

                    // Calculate the final column letter
                    string finalColLetter = string.Empty;
                    string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int colCharsetLen = colCharset.Length;

                    if (dt.Columns.Count > colCharsetLen)
                    {
                        finalColLetter = colCharset.Substring(
                            (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
                    }

                    finalColLetter += colCharset.Substring(
                            (dt.Columns.Count - 1) % colCharsetLen, 1);

                    // Create a new Sheet
                    Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.Add(
                        excelWorkbook.Sheets.get_Item(++sheetIndex),
                        Type.Missing, 1, XlSheetType.xlWorksheet);

                    excelSheet.Name = dt.TableName;

                    Object o = "test";

                    //Set เรื่องของ Format แต่ละ columns ก่อน
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];

                        if (dc.DataType.Equals(typeof(System.Int16))
                            || dc.DataType.Equals(typeof(System.Int32))
                            || dc.DataType.Equals(typeof(System.Int64))
                            )
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.INTEGER_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.INTEGER_FORMAT];

                            }
                        }
                        else if (dc.DataType.Equals(typeof(System.Decimal))
                            || dc.DataType.Equals(typeof(System.Single)) // float
                            || dc.DataType.Equals(typeof(System.Double))
                            )
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.NUMBER_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.NUMBER_FORMAT];
                            }
                        }
                        else if (dc.DataType.Equals(typeof(System.DateTime)))
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.DATE_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.DATE_FORMAT];
                            }
                        }
                        else //(dc.DataType.Equals(typeof(System.String)))
                        {
                            //ไม่ใช่ ตัวเลข , วันที่ ก็ export เป็น text เลย
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.TEXT_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1)], excelSheet.Cells[65535, (i + 1)]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.TEXT_FORMAT];
                            }
                        }


                    }

                    string excelRange = string.Format("A1:{0}{1}",
                        finalColLetter, dt.Rows.Count + 1);

                    if (!UseVS2010ToBuild)
                    {
                        excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;
                        excelSheet.get_Range(excelRange, Type.Missing).Name = dt.TableName;
                    }
                    else
                    {
                        excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;
                        excelSheet.Range[excelRange, Type.Missing].Name = dt.TableName;
                    }



                    // Mark the first row as BOLD
                    ((Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;

                }


                Worksheet sht = null;

                //ลบ Sheet1 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet1"];
                    sht.Delete();
                }
                catch
                {
                }

                //ลบ Sheet2 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet2"];
                    sht.Delete();
                }
                catch
                {
                }

                //ลบ Sheet3 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet3"];
                    sht.Delete();
                }
                catch
                {
                }

                // Save and Close the Workbook
                excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

                //// Release the Application object
                excelApp.Quit();
                excelApp = null;

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            catch (Exception ex)
            {
                if (dataSet != null)
                {
                    StreamWriter excelDoc;

                    excelDoc = new StreamWriter(outputPath);
                    const string startExcelXML = "<xml version>\r\n<Workbook " +
                          "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                          " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                          "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                          "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                          "office:spreadsheet\">\r\n <Styles>\r\n " +
                          "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                          "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                          "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                          "\r\n <Protection/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                          "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                          "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                          " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                          "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                          "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                          "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                          "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                          "ss:Format=\"dd/MMM/yyyy;@\"/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"HeaderColumn\">\r\n " +
                          "<Font ss:Bold=\"1\"/>\r\n " +
                        //"<Interior ss:Color=\"#FFFF99\" ss:Pattern=\"Solid\"/>\r\n " +
                          "</Style>\r\n " +
                          "</Styles>\r\n ";
                    const string endExcelXML = "</Workbook>";

                    int rowCount = 0;
                    int sheetCount = 1;
                    /*
                   <xml version>
                   <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
                   xmlns:o="urn:schemas-microsoft-com:office:office"
                   xmlns:x="urn:schemas-microsoft-com:office:excel"
                   xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
                   <Styles>
                   <Style ss:ID="Default" ss:Name="Normal">
                     <Alignment ss:Vertical="Bottom"/>
                     <Borders/>
                     <Font/>
                     <Interior/>
                     <NumberFormat/>
                     <Protection/>
                   </Style>
                   <Style ss:ID="BoldColumn">
                     <Font x:Family="Swiss" ss:Bold="1"/>
                   </Style>
                   <Style ss:ID="StringLiteral">
                     <NumberFormat ss:Format="@"/>
                   </Style>
                   <Style ss:ID="Decimal">
                     <NumberFormat ss:Format="0.0000"/>
                   </Style>
                   <Style ss:ID="Integer">
                     <NumberFormat ss:Format="0"/>
                   </Style>
                   <Style ss:ID="DateLiteral">
                     <NumberFormat ss:Format="dd/MMM/yyyy;@"/>
                   </Style>
                   <Style ss:ID="HeaderColumn">
                      <Font ss:Bold="1"/>
                      <Interior ss:Color="#FFFF99" ss:Pattern="Solid"/>
                   </Style>
                   </Styles>
                   <Worksheet ss:Name="Sheet1">
                   </Worksheet>
                   </Workbook>
                   */
                    excelDoc.Write(startExcelXML);

                    foreach (System.Data.DataTable source in dataSet.Tables)
                    {

                        excelDoc.Write("<Worksheet ss:Name=\"" + source.TableName + "\">");
                        excelDoc.Write("<Table>");
                        excelDoc.Write("<Row>");
                        for (int x = 0; x < source.Columns.Count; x++)
                        {
                            //excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                            excelDoc.Write("<Cell ss:StyleID=\"HeaderColumn\"><Data ss:Type=\"String\">");
                            excelDoc.Write(source.Columns[x].ColumnName);
                            excelDoc.Write("</Data></Cell>");
                        }
                        excelDoc.Write("</Row>");
                        foreach (DataRow x in source.Rows)
                        {
                            rowCount++;
                            //if the number of rows is > 64000 create a new page to continue output
                            if (rowCount == 64000)
                            {
                                rowCount = 0;
                                sheetCount++;
                                excelDoc.Write("</Table>");
                                excelDoc.Write(" </Worksheet>");
                                excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                                excelDoc.Write("<Table>");
                            }
                            excelDoc.Write("<Row>"); //ID=" + rowCount + "
                            for (int y = 0; y < source.Columns.Count; y++)
                            {
                                System.Type rowType;
                                rowType = x[y].GetType();
                                switch (rowType.ToString())
                                {
                                    case "System.String":
                                        string XMLstring = x[y].ToString();
                                        XMLstring = XMLstring.Trim();
                                        XMLstring = XMLstring.Replace("&", "&");
                                        XMLstring = XMLstring.Replace(">", ">");
                                        XMLstring = XMLstring.Replace("<", "<");
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                       "<Data ss:Type=\"String\">");
                                        excelDoc.Write(XMLstring);
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.DateTime":
                                        //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                        //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                        //The Following Code puts the date stored in XMLDate 
                                        //to the format above
                                        DateTime XMLDate = (DateTime)x[y];
                                        string XMLDatetoString = ""; //Excel Converted Date
                                        XMLDatetoString = XMLDate.Year.ToString() +
                                             "-" +
                                             (XMLDate.Month < 10 ? "0" +
                                             XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                             "-" +
                                             (XMLDate.Day < 10 ? "0" +
                                             XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                             "T" +
                                             (XMLDate.Hour < 10 ? "0" +
                                             XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                             ":" +
                                             (XMLDate.Minute < 10 ? "0" +
                                             XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                             ":" +
                                             (XMLDate.Second < 10 ? "0" +
                                             XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                             ".000";
                                        excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                                     "<Data ss:Type=\"DateTime\">");
                                        excelDoc.Write(XMLDatetoString);
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Boolean":
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                    "<Data ss:Type=\"String\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Int16":
                                    case "System.Int32":
                                    case "System.Int64":
                                    case "System.Byte":
                                        excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                                "<Data ss:Type=\"Number\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Decimal":
                                    case "System.Double":
                                        excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                              "<Data ss:Type=\"Number\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.DBNull":
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                              "<Data ss:Type=\"String\">");
                                        excelDoc.Write("");
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    default:
                                        throw (new Exception(rowType.ToString() + " not handled."));
                                }
                            }
                            excelDoc.Write("</Row>");
                        }
                        excelDoc.Write("</Table>");
                        excelDoc.Write(" </Worksheet>");

                        //sheetCount++;
                    }
                    excelDoc.Write(endExcelXML);
                    excelDoc.Close();
                }

            }
        }


        public static void Export(DataSet dataSet, string templatePath, string outputPath, string[] FormatValue)
        {
            if (templatePath == string.Empty || templatePath == null)
            {
                Export(dataSet, outputPath, FormatValue);
            }
            else
            {
                try
                {
                    // Create the Excel Application object
                    Application excelApp = new Application();

                    // Create a new Excel Workbook
                    Workbook excelWorkbook = excelApp.Workbooks.Add(templatePath);

                    int sheetIndex = 0;

                    // Copy each DataTable
                    foreach (System.Data.DataTable dt in dataSet.Tables)
                    {

                        // Copy the DataTable to an object array
                        object[,] rawData = new object[dt.Rows.Count, dt.Columns.Count];

                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            for (int row = 0; row < dt.Rows.Count; row++)
                            {
                                rawData[row, col] = dt.Rows[row].ItemArray[col];
                            }
                        }

                        // Calculate the final column letter
                        string finalColLetter = string.Empty;
                        string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        int colCharsetLen = colCharset.Length;

                        if (dt.Columns.Count > colCharsetLen)
                        {
                            finalColLetter = colCharset.Substring(
                                (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
                        }

                        finalColLetter += colCharset.Substring(
                                (dt.Columns.Count - 1) % colCharsetLen, 1);

                        // Create a new Sheet
                        Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.get_Item(++sheetIndex);

                        // Fast data export to Excel
                        string excelRange = string.Format("A2:{0}{1}",
                            finalColLetter, dt.Rows.Count + 1);

                        if (!UseVS2010ToBuild)
                        {
                            excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;
                            excelSheet.get_Range(excelRange, Type.Missing).Name = dt.TableName;
                        }
                        else
                        {
                            excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;
                            excelSheet.Range[excelRange, Type.Missing].Name = dt.TableName;
                        }
                    }


                    // Save and Close the Workbook
                    excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    excelWorkbook.Close(true, Type.Missing, Type.Missing);
                    excelWorkbook = null;

                    //// Release the Application object
                    excelApp.Quit();
                    excelApp = null;

                    // Collect the unreferenced objects
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                catch (Exception ex)
                {
                    if (dataSet != null)
                    {
                        StreamWriter excelDoc;

                        excelDoc = new StreamWriter(outputPath);
                        const string startExcelXML = "<xml version>\r\n<Workbook " +
                              "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                              " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                              "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                              "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                              "office:spreadsheet\">\r\n <Styles>\r\n " +
                              "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                              "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                              "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                              "\r\n <Protection/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                              "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                              "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                              " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                              "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                              "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                              "ss:Format=\"dd/MMM/yyyy;@\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"HeaderColumn\">\r\n " +
                              "<Font ss:Bold=\"1\"/>\r\n " +
                            //"<Interior ss:Color=\"#FFFF99\" ss:Pattern=\"Solid\"/>\r\n " +
                              "</Style>\r\n " +
                              "</Styles>\r\n ";
                        const string endExcelXML = "</Workbook>";

                        int rowCount = 0;
                        int sheetCount = 1;

                        excelDoc.Write(startExcelXML);

                        foreach (System.Data.DataTable source in dataSet.Tables)
                        {

                            excelDoc.Write("<Worksheet ss:Name=\"" + source.TableName + "\">");
                            excelDoc.Write("<Table>");
                            excelDoc.Write("<Row>");
                            for (int x = 0; x < source.Columns.Count; x++)
                            {
                                //excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write("<Cell ss:StyleID=\"HeaderColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write(source.Columns[x].ColumnName);
                                excelDoc.Write("</Data></Cell>");
                            }
                            excelDoc.Write("</Row>");
                            foreach (DataRow x in source.Rows)
                            {
                                rowCount++;
                                //if the number of rows is > 64000 create a new page to continue output
                                if (rowCount == 64000)
                                {
                                    rowCount = 0;
                                    sheetCount++;
                                    excelDoc.Write("</Table>");
                                    excelDoc.Write(" </Worksheet>");
                                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                                    excelDoc.Write("<Table>");
                                }
                                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                                for (int y = 0; y < source.Columns.Count; y++)
                                {
                                    System.Type rowType;
                                    rowType = x[y].GetType();
                                    switch (rowType.ToString())
                                    {
                                        case "System.String":
                                            string XMLstring = x[y].ToString();
                                            XMLstring = XMLstring.Trim();
                                            XMLstring = XMLstring.Replace("&", "&");
                                            XMLstring = XMLstring.Replace(">", ">");
                                            XMLstring = XMLstring.Replace("<", "<");
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                           "<Data ss:Type=\"String\">");
                                            excelDoc.Write(XMLstring);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DateTime":
                                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                            //The Following Code puts the date stored in XMLDate 
                                            //to the format above
                                            DateTime XMLDate = (DateTime)x[y];
                                            string XMLDatetoString = ""; //Excel Converted Date
                                            XMLDatetoString = XMLDate.Year.ToString() +
                                                 "-" +
                                                 (XMLDate.Month < 10 ? "0" +
                                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                                 "-" +
                                                 (XMLDate.Day < 10 ? "0" +
                                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                                 "T" +
                                                 (XMLDate.Hour < 10 ? "0" +
                                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                                 ":" +
                                                 (XMLDate.Minute < 10 ? "0" +
                                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                                 ":" +
                                                 (XMLDate.Second < 10 ? "0" +
                                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                                 ".000";
                                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                                         "<Data ss:Type=\"DateTime\">");
                                            excelDoc.Write(XMLDatetoString);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Boolean":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                        "<Data ss:Type=\"String\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Int16":
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Byte":
                                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                                    "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Decimal":
                                        case "System.Double":
                                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                                  "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DBNull":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                  "<Data ss:Type=\"String\">");
                                            excelDoc.Write("");
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        default:
                                            throw (new Exception(rowType.ToString() + " not handled."));
                                    }
                                }
                                excelDoc.Write("</Row>");
                            }
                            excelDoc.Write("</Table>");
                            excelDoc.Write(" </Worksheet>");

                            //sheetCount++;
                        }
                        excelDoc.Write(endExcelXML);
                        excelDoc.Close();
                    }

                }
            }


        }



        public static void Export(DataSet dataSet, string outputPath, string[] FormatValue, int StartCol, int StartRow)
        {
            try
            {
                // Create the Excel Application object
                Application excelApp = new Application();

                // Create a new Excel Workbook
                Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);



                int sheetIndex = 0;

                // Copy each DataTable
                foreach (System.Data.DataTable dt in dataSet.Tables)
                {

                    // Copy the DataTable to an object array
                    object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

                    // Copy the column names to the first row of the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        rawData[0, col] = dt.Columns[col].ColumnName;
                    }

                    // Copy the values to the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                        }
                    }

                    // Calculate the final column letter
                    string finalColLetter = string.Empty;
                    string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int colCharsetLen = colCharset.Length;

                    if (dt.Columns.Count + StartCol > colCharsetLen)
                    {
                        finalColLetter = colCharset.Substring(
                            (dt.Columns.Count + StartCol - 1) / colCharsetLen - 1, 1); // (1)
                    }

                    finalColLetter += colCharset.Substring(
                            (dt.Columns.Count + StartCol - 1) % colCharsetLen, 1); // (2)

                    string startColLetter = colCharset.Substring(StartCol, 1); //(3)



                    // Create a new Sheet
                    Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.Add(
                        excelWorkbook.Sheets.get_Item(++sheetIndex),
                        Type.Missing, 1, XlSheetType.xlWorksheet);

                    excelSheet.Name = dt.TableName;

                    //Set เรื่องของ Format แต่ละ columns ก่อน
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];

                        if (dc.DataType.Equals(typeof(System.Int16))
                            || dc.DataType.Equals(typeof(System.Int32))
                            || dc.DataType.Equals(typeof(System.Int64))
                            )
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.INTEGER_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.INTEGER_FORMAT];

                            }
                        }
                        else if (dc.DataType.Equals(typeof(System.Decimal))
                            || dc.DataType.Equals(typeof(System.Single)) // float
                            || dc.DataType.Equals(typeof(System.Double))
                            )
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.NUMBER_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.NUMBER_FORMAT];
                            }
                        }
                        else if (dc.DataType.Equals(typeof(System.DateTime)))
                        {
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.DATE_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.DATE_FORMAT];
                            }
                        }
                        else //(dc.DataType.Equals(typeof(System.String)))
                        {
                            //ไม่ใช่ ตัวเลข , วันที่ ก็ export เป็น text เลย
                            if (!UseVS2010ToBuild)
                            {
                                excelSheet.get_Range(excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]).EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.TEXT_FORMAT];
                            }
                            else
                            {
                                excelSheet.Range[excelSheet.Cells[1, (i + 1) + StartCol], excelSheet.Cells[65535, (i + 1) + StartCol]].EntireColumn.NumberFormat = FormatValue[(int)ExcelFormat.TEXT_FORMAT];
                            }
                        }


                    }

                    //DataColumnCollection dcc = dt.Columns;

                    //if(dcc[0].AutoIncrement || dcc[0]



                    //                    Sheets("Sheet3").Select
                    //ActiveWindow.SelectedSheets.Delete


                    // Fast data export to Excel
                    string excelRange = string.Format("{0}{1}:{2}{3}",
                        startColLetter, StartRow + 1,
                        finalColLetter, dt.Rows.Count + StartRow + 1); //(4)

                    if (!UseVS2010ToBuild)
                    {
                        excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;
                        excelSheet.get_Range(excelRange, Type.Missing).Name = dt.TableName;
                    }
                    else
                    {
                        excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;
                        excelSheet.Range[excelRange, Type.Missing].Name = dt.TableName;
                    }

                    // Mark the first row as BOLD
                    ((Range)excelSheet.Rows[StartRow + 1, Type.Missing]).Font.Bold = true;

                }


                Worksheet sht = null;

                //ลบ Sheet1 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet1"];
                    sht.Delete();
                }
                catch
                {
                }

                //ลบ Sheet2 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet2"];
                    sht.Delete();
                }
                catch
                {
                }

                //ลบ Sheet3 ที่มากับ Excel
                try
                {
                    sht = (Worksheet)excelWorkbook.Sheets["Sheet3"];
                    sht.Delete();
                }
                catch
                {
                }

                // Save and Close the Workbook
                excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

                //// Release the Application object
                excelApp.Quit();
                excelApp = null;

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            catch (Exception ex)
            {
                if (dataSet != null)
                {
                    StreamWriter excelDoc;

                    excelDoc = new StreamWriter(outputPath);
                    const string startExcelXML = "<xml version>\r\n<Workbook " +
                          "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                          " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                          "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                          "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                          "office:spreadsheet\">\r\n <Styles>\r\n " +
                          "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                          "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                          "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                          "\r\n <Protection/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                          "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                          "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                          " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                          "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                          "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                          "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                          "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                          "ss:Format=\"dd/MMM/yyyy;@\"/>\r\n </Style>\r\n " +
                          "<Style ss:ID=\"HeaderColumn\">\r\n " +
                          "<Font ss:Bold=\"1\"/>\r\n " +
                        //"<Interior ss:Color=\"#FFFF99\" ss:Pattern=\"Solid\"/>\r\n " +
                          "</Style>\r\n " +
                          "</Styles>\r\n ";
                    const string endExcelXML = "</Workbook>";

                    int rowCount = 0;
                    int sheetCount = 1;
                    /*
                   <xml version>
                   <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
                   xmlns:o="urn:schemas-microsoft-com:office:office"
                   xmlns:x="urn:schemas-microsoft-com:office:excel"
                   xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
                   <Styles>
                   <Style ss:ID="Default" ss:Name="Normal">
                     <Alignment ss:Vertical="Bottom"/>
                     <Borders/>
                     <Font/>
                     <Interior/>
                     <NumberFormat/>
                     <Protection/>
                   </Style>
                   <Style ss:ID="BoldColumn">
                     <Font x:Family="Swiss" ss:Bold="1"/>
                   </Style>
                   <Style ss:ID="StringLiteral">
                     <NumberFormat ss:Format="@"/>
                   </Style>
                   <Style ss:ID="Decimal">
                     <NumberFormat ss:Format="0.0000"/>
                   </Style>
                   <Style ss:ID="Integer">
                     <NumberFormat ss:Format="0"/>
                   </Style>
                   <Style ss:ID="DateLiteral">
                     <NumberFormat ss:Format="dd/MMM/yyyy;@"/>
                   </Style>
                   <Style ss:ID="HeaderColumn">
                      <Font ss:Bold="1"/>
                      <Interior ss:Color="#FFFF99" ss:Pattern="Solid"/>
                   </Style>
                   </Styles>
                   <Worksheet ss:Name="Sheet1">
                   </Worksheet>
                   </Workbook>
                   */
                    excelDoc.Write(startExcelXML);

                    foreach (System.Data.DataTable source in dataSet.Tables)
                    {

                        excelDoc.Write("<Worksheet ss:Name=\"" + source.TableName + "\">");
                        excelDoc.Write("<Table>");
                        excelDoc.Write("<Row>");
                        for (int x = 0; x < source.Columns.Count; x++)
                        {
                            //excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                            excelDoc.Write("<Cell ss:StyleID=\"HeaderColumn\"><Data ss:Type=\"String\">");
                            excelDoc.Write(source.Columns[x].ColumnName);
                            excelDoc.Write("</Data></Cell>");
                        }
                        excelDoc.Write("</Row>");
                        foreach (DataRow x in source.Rows)
                        {
                            rowCount++;
                            //if the number of rows is > 64000 create a new page to continue output
                            if (rowCount == 64000)
                            {
                                rowCount = 0;
                                sheetCount++;
                                excelDoc.Write("</Table>");
                                excelDoc.Write(" </Worksheet>");
                                excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                                excelDoc.Write("<Table>");
                            }
                            excelDoc.Write("<Row>"); //ID=" + rowCount + "
                            for (int y = 0; y < source.Columns.Count; y++)
                            {
                                System.Type rowType;
                                rowType = x[y].GetType();
                                switch (rowType.ToString())
                                {
                                    case "System.String":
                                        string XMLstring = x[y].ToString();
                                        XMLstring = XMLstring.Trim();
                                        XMLstring = XMLstring.Replace("&", "&");
                                        XMLstring = XMLstring.Replace(">", ">");
                                        XMLstring = XMLstring.Replace("<", "<");
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                       "<Data ss:Type=\"String\">");
                                        excelDoc.Write(XMLstring);
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.DateTime":
                                        //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                        //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                        //The Following Code puts the date stored in XMLDate 
                                        //to the format above
                                        DateTime XMLDate = (DateTime)x[y];
                                        string XMLDatetoString = ""; //Excel Converted Date
                                        XMLDatetoString = XMLDate.Year.ToString() +
                                             "-" +
                                             (XMLDate.Month < 10 ? "0" +
                                             XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                             "-" +
                                             (XMLDate.Day < 10 ? "0" +
                                             XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                             "T" +
                                             (XMLDate.Hour < 10 ? "0" +
                                             XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                             ":" +
                                             (XMLDate.Minute < 10 ? "0" +
                                             XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                             ":" +
                                             (XMLDate.Second < 10 ? "0" +
                                             XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                             ".000";
                                        excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                                     "<Data ss:Type=\"DateTime\">");
                                        excelDoc.Write(XMLDatetoString);
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Boolean":
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                    "<Data ss:Type=\"String\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Int16":
                                    case "System.Int32":
                                    case "System.Int64":
                                    case "System.Byte":
                                        excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                                "<Data ss:Type=\"Number\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.Decimal":
                                    case "System.Double":
                                        excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                              "<Data ss:Type=\"Number\">");
                                        excelDoc.Write(x[y].ToString());
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    case "System.DBNull":
                                        excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                              "<Data ss:Type=\"String\">");
                                        excelDoc.Write("");
                                        excelDoc.Write("</Data></Cell>");
                                        break;
                                    default:
                                        throw (new Exception(rowType.ToString() + " not handled."));
                                }
                            }
                            excelDoc.Write("</Row>");
                        }
                        excelDoc.Write("</Table>");
                        excelDoc.Write(" </Worksheet>");

                        //sheetCount++;
                    }
                    excelDoc.Write(endExcelXML);
                    excelDoc.Close();
                }

            }
        }


        public static void Export(DataSet dataSet, string templatePath, string outputPath, string[] FormatValue, int StartCol, int StartRow)
        {
            if (templatePath == string.Empty || templatePath == null)
            {
                Export(dataSet, outputPath, FormatValue, StartCol, StartRow);
            }
            else
            {
                try
                {
                    // Create the Excel Application object
                    Application excelApp = new Application();

                    // Create a new Excel Workbook
                    Workbook excelWorkbook = excelApp.Workbooks.Add(templatePath);

                    int sheetIndex = 0;

                    // Copy each DataTable
                    foreach (System.Data.DataTable dt in dataSet.Tables)
                    {

                        // Copy the DataTable to an object array
                        object[,] rawData = new object[dt.Rows.Count, dt.Columns.Count];

                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            for (int row = 0; row < dt.Rows.Count; row++)
                            {
                                rawData[row, col] = dt.Rows[row].ItemArray[col];
                            }
                        }

                        // Calculate the final column letter
                        string finalColLetter = string.Empty;
                        string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        int colCharsetLen = colCharset.Length;

                        if (dt.Columns.Count + StartCol > colCharsetLen)
                        {
                            finalColLetter = colCharset.Substring(
                                (dt.Columns.Count + StartCol - 1) / colCharsetLen - 1, 1); // (1)
                        }

                        finalColLetter += colCharset.Substring(
                                (dt.Columns.Count + StartCol - 1) % colCharsetLen, 1); // (2)

                        string startColLetter = colCharset.Substring(StartCol, 1); // (3)

                        // Create a new Sheet
                        Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.get_Item(++sheetIndex);

                        // Fast data export to Excel
                        string excelRange = string.Format("{0}{1}:{2}{3}",
                            startColLetter, StartRow + 1,
                            finalColLetter, dt.Rows.Count + StartRow); //(4)

                        if (!UseVS2010ToBuild)
                        {
                            excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;
                            excelSheet.get_Range(excelRange, Type.Missing).Name = dt.TableName;
                        }
                        else
                        {
                            excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;
                            excelSheet.Range[excelRange, Type.Missing].Name = dt.TableName;
                        }

                    }


                    // Save and Close the Workbook
                    excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    excelWorkbook.Close(true, Type.Missing, Type.Missing);
                    excelWorkbook = null;

                    //// Release the Application object
                    excelApp.Quit();
                    excelApp = null;

                    // Collect the unreferenced objects
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                catch (Exception ex)
                {
                    if (dataSet != null)
                    {
                        StreamWriter excelDoc;

                        excelDoc = new StreamWriter(outputPath);
                        const string startExcelXML = "<xml version>\r\n<Workbook " +
                              "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                              " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                              "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                              "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                              "office:spreadsheet\">\r\n <Styles>\r\n " +
                              "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                              "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                              "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                              "\r\n <Protection/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                              "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                              "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                              " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                              "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                              "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                              "ss:Format=\"dd/MMM/yyyy;@\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"HeaderColumn\">\r\n " +
                              "<Font ss:Bold=\"1\"/>\r\n " +
                            //"<Interior ss:Color=\"#FFFF99\" ss:Pattern=\"Solid\"/>\r\n " +
                              "</Style>\r\n " +
                              "</Styles>\r\n ";
                        const string endExcelXML = "</Workbook>";

                        int rowCount = 0;
                        int sheetCount = 1;

                        excelDoc.Write(startExcelXML);

                        foreach (System.Data.DataTable source in dataSet.Tables)
                        {

                            excelDoc.Write("<Worksheet ss:Name=\"" + source.TableName + "\">");
                            excelDoc.Write("<Table>");
                            excelDoc.Write("<Row>");
                            for (int x = 0; x < source.Columns.Count; x++)
                            {
                                //excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write("<Cell ss:StyleID=\"HeaderColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write(source.Columns[x].ColumnName);
                                excelDoc.Write("</Data></Cell>");
                            }
                            excelDoc.Write("</Row>");
                            foreach (DataRow x in source.Rows)
                            {
                                rowCount++;
                                //if the number of rows is > 64000 create a new page to continue output
                                if (rowCount == 64000)
                                {
                                    rowCount = 0;
                                    sheetCount++;
                                    excelDoc.Write("</Table>");
                                    excelDoc.Write(" </Worksheet>");
                                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                                    excelDoc.Write("<Table>");
                                }
                                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                                for (int y = 0; y < source.Columns.Count; y++)
                                {
                                    System.Type rowType;
                                    rowType = x[y].GetType();
                                    switch (rowType.ToString())
                                    {
                                        case "System.String":
                                            string XMLstring = x[y].ToString();
                                            XMLstring = XMLstring.Trim();
                                            XMLstring = XMLstring.Replace("&", "&");
                                            XMLstring = XMLstring.Replace(">", ">");
                                            XMLstring = XMLstring.Replace("<", "<");
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                           "<Data ss:Type=\"String\">");
                                            excelDoc.Write(XMLstring);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DateTime":
                                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                            //The Following Code puts the date stored in XMLDate 
                                            //to the format above
                                            DateTime XMLDate = (DateTime)x[y];
                                            string XMLDatetoString = ""; //Excel Converted Date
                                            XMLDatetoString = XMLDate.Year.ToString() +
                                                 "-" +
                                                 (XMLDate.Month < 10 ? "0" +
                                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                                 "-" +
                                                 (XMLDate.Day < 10 ? "0" +
                                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                                 "T" +
                                                 (XMLDate.Hour < 10 ? "0" +
                                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                                 ":" +
                                                 (XMLDate.Minute < 10 ? "0" +
                                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                                 ":" +
                                                 (XMLDate.Second < 10 ? "0" +
                                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                                 ".000";
                                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                                         "<Data ss:Type=\"DateTime\">");
                                            excelDoc.Write(XMLDatetoString);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Boolean":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                        "<Data ss:Type=\"String\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Int16":
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Byte":
                                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                                    "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Decimal":
                                        case "System.Double":
                                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                                  "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DBNull":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                  "<Data ss:Type=\"String\">");
                                            excelDoc.Write("");
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        default:
                                            throw (new Exception(rowType.ToString() + " not handled."));
                                    }
                                }
                                excelDoc.Write("</Row>");
                            }
                            excelDoc.Write("</Table>");
                            excelDoc.Write(" </Worksheet>");

                            //sheetCount++;
                        }
                        excelDoc.Write(endExcelXML);
                        excelDoc.Close();
                    }

                }
            }
        }



        public static void ExportDeliverySchedule(DataSet dataSet, string templatePath, string outputPath, string[] FormatValue, int StartCol, int StartRow, int templateRow)
        {
            if (templatePath == string.Empty || templatePath == null)
            {
                Export(dataSet, outputPath, FormatValue, StartCol, StartRow);
            }
            else
            {
                try
                {
                    // Create the Excel Application object
                    Application excelApp = new Application();

                    // Create a new Excel Workbook
                    Workbook excelWorkbook = excelApp.Workbooks.Add(templatePath);

                    int sheetIndex = 0;

                    // Copy each DataTable
                    foreach (System.Data.DataTable dt in dataSet.Tables)
                    {

                        // Copy the DataTable to an object array
                        object[,] rawData = new object[dt.Rows.Count, dt.Columns.Count];

                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            for (int row = 0; row < dt.Rows.Count; row++)
                            {
                                rawData[row, col] = dt.Rows[row].ItemArray[col];
                            }
                        }

                        // Calculate the final column letter
                        string finalColLetter = string.Empty;
                        string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        int colCharsetLen = colCharset.Length;

                        if (dt.Columns.Count > colCharsetLen)
                        {
                            finalColLetter = colCharset.Substring(
                                (dt.Columns.Count + StartCol - 1) / colCharsetLen - 1, 1); // (1)
                        }

                        finalColLetter += colCharset.Substring(
                                (dt.Columns.Count + StartCol - 1) % colCharsetLen, 1); // (2)

                        string startColLetter = colCharset.Substring(StartCol, 1); // (3)

                        // Create a new Sheet
                        Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.get_Item(++sheetIndex);

                        // Fast data export to Excel
                        string excelRange = string.Format("{0}{1}:{2}{3}",
                            startColLetter, StartRow + 1,
                            finalColLetter, dt.Rows.Count + StartRow); //(4)

                        if (!UseVS2010ToBuild)
                        {
                            excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle
                             = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.get_Range(excelRange, Type.Missing).Name = dt.TableName;
                        }
                        else
                        {
                            excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle
                                = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle
                             = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.Range[excelRange, Type.Missing].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight
                                = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                            excelSheet.Range[excelRange, Type.Missing].Name = dt.TableName;
                        }
                    }


                    // Save and Close the Workbook
                    excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    excelWorkbook.Close(true, Type.Missing, Type.Missing);
                    excelWorkbook = null;

                    //// Release the Application object
                    excelApp.Quit();
                    excelApp = null;

                    // Collect the unreferenced objects
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                catch (Exception ex)
                {
                    if (dataSet != null)
                    {
                        StreamWriter excelDoc;

                        excelDoc = new StreamWriter(outputPath);
                        const string startExcelXML = "<xml version>\r\n<Workbook " +
                              "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                              " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                              "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                              "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                              "office:spreadsheet\">\r\n <Styles>\r\n " +
                              "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                              "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                              "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                              "\r\n <Protection/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                              "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                              "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                              " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                              "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                              "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                              "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                              "ss:Format=\"dd/MMM/yyyy;@\"/>\r\n </Style>\r\n " +
                              "<Style ss:ID=\"HeaderColumn\">\r\n " +
                              "<Font ss:Bold=\"1\"/>\r\n " +
                            //"<Interior ss:Color=\"#FFFF99\" ss:Pattern=\"Solid\"/>\r\n " +
                              "</Style>\r\n " +
                              "</Styles>\r\n ";
                        const string endExcelXML = "</Workbook>";

                        int rowCount = 0;
                        int sheetCount = 1;

                        excelDoc.Write(startExcelXML);

                        foreach (System.Data.DataTable source in dataSet.Tables)
                        {

                            excelDoc.Write("<Worksheet ss:Name=\"" + source.TableName + "\">");
                            excelDoc.Write("<Table>");
                            excelDoc.Write("<Row>");
                            for (int x = 0; x < source.Columns.Count; x++)
                            {
                                //excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write("<Cell ss:StyleID=\"HeaderColumn\"><Data ss:Type=\"String\">");
                                excelDoc.Write(source.Columns[x].ColumnName);
                                excelDoc.Write("</Data></Cell>");
                            }
                            excelDoc.Write("</Row>");
                            foreach (DataRow x in source.Rows)
                            {
                                rowCount++;
                                //if the number of rows is > 64000 create a new page to continue output
                                if (rowCount == 64000)
                                {
                                    rowCount = 0;
                                    sheetCount++;
                                    excelDoc.Write("</Table>");
                                    excelDoc.Write(" </Worksheet>");
                                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                                    excelDoc.Write("<Table>");
                                }
                                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                                for (int y = 0; y < source.Columns.Count; y++)
                                {
                                    System.Type rowType;
                                    rowType = x[y].GetType();
                                    switch (rowType.ToString())
                                    {
                                        case "System.String":
                                            string XMLstring = x[y].ToString();
                                            XMLstring = XMLstring.Trim();
                                            XMLstring = XMLstring.Replace("&", "&");
                                            XMLstring = XMLstring.Replace(">", ">");
                                            XMLstring = XMLstring.Replace("<", "<");
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                           "<Data ss:Type=\"String\">");
                                            excelDoc.Write(XMLstring);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DateTime":
                                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                            //The Following Code puts the date stored in XMLDate 
                                            //to the format above
                                            DateTime XMLDate = (DateTime)x[y];
                                            string XMLDatetoString = ""; //Excel Converted Date
                                            XMLDatetoString = XMLDate.Year.ToString() +
                                                 "-" +
                                                 (XMLDate.Month < 10 ? "0" +
                                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                                 "-" +
                                                 (XMLDate.Day < 10 ? "0" +
                                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                                 "T" +
                                                 (XMLDate.Hour < 10 ? "0" +
                                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                                 ":" +
                                                 (XMLDate.Minute < 10 ? "0" +
                                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                                 ":" +
                                                 (XMLDate.Second < 10 ? "0" +
                                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                                 ".000";
                                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                                         "<Data ss:Type=\"DateTime\">");
                                            excelDoc.Write(XMLDatetoString);
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Boolean":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                        "<Data ss:Type=\"String\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Int16":
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Byte":
                                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                                    "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.Decimal":
                                        case "System.Double":
                                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                                  "<Data ss:Type=\"Number\">");
                                            excelDoc.Write(x[y].ToString());
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        case "System.DBNull":
                                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                                  "<Data ss:Type=\"String\">");
                                            excelDoc.Write("");
                                            excelDoc.Write("</Data></Cell>");
                                            break;
                                        default:
                                            throw (new Exception(rowType.ToString() + " not handled."));
                                    }
                                }
                                excelDoc.Write("</Row>");
                            }
                            excelDoc.Write("</Table>");
                            excelDoc.Write(" </Worksheet>");

                            //sheetCount++;
                        }
                        excelDoc.Write(endExcelXML);
                        excelDoc.Close();
                    }

                }
            }
        }



    }
}
