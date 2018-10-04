using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework;
using SystemMaintenance;
using Rubik.Forms.FindDialog;
using CommonLib;
using FarPoint.Win.Spread;
using Rubik.Validators;

namespace Rubik.MRP {

    //[Screen("ORD020", "Demand Order", eShowAction.Normal, eScreenType.Screen, "Demand Order")]
    public partial class ORD020_DemandOrder : CustomizeBaseForm 
    {
        private void ORD020_DemandOrder_Load(object sender, EventArgs e)
        {                     
            m_BIZDemandOrder = new DemandOrderBIZ();
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumn));
            shtView.Columns[(int)eColumn.ITEM_DESC].Locked = true;

            //Add by Sansanee K. 06 June 2011
            dtpDemand.Focus();

            dtpDemand.Format = MRPDateTimeUtil.SetShortDate(Common.CurrentUserInfomation.DateFormat);

            if (m_DTODemandOrder == null)
            {
                dtpDemand.Text = txtCusCD.Text = txtCusName.Text = string.Empty;
                SetScreenState(eScreenState.View);
            }
            else
            {               
                dtpDemand.Value = m_DTODemandOrder.YEAR_MONTH;
                txtCusCD.Text = m_DTODemandOrder.CUSTOMER_CD;
                txtCusName.Text = (new DealingBIZ().LoadLocation(m_DTODemandOrder.CUSTOMER_CD)).LOC_DESC.StrongValue;
                shtView.DataSource = SearchData(m_DTODemandOrder);
                SetScreenState(eScreenState.Edit);
                SetHolidayColor();
            }
        }

        #region enum


        public enum eScreenState
        {
            View,
            Idle,
            Add,
            Edit
        }

        public enum eModifyState
        {
            None,
            Add,
            Edit,
            Delete
        }

        public enum eColumn
        {
            ITEM_CD, 
            Button,
            ITEM_DESC,
            Day1,
            Day2,
            Day3,
            Day4,
            Day5,
            Day6,
            Day7,
            Day8,
            Day9,
            Day10,
            Day11,
            Day12,
            Day13,
            Day14,
            Day15,
            Day16,
            Day17,
            Day18,
            Day19,
            Day20,
            Day21,
            Day22,
            Day23,
            Day24,
            Day25,
            Day26,
            Day27,
            Day28,
            Day29,
            Day30,
            Day31,
        }      

        #endregion

        #region properties
        private eScreenState m_ScreenStateEnum ;
        private DemandOrderBIZ m_BIZDemandOrder;
        private DialogResult m_Result = DialogResult.Cancel;
        private DemandOrderDTO m_DTODemandOrder = null;
        #endregion

        #region Constructor


        public ORD020_DemandOrder() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.AliceBlue;
            //Add  by Sansanee K. 06 June 2011
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
        }

        public ORD020_DemandOrder(DemandOrderDTO dtoDemandOrder):this()
        {
            m_DTODemandOrder = dtoDemandOrder;
        }

        #endregion

        #region event handler
        

        private void btnSearchByCustomerCode_Click(object sender, EventArgs e)
        {
            NZString[] LocationType = new NZString[] {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer),
                                                           (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)};
            LocationFindDialog dialogLocation = new LocationFindDialog(LocationType);

            dialogLocation.ShowDialog(this);
            if (dialogLocation.IsSelected)
            {
                txtCusCD.Text = dialogLocation.SelectedItem.LOC_CD.ToString();
                txtCusName.Text = dialogLocation.SelectedItem.LOC_DESC.ToString();
            }
        }    

        private void txtCusCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCusCD_Leave(this, null);              
            }
        }

        private void fpView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                eItemType[] itemTypeEnum = { eItemType.All };
                ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.Equal, itemTypeEnum);
                dialog.ShowDialog(this);
                if (dialog.IsSelected)
                {
                    #region validateion
                    int iRow = shtView.ActiveRowIndex;
                    List<string> strItemCDList = new List<string>();
                    for (int i = 0; i < shtView.Rows.Count; i++)
                    {
                        if (i != iRow)
                            strItemCDList.Add(Convert.ToString(shtView.Cells[i, (int)eColumn.ITEM_CD].Value));
                    }
                    ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckDupItem(dialog.SelectedItem.ITEM_CD, strItemCDList));
                    #endregion

                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value = dialog.SelectedItem.ITEM_CD.ToString();
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = dialog.SelectedItem.ITEM_DESC.ToString();
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        private void LoadItemDesc(int iRow)
        {
            try
            {
                #region validateion
                List<string> strItemCDList = new List<string>();
                for (int i = 0; i < shtView.Rows.Count; i++)
                {
                    if (i != iRow)
                        strItemCDList.Add(Convert.ToString(shtView.Cells[i, (int)eColumn.ITEM_CD].Value));
                }
                ErrorItem errItem = PurchaseOrderEntryValidation.CheckDupItem
                    (new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value), strItemCDList);
                if (errItem != null)
                {
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value = string.Empty;
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
                    ValidateException.ThrowErrorItem(errItem);
                }
                #endregion

                ItemBIZ bizItem = new ItemBIZ();
                ItemDTO dtoItem = bizItem.LoadItem((NZString)Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value));

                if (dtoItem != null)
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = Convert.ToString(dtoItem.ITEM_DESC);
                else
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && shtView.ActiveColumnIndex == (int)eColumn.ITEM_CD && shtView.RowCount > 0)
            {
                LoadItemDesc(shtView.ActiveRowIndex);
            }
        }

        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            if (shtView.ActiveColumnIndex == (int)eColumn.ITEM_CD)
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
        }

        private void AddContextMenu_Click(object sender, EventArgs e)
        {
            shtView.OperationMode = OperationMode.Normal;
            shtView.RowCount += 1;

            // ถ้าในตารางมี Record > 0 จะเพิ่มคำสั่ง Delete เข้าไป
            if (shtView.Rows.Count > 0 && ctxMenu.Items.Count < 2)
            {
                ctxMenu.Items.Add("Delete");
                ctxMenu.Items[1].Click += new EventHandler(DeleteContextMenu_Click);
            }
        }

        private void DeleteContextMenu_Click(object sender, EventArgs e)
        {
            shtView.Rows[shtView.ActiveRowIndex].Remove();

            // เช็คว่าถ้าในตารางไม่มี Record อยู่เลย จะเอาคำสั่ง Delete ออก
            if (shtView.RowCount == 0)
                ctxMenu.Items.RemoveAt(1);
        }

        private void ORD020_DemandOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_Result;
        }

        private void tsbSaveAndNew_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.m_DTODemandOrder = null;
                this.SetScreenState(eScreenState.Add);
            }
        }

        private void tsbSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Save())
                this.Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (!IsDoOperation(Messages.eConfirm.CFM9002))
                return;

            try
            {
                DemandOrderDTO dtoDO = GenerateHeaderDemandOrderDTO();
                m_BIZDemandOrder.DeleteDemandOrder(dtoDO);
                shtView.DataSource = SearchData(dtoDO);
                //SetScreenState(eScreenState.View);
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                m_Result = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dtpDemand_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDemand.Value != null)
                SetHolidayColor();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (CanSearchandShowData(GenerateHeaderDemandOrderDTO()))
                    this.SetScreenState(eScreenState.Edit);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        private void txtCusCD_Leave(object sender, EventArgs e)
        {
            DealingBIZ bizLocation = new DealingBIZ();
            DealingDTO dtoLocation = bizLocation.LoadLocation((NZString)Convert.ToString(txtCusCD.Text));
            if (dtoLocation != null)
            {
                txtCusName.Text = Convert.ToString(dtoLocation.LOC_DESC);
            }
            else
                txtCusName.Text = string.Empty;
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (e.Column == (int)eColumn.ITEM_CD)
                LoadItemDesc(e.Row);
        }

        #endregion

        #region private methods


        private bool IsDoOperation(Messages.eConfirm msgCD)
        {
            bool bDoOperation = false;
            switch (MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription))
            {
                case MessageDialogResult.Cancel:
                    break;
                case MessageDialogResult.No:
                    break;
                case MessageDialogResult.Yes:
                    bDoOperation = true;
                    break;
            }
            return bDoOperation;
        }

        private void SetScreenState(eScreenState screenState)
        {            
            this.m_ScreenStateEnum = screenState;           
            shtView.OperationMode = OperationMode.Normal;
            ctxMenu.Items.Clear();          

            switch (m_ScreenStateEnum)
            {
                case (eScreenState.Edit):
                    tsbSaveAndClose.Enabled = true;
                    btnSearch.Enabled = dtpDemand.Enabled = txtCusCD.Enabled = btnSearchByCustomerCode.Enabled = false;                    
                    ctxMenu.Items.Add("Add");
                    ctxMenu.Items[0].Click += new EventHandler(AddContextMenu_Click);
                    if (shtView.RowCount > 0)
                    {
                        ctxMenu.Items.Add("Delete");
                        ctxMenu.Items[1].Click += new EventHandler(DeleteContextMenu_Click);
                    }
                    break;
                case (eScreenState.Add):
                    btnSearch.Enabled = dtpDemand.Enabled = txtCusCD.Enabled = btnSearchByCustomerCode.Enabled = false;

                    tsbSaveAndClose.Enabled = true;

                    ctxMenu.Items.Add("Add");
                    ctxMenu.Items[0].Click += new EventHandler(AddContextMenu_Click);
                    break;
                case (eScreenState.View):
                    shtView.RowCount = 0;
                    tsbSaveAndClose.Enabled = false;
                    btnSearch.Enabled = dtpDemand.Enabled = txtCusCD.Enabled = btnSearchByCustomerCode.Enabled = true;
                    break;
            }    
        }

        private bool Save()
        {
            try
            {
                if (!IsDoOperation(Messages.eConfirm.CFM9001))
                    return false;

                //ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckRecord((NZInt)(shtView.RowCount)));

                switch (this.m_ScreenStateEnum)
                {
                    case eScreenState.Add:
                        AddDemandOrder();
                        break;
                    case eScreenState.Edit:
                        EditDemandOrder();
                        break;
                }

                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                m_Result = DialogResult.OK;
                return true;
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
                return false;
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
                return false;
            }
        }

        private void AddDemandOrder()
        {
            List<TmpDemandOrderDTO> dtoListDemandOrder = new List<TmpDemandOrderDTO>() ;
            GenerateTmpDemandOrderDTOList(dtoListDemandOrder);

            ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckRecord(new NZInt(null, dtoListDemandOrder.Count)));

            DemandOrderDTO dtoDemandOrder = GenerateHeaderDemandOrderDTO();
            if(dtoListDemandOrder.Count >0)
                m_BIZDemandOrder.Add(dtoDemandOrder, dtoListDemandOrder);
        }

        private void EditDemandOrder()
        {
            List<TmpDemandOrderDTO> dtoListDemandOrderUpdate = new List<TmpDemandOrderDTO>();         
            GenerateTmpDemandOrderDTOList(dtoListDemandOrderUpdate);

            ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckRecord(new NZInt(null, dtoListDemandOrderUpdate.Count)));

            DemandOrderDTO dtoDemandOrder = GenerateHeaderDemandOrderDTO();
            if (dtoListDemandOrderUpdate.Count > 0) 
                m_BIZDemandOrder.Update(dtoDemandOrder, dtoListDemandOrderUpdate);
        }

        private void SetHolidayColor()
        {
            shtView.ColumnCount = (int)eColumn.Day31 + 1;
            DateTime dtmSelect = Convert.ToDateTime(dtpDemand.Value);
            DateTime dtmPeriod = new DateTime(dtmSelect.Year, dtmSelect.Month, 1);
            int iDayInMonth = DateTime.DaysInMonth(dtmPeriod.Year, dtmPeriod.Month);

            // set color to holiday
            int ieDay = (int)eColumn.Day1;
            for (int iDay = 1; iDay <= iDayInMonth; iDay++, ieDay++)
            {
                Color color = Color.White;
                if (!m_BIZDemandOrder.IsHoliday(dtmPeriod, new DateTime(dtmPeriod.Year, dtmPeriod.Month, iDay)))
                    color = Color.Gray;
                shtView.Columns[ieDay].BackColor = color;
                if (iDay > 27)
                    shtView.Columns[ieDay].Label = iDay.ToString();
            }
            // set day in month = current date
            shtView.ColumnCount = iDayInMonth + 3;

            for (int iColumn = 0; iColumn < shtView.ColumnCount; iColumn++)
            {
                if (iColumn != (int)eColumn.Button && iColumn != (int)eColumn.ITEM_DESC)
                    shtView.Columns[iColumn].ForeColor = Color.Blue;
            }
        }

        private bool CanSearchandShowData(DemandOrderDTO doDTO)
        {
            DataTable dt = SearchData(doDTO);
            if (dt.Rows.Count > 0)
            {
                shtView.DataSource = dt;
                this.SetScreenState(eScreenState.Idle);
                return true;
            }
            else if (this.m_ScreenStateEnum != eScreenState.Edit)
            {
                if (IsDoOperation(Messages.eConfirm.CFM9013))
                {
                    SetScreenState(eScreenState.Add);
                }
                
            }
            return false;
        }

        private DataTable SearchData(DemandOrderDTO dtoDO)
        {
            SetHolidayColor();

            shtView.Rows.Count = 0;

            DataTable dt = m_BIZDemandOrder.LoadDemandOrderSummary(dtoDO);
            return dt;
        }
       
        private DemandOrderDTO GenerateHeaderDemandOrderDTO()
        {
            ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckEmptyDemandMonth(dtpDemand.Value));
            ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckEmptyCustomerCode(new NZString(txtCusCD, txtCusCD.Text.ToNZString())));
            ValidateException.ThrowErrorItem(DemandOrderSimpleValidation.CheckEmptyCustomerName(new NZString(txtCusCD, txtCusName.Text)));

            return new DemandOrderDTO
            {
                CUSTOMER_CD = (NZString)txtCusCD.Text,
                YEAR_MONTH = (NZDateTime)dtpDemand.Value,
                CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                CRT_DATE = (NZDateTime)DateTime.UtcNow,
                CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                UPD_DATE = (NZDateTime)DateTime.UtcNow,
                UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
            };
        }

        private void GenerateTmpDemandOrderDTOList(List<TmpDemandOrderDTO> dtoDemandOrderList)
        {         
            DateTime dtmSelect = Convert.ToDateTime(dtpDemand.Value);
            for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            {
                #region validation
                ValidateException.ThrowErrorItem(
                    PurchaseOrderEntryValidation.CheckEmptyString((NZString)Convert.ToString(shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value), Messages.eValidate.VLM0129));
                #endregion
                for (int iColumn = (int)eColumn.Day1; iColumn < DateTime.DaysInMonth(dtmSelect.Year, dtmSelect.Month) + (int)eColumn.Day1; iColumn++)
                {
                    TmpDemandOrderDTO dtoTmpDemandOrder = new TmpDemandOrderDTO
                    {
                        CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                        CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                        CRT_DATE = (NZDateTime)DateTime.UtcNow,
                        CUSTOMER_CD = (NZString)txtCusCD.Text,
                        DUE_DATE = (NZDateTime)(new DateTime(dtmSelect.Year, dtmSelect.Month, (iColumn - 2))),
                        ITEM_CD = (NZString)Convert.ToString(shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value.ToString()),
                        ITEM_DESC = (NZString)Convert.ToString(shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value),
                        ORDER_QTY = (NZDecimal)(Convert.ToDecimal(shtView.Cells[iRow, iColumn].Value)),
                        ORDER_TYPE = null,
                        YEAR_MONTH = (NZDateTime)dtpDemand.Value,
                    };

                    if (dtoTmpDemandOrder.ORDER_QTY > 0)
                        dtoDemandOrderList.Add(dtoTmpDemandOrder);
                }
            }
        }

        #endregion    

        private void txtCusCD_TextChanged(object sender, EventArgs e)
        {
            txtCusName.Text = string.Empty;
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }

    public static class DemandOrderSimpleValidation
    {
        public static ErrorItem CheckEmptyDemandMonth(DateTime? dtmCheck)
        {
            if (dtmCheck == null)
                return new ErrorItem(((NZDateTime)Convert.ToDateTime(dtmCheck)).Owner, Messages.eValidate.VLM0112.ToString());
            else
                return null;
        }
        public static ErrorItem CheckEmptyCustomerCode(NZString strCusCode)
        {
            if (strCusCode.IsNull)
                return new ErrorItem(strCusCode.Owner, Messages.eValidate.VLM0113.ToString());
            else
                return null;
        }
        public static ErrorItem CheckEmptyCustomerName(NZString strCusName)
        {
            if (strCusName.IsNull)
                return new ErrorItem(strCusName.Owner, Messages.eValidate.VLM0114.ToString());
            else
                return null;
        }
        public static ErrorItem CheckRecord(NZInt iRow)
        {
            if (iRow == 0)
                return new ErrorItem(iRow.Owner, Messages.eValidate.VLM0151.ToString());
            else
                return null;
        }
    }
}
