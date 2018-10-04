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

namespace SystemMaintenance.Forms
{

    [Screen("MCS010", "Multi Column Sorting", eShowAction.Normal, eScreenType.Screen, "Multi Column Sorting")]
    public partial class MultiColumnSorting : CustomizeBaseForm
    {
        #region Enum
        enum eCol
        {
            Checkbox,
            ColumnName,
            Priority,
            Sorting,
            ColumnIndex
        }

        #endregion

        #region Constants

        #endregion

        #region Variables

        private SheetView m_SheetViewData;
        private SortInfo[] m_SortingInfo;

        #endregion

        #region Constructor

        public MultiColumnSorting() { InitializeComponent(); }

        public MultiColumnSorting(SheetView sht)
            : this()
        {
            m_SheetViewData = sht;
        }

        #endregion

        #region Initialize Screen

        #endregion


        #region Properties

        public SortInfo[] SortingInfo { get { return m_SortingInfo; } }

        //public SheetView SortingData { get { return m_SheetViewData; } }

        #endregion

        #region Handles and Overrides

        private void MultiColumnSorting_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                shtQueryList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

                shtQueryList.Columns[(int)eCol.ColumnIndex].Visible = false;

                fpQueryList.Enabled = true;

                ShowColumnName();


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
                    shtQueryList.Cells[iRowCount, (int)eCol.Sorting].Value = true;
                    shtQueryList.Cells[iRowCount, (int)eCol.ColumnIndex].Value = i;
                }
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //SortInfo[] si = new SortInfo[3];
            //si[0] = new SortInfo(2, true);
            //si[1] = new SortInfo(1, true);
            //shtView.SortRows(0, shtView.RowCount, si);



            SortInfo[] si = new SortInfo[shtQueryList.RowCount];

            //ทำให้มันเรียง priority ก่อน
            shtQueryList.SortRows((int)eCol.Priority, true, true);

            int iCountSortInfo = 0;

            for (int i = 0; i < shtQueryList.RowCount; i++)
            {
                bool blCheck = Convert.ToBoolean(shtQueryList.Cells[i, (int)eCol.Checkbox].Value);

                if (blCheck)
                {
                    bool blAscending = Convert.ToBoolean(shtQueryList.Cells[i, (int)eCol.Sorting].Value);
                    int iColIndex = Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.ColumnIndex].Value);
                    si[iCountSortInfo] = new SortInfo(iColIndex, blAscending);
                    iCountSortInfo++;
                }
            }


            m_SortingInfo = si;
            //m_SheetViewData.SortRows(0, m_SheetViewData.ColumnCount, si);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        #endregion

        private void fpQueryList_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)eCol.Checkbox)
            {
                bool blCheck = Convert.ToBoolean(shtQueryList.Cells[e.Row, (int)eCol.Checkbox].Value);

                if (blCheck)
                {
                    int iMaxPriority = 0;
                    int iPriority = 0;
                    for (int i = 0; i < shtQueryList.RowCount; i++)
                    {
                        iPriority = 0;
                        iPriority = Convert.ToInt32(shtQueryList.Cells[i, (int)eCol.Priority].Value);

                        if (iPriority > iMaxPriority)
                        {
                            iMaxPriority = iPriority;
                        }
                    }

                    iMaxPriority = (int)(iMaxPriority / 10 * 10) + 10;

                    shtQueryList.Cells[e.Row, (int)eCol.Priority].Value = iMaxPriority;
                }
                else
                {
                    shtQueryList.Cells[e.Row, (int)eCol.Priority].Value = null;
                }
            }
        }




    }
}
