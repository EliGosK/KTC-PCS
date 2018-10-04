using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using System.Data;
using System;
using FarPoint.Win.Spread.CellType;
using EVOFramework.Data;
using FarPoint.Win.Spread.Model;

namespace CommonLib
{
    /// <summary>
    /// Common Control Utility
    /// </summary>
    public class CtrlUtil
    {
        #region Set Next Control
        public static void SetNextControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Control ctrl = (Control)sender;
                Form frm = ctrl.FindForm();
                if (frm == null)
                    return;

                if (!e.Handled)
                    frm.SelectNextControl(frm.ActiveControl, true, true, true, false);
            }
        }
        #endregion

        //#region Prevent RestrictInput
        ///// <summary>
        ///// Set restrict key that can input to textbox. Some character are not allow to input.
        ///// How to use : Bind this event to Textbox.keypress event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public static void SetRestrictKeyInput(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = false;

        //    char[] RestrictChars = new[] { '\'', '"', '[', ']', '%', '&', '*' };

        //    for (int i = 0; i < RestrictChars.Length; i++)
        //    {
        //        if (e.KeyChar == RestrictChars[i])
        //        {
        //            e.Handled = true;
        //        }
        //    }


        //}
        //public static void FilterRestrictChar(object sender, EventArgs e)
        //{
        //    //if (sender != null)
        //    //{
        //    //    char[] RestrictChars = new[] { '\'', '"', '[', ']', '%', '&', '*' };
        //    //    string txt = ((EVOTextBox)sender).Text;
        //    //    //for (int i = 0; i < txt.Length; i++)
        //    //    //{
        //    //    for (int j = 0; j < RestrictChars.Length; j++)
        //    //    {
        //    //        txt = txt.Replace(RestrictChars[j], '_');
        //    //    }
        //    //    ((EVOTextBox)sender).Text = txt;
        //    //}
        //}
        //public static void FilterRestrictChar(object sender)//, KeyEventArgs e)
        //{
        //    //if (sender != null)
        //    //{
        //    //    char[] RestrictChars = new[] { '\'', '"', '[', ']', '%', '&', '*' };
        //    //    string txt = ((EVOTextBox)sender).Text;
        //    //    //for (int i = 0; i < txt.Length; i++)
        //    //    //{
        //    //    for (int j = 0; j < RestrictChars.Length; j++)
        //    //    {
        //    //        txt = txt.Replace(RestrictChars[j], '_');
        //    //    }
        //    //    ((EVOTextBox)sender).Text = txt;
        //    //}

        //}


        //#endregion

        #region VisibleControl
        //add toolstripbutton
        public static void VisibleControl(bool bEnabled, params ToolStripButton[] tbButtons)
        {
            foreach (ToolStripButton tbButton in tbButtons)
            {
                if (tbButton != null)
                {
                    tbButton.Visible = bEnabled;
                }
            }
        }
        private static void _VisibleControl(bool bVisible, Control control)
        {
            control.Visible = bVisible;
        }
        public static void VisibleControl(bool bVisible, params Control[] controls)
        {
            foreach (Control c in controls)
            {
                _VisibleControl(bVisible, c);
            }
        }
        public static void VisibleControl(bool bVisible, Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                _VisibleControl(bVisible, c);
            }
        }
        public static void VisibleControl(bool bVisible, params ToolBarButton[] toolbarButtons)
        {
            foreach (ToolBarButton b in toolbarButtons)
            {
                b.Visible = bVisible;
            }
        }
        #endregion

        #region EnabledControl

        private static void _EnabledControl(bool bEnabled, Control ctl)
        {
            if (ctl == null)
                return;
            if (ctl is TextBoxBase)
            {
                TextBoxBase txt = ((TextBoxBase)ctl);

                txt.ReadOnly = !bEnabled;
                txt.TabStop = bEnabled;
                if (bEnabled)
                {
                    //Normal

                    txt.BackColor = Common.COLOR_NORMAL_BG;
                    txt.ForeColor = Common.COLOR_NORMAL_FG;
                }
                else
                {
                    txt.BackColor = Common.COLOR_READONLY_BG;
                    txt.ForeColor = Common.COLOR_READONLY_FG;
                }
            }
            else if (ctl is EVOComboBox)
            {
                EVOComboBox cbo = ((EVOComboBox)ctl);
                cbo.TabStop = bEnabled;
                cbo.ReadOnly = !bEnabled;

                if (bEnabled)
                {
                    cbo.BackColor = Common.COLOR_NORMAL_BG;
                    cbo.ForeColor = Common.COLOR_NORMAL_FG;
                }
                else
                {
                    cbo.BackColor = Common.COLOR_READONLY_BG;
                    cbo.ForeColor = Common.COLOR_READONLY_FG;
                }

                cbo.SelectionStart = 0;
                cbo.SelectionLength = 0;
            }
            else if (ctl is ComboBox)
            {
                ComboBox cbo = ((ComboBox)ctl);

                cbo.TabStop = bEnabled;
                cbo.Enabled = bEnabled;

                if (bEnabled)
                {
                    cbo.BackColor = Common.COLOR_NORMAL_BG;
                    cbo.ForeColor = Common.COLOR_NORMAL_FG;
                }
                else
                {
                    cbo.BackColor = Common.COLOR_READONLY_BG;
                    cbo.ForeColor = Common.COLOR_READONLY_FG;
                }
            }
            else if (ctl is RadioButton)
            {
                RadioButton cbo = ((RadioButton)ctl);
                cbo.TabStop = bEnabled;
                cbo.Enabled = bEnabled;

            }
            else if (ctl is DateTextBoxWithCalendar)
            {
                DateTextBoxWithCalendar dt = (DateTextBoxWithCalendar)ctl;
                DateTextBox textbox = null;
                Button btn = null;

                for (int i = 0; i < dt.Controls.Count; i++)
                {
                    if (dt.Controls[i] is DateTextBox)
                    {
                        textbox = (DateTextBox)dt.Controls[i];
                    }
                    if (dt.Controls[i] is Button)
                    {
                        btn = (Button)dt.Controls[i];
                    }
                }

                textbox.ReadOnly = !bEnabled;
                btn.Enabled = bEnabled;
                dt.TabStop = bEnabled;

                if (textbox == null)
                    return;

                if (bEnabled)
                {
                    textbox.BackColor = Common.COLOR_NORMAL_BG;
                    textbox.ForeColor = Common.COLOR_NORMAL_FG;
                }
                else
                {
                    textbox.BackColor = Common.COLOR_READONLY_BG;
                    textbox.ForeColor = Common.COLOR_READONLY_FG;
                }

            }
            else if (ctl is Label == false
               && ctl is ToolBar == false
               && ctl is ListView == false
               && ctl is Splitter == false
               && ctl is TreeView == false
               && ctl is FpSpread == false)
            {

                ctl.Enabled = bEnabled;
            }
        }
        //Add by Wirachai T. 2007/05/22
        public static void EnabledControl(bool bEnabled, params FpSpread[] fpSpreads)
        {
            foreach (FpSpread fp in fpSpreads)
            {
                if (fp != null)
                {
                    fp.Enabled = bEnabled;
                }
            }
        }

        public static void EnabledControl(bool bEnabled, params Control[] Controls)
        {
            foreach (Control c in Controls)
            {
                //Raktai 2007/06/14---------------
                if (c.Tag != null && c.Tag.Equals("no control"))
                {

                }
                else
                    //--------------------------------
                    if (c is Panel)
                    {
                        EnabledControl(bEnabled, c.Controls);
                    }
                    else if (c is GroupBox)
                    {
                        EnabledControl(bEnabled, c.Controls);
                    }
                    else if (c is TabControl)
                    {
                        foreach (TabPage tp in ((TabControl)c).TabPages)
                        {
                            EnabledControl(bEnabled, tp.Controls);
                        }
                        //}else if (c is CurrencyTextBox){
                        //    foreach (CurrencyTextBox cb in ((CurrencyTextBox)c.Controls)){
                        //        EnabledControl(bEnabled, cb.Controls);
                        //    }
                    }
                    else
                    {
                        _EnabledControl(bEnabled, c);
                    }
            }
        }
        public static void EnabledControl(bool bEnabled, Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                //Raktai 2007/06/14---------------
                if (c.Tag != null && c.Tag.Equals("no control"))
                {

                }
                else
                    //--------------------------------
                    if (c is Panel)
                    {
                        EnabledControl(bEnabled, c.Controls);
                    }
                    else if (c is GroupBox)
                    {
                        EnabledControl(bEnabled, c.Controls);
                    }
                    else if (c is TabControl)
                    {
                        foreach (TabPage tp in ((TabControl)c).TabPages)
                        {
                            EnabledControl(bEnabled, tp.Controls);
                        }
                    }
                    else
                    {
                        _EnabledControl(bEnabled, c);
                    }
            }
        }

        public static void EnabledControl(bool bEnabled, params ToolStripItem[] tbItems)
        {
            foreach (ToolStripItem tbItem in tbItems)
            {
                if (tbItem != null)
                {
                    tbItem.Enabled = bEnabled;
                }
            }
        }
        // change toolbarbutton to ToolStripButton by Jessada C. 8/5/2008
        public static void EnabledControl(bool bEnabled, params ToolStripButton[] tbButtons)
        {
            foreach (ToolStripButton tbButton in tbButtons)
            {
                if (tbButton != null)
                {
                    tbButton.Enabled = bEnabled;
                }
            }
        }
        public static void EnabledControl(bool bEnabled, params ListView[] lvListView)
        {
            foreach (ListView listView in lvListView)
            {
                if (listView != null)
                {
                    listView.Enabled = bEnabled;
                }
            }
        }
        #endregion

        #region ClearControlData
        private static void _ClearControlData(Control ctl)
        {
            if (ctl == null)
                return;

            if (ctl is ComboBox)
            {
                ((ComboBox)ctl).SelectedIndex = -1;
                ctl.Text = string.Empty;
            }
            else if (ctl is TextBox)
            {
                ctl.Text = string.Empty;
            }

            else if (ctl is CheckBox)
            {
                ((CheckBox)ctl).Checked = false;
            }
            else if (ctl is RadioButton)
            {
                ((RadioButton)ctl).Checked = false;
            }
        }
        public static void ClearControlData(params SheetView[] SheetViews)
        {
            foreach (SheetView sht in SheetViews)
            {
                sht.DataSource = null;
                sht.Rows.Count = 0;
            }
        }
        public static void ClearControlData(params Control[] Controls)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    ClearControlData(c.Controls);
                }

                //// ============================
                else if (c.GetType() == typeof(TabControl))
                {
                    ClearControlData(c.Controls);
                }
                else if (c.GetType() == typeof(TabPage))
                {
                    ClearControlData(c.Controls);
                }
                else if (c.GetType() == typeof(EVODateTextBoxWithCalendar))
                {
                    ((EVODateTextBoxWithCalendar)c).Value = null;
                }

                else if (c.GetType() == typeof(FpSpread))
                {
                    ((FpSpread)c).DataSource = null;
                    ((FpSpread)c).ActiveSheet.Rows.Count = 0;
                }
                else
                {
                    _ClearControlData(c);
                }
            }
        }
        public static void ClearControlData(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    ClearControlData(c.Controls);
                }

                //// ============================
                else if (c.GetType() == typeof(TabControl))
                {
                    ClearControlData(c.Controls);
                }
                else if (c.GetType() == typeof(TabPage))
                {
                    ClearControlData(c.Controls);
                }
                else
                {
                    _ClearControlData(c);
                }
            }
        }
        #endregion

        #region Focus Control
        /// <summary>
        /// Common Control Utility use for focus control.
        /// </summary>
        /// <param name="control"></param>
        public static void FocusControl(Control control)
        {
            control.Focus();
        }

        #endregion

        #region SelectDistinct DataTable
        /// <summary>
        /// Select Distinct same SQL Command
        /// </summary>
        /// <param name="SourceTable">Specific SourceTable</param>
        /// <param name="FieldNames">Specific Field distinct.</param>
        /// <returns>Return specificed filed only.</returns>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
        {
            object[] lastValues = null;
            DataTable newTable = null;
            DataRow[] orderedRows = null;

            if (FieldNames == null || FieldNames.Length == 0)
                throw new ArgumentNullException("FieldNames");

            lastValues = new object[FieldNames.Length];
            newTable = new DataTable();

            foreach (string fieldName in FieldNames)
                newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);

            orderedRows = SourceTable.Select("", string.Join(", ", FieldNames));

            foreach (DataRow row in orderedRows)
            {
                if (!fieldValuesAreEqual(lastValues, row, FieldNames))
                {
                    newTable.Rows.Add(createRowClone(row, newTable.NewRow(), FieldNames));

                    setLastValues(lastValues, row, FieldNames);
                }
            }

            return newTable;
        }

        private static bool fieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
        {
            bool areEqual = true;

            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }

        private static DataRow createRowClone(DataRow sourceRow, DataRow newRow, params string[] fieldNames)
        {
            foreach (string field in fieldNames)
                newRow[field] = sourceRow[field];

            return newRow;
        }

        private static void setLastValues(object[] lastValues, DataRow sourceRow, params string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
                lastValues[i] = sourceRow[fieldNames[i]];
        }
        #endregion

        #region FarPoint Utility
        public static void SpreadUpdateColumnSorting(SheetView shtView)
        {
            for (int i = 0; i < shtView.Columns.Count; i++)
            {
                if (shtView.Columns[i].SortIndicator != SortIndicator.None)
                {
                    shtView.SortRows(i, shtView.Columns[i].SortIndicator == SortIndicator.Ascending, true);
                    break;
                }
            }
        }

        /// <summary>
        /// Use to binding event SubEditorOpening.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SpreadDisableSubEditorOpening(object sender, SubEditorOpeningEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>
        /// Set cell of spread with fore-color and locked cell.
        /// </summary>
        /// <param name="shtView"></param>
        /// <param name="bLock"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public static void SpreadSetCellLocked(SheetView shtView, bool bLock, int row, int col)
        {
            shtView.Cells[row, col].Locked = bLock;
            shtView.Cells[row, col].ForeColor = (bLock) ? Common.SP_LOCK_FG_COLOR : Common.SP_UNLOCK_FG_COLOR;
        }
        /// <summary>
        /// Set cell of spread with fore-color and locked columns.
        /// </summary>
        /// <param name="shtView"></param>
        /// <param name="bLock"></param>
        /// <param name="col"></param>
        public static void SpreadSetColumnsLocked(SheetView shtView, bool bLock, int col)
        {
            shtView.Columns[col].Locked = bLock;
            shtView.Columns[col].ForeColor = (bLock) ? Common.SP_LOCK_FG_COLOR : Common.SP_UNLOCK_FG_COLOR;
        }

        /// <summary>
        /// Get data row from specific view row index.
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="viewRowIndex"></param>
        /// <returns>Return null if can't found data row.</returns>
        public static DataRowView SpreadGetDataRowFromRowIndex(SheetView sheetView, int viewRowIndex)
        {
            int rowIndex = sheetView.GetModelRowFromViewRow(viewRowIndex);
            if (rowIndex == -1)
                return null;
            DefaultSheetDataModel defaultSheetDataModel = (DefaultSheetDataModel)sheetView.Models.Data;
            if (defaultSheetDataModel == null)
                return null;

            int dataIndex = defaultSheetDataModel.GetDataRowFromModelRow(rowIndex);
            if (dataIndex == -1)
                return null;

            DataRowView dr = defaultSheetDataModel.GetDataRow(dataIndex);
            return dr;
        }

        /// <summary>
        /// Function to invoke EndEdit() method of specific row index of spread sheet.
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="viewRowIndex"></param>
        /// <returns>If can't end edit return false. Otherwise return true.</returns>
        public static bool SpreadSheetRowEndEdit(SheetView sheetView, int viewRowIndex)
        {
            int rowIndex = sheetView.GetModelRowFromViewRow(viewRowIndex);
            if (rowIndex == -1)
                return false;
            DefaultSheetDataModel defaultSheetDataModel = (DefaultSheetDataModel)sheetView.Models.Data;
            if (defaultSheetDataModel == null)
                return false;

            int dataIndex = defaultSheetDataModel.GetDataRowFromModelRow(rowIndex);
            if (dataIndex == -1)
                return false;

            DataRowView dr = defaultSheetDataModel.GetDataRow(dataIndex);
            if (dr == null)
                return false;

            dr.EndEdit();
            return true;

        }

        /// <summary>
        /// Map with all name of enum to all column on sheet view.
        /// <para>Order by Column, Relation one-one.</para>
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="typeOfEnum"></param>
        public static void MappingDataFieldWithEnum(SheetView sheetView, Type typeOfEnum)
        {
            string[] strEnumNames = Enum.GetNames(typeOfEnum);

            if (strEnumNames.Length == 0)
                return;

            if (strEnumNames.Length != sheetView.Columns.Count)
            {
                throw new Exception("Please check Spread design with Enum Mapping" + typeOfEnum.Name);
            }

            for (int i = 0; i < sheetView.Columns.Count; i++)
            {
                sheetView.Columns[i].DataField = strEnumNames[i];
            }
        }

        /// <summary>
        /// Map with all name of datasource to all column on sheet view.
        /// <para>Order by Column, Relation one-one.</para>
        /// </summary>
        /// <param name="sheetView"></param>
        /// <param name="typeOfEnum"></param>
        public static void MappingDataFieldWithColumnName(SheetView sheetView, string[] strColumn)
        {

            if (strColumn.Length == 0)
                return;

            for (int i = 0; i < sheetView.Columns.Count; i++)
            {
                sheetView.Columns[i].DataField = strColumn[i];
            }
        }

        /// <summary>
        /// Create instance of DateTimeCellType.
        /// </summary>
        /// <returns></returns>
        public static DateTimeCellType CreateDateTimeCellType()
        {
            return CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
        }

        /// <summary>
        /// Create instance of DateTimeCellType.
        /// </summary>
        /// <param name="dateFormatString">DateTime Format string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>dateFormat</c> is out of range.</exception>
        public static DateTimeCellType CreateDateTimeCellType(string dateFormatString)
        {
            DateTimeCellType cellType = new DateTimeCellType();
            cellType.UserDefinedFormat = dateFormatString;
            cellType.DateTimeFormat = DateTimeFormat.UserDefined;
            cellType.MaximumDate = new DateTime(DateTime.Today.AddYears(10).Year, DateTime.Today.Month, DateTime.Today.Day);
            cellType.MinimumDate = new DateTime(DateTime.Today.AddYears(-10).Year, DateTime.Today.Month, DateTime.Today.Day);


            return cellType;
        }

        public static TextCellType CreateTextCellType()
        {
            TextCellType cellType = new TextCellType();
            return cellType;
        }

        public static CheckBoxCellType CreateCheckboxCellType(string strTextTrue, string strTextFalse)
        {
            CheckBoxCellType chkCellType = new CheckBoxCellType();
            chkCellType.TextTrue = strTextTrue;
            chkCellType.TextFalse = strTextFalse;
            return chkCellType;
        }

        public static CheckBoxCellType CreateCheckboxCellType()
        {
            CheckBoxCellType chkCellType = new CheckBoxCellType();
            return chkCellType;
        }

        /// <summary>
        /// Create Spread's ComboBoxCellType with lookup data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ComboBoxCellType CreateComboBoxCellType(LookupData data)
        {
            return CreateComboBoxCellType(data, true);
        }

        /// <summary>
        /// Create Spread's ComboBoxCellType with lookup data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="showDisplayMember"></param>
        /// <returns></returns>
        public static ComboBoxCellType CreateComboBoxCellType(LookupData data, bool showDisplayMember)
        {
            ComboBoxCellType cell = new ComboBoxCellType();
            cell.Editable = true;
            cell.EditorValue = EditorValue.ItemData;

            if ((data.DataSource as DataTable) != null)
            {
                DataTable dt = data.DataSource;

                string[] strItems = new string[dt.Rows.Count];
                string[] strItemData = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strItemData[i] = dt.Rows[i][data.ValueMember] as string;
                    if (showDisplayMember)
                    {
                        strItems[i] = String.Format("{0}{1}{2}",
                                                    strItemData[i],
                                                    Common.COMBOBOX_SEPERATOR_SYMBOL,
                                                    dt.Rows[i][data.DisplayMember]
                            );

                    }
                    else
                    {
                        strItems[i] = String.Format("{0}",
                                                    strItemData[i]
                            );
                    }
                }

                cell.Items = strItems;
                cell.ItemData = strItemData;
            }

            return cell;
        }

        /// <summary>
        /// Create Spread's ReadOnly pair value text with lookup data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ReadOnlyPairCellType CreateReadOnlyPairCellType(LookupData data)
        {
            return new ReadOnlyPairCellType(data, Common.COMBOBOX_SEPERATOR_SYMBOL);
        }

        public static ReadOnlyPairCellType CreateReadOnlyPairCellType(LookupData data, bool ShowValue)
        {
            return new ReadOnlyPairCellType(data, Common.COMBOBOX_SEPERATOR_SYMBOL, ShowValue);
        }

        public static NumberCellType CreateNumberCellType()
        {
            NumberCellType cellType = new NumberCellType();

            cellType.DecimalPlaces = 2;
            cellType.DecimalSeparator = ".";
            cellType.Separator = ",";
            cellType.ShowSeparator = true;

            cellType.MaximumValue = (Math.Pow(10, 10 /*จำนวนหลัก*/) - 1);
            cellType.MinimumValue = (-1) * (Math.Pow(10, 10 /*จำนวนหลัก*/) - 1);


            return cellType;
        }

        public static void FilterShortCut(KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.Handled = true;
            }
            if (e.Shift && (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Delete))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region DateTime Format Utility
        /// <summary>
        /// Convert DateTime object to formatted string.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ConvertDateTimeToCurrentFormat(DateTime dateTime)
        {
            return dateTime.ToString(Common.CurrentUserInfomation.DateFormatString);
        }

        /// <summary>
        /// Convert DateTime object to formatted string.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><c>dateTime</c> is null.</exception>
        public static string ConvertDateTimeToCurrentFormat(EVOFramework.NZDateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            if (dateTime.IsNull)
                throw new ArgumentNullException("dateTime", "Value is null.");

            return ConvertDateTimeToCurrentFormat(dateTime.StrongValue);
        }
        #endregion

        #region Numeric Format Utility
        /// <summary>
        /// จะคืนค่าเป็น format ของตัวเลขที่จะแสดง
        /// </summary>
        /// <param name="MaxDecimalPlaces"></param>
        /// <returns></returns>
        public static string GetFormatNumber(int MaxDecimalPlaces)
        {
            string dd = "#,##0";
            if (MaxDecimalPlaces > 0)
            {
                dd += ".";
                dd += string.Empty.PadRight(MaxDecimalPlaces, '#');
            }
            return dd;
        }

        /// <summary>
        /// รับค่าตัวเลขที่ต้องการเข้ามาและส่งกลับเป็น format ที่ถูกต้อง
        /// </summary>
        /// <param name="MaxDecimalPlaces"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetCompleteNumberFormatValue(int MaxDecimalPlaces, EVOFramework.NZDecimal Value)
        {
            return string.Format("{0:" + GetFormatNumber(MaxDecimalPlaces) + "}", Value.NVL(0));
        }
        #endregion


        #region Permission Utility

        public enum ePermissionMode { View, Add, Edit, Delete }
        private const string COLUMN_NAME_VIEW = "FLG_VIEW";
        private const string COLUMN_NAME_ADD = "FLG_ADD";
        private const string COLUMN_NAME_EDIT = "FLG_CHG";
        private const string COLUMN_NAME_DELETE = "FLG_DEL";
        private const string COLUMN_NAME_SCREEN_CD = "SCREEN_CD";

        public static void SetPermissionControl(string strScreenCode, ePermissionMode ePermission, params Control[] Controls)
        {
            bool bEnableControl = false;

            bEnableControl = GetPermissionControl(strScreenCode, ePermission);

            CtrlUtil.EnabledControl(bEnableControl, Controls);
        }

        public static void SetPermissionControl(string strScreenCode, ePermissionMode ePermission, params ToolStripItem[] Controls)
        {
            bool bEnableControl = false;

            bEnableControl = GetPermissionControl(strScreenCode, ePermission);

            CtrlUtil.EnabledControl(bEnableControl, Controls);
        }

        public static bool GetPermissionControl(string strScreenCode, ePermissionMode ePermission)
        {
            bool bEnableControl = false;

            DataTable dtPermission = Common.PermissionTable;

            if (dtPermission == null
                || dtPermission.Rows.Count == 0
                || strScreenCode == null
                || "".Equals(strScreenCode.Trim()))
            {
                bEnableControl = false;
            }
            else
            {
                bEnableControl = CheckPermission(strScreenCode, ePermission, dtPermission);
            }


            return bEnableControl;
        }


        private static bool CheckPermission(string strScreenCode, ePermissionMode ePermission, DataTable dtPermission)
        {
            bool bEnableControl = false;
            string strFilterText = "";

            strFilterText = string.Format(COLUMN_NAME_SCREEN_CD + "='{0}'", strScreenCode);


            DataRow[] drResult = dtPermission.Select(strFilterText);

            int iPermissionFlag = 0;

            if (drResult != null && drResult.Length > 0)
            {

                try
                {
                    object oFlag = null;
                    switch (ePermission)
                    {
                        case ePermissionMode.Add:
                            oFlag = drResult[0][COLUMN_NAME_ADD];
                            break;
                        case ePermissionMode.Delete:
                            oFlag = drResult[0][COLUMN_NAME_DELETE];
                            break;
                        case ePermissionMode.Edit:
                            oFlag = drResult[0][COLUMN_NAME_EDIT];
                            break;
                        case ePermissionMode.View:
                            oFlag = drResult[0][COLUMN_NAME_VIEW];
                            break;
                        default:
                            break;
                    }

                    if (oFlag != DBNull.Value)
                    {
                        iPermissionFlag = Convert.ToInt32(oFlag);
                    }
                    else
                    {
                        iPermissionFlag = 0;
                    }
                }
                catch
                {
                    iPermissionFlag = 0;
                }
            }

            if (iPermissionFlag == 1)
            {
                bEnableControl = true;
            }
            else
            {
                bEnableControl = false;
            }


            return bEnableControl;
        }

        #endregion

    }
}
