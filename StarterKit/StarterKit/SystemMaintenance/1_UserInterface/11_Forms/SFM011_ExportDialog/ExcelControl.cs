/* Created date : 2008/09/30
 * Created by : Mr.Teerayut Sinlan 
 * Department : SI-JE2 ASSI
 * 
 * Record of change -------------------
 * 2008/09/30
 *   Create and implement class.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace SystemMaintenance.Forms
{
    public class ExcelControl : IDisposable
    {
        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, ref IntPtr lpdwProcessId);

        #region Variables
        private object oMissing = System.Reflection.Missing.Value;
        private object oTrue = (object)true;
        private object oFalse = (object)false;
        private Application m_objExcel = null;

        private object[,] rawData = null;

        private int m_headerRowCount = 1;
        private int m_dataRowCount = 0;
        private int m_dataColCount = 0;

        #endregion

        #region Constructor
        public ExcelControl()
        {
            m_objExcel = new Application();
            m_objExcel.DisplayAlerts = false;

            m_objExcel.SheetsInNewWorkbook = 1;
            m_objExcel.Workbooks.Add(oMissing);
            m_objExcel.Worksheets.Select(oMissing);
        }


        public ExcelControl(string templatePath)
        {
            m_objExcel = new Application();
            m_objExcel.DisplayAlerts = false;
            m_objExcel.Workbooks.Add(templatePath);
            m_objExcel.Worksheets.Select(oMissing);
        }
        #endregion

        #region Application
        /// <summary>
        /// Get instance Excel application.
        /// </summary>
        public Application ExcelApplication
        {
            get { return m_objExcel; }
        }
        public void Show()
        {
            m_objExcel.Visible = true;
        }
        public void Hide()
        {
            m_objExcel.Visible = false;
        }
        public void Open(string fileName)
        {
            m_objExcel.Workbooks.Open(fileName, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
        }
        public void Save()
        {
            m_objExcel.ActiveWorkbook.Save();
        }
        public void SaveAs(string strFilename)
        {
            string excelRange = string.Format("{0}{1}:{2}{3}",
                      GetColumnChar(1), m_headerRowCount + 1,
                      GetColumnChar(m_dataColCount), m_dataRowCount + 1);

            //ตอน write จะเป็น 1 based เลยต้อง +1 ที่ index 
            m_objExcel.Range[excelRange, Type.Missing].Value2 = rawData;


            // You can change excel save FileFormat at second parameter.
            m_objExcel.ActiveWorkbook.SaveAs(strFilename, XlFileFormat.xlOpenXMLWorkbook, oMissing, oMissing, oMissing, oMissing,
                XlSaveAsAccessMode.xlExclusive, oMissing, oMissing, oMissing, oMissing, oMissing);
        }
        public void FreezePane(int iRow, int iCol)
        {
            Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
            objWorkSheet.Range[objWorkSheet.Cells[iRow, iCol], oMissing].Select();
            m_objExcel.ActiveWindow.FreezePanes = true;
        }

        public void DeclareDataContent(int iHeaderRowCount, int iDataRowCount, int iDataColCount)
        {
            m_headerRowCount = iHeaderRowCount;
            m_dataRowCount = iDataRowCount;
            m_dataColCount = iDataColCount;
            rawData = new object[iDataRowCount, iDataColCount];
        }

        public void ResizeDataContent(int iHeaderRowCount, int iDataRowCount, int iDataColCount)
        {
            m_headerRowCount = iHeaderRowCount;
            m_dataRowCount = iDataRowCount;
            m_dataColCount = iDataColCount;

            ResizeArray(ref rawData, iDataRowCount, iDataColCount);
            //rawData.with
        }

        private void ResizeArray(ref object[,] original, int rows, int cols)
        {
            //create a new 2 dimensional array with
            //the size we want
            object[,] newArray = new object[rows, cols];
            //copy the contents of the old array to the new one
            Array.Copy(original, newArray, newArray.Length);
            //set the original to the new array
            original = newArray;
        }




        #endregion

        #region Editable
        /// <summary>
        /// Copy Method
        /// </summary>
        /// <param name="iStartRow">Start Row</param>
        /// <param name="iStartCol">Start Column</param>
        /// <param name="iEndRow">End Row</param>
        /// <param name="iEndCol">End Column</param>
        /// <param name="strFormat">Format</param>
        public void Copy(int iStartRow, int iStartCol, int iEndRow, int iEndCol)
        {
            m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]].Copy(Type.Missing);
        }
        /// <summary>
        /// Cut Method
        /// </summary>
        /// <param name="iStartRow">Start Row</param>
        /// <param name="iStartCol">Start Column</param>
        /// <param name="iEndRow">End Row</param>
        /// <param name="iEndCol">End Column</param>
        /// <param name="strFormat">Format</param>
        public void Cut(int iStartRow, int iStartCol, int iEndRow, int iEndCol)
        {
            m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]].Cut(Type.Missing);
        }
        /// <summary>
        /// Paste Method
        /// </summary>
        /// <param name="iStartRow">Start Row</param>
        /// <param name="iStartCol">Start Column</param>
        /// <param name="iEndRow">End Row</param>
        /// <param name="iEndCol">End Column</param>
        /// <param name="strFormat">Format</param>
        /// <param name="pasteType">PasteType</param>
        public void Paste(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string strFormat, XlPasteType pasteType)
        {
            m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]].PasteSpecial(pasteType, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);
        }

        #endregion

        #region Spread Sheet
        /// <summary>
        /// Set Sheet Name Method
        /// </summary>
        /// <param name="strName">Sheet Name</param>
        /// <param name="iIndex">Index</param>
        public void SetSheetName(int iIndex, string strName)
        {
            if (iIndex < 0 && iIndex > m_objExcel.Sheets.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }

            ((Worksheet)m_objExcel.Sheets[iIndex]).Name = strName;
        }

        /// <summary>
        /// Set Sheet Name Method
        /// </summary>
        /// <param name="strName">Sheet Name</param>
        public void SetSheetName(string strName)
        {
            int index = ((Worksheet)m_objExcel.ActiveSheet).Index;
            SetSheetName(index, strName);
        }

        /// <summary>
        /// Get Sheet Number Method
        /// </summary>
        /// <returns>Sheet Number</returns>
        public int GetSheetNum()
        {
            return m_objExcel.Sheets.Count;
        }

        /// <summary>
        /// Next Sheet Method
        /// </summary>
        /// <param name="bLnAddAtLast">At Last Position Status</param>
        public void NextSheet(bool bLnAddAtLast)
        {
            Worksheet objWorksheet;
            if (bLnAddAtLast)
            {
                m_objExcel.Sheets.Add(Type.Missing, m_objExcel.Sheets[GetSheetNum()], Type.Missing, Type.Missing);
                objWorksheet = (Worksheet)m_objExcel.Sheets[GetSheetNum()];
            }
            else
            {
                m_objExcel.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                objWorksheet = (Worksheet)m_objExcel.Sheets[1];
            }
            objWorksheet.Select(Type.Missing);
        }

        /// <summary>
        /// Delete Sheet Method
        /// </summary>
        /// <param name="iIndex">Index</param>
        public void DeleteSheet(int iIndex)
        {
            Worksheet objWorksheet;
            if (iIndex == 0)
            {
                objWorksheet = (Worksheet)m_objExcel.Sheets[GetSheetNum()];
            }
            else
            {
                objWorksheet = (Worksheet)m_objExcel.Sheets[iIndex];
            }
            objWorksheet.Delete();
        }

        /// <summary>
        /// Row Auto Fit All Sheet Method
        /// </summary>
        public void FitAllRowOnSheets()
        {
            Worksheet objWorkSheet;
            for (int i = 1; i <= m_objExcel.Sheets.Count; i++)
            {
                objWorkSheet = (Worksheet)m_objExcel.Sheets[i];
                objWorkSheet.Rows.AutoFit();
            }
        }

        public void FormatCell(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string format)
        {
            m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]].NumberFormat = format;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStartCol">one-based</param>
        /// <param name="iEndCol">one-based</param>
        /// <param name="format"></param>
        public void FormatColumn(int iStartCol, int iEndCol, string format)
        {
            string StartCol = GetColumnChar(iStartCol);
            string EndCol = GetColumnChar(iEndCol);
            Range r = (Range)m_objExcel.Columns[String.Format("{0}:{1}", StartCol, EndCol), oMissing];
            r.NumberFormat = format;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStartRow">one-based</param>
        /// <param name="iEndRow">one-based</param>
        /// <param name="format"></param>
        public void FormatRow(int iStartRow, int iEndRow, string format)
        {
            Range r = (Range)m_objExcel.Rows[String.Format("{0}:{1}", iStartRow, iEndRow), oMissing];
            r.NumberFormat = format;
        }
        /// <summary>
        /// Merge Cell Method
        /// </summary>
        /// <param name="iStartRow">Start Row</param>
        /// <param name="iStartCol">Start Column</param>
        /// <param name="iEndRow">End Row</param>
        /// <param name="iEndCol">End Column</param>
        public void MergeCell(int iStartRow, int iStartCol, int iEndRow, int iEndCol)
        {
            m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]].Merge(Type.Missing);
        }

        ///// <summary>
        ///// Set Row Height
        ///// กำหนดความสูงของ row ใน Excel ทั้ง Range  จาก startRow to EndRow
        ///// </summary>
        ///// <param name="iStartRow">Start Row</param>
        ///// <param name="iEndRow">End Row</param>
        ///// <param name="iRowHeight">Row Height</param>
        //public void SetRowHeight(int iStartRow, int iEndRow, int iRowHeight)
        //{
        //    Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
        //    objWorkSheet.get_Range(objWorkSheet.Cells[iStartRow, 1], objWorkSheet.Cells[iEndRow, 1]).RowHeight = ConvertPixelToHeigthUnit(iRowHeight);
        //}
        /// <summary>
        /// Set Column Width Method
        /// กำหนดความกว้างของ  column ใน Excel ทั้ง Range  จาก startColumn to endColumn
        /// </summary>
        /// <param name="iStartColumn">Start Column</param>
        /// <param name="iEndColumn">End Column</param>
        /// <param name="iColumnWidth">Column Width</param>
        public void SetColumnWidth(int iStartColumn, int iEndColumn, int iColumnWidth)
        {
            Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
            objWorkSheet.Range[objWorkSheet.Cells[1, iStartColumn], objWorkSheet.Cells[1, iEndColumn]].ColumnWidth = ConvertPixelToWidthUnit(iColumnWidth);
        }

        public void SetRowHeight(int iStartRow, int iEndRow, int iColumnHeight)
        {
            Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
            objWorkSheet.Range[objWorkSheet.Cells[iStartRow, 1], objWorkSheet.Cells[iEndRow, 1]].RowHeight = ConvertPixelToWidthUnit(iColumnHeight);
        }

        #endregion

        #region SetText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStartRow">one based (Start Index = 1,2,3,...)</param>
        /// <param name="iStartCol">one based (Start Index = 1,2,3,...)</param>
        /// <param name="text"></param>
        public void WriteCellText(int iStartRow, int iStartCol, object text)
        {
            m_objExcel.Cells[iStartRow, iStartCol] = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iStartRow">Zero based (Start Index = 0,1,2,...)</param>
        /// <param name="iStartCol">Zero based (Start Index = 0,1,2,...)</param>
        /// <param name="text"></param>
        public void WriteRawData(int iStartRow, int iStartCol, object text)
        {
            //m_objExcel.Cells[iStartRow, iStartCol] = text;
            rawData[iStartRow, iStartCol] = text;
        }
        //public void WriteText(int iStartRow, int iStartCol, string text, string format)
        //{
        //    Range range = m_objExcel.get_Range(m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iStartRow, iStartCol]);
        //    //(Range)m_objExcel.Cells[iStartRow, iStartCol] = text;
        //    range.NumberFormat = format;
        //    range.FormulaR1C1 = text;
        //}
        #endregion

        #region SetFormat

        public void SetColumnFormat(int iCol, string format)
        {
            Range range = m_objExcel.Range[m_objExcel.Cells[1, iCol], m_objExcel.Cells[1, iCol]].EntireColumn;
            range.NumberFormat = format;
        }

        #endregion

        #region SetColor
        public void SetForgroundColor(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Color color)
        {
            Range range = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];
            range.Font.Color = color.ToArgb();
        }
        public void SetBackgroundColor(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Color color)
        {
            Range range = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];
            range.Interior.Color = color.ToArgb();
        }
        #endregion

        #region Font-Style
        //public void SetFont(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string fontName)
        //{
        //    //Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
        //    //objWorkSheet.get_Range(objWorkSheet.Cells[iStartRow, iStartCol], objWorkSheet.Cells[iEndRow, iEndCol]).Font.Name = fontName;            
        //    Range range = m_objExcel.get_Range(m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]);
        //    range.Font.Name = fontName;
        //}

        //public void SetFontSize(int iStartRow, int iStartCol, int iEndRow, int iEndCol, int iFontSize)
        //{
        //    Range range = m_objExcel.get_Range(m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]);
        //    range.Font.Size = iFontSize;
        //}

        public void SetFontBold(int iStartRow, int iStartCol, int iEndRow, int iEndCol, bool bBold)
        {
            Range range = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];
            range.Font.Bold = bBold;
        }
        #endregion

        #region Alignment

        public void SetAlignment(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Microsoft.Office.Interop.Excel.XlHAlign hAlign, Microsoft.Office.Interop.Excel.XlVAlign vAlign)
        {
            Range objRange = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];
            objRange.HorizontalAlignment = hAlign;
            objRange.VerticalAlignment = vAlign;
        }

        public void SetVerticalAlignment(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Microsoft.Office.Interop.Excel.XlVAlign vAlign)
        {
            Range objRange = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];      
            objRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            objRange.VerticalAlignment = vAlign;
        }
        //public void SetHorizontalAlignment(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Microsoft.Office.Interop.Excel.XlHAlign align)
        //{
        //    Range objRange = m_objExcel.get_Range(m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]);
        //    objRange.HorizontalAlignment = align;
        //}
        //public void SetVerticalAlignment(int iStartRow, int iStartCol, int iEndRow, int iEndCol, Microsoft.Office.Interop.Excel.XlVAlign align)
        //{
        //    Range objRange = m_objExcel.get_Range(m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]);
        //    objRange.VerticalAlignment = align;
        //}
        #endregion

        #region Draw-Line
        //public void DrawLine(int iStartRow, int iStartCol, int iEndRow, int iEndCol, XlBordersIndex objBorderLine, XlLineStyle objLineStyle)
        //{
        //    DrawLine(iStartRow, iStartCol, iEndRow, iEndCol, objBorderLine, objLineStyle, XlBorderWeight.xlHairline, Color.Black);
        //}

        //public void DrawLine(int iStartRow, int iStartCol, int iEndRow, int iEndCol, XlBordersIndex objBorderLine, XlLineStyle objLineStyle, Color lineColor)
        //{
        //    DrawLine(iStartRow, iStartCol, iEndRow, iEndCol, objBorderLine, objLineStyle, XlBorderWeight.xlHairline, lineColor);
        //}
        ///// <summary>
        ///// Draw Line Method
        ///// </summary>
        ///// <param name="iStartRow">Start Row</param>
        ///// <param name="iStartCol">Start Column</param>
        ///// <param name="iEndRow">End Row</param>
        ///// <param name="iEndCol">End Column</param>
        ///// <param name="objIsLine">Border Index</param>
        ///// <param name="objLineStyle">Line Style</param>
        //public void DrawLine(int iStartRow, int iStartCol, int iEndRow, int iEndCol, XlBordersIndex objBorderLine, XlLineStyle objLineStyle, XlBorderWeight objWeightStyle, Color lineColor)
        //{
        //    // xlThin  เส้นประ
        //    // xlContinuous   เส้นตรง
        //    Worksheet objWorkSheet = (Worksheet)m_objExcel.ActiveSheet;
        //    Range range = m_objExcel.get_Range(objWorkSheet.Cells[iStartRow, iStartCol], objWorkSheet.Cells[iEndRow, iEndCol]);
        //    range.Borders[objBorderLine].LineStyle = objLineStyle;
        //    range.Borders[objBorderLine].Weight = objWeightStyle;
        //    range.Borders[objBorderLine].Color = lineColor.ToArgb();
        //}
        #endregion

        #region Convert Unit for Excel measure
        /// <summary>
        /// แปลงหน่วยจาก Pixel เป็นหน่วยที่ใช้ใน Excel สำหรับระบุความกว้างของคอลัมน์
        /// </summary>
        /// <param name="pixel">ความกว้างหน่วย Pixel</param>
        /// <returns>ความกว้างหน่วย Unit</returns>
        public float ConvertPixelToWidthUnit(int pixel)
        {
            float init_w = 1 / 12f;
            if (pixel <= 12)
            {
                return pixel * init_w;
            }
            else
            {
                return ((pixel - 12) / 7f) + 1;
            }
        }

        /// <summary>
        /// แปลงหน่วยจาก Pixel เป็นหน่วยที่ใช้ใน Excel  สำหรับระบุความสูงของแถว
        /// </summary>
        /// <param name="pixel">ความสูงหน่วย Pixel</param>
        /// <returns>ความสูงหน่วย Unit</returns>
        public float ConvertPixelToHeigthUnit(int pixel)
        {
            return pixel * 0.75f;
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// ถูกเรียกใช้เมื่อใช้งาน COM Object เสร็จแล้ว
        /// เพื่อคืนค่าให้หน่วยความจำ
        /// </summary>        
        public void Dispose()
        {
            if (this.m_objExcel != null)
            {
                IntPtr hwndExcel = new IntPtr(m_objExcel.Hwnd);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel.Workbooks);

                m_objExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);

                // ต้องตรวจเช็ค ProcessID อีกครั้ง เพื่อแน่ใจว่า Excel Instance ปิดแล้วจริงๆ
                IntPtr ptrProcess = IntPtr.Zero;
                IntPtr ptrThread = GetWindowThreadProcessId(hwndExcel, ref ptrProcess);

                if (ptrProcess != IntPtr.Zero)
                {
                    System.Diagnostics.Process prc = System.Diagnostics.Process.GetProcessById(ptrProcess.ToInt32());
                    prc.Kill();
                }
            }

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iColumnNo">One based (Start Index = 1,2,3,...)</param>
        /// <returns></returns>
        /// 
        public string GetColumnChar(int iColumnNo)
        {

            //if (iColumnNo < 27)
            //    return Convert.ToChar(64 + iColumnNo) + "";
            //else if (iColumnNo < 53)
            //    return "A" + Convert.ToChar(64 + iColumnNo - 26);
            //else if (iColumnNo < 79)
            //    return "B" + Convert.ToChar(64 + iColumnNo - 52);
            //else if (iColumnNo < 105)
            //    return "C" + Convert.ToChar(64 + iColumnNo - 78);
            //else
            //    return "";

            // Calculate the final column letter
            string finalColLetter = string.Empty;
            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;

            if (iColumnNo > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (iColumnNo - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                    (iColumnNo - 1) % colCharsetLen, 1);


            return finalColLetter;

        }

        public void SetWrapText(int iStartRow, int iStartCol, int iEndRow, int iEndCol)
        {
            Range range = m_objExcel.Range[m_objExcel.Cells[iStartRow, iStartCol], m_objExcel.Cells[iEndRow, iEndCol]];
            range.WrapText = true;
        }

    }
}
