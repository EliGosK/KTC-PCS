using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Cube.AFD.Windows.Controls.CalendarControls;
using Rubik.BIZ;
using Rubik.DTO;
using System.Runtime.InteropServices;
using SystemMaintenance;
using CommonLib;

namespace Rubik.MRP
{
    /// <summary>
    /// สถานะของหน้าจอ สำหรับกำหนดการ Edit
    /// </summary>
    //[Screen("MRP011", "Source Order", eShowAction.Normal, eScreenType.Dialog, "Source Order")]
    public partial class MRP011_SourceOrder : CustomizeBaseForm {

        #region Enum

        private enum eData 
        {
            ItemCD,
            ItemDesc,
            Date
        }

        #endregion

        #region constructor
        public MRP011_SourceOrder()
        {
            InitializeComponent();
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
        }

        public MRP011_SourceOrder(GenerateMRPDTO param) : this(){
            InitialData(param);
        }
        #endregion

        #region General Method

        private void ClearControl()
        {
            CtrlUtil.ClearControlData(this.Controls);
            shtView.RowCount = 0;
            shtView.ColumnCount = 0;
        }

        private void InitialData(GenerateMRPDTO dto) 
        {
            ClearControl();

            txtStartDate.Text = ((DateTime)dto.START_DATE.Value).ToString(Common.CurrentUserInfomation.DateFormatString);
            txtItemFrom.Text = dto.ITEM_CD_FROM;
            txtItemTo.Text = dto.ITEM_CD_TO;

            DemandOrderBIZ biz = new DemandOrderBIZ();
            DataTable dt = biz.LoadSourceOrderSummaryEachMonth(dto);
            if (dt != null && dt.Rows.Count > 0) 
            {
                BindData(dt);
            }
        }

        private void BindData(DataTable dt) 
        {
            //string [] strColumn = new string[dt.Columns.Count];
            //for (int i = 0; i < strColumn.Length; i++) 
            //{
            //    strColumn[i] = dt.Columns[i].ColumnName;
            //}

            //shtView.Columns.Count = strColumn.Length;
            //CtrlUtil.MappingDataFieldWithColumnName(shtView, strColumn);
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
            shtView.DataSource = dt;
            //for (int i = 0; i < strColumn.Length; i++) 
            //{
                
            //}

            //shtView.Columns[(int)eData.ItemCD].Width = 100;
            //shtView.Columns[(int)eData.ItemDesc].Width = 100;
            //for (int i = (int)eData.Date; i < shtView.Columns.Count; i++) 
            //{
            //    shtView.Columns[i].Width = 60;
            //    shtView.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //}
        }
        
        #endregion

        #region Event

        private void MRP011_SourceOrder_Load(object sender, EventArgs e) {

        }  

        #endregion

        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}