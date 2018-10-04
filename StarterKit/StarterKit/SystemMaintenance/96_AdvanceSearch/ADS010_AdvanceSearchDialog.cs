using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using CommonLib;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using EVOFramework.Database;
using FarPoint.Win.Spread.CellType;
using System.Text.RegularExpressions;

namespace SystemMaintenance.Forms
{

    [Screen("ADS010", "Advance Search Dialog", eShowAction.Normal, eScreenType.Screen, "Advance Search Dialog")]
    public partial class AdvanceSearchDialog : CustomizeBaseForm
    {
        #region Enum
        enum eCol
        {
            Checkbox,
            ColumnIndex,
            ColumnName,
            ColumnType,
            Sign,
            Value1,
            Value2
        }

        enum eSign
        {
            Between,
            Like
        }

        enum eColumnType
        {
            Number,
            DateTime,
            String
        }

        #endregion

        #region Constants

        #endregion

        #region Variables

        private SheetView m_SheetViewData;
        private DataTable m_DataView;
        private Type m_EnumOfSheetData;
        private SortInfo[] m_SortingInfo;

        #endregion

        #region Constructor

        public AdvanceSearchDialog() { InitializeComponent(); }

        public AdvanceSearchDialog(SheetView sht, Type enumType, DataTable data)
            : this()
        {
            m_SheetViewData = sht;
            m_DataView = data;
            m_EnumOfSheetData = enumType;
        }

        #endregion

        #region Initialize Screen

        #endregion


        #region Properties

        public SortInfo[] SortingInfo { get { return m_SortingInfo; } }

        //public SheetView SortingData { get { return m_SheetViewData; } }

        #endregion

        #region Handles and Overrides

        private void AdvanceSearchDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                shtQueryList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

                fpQueryList.Enabled = true;

                shtQueryList.Columns[(int)eCol.ColumnIndex].Visible = false;
                shtQueryList.Columns[(int)eCol.ColumnType].Visible = false;

                CtrlUtil.SpreadSetColumnsLocked(shtQueryList, false, (int)eCol.Checkbox);
                CtrlUtil.SpreadSetColumnsLocked(shtQueryList, true, (int)eCol.ColumnName);
                CtrlUtil.SpreadSetColumnsLocked(shtQueryList, true, (int)eCol.Sign);
                CtrlUtil.SpreadSetColumnsLocked(shtQueryList, true, (int)eCol.Value1);
                CtrlUtil.SpreadSetColumnsLocked(shtQueryList, true, (int)eCol.Value2);

                ShowColumnName();

                // Add by Pongthorn S. @ 2012-05-18
                //fpQueryList.KeyPress += CtrlUtil.SetRestrictKeyInput;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }


        #endregion

        #region User Defines



        private void ShowColumnName()
        {
            shtQueryList.RowCount = 0;

            for (int i = 0; i < m_SheetViewData.ColumnCount; i++)
            {
                if (m_SheetViewData.Columns[i].Visible == true)
                {
                    int iRowCount = shtQueryList.RowCount++;
                    shtQueryList.Cells[iRowCount, (int)eCol.ColumnName].Text = m_SheetViewData.ColumnHeader.Cells[0, i].Text;
                    shtQueryList.Cells[iRowCount, (int)eCol.ColumnIndex].Text = i.ToString();

                    ICellType cellType = m_SheetViewData.GetCellType(0, i);

                    if (cellType is NumberCellType)
                    {
                        shtQueryList.Cells[iRowCount, (int)eCol.ColumnType].Value = eColumnType.Number;
                        shtQueryList.Cells[iRowCount, (int)eCol.Sign].Value = eSign.Between.ToString();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value1].CellType = CtrlUtil.CreateNumberCellType();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value2].CellType = CtrlUtil.CreateNumberCellType();
                    }
                    else if (cellType is DateTimeCellType)
                    {
                        shtQueryList.Cells[iRowCount, (int)eCol.ColumnType].Value = eColumnType.DateTime;
                        shtQueryList.Cells[iRowCount, (int)eCol.Sign].Value = eSign.Between.ToString();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value1].CellType = CtrlUtil.CreateDateTimeCellType();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value2].CellType = CtrlUtil.CreateDateTimeCellType();
                    }
                    //else
                    //{
                    //    shtQueryList.Cells[iRowCount, (int)eCol.ColumnType].Value = eColumnType.String;
                    //    shtQueryList.Cells[iRowCount, (int)eCol.Sign].Value = eSign.Like.ToString();
                    //    shtQueryList.Cells[iRowCount, (int)eCol.Value1].CellType = CtrlUtil.CreateTextCellType();
                    //    shtQueryList.Cells[iRowCount, (int)eCol.Value2].Locked = true;
                    //    shtQueryList.Cells[iRowCount, (int)eCol.Value2].BackColor = Color.LightGray;
                    //}
                    else if (m_SheetViewData.ColumnHeader.Cells[0, i].Text != DataDefine.MASTER_NO_FIELD_NAME)
                    {
                        shtQueryList.Cells[iRowCount, (int)eCol.ColumnType].Value = eColumnType.String;
                        shtQueryList.Cells[iRowCount, (int)eCol.Sign].Value = eSign.Like.ToString();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value1].CellType = CtrlUtil.CreateTextCellType();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value2].Locked = true;
                        shtQueryList.Cells[iRowCount, (int)eCol.Value2].BackColor = Color.LightGray;
                    }

                    // Add by Pongthorn S. @ 2012-05-18
                    if (m_SheetViewData.ColumnHeader.Cells[0, i].Text == DataDefine.MASTER_NO_FIELD_NAME)
                    {
                        shtQueryList.Cells[iRowCount, (int)eCol.ColumnType].Value = eColumnType.String;
                        shtQueryList.Cells[iRowCount, (int)eCol.Sign].Value = eSign.Between.ToString();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value1].CellType = CtrlUtil.CreateTextCellType();
                        shtQueryList.Cells[iRowCount, (int)eCol.Value2].CellType = CtrlUtil.CreateTextCellType();
                    }
                }
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_DataView == null)
                return;

            DataTable dt = m_DataView;
            string[] colNames = Enum.GetNames(m_EnumOfSheetData);

            string strFilter = "1=1";

            for (int i = 0; i < shtQueryList.RowCount; i++)
            {
                bool bCheck = Convert.ToBoolean(shtQueryList.Cells[i, (int)eCol.Checkbox].Value);
                eColumnType eType = (eColumnType)Enum.Parse(typeof(eColumnType), shtQueryList.Cells[i, (int)eCol.ColumnType].Value.ToString(), true);
                if (bCheck)
                {
                    switch (eType)
                    {
                        case eColumnType.Number:

                            if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value1].Text)))
                                strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " >= " + shtQueryList.Cells[i, (int)eCol.Value1].Value.ToString();
                            if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value2].Text)))
                                strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " <= " + shtQueryList.Cells[i, (int)eCol.Value2].Value.ToString();

                            break;

                        case eColumnType.DateTime:

                            if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value1].Text)))
                                strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " >= '" + shtQueryList.Cells[i, (int)eCol.Value1].Value.ToString() + "'";
                            if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value2].Text)))
                                strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " <= '" + shtQueryList.Cells[i, (int)eCol.Value2].Value.ToString() + "'";

                            break;

                        case eColumnType.String:
                            

                            if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value1].Text)))
                            // Modified by Pongthorn S. @ 2012-05-18
                            //strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " LIKE '%" + shtQueryList.Cells[i, (int)eCol.Value1].Value.ToString() + "%'";
                            {
                                if (shtQueryList.Cells[i, (int)eCol.ColumnName].Text != DataDefine.MASTER_NO_FIELD_NAME)
                                    strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " LIKE '%" + shtQueryList.Cells[i, (int)eCol.Value1].Value.ToString().Replace("'","''") + "%'";
                                else
                                {
                                    strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " >= " + FilterNumbers(shtQueryList.Cells[i, (int)eCol.Value1].Value.ToString());

                                    if (!(string.Empty.Equals(shtQueryList.Cells[i, (int)eCol.Value2].Text)))
                                        strFilter += " AND " + colNames[Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value)] + " <= " + FilterNumbers(shtQueryList.Cells[i, (int)eCol.Value2].Value.ToString());
                                }
                            }

                            break;

                    }
                }
            }

            DataRow[] results;
            try
            {
                results = dt.Select(strFilter);
            }
            catch (Exception)
            {
                MessageBox.Show("Filter value is not correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //DataRow[] results = dt.Select(strFilter);
            DataTable dtFilter = dt.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            m_SheetViewData.DataSource = dtFilter;

            ////SortInfo[] si = new SortInfo[3];
            ////si[0] = new SortInfo(2, true);
            ////si[1] = new SortInfo(1, true);
            ////shtView.SortRows(0, shtView.RowCount, si);



            //SortInfo[] si = new SortInfo[shtQueryList.RowCount];

            ////ทำให้มันเรียง priority ก่อน
            //shtQueryList.SortRows((int)eCol.Priority, true, true);

            //int iCountSortInfo = 0;

            //for (int i = 0; i < shtQueryList.RowCount; i++)
            //{
            //    bool blCheck = Convert.ToBoolean(shtQueryList.Cells[i, (int)eCol.Checkbox].Value);

            //    if (blCheck)
            //    {
            //        bool blAscending = Convert.ToBoolean(shtQueryList.Cells[i, (int)eCol.Sorting].Value);
            //        int iColIndex = Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value);
            //        si[iCountSortInfo] = new SortInfo(iColIndex, blAscending);
            //        iCountSortInfo++;
            //    }
            //}


            //m_SortingInfo = si;
            ////m_SheetViewData.SortRows(0, m_SheetViewData.ColumnCount, si);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        // Add by Pongthorn S. @ 2012-05-18
        private string FilterNumbers(string unformattedNumber)
        {
            string numberExtractorExpression = @"(\d+\.?\d*|\.\d+)";

            MatchCollection formattedNumber = Regex.Matches(unformattedNumber, numberExtractorExpression);

            StringBuilder numbers = new StringBuilder();

            for (int i = 0; i != formattedNumber.Count; ++i)
            {
                numbers.Append(formattedNumber[i].Value);
            }

            return numbers.ToString();
            //char[] RestrictChars = new[] { '\'', '!', '?', '^', '$', '#', '"', '[', ']', '%', '&', '*' };

            //for (int j = 0; j < RestrictChars.Length; j++)
            //{
            //    text = text.Replace(RestrictChars[j].ToString(), string.Empty);
            //}

            //return text;
        }

        private bool CheckSpecialFilterSymbol(string strFilter)
        {
            char[] SpeacialChar = new[] { '^', '(', ')', '&', '*' };
            int AmountSpeacialChar = 0;

            foreach (char symbol in SpeacialChar)
            {
                AmountSpeacialChar = strFilter.Contains(symbol.ToString()) ? AmountSpeacialChar + 1 : AmountSpeacialChar;
            }

            return !(AmountSpeacialChar == SpeacialChar.Length);
        }

        #endregion

        private void fpQueryList_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)eCol.Checkbox)
            {
                bool blCheck = Convert.ToBoolean(shtQueryList.Cells[e.Row, (int)eCol.Checkbox].Value);

                if (blCheck)
                {
                    string oType = shtQueryList.Cells[e.Row, (int)eCol.ColumnType].Text;

                    if (eColumnType.String.ToString().Equals(oType))
                    {
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, false, e.Row, (int)eCol.Value1);
                        // Add by Pongthorn S. @ 2012-05-18
                        if (shtQueryList.Cells[e.Row,(int)eCol.ColumnName].Text != DataDefine.MASTER_NO_FIELD_NAME)
                            CtrlUtil.SpreadSetCellLocked(shtQueryList, true, e.Row, (int)eCol.Value2);
                        else CtrlUtil.SpreadSetCellLocked(shtQueryList, false, e.Row, (int)eCol.Value2);

                       
                    }
                    else
                    {
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, false, e.Row, (int)eCol.Value1);
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, false, e.Row, (int)eCol.Value2);
                    }


                }
                else
                {
                    object oType = shtQueryList.Cells[e.Row, (int)eCol.ColumnType].Value;

                    if (eColumnType.String.ToString().Equals(oType))
                    {
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, true, e.Row, (int)eCol.Value1);
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, true, e.Row, (int)eCol.Value2);
                    }
                    else
                    {
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, true, e.Row, (int)eCol.Value1);
                        CtrlUtil.SpreadSetCellLocked(shtQueryList, true, e.Row, (int)eCol.Value2);
                    }
                }
            }

            //if (e.Column == (int)eCol.Checkbox)
            //{
            //    bool blCheck = Convert.ToBoolean(shtQueryList.Cells[e.Row, (int)eCol.Checkbox].Value);

            //    if (blCheck)
            //    {
            //        int iMaxPriority = 0;
            //        int iPriority = 0;
            //        for (int i = 0; i < shtQueryList.RowCount; i++)
            //        {
            //            iPriority = 0;
            //            iPriority = Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.Priority].Value);

            //            if (iPriority > iMaxPriority)
            //            {
            //                iMaxPriority = iPriority;
            //            }
            //        }

            //        iMaxPriority = (int)(iMaxPriority / 10 * 10) + 10;

            //        shtQueryList.Cells[e.Row, (int)eCol.Priority].Value = iMaxPriority;
            //    }
            //    else
            //    {
            //        shtQueryList.Cells[e.Row, (int)eCol.Priority].Value = null;
            //    }
            //}
        }




    }
}
