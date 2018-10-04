/* Create date: 2008/09/30
 * Create by Mr.Teerayut Sinlan
 * Department : ASSI [SI-JE2] 
 */

/* RECORD OF CHANGE
 * ================
 * 2008/09/30
 *   Create screen and all library. 
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using XL = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace SystemMaintenance.Forms
{
    [Screen("SYS_EXPORT_DIALOG", "Export Dialog", eShowAction.PopupModal, eScreenType.Dialog, "Export Dialog")]
    public partial class ExportDialog : CustomizeBaseForm
    {
        #region Variables
        private FpSpread m_spread = null;
        private SelectorCollection m_selectorCollection = new SelectorCollection();
        #endregion

        #region Constructor
        public ExportDialog()
        {
            InitializeComponent();
        }

        public ExportDialog(FpSpread spread)
        {
            InitializeComponent();

            m_spread = spread;

            // Set default dialog result
            DialogResult = DialogResult.Cancel;

        }
        #endregion

        #region Form Event
        private void ScrExportBy_Load(object sender, EventArgs e)
        {
            if (m_spread.ActiveSheet.RowCount == 0)
            {
                MessageDialog.ShowBusiness(this, "No data found to export.");
                DialogResult = DialogResult.Cancel;
                return;
            }

            //RaiseChangedLanguage();

            // Add all selector button.
            m_selectorCollection.Add(btnExcel);
            m_selectorCollection.Add(btnCSV);

            Lookup_SeperatorSymbol();

            //Default Encoding for CSV
            rdoCSV_EncodingUnicode.Checked = true;

        }
        private void ScrExportBy_Shown(object sender, EventArgs e)
        {
            //m_selectorCollection.SelectedStepButton = btnCSV;
            m_selectorCollection.SelectedStepButton = btnExcel;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// สร้าง Lookup-Data ให้แก่ Combobox ของ CSV
        /// </summary>
        private void Lookup_SeperatorSymbol()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("VALUE", typeof(byte)));
            dt.Columns.Add(new DataColumn("DESC", typeof(string)));

            dt.Rows.Add(new object[] { 1, ',', "Comma" });
            dt.Rows.Add(new object[] { 2, '\t', "Tab" });
            dt.Rows.Add(new object[] { 3, ';', "Semi-Colon" });

            cboCSV_SplitBy.DisplayMember = "DESC";
            cboCSV_SplitBy.ValueMember = "VALUE";
            cboCSV_SplitBy.DataSource = dt;

            cboCSV_SplitBy.SelectedIndex = 0;
        }

        /// <summary>
        /// ทดสอบว่าไฟล์ที่ระบุมา  ถูกใช้โดยโปรเซสอื่นหรือไม่ ?
        /// </summary>
        /// <param name="strFullFileName"></param>
        /// <returns></returns>
        private bool FileIsLocked(string strFullFileName)
        {
            bool blnReturn = false;
            System.IO.FileStream fs;
            try
            {
                fs = System.IO.File.Open(strFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
                fs.Close();
            }
            catch (System.IO.IOException ex)
            {
                blnReturn = true;
            }
            return blnReturn;
        }

        /// <summary>
        /// Get format string for Excel's cell.
        /// </summary>
        /// <param name="cellType">Specific CellType</param>
        /// <returns></returns>
        private string GetExcelCellFormatString(ICellType cellType)
        {
            string strFormat = "";
            if (cellType is NumberCellType)
            {
                NumberCellType numberCellType = (NumberCellType)cellType;
                if (numberCellType.DecimalPlaces < 0)
                {
                    strFormat = "#,##0.00";
                }
                else if (numberCellType.DecimalPlaces == 0)
                {
                    if (numberCellType.ShowSeparator)
                    {
                        strFormat = "#,##0";
                    }
                    else
                    {
                        strFormat = "#0";
                    }
                }
                else
                {
                    string decimalPlace = "";
                    decimalPlace = decimalPlace.PadLeft(numberCellType.DecimalPlaces, '0');
                    strFormat = "#,##0." + decimalPlace;
                }
            }
            else if (cellType is DateTimeCellType)
            {
                DateTimeCellType dateTimeCellType = (DateTimeCellType)cellType;
                if (dateTimeCellType.UserDefinedFormat == String.Empty)
                    strFormat = CommonLib.Common.CurrentUserInfomation.DateFormat.ToString();// CommonLib.Common.CurrentUserInfomation.DateFormat.ToString();
                else
                    strFormat = dateTimeCellType.UserDefinedFormat;


            }
            else
            {
                strFormat = "@";
            }

            return strFormat;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get or set default export CSV filename.
        /// </summary>
        public string DefaultCSV_Filename
        {
            get { return txtCSV_Filename.Text; }
            set { txtCSV_Filename.Text = value; }
        }

        /// <summary>
        /// Get or set default export excel filename.
        /// </summary>
        public string DefaultExcel_Filename
        {
            get { return txtExcel_Filename.Text; }
            set { txtExcel_Filename.Text = value; }
        }
        #endregion

        #region Control Event
        private void btnCSV_Browse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV Files(*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCSV_Filename.Text = saveFileDialog1.FileName;
            }
        }
        private void btnExcel_Browse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtExcel_Filename.Text = saveFileDialog1.FileName;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (m_selectorCollection.SelectedStepButton == btnCSV)
            {
                if (txtCSV_Filename.Text.Trim() == String.Empty)
                {
                    MessageDialog.ShowBusiness(this, "Filename is empty.");
                    return;
                }

                try
                {
                    ExportCSV(txtCSV_Filename.Text);
                    if (chkCSV_OpenFile.Checked)
                    {
                        // Open file.
                        System.Diagnostics.Process.Start(txtCSV_Filename.Text);
                    }
                }
                catch (ApplicationException err)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    return;
                }
            }
            else if (m_selectorCollection.SelectedStepButton == btnExcel)
            {
                if (txtExcel_Filename.Text.Trim() == String.Empty)
                {
                    MessageDialog.ShowBusiness(this, "Filename is empty.");
                    return;
                }

                try
                {
                    ExportExcel(txtExcel_Filename.Text);
                    if (chkExcel_OpenFile.Checked)
                    {
                        // Open file.
                        System.Diagnostics.Process.Start(txtExcel_Filename.Text);
                    }
                }
                catch (ApplicationException err)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    return;
                }
            }

            MessageDialog.ShowInformation(this, null, "Export successful.");
            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Export Excel
        private void GetColumnHeaderAlignment(FarPoint.Win.Spread.Cell cell, out XL.XlHAlign hAlign, out XL.XlVAlign vAlign)
        {
            switch (cell.HorizontalAlignment)
            {
                case CellHorizontalAlignment.Center:
                    hAlign = XL.XlHAlign.xlHAlignCenter;
                    break;
                case CellHorizontalAlignment.General:
                    hAlign = XL.XlHAlign.xlHAlignCenter;
                    break;
                case CellHorizontalAlignment.Left:
                    hAlign = XL.XlHAlign.xlHAlignLeft;
                    break;
                case CellHorizontalAlignment.Right:
                    hAlign = XL.XlHAlign.xlHAlignRight;
                    break;
                default:
                    hAlign = XL.XlHAlign.xlHAlignCenter;
                    break;
            }

            switch (cell.VerticalAlignment)
            {
                case CellVerticalAlignment.Bottom:
                    vAlign = XL.XlVAlign.xlVAlignBottom;
                    break;
                case CellVerticalAlignment.Center:
                    vAlign = XL.XlVAlign.xlVAlignCenter;
                    break;
                case CellVerticalAlignment.General:
                    vAlign = XL.XlVAlign.xlVAlignCenter;
                    break;
                case CellVerticalAlignment.Top:
                    vAlign = XL.XlVAlign.xlVAlignTop;
                    break;
                default:
                    vAlign = XL.XlVAlign.xlVAlignCenter;
                    break;
            }
        }
        private void GetAlignment(FarPoint.Win.Spread.Cell cell, out XL.XlHAlign hAlign, out XL.XlVAlign vAlign)
        {
            switch (cell.HorizontalAlignment)
            {
                case CellHorizontalAlignment.Center:
                    hAlign = XL.XlHAlign.xlHAlignCenter;
                    break;
                case CellHorizontalAlignment.General:
                    hAlign = XL.XlHAlign.xlHAlignGeneral;
                    break;
                case CellHorizontalAlignment.Left:
                    hAlign = XL.XlHAlign.xlHAlignLeft;
                    break;
                case CellHorizontalAlignment.Right:
                    hAlign = XL.XlHAlign.xlHAlignRight;
                    break;
                default:
                    hAlign = XL.XlHAlign.xlHAlignGeneral;
                    break;
            }

            switch (cell.VerticalAlignment)
            {
                case CellVerticalAlignment.Bottom:
                    vAlign = XL.XlVAlign.xlVAlignBottom;
                    break;
                case CellVerticalAlignment.Center:
                    vAlign = XL.XlVAlign.xlVAlignCenter;
                    break;
                case CellVerticalAlignment.General:
                    vAlign = XL.XlVAlign.xlVAlignTop;
                    break;
                case CellVerticalAlignment.Top:
                    vAlign = XL.XlVAlign.xlVAlignTop;
                    break;
                default:
                    vAlign = XL.XlVAlign.xlVAlignTop;
                    break;
            }
        }
        private void WriteHeaderLabel(FarPoint.Win.Spread.SheetView sht, int shtColumnHeaderRow, int shtColumnHeader, int excelColumn)
        {

        }
        private void ExportExcel(string filename)
        {
            if (FileIsLocked(filename))
            {
                throw new ApplicationException("File is used by another program.");
            }

            ExcelControl xlApp = new ExcelControl();
            xlApp.Hide();

            bool bHeader = chkExcel_Header.Checked;
            //int iCurrentRowIndex = 0;

            FarPoint.Win.Spread.SheetView sht = m_spread.ActiveSheet;

            //คำนวณค่าของ MaxProgress ทั้งหมด
            prgExport.Maximum = sht.RowCount + 1;
            prgExport.Value = 1;

            //Current excel column
            int iCurrentExcelColumn = 0;
            int iTotalExcelColumn = 0;

            List<int> lastExportcolumn = new List<int>();

            //#################
            //ColumnHeader  :: Adjust column-width
            //#################
            for (int i = 0; i < sht.Columns.Count; i++)
            {
                if (sht.Columns[i].StyleName == "NO_EXPORT")
                    continue;

                if (sht.Columns[i].StyleName == "EXPORT_LAST")
                {
                    lastExportcolumn.Add(i);
                    continue;
                }

                //Adjust column-width
                //xlApp.SetColumnWidth(i + 1, i + 1, Convert.ToInt32(sht.Columns[i].Width));
                xlApp.SetColumnWidth(iCurrentExcelColumn + 1, iCurrentExcelColumn + 1, Convert.ToInt32(sht.Columns[i].Width));

                iCurrentExcelColumn = iCurrentExcelColumn + 1;
                iTotalExcelColumn = iTotalExcelColumn + 1;
            }

            //Add export_last column
            foreach (int i in lastExportcolumn)
            {
                xlApp.SetColumnWidth(iCurrentExcelColumn + 1, iCurrentExcelColumn + 1, Convert.ToInt32(sht.Columns[i].Width));

                iCurrentExcelColumn = iCurrentExcelColumn + 1;
                iTotalExcelColumn = iTotalExcelColumn + 1;
            }


            //#################
            // ColumnHeader :: ColSpan && RowSpan
            //#################
            if (bHeader)
            {
                for (int i = 0; i < sht.ColumnHeader.RowCount; i++)
                {
                    iCurrentExcelColumn = 0;

                    for (int j = 0; j < sht.ColumnHeader.Columns.Count; j++)
                    {
                        if (sht.Columns[j].StyleName == "NO_EXPORT" || sht.Columns[j].StyleName == "EXPORT_LAST")
                            continue;

                        //WriteText
                        if (sht.ColumnHeader.Cells[i, j].Text == "")
                            //xlApp.WriteCellText(i + 1, j + 1, sht.ColumnHeader.Cells[i, j].Column.Label);
                            xlApp.WriteCellText(i + 1, iCurrentExcelColumn + 1, "'" + sht.ColumnHeader.Cells[i, j].Column.Label);
                        else
                            //xlApp.WriteCellText(i + 1, j + 1, sht.ColumnHeader.Cells[i, j].Text);
                            xlApp.WriteCellText(i + 1, iCurrentExcelColumn + 1, "'" + sht.ColumnHeader.Cells[i, j].Text);

                        //Set alignment ColumnHeader
                        XL.XlHAlign hAlign = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        XL.XlVAlign vAlign = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        GetColumnHeaderAlignment(sht.ColumnHeader.Cells[i, j], out hAlign, out vAlign);
                        //xlApp.SetAlignment(i + 1, j + 1, i + 1, j + 1, hAlign, vAlign);
                        xlApp.SetAlignment(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, hAlign, vAlign);
                        //xlApp.SetBackgroundColor(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, Color.FromArgb(250, 206, 135));
                        //xlApp.SetFontBold(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, true);

                        //Set ColumnSpan and RowSpan
                        if (sht.ColumnHeader.Cells[i, j].ColumnSpan > 1)
                        {
                            //xlApp.MergeCell(i + 1, j + 1, i + 1, j + sht.ColumnHeader.Cells[i, j].ColumnSpan);
                            xlApp.MergeCell(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + sht.ColumnHeader.Cells[i, j].ColumnSpan);
                            j += sht.ColumnHeader.Cells[i, j].ColumnSpan - 1;
                        }

                        if (sht.ColumnHeader.Cells[i, j].RowSpan > 1)
                        {
                            //xlApp.MergeCell(i + 1, j + 1, i + sht.ColumnHeader.Cells[i, j].RowSpan, j + 1);
                            xlApp.MergeCell(i + 1, iCurrentExcelColumn + 1, i + sht.ColumnHeader.Cells[i, j].RowSpan, iCurrentExcelColumn + 1);
                        }

                        iCurrentExcelColumn = iCurrentExcelColumn + 1;
                    }

                    //Set label to export_last column
                    foreach (int j in lastExportcolumn)
                    {
                        //WriteText
                        if (sht.ColumnHeader.Cells[i, j].Text == "")
                            xlApp.WriteCellText(i + 1, iCurrentExcelColumn + 1, "'" + sht.ColumnHeader.Cells[i, j].Column.Label);
                        else
                            xlApp.WriteCellText(i + 1, iCurrentExcelColumn + 1, "'" + sht.ColumnHeader.Cells[i, j].Text);

                        //Set alignment ColumnHeader
                        XL.XlHAlign hAlign = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        XL.XlVAlign vAlign = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        GetColumnHeaderAlignment(sht.ColumnHeader.Cells[i, j], out hAlign, out vAlign);

                        xlApp.SetAlignment(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, hAlign, vAlign);
                        //xlApp.SetBackgroundColor(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, Color.FromArgb(250, 206, 135));
                        //xlApp.SetFontBold(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + 1, true);

                        //Set ColumnSpan and RowSpan
                        if (sht.ColumnHeader.Cells[i, j].ColumnSpan > 1)
                        {
                            xlApp.MergeCell(i + 1, iCurrentExcelColumn + 1, i + 1, iCurrentExcelColumn + sht.ColumnHeader.Cells[i, j].ColumnSpan);
                            //j += sht.ColumnHeader.Cells[i, j].ColumnSpan - 1;
                        }

                        if (sht.ColumnHeader.Cells[i, j].RowSpan > 1)
                        {
                            //xlApp.MergeCell(i + 1, j + 1, i + sht.ColumnHeader.Cells[i, j].RowSpan, j + 1);
                            xlApp.MergeCell(i + 1, iCurrentExcelColumn + 1, i + sht.ColumnHeader.Cells[i, j].RowSpan, iCurrentExcelColumn + 1);
                        }

                        iCurrentExcelColumn = iCurrentExcelColumn + 1;
                    }


                    xlApp.SetRowHeight(i + 1, i + 1, 200);
                    xlApp.SetBackgroundColor(i + 1, 1 , i + 1, iCurrentExcelColumn , Color.FromArgb(250, 206, 135));
                    xlApp.SetFontBold(i + 1, 1, i + 1, iCurrentExcelColumn , true);
                    xlApp.SetWrapText(i + 1, 1, i + 1, iCurrentExcelColumn);
                }

                //Microsoft.Office.Interop.Excel.Range range = xlApp.ExcelApplication.get_Range(
                //                    "A1:F1"
                //    //+ (sht.RowCount + sht.ColumnHeader.RowCount).ToString()
                //    //, xlApp.GetColumnChar(sht.ColumnHeader.Columns.Count)
                //    // + (sht.RowCount + sht.ColumnHeader.RowCount).ToString()
                //);

                //range.Interior.Color = System.Drawing.Color.Moccasin.ToArgb();
                //range.Font.Bold = true;

            }

            //if (bHeader)
            //{
            //    //Update FormatText for ColumnHeader = "@"
            //    xlApp.FormatRow(1, sht.ColumnHeader.RowCount, "@");

            //    //Update start row index.
            //    iCurrentRowIndex = sht.ColumnHeader.RowCount;
            //}

            //#################
            // Draw DataContent
            //#################

            //for (int i = 0; i < sht.Rows.Count; i++)
            //{
            //    for (int j = 0; j < sht.Columns.Count; j++)
            //    {
            //        ICellType cellType = sht.GetCellType(i, j);
            //        string strFormat = GetExcelCellFormatString(cellType);

            //        if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
            //        {
            //            if (String.IsNullOrEmpty(strFormat))
            //                strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

            //            if (sht.Cells[i, j].Value != null)
            //            {
            //                DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
            //                xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat),strFormat);
            //            }

            //        }
            //        else  // Another CellType.
            //        {
            //            string strOutput = String.Empty;
            //            if (sht.Cells[i, j].Value != null)
            //                strOutput = sht.Cells[i, j].Value.ToString();
            //            xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);
            //        }
            //    }
            //    prgExport.Value += 1;
            //    prgExport.Refresh();

            //    iCurrentRowIndex++;
            //}

            //xlApp.DeclareDataContent(sht.ColumnHeader.Rows.Count, sht.Rows.Count, sht.Columns.Count);
            xlApp.DeclareDataContent(sht.ColumnHeader.Rows.Count, sht.Rows.Count, iTotalExcelColumn);

           

            //check row count แล้วค่อย set format เพราะว่าข้างในมันต้องใช้ cell type ไป checkว่าเป็น typeอะไร
            if (sht.Rows.Count > 0)
            {
                iCurrentExcelColumn = 0;

                for (int iSetColFormat = 0; iSetColFormat < sht.Columns.Count; iSetColFormat++)
                {
                    if (sht.Columns[iSetColFormat].StyleName == "NO_EXPORT" || sht.Columns[iSetColFormat].StyleName == "EXPORT_LAST")
                        continue;

                    ICellType cellType = sht.GetCellType(0, iSetColFormat);

                    string strFormat = GetExcelCellFormatString(cellType);


                    if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
                    {
                        if (String.IsNullOrEmpty(strFormat))
                            strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

                        //if (sht.Cells[i, j].Value != null)
                        //{
                        //    DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
                        //    xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat), strFormat);
                        //}

                        xlApp.SetColumnFormat(iCurrentExcelColumn + 1, strFormat);

                        //xlApp.SetColumnFormat(iSetColFormat + 1, strFormat);

                    }
                    else  // Another CellType.
                    {
                        //string strOutput = String.Empty;
                        //if (sht.Cells[i, j].Value != null)
                        //    strOutput = sht.Cells[i, j].Value.ToString();
                        //xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);

                        //xlApp.SetColumnFormat(iSetColFormat + 1, strFormat);
                        xlApp.SetColumnFormat(iCurrentExcelColumn + 1, strFormat);

                    }

                    iCurrentExcelColumn = iCurrentExcelColumn + 1;

                }

                //Set format to export_last column
                foreach (int iSetColFormat in lastExportcolumn)
                {
                    ICellType cellType = sht.GetCellType(0, iSetColFormat);

                    string strFormat = GetExcelCellFormatString(cellType);


                    if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
                    {
                        if (String.IsNullOrEmpty(strFormat))
                            strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;

                        xlApp.SetColumnFormat(iCurrentExcelColumn + 1, strFormat);

                    }
                    else  // Another CellType.
                    {
                        xlApp.SetColumnFormat(iCurrentExcelColumn + 1, strFormat);
                    }

                    iCurrentExcelColumn = iCurrentExcelColumn + 1;
                }
            }


            int iVisibledRowCount = 0;
            for (int i = 0; i < sht.Rows.Count; i++)
            {                

                //modify by Bunyapat L. on 29 Jun 2011
                //export เฉพาะ row ที่แสดงผลเท่านั้น
                if (sht.GetRowVisible(i))
                {
                    iCurrentExcelColumn = 0;

                    for (int j = 0; j < sht.Columns.Count; j++)
                    {
                        //ICellType cellType = sht.GetCellType(i, j);
                        ////set format ของ column
                        //string strFormat = GetExcelCellFormatString(cellType);


                        //if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
                        //{
                        //    if (String.IsNullOrEmpty(strFormat))
                        //        strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

                        //    if (sht.Cells[i, j].Value != null)
                        //    {
                        //        DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
                        //        xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat), strFormat);
                        //    }

                        //}
                        //else  // Another CellType.
                        //{
                        //    string strOutput = String.Empty;
                        //    if (sht.Cells[i, j].Value != null)
                        //        strOutput = sht.Cells[i, j].Value.ToString();
                        //    xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);
                        //}

                        if (sht.Columns[j].StyleName == "NO_EXPORT" || sht.Columns[j].StyleName == "EXPORT_LAST")
                            continue;

                        //xlApp.WriteRawData(iVisibledRowCount, j, sht.Cells[i, j].Value);
                        xlApp.WriteRawData(iVisibledRowCount, iCurrentExcelColumn, sht.Cells[i, j].Value);
                                                
                        iCurrentExcelColumn = iCurrentExcelColumn + 1;
                    }

                    //Set data to export_last column
                    foreach (int j in lastExportcolumn)
                    {
                        xlApp.WriteRawData(iVisibledRowCount, iCurrentExcelColumn, sht.Cells[i, j].Value);
                       
                        iCurrentExcelColumn = iCurrentExcelColumn + 1;
                    }                    

                    iVisibledRowCount++;
                }

                prgExport.Value += 1;
                prgExport.Refresh();

                //iCurrentRowIndex++;
            }

            //set alignment of detail
            xlApp.SetVerticalAlignment(sht.ColumnHeader.Rows.Count+1, 1, iVisibledRowCount + 1, iTotalExcelColumn, Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop);

            //xlApp.ResizeDataContent(sht.ColumnHeader.Rows.Count, iVisibledRowCount, sht.Columns.Count);
            xlApp.ResizeDataContent(sht.ColumnHeader.Rows.Count, iVisibledRowCount, iTotalExcelColumn);

            //#################
            // Save to file.
            //#################
            xlApp.SaveAs(filename);

            // Close Excel Application.
            xlApp.Hide();
            xlApp.Dispose();
        }

        #region Backup export excel function
        //private void ExportExcel(string filename)
        //{
        //    if (FileIsLocked(filename))
        //    {
        //        throw new ApplicationException("File is used by another program.");
        //    }

        //    ExcelControl xlApp = new ExcelControl();
        //    xlApp.Hide();

        //    bool bHeader = chkExcel_Header.Checked;
        //    //int iCurrentRowIndex = 0;

        //    FarPoint.Win.Spread.SheetView sht = m_spread.ActiveSheet;

        //    //คำนวณค่าของ MaxProgress ทั้งหมด
        //    prgExport.Maximum = sht.RowCount + 1;
        //    prgExport.Value = 1;


        //    //#################
        //    //ColumnHeader  :: Adjust column-width
        //    //#################
        //    for (int i = 0; i < sht.Columns.Count; i++)
        //    {
        //        //Adjust column-width
        //        xlApp.SetColumnWidth(i + 1, i + 1, Convert.ToInt32(sht.Columns[i].Width));
        //    }


        //    //#################
        //    // ColumnHeader :: ColSpan && RowSpan
        //    //#################
        //    if (bHeader)
        //    {
        //        for (int i = 0; i < sht.ColumnHeader.RowCount; i++)
        //        {
        //            for (int j = 0; j < sht.ColumnHeader.Columns.Count; j++)
        //            {
        //                //WriteText
        //                if (sht.ColumnHeader.Cells[i, j].Text == "")
        //                    xlApp.WriteCellText(i + 1, j + 1, sht.ColumnHeader.Cells[i, j].Column.Label);
        //                else
        //                    xlApp.WriteCellText(i + 1, j + 1, sht.ColumnHeader.Cells[i, j].Text);

        //                //Set alignment ColumnHeader
        //                XL.XlHAlign hAlign = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //                XL.XlVAlign vAlign = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //                GetColumnHeaderAlignment(sht.ColumnHeader.Cells[i, j], out hAlign, out vAlign);
        //                xlApp.SetAlignment(i + 1, j + 1, i + 1, j + 1, hAlign, vAlign);

        //                //Set ColumnSpan and RowSpan
        //                if (sht.ColumnHeader.Cells[i, j].ColumnSpan > 1)
        //                {
        //                    xlApp.MergeCell(i + 1, j + 1, i + 1, j + sht.ColumnHeader.Cells[i, j].ColumnSpan);
        //                    j += sht.ColumnHeader.Cells[i, j].ColumnSpan - 1;
        //                }

        //                if (sht.ColumnHeader.Cells[i, j].RowSpan > 1)
        //                {
        //                    xlApp.MergeCell(i + 1, j + 1, i + sht.ColumnHeader.Cells[i, j].RowSpan, j + 1);
        //                }
        //            }
        //        }

        //        //Microsoft.Office.Interop.Excel.Range range = xlApp.ExcelApplication.get_Range(
        //        //                    "A1:F1"
        //        //    //+ (sht.RowCount + sht.ColumnHeader.RowCount).ToString()
        //        //    //, xlApp.GetColumnChar(sht.ColumnHeader.Columns.Count)
        //        //    // + (sht.RowCount + sht.ColumnHeader.RowCount).ToString()
        //        //);

        //        //range.Interior.Color = System.Drawing.Color.Moccasin.ToArgb();
        //        //range.Font.Bold = true;

        //    }

        //    //if (bHeader)
        //    //{
        //    //    //Update FormatText for ColumnHeader = "@"
        //    //    xlApp.FormatRow(1, sht.ColumnHeader.RowCount, "@");

        //    //    //Update start row index.
        //    //    iCurrentRowIndex = sht.ColumnHeader.RowCount;
        //    //}

        //    //#################
        //    // Draw DataContent
        //    //#################

        //    //for (int i = 0; i < sht.Rows.Count; i++)
        //    //{
        //    //    for (int j = 0; j < sht.Columns.Count; j++)
        //    //    {
        //    //        ICellType cellType = sht.GetCellType(i, j);
        //    //        string strFormat = GetExcelCellFormatString(cellType);

        //    //        if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
        //    //        {
        //    //            if (String.IsNullOrEmpty(strFormat))
        //    //                strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

        //    //            if (sht.Cells[i, j].Value != null)
        //    //            {
        //    //                DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
        //    //                xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat),strFormat);
        //    //            }

        //    //        }
        //    //        else  // Another CellType.
        //    //        {
        //    //            string strOutput = String.Empty;
        //    //            if (sht.Cells[i, j].Value != null)
        //    //                strOutput = sht.Cells[i, j].Value.ToString();
        //    //            xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);
        //    //        }
        //    //    }
        //    //    prgExport.Value += 1;
        //    //    prgExport.Refresh();

        //    //    iCurrentRowIndex++;
        //    //}

        //    xlApp.DeclareDataContent(sht.ColumnHeader.Rows.Count, sht.Rows.Count, sht.Columns.Count);

        //    //check row count แล้วค่อย set format เพราะว่าข้างในมันต้องใช้ cell type ไป checkว่าเป็น typeอะไร
        //    if (sht.Rows.Count > 0)
        //    {
        //        for (int iSetColFormat = 0; iSetColFormat < sht.Columns.Count; iSetColFormat++)
        //        {
        //            ICellType cellType = sht.GetCellType(0, iSetColFormat);

        //            string strFormat = GetExcelCellFormatString(cellType);


        //            if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
        //            {
        //                if (String.IsNullOrEmpty(strFormat))
        //                    strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

        //                //if (sht.Cells[i, j].Value != null)
        //                //{
        //                //    DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
        //                //    xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat), strFormat);
        //                //}

        //                xlApp.SetColumnFormat(iSetColFormat + 1, strFormat);

        //            }
        //            else  // Another CellType.
        //            {
        //                //string strOutput = String.Empty;
        //                //if (sht.Cells[i, j].Value != null)
        //                //    strOutput = sht.Cells[i, j].Value.ToString();
        //                //xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);

        //                xlApp.SetColumnFormat(iSetColFormat + 1, strFormat);
        //            }

        //        }
        //    }


        //    int iVisibledRowCount = 0;
        //    for (int i = 0; i < sht.Rows.Count; i++)
        //    {

        //        //modify by Bunyapat L. on 29 Jun 2011
        //        //export เฉพาะ row ที่แสดงผลเท่านั้น
        //        if (sht.GetRowVisible(i))
        //        {

        //            for (int j = 0; j < sht.Columns.Count; j++)
        //            {
        //                //ICellType cellType = sht.GetCellType(i, j);
        //                ////set format ของ column
        //                //string strFormat = GetExcelCellFormatString(cellType);


        //                //if (cellType is DateTimeCellType)  // Check CellType of current cell for DateTime type.
        //                //{
        //                //    if (String.IsNullOrEmpty(strFormat))
        //                //        strFormat = CommonLib.Common.CurrentUserInfomation.DateFormatString;//.ToString();

        //                //    if (sht.Cells[i, j].Value != null)
        //                //    {
        //                //        DateTime dateTime = Convert.ToDateTime(sht.Cells[i, j].Value);
        //                //        xlApp.WriteText(iCurrentRowIndex + 1, j + 1, dateTime.ToString(strFormat), strFormat);
        //                //    }

        //                //}
        //                //else  // Another CellType.
        //                //{
        //                //    string strOutput = String.Empty;
        //                //    if (sht.Cells[i, j].Value != null)
        //                //        strOutput = sht.Cells[i, j].Value.ToString();
        //                //    xlApp.WriteText(iCurrentRowIndex + 1, j + 1, strOutput, strFormat);
        //                //}

        //                xlApp.WriteRawData(iVisibledRowCount, j, sht.Cells[i, j].Value);

        //            }

        //            iVisibledRowCount++;
        //        }

        //        prgExport.Value += 1;
        //        prgExport.Refresh();

        //        //iCurrentRowIndex++;
        //    }

        //    xlApp.ResizeDataContent(sht.ColumnHeader.Rows.Count, iVisibledRowCount, sht.Columns.Count);

        //    //#################
        //    // Save to file.
        //    //#################
        //    xlApp.SaveAs(filename);

        //    // Close Excel Application.
        //    xlApp.Hide();
        //    xlApp.Dispose();
        //}

        #endregion

        #endregion

        #region Export CSV
        private void ExportCSV(string filename)
        {
            if (FileIsLocked(filename))
            {
                throw new ApplicationException("File is used by another program.");
            }

            Encoding encoding = Encoding.ASCII;
            if (rdoCSV_EncodingUnicode.Checked)
                encoding = Encoding.Unicode;
            else if (rdoCSV_EncodingANSI.Checked)
                encoding = Encoding.ASCII;

            CSVFile.Sign sign = chkCSV_Quote.Checked ? CSVFile.Sign.WithDBQuote : CSVFile.Sign.WithOutDBQuote;
            CSVFile csvFile = new CSVFile(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileName(filename), encoding);

            prgExport.Maximum = m_spread.ActiveSheet.RowCount + 1;
            prgExport.Value = 1;

            csvFile.WriteLine += new CSVFile.WriteLineHandler(csvFile_WriteLine);
            csvFile.WriteSpread(sign, Convert.ToChar(cboCSV_SplitBy.SelectedValue).ToString(), chkCSV_Header.Checked, m_spread);
        }
        void csvFile_WriteLine()
        {
            prgExport.Value += 1;
            prgExport.Refresh();
        }
        #endregion
    }

    internal class SelectorCollection : CollectionBase
    {
        /// <summary>
        /// สีตัวอักษรปุ่มที่ถูกเลือก
        /// </summary>
        private Color C_SELECTED_COLOR_FG = Color.White;

        /// <summary>
        /// สีพื้นหลังปุ่มที่ถูกเลือก
        /// </summary>
        private Color C_SELECTED_COLOR_BG = Color.FromArgb(30, 144, 255);

        /// <summary>
        /// สีตัวอักษรปุ่มที่ไม่ถูกเลือก
        /// </summary>
        private Color C_UNSELECTED_COLOR_FG = Color.Black;

        /// <summary>
        /// สีพื้นหลังปุ่มที่ไม่ถูกเลือก
        /// </summary>
        private Color C_UNSELECTED_COLOR_BG = Color.FromArgb(236, 233, 216);

        /// <summary>
        /// สีพื้นหลังปุ่ม เมื่อเมาส์กดลง
        /// </summary>
        private Color C_MOUSEDOWN_COLOR = Color.FromArgb(50, 30, 144, 255);

        /// <summary>
        /// สีพื้นหลังปุ่ม เมื่อเมาส์ลากผ่าน
        /// </summary>
        private Color C_MOUSEOVER_COLOR = Color.FromArgb(20, 30, 144, 255);

        /// <summary>
        /// ปุ่มที่กำลังถูกเลือก
        /// </summary>
        private StepButton m_selectedStepButton = null;

        #region Indexer
        private StepButton this[int index]
        {
            get { return List[index] as StepButton; }
            set { List[index] = value; }
        }
        #endregion

        #region Collection method
        public void Add(StepButton item)
        {
            BindEvent(item);
            List.Add(item);
        }
        public void Remove(StepButton item)
        {
            UnBindEvent(item);
            List.Remove(item);
        }
        public void Insert(int index, StepButton item)
        {
            BindEvent(item);
            List.Insert(index, item);
        }
        #endregion

        #region Internal Event
        private void BindEvent(StepButton item)
        {
            item.BackColor = C_UNSELECTED_COLOR_BG;

            item.Click += new EventHandler(item_Click);
            item.MouseDown += new MouseEventHandler(item_MouseDown);
            item.MouseUp += new MouseEventHandler(item_MouseUp);
            item.MouseEnter += new EventHandler(item_MouseEnter);
            item.MouseLeave += new EventHandler(item_MouseLeave);
        }
        private void UnBindEvent(Button item)
        {
            item.Click -= new EventHandler(item_Click);
            item.MouseDown -= new MouseEventHandler(item_MouseDown);
            item.MouseUp -= new MouseEventHandler(item_MouseUp);
            item.MouseEnter -= new EventHandler(item_MouseEnter);
            item.MouseLeave -= new EventHandler(item_MouseLeave);
        }


        void item_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Equals(sender))
                {
                    this[i].BackColor = C_SELECTED_COLOR_BG;
                    this[i].ForeColor = C_SELECTED_COLOR_FG;
                    m_selectedStepButton = this[i];
                    m_selectedStepButton.ContentPanel.Visible = true;
                }
                else
                {
                    this[i].BackColor = C_UNSELECTED_COLOR_BG;
                    this[i].ForeColor = C_UNSELECTED_COLOR_FG;
                    this[i].ContentPanel.Visible = false;
                }
            }

            m_selectedStepButton.ContentPanel.BringToFront();
            m_selectedStepButton.ContentPanel.Focus();

        }
        void item_MouseDown(object sender, MouseEventArgs e)
        {
            if (!SelectedStepButton.Equals(sender))
                ((StepButton)sender).BackColor = C_MOUSEDOWN_COLOR;
        }
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedStepButton.Equals(sender))
                ((StepButton)sender).BackColor = C_SELECTED_COLOR_BG;
            else
                ((StepButton)sender).BackColor = C_UNSELECTED_COLOR_BG;
        }
        void item_MouseEnter(object sender, EventArgs e)
        {
            if (!SelectedStepButton.Equals(sender))
                ((StepButton)sender).BackColor = C_MOUSEOVER_COLOR;
        }
        void item_MouseLeave(object sender, EventArgs e)
        {
            if (SelectedStepButton.Equals(sender))
                ((StepButton)sender).BackColor = C_SELECTED_COLOR_BG;
            else
                ((StepButton)sender).BackColor = C_UNSELECTED_COLOR_BG;
        }
        #endregion

        #region Properties
        public StepButton SelectedStepButton
        {
            get { return m_selectedStepButton; }
            set
            {
                m_selectedStepButton = value;
                m_selectedStepButton.PerformClick();
            }
        }
        #endregion

    }

    [ToolboxItem(false)]
    internal class StepButton : Button
    {
        private Panel m_panel = null;

        public StepButton()
        {
        }

        public Panel ContentPanel
        {
            get { return m_panel; }
            set { m_panel = value; }
        }
    }
}
