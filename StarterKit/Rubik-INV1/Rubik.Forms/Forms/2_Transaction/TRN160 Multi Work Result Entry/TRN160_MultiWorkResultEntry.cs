using SystemMaintenance.Forms;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using Rubik.BIZ;
using CommonLib;
using EVOFramework;
using Rubik.Controller;
using Rubik.Forms.FindDialog;
using Rubik.UIDataModel;
using Rubik.Validators;
using Rubik.DTO;
using Message = EVOFramework.Message;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Data;
using System.ComponentModel;
using SystemMaintenance;

namespace Rubik.Transaction
{


    //[Screen("TRN160", "Work Result Entry (Multi-line)", eShowAction.Normal, eScreenType.Screen, "Work Result Entry (Multi-line)")]
    public partial class TRN160_MultiWorkResultEntry : CustomizeForm
    {
        #region Enum

        private enum eScreenMode
        {
            VIEW,
            ADD,
            EDIT
        } ;

        private enum eSubStateAdd
        {
            A_OpenScreeen,
            B_SelectWorkResult,
            C_SpecifyLotNo,
            D_InputDetail,
        }

        public enum eColView
        {
            WORK_RESULT_NO,
            LOT_NO,
            ON_HAND_QTY,
            GOOD_QTY,
            RESERVE_QTY,
            NG_QTY,
            GOOD_TRANSACTION_ID,
            RESERVE_TRANSACTION_ID,
            NG_TRANSACTION_ID,
            CONSUMPTION_TRANSACTION_ID,
            NG_REASON
        } ;
        #endregion

        #region Variables
        private readonly MultiWorkResultController m_controller = new MultiWorkResultController();

        private readonly LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
        private readonly InventoryBIZ m_bizInventory = new InventoryBIZ();
        private readonly InventoryTransBIZ m_bizInventoryTrans = new InventoryTransBIZ();
        private readonly BOMBIZ m_bizBOM = new BOMBIZ();
        private readonly ItemBIZ m_bizItem = new ItemBIZ();

        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();


        private eScreenMode m_screenMode = eScreenMode.ADD;
        private DialogResult m_dialogResult = DialogResult.Cancel;
        private KeyboardSpread m_keyboardSpread = null;
        private NZString m_TransID = null;


        private List<BOMSetupDTO> m_listEquivalent;
        private string m_orderLoc;
        //private const string DEFAULT_STORE_LOC_FOR_FG = "QAWH";
        /// <summary>
        /// เก็บรายการของ Child Item ที่จะใช้ทำ Consumption
        /// ค่านี้จะใช้ตรวจสอบก่อนที่จะ
        /// </summary>
        //private List<WorkResultEntryViewDTO> m_listRequireChildItems = new List<WorkResultEntryViewDTO>();
        #endregion

        #region Constructor
        public TRN160_MultiWorkResultEntry()
        {
            m_listEquivalent = new List<BOMSetupDTO>();

            InitializeComponent();
            this.btnItemCode.Click += new System.EventHandler(this.btnItemCode_Click);
            this.txtItemCode.Validating += new CancelEventHandler(txtItemCode_Validating);
        }

        public TRN160_MultiWorkResultEntry(NZString transID)
            : this()
        {

            m_TransID = transID;
        }
        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            CheckCurrentInvPeriod();
            InitializeComboBox();
            InitializeSpread();
            InitializeLookupData();


            InitlializeBindingControl();
            InitializeKeyPress();

            //dtWorkResultDate.Format = Common.CurrentUserInfomation.DateFormatString;
            //txtGoodQty.AllowNegative = true;

            //CtrlUtil.EnabledControl(false, txtItemDesc, cboConsumptionCls, txtGoodQty);

        }

        #region Sub-Initialize screen method
        private void InitializeLookupData()
        {
            LookupData locationData = m_bizLookupData.LoadLookupLocation();
            cboOrderLoc.LoadLookupData(locationData);
            cboStoredLoc.LoadLookupData(locationData.Clone());

            //// Lookup Consumption class
            //LookupData lookupConsumtion = m_bizLookupData.LoadLookupClassType(DataDefine.CONSUMPTION_CLS.ToNZString());
            //cboConsumptionCls.LoadLookupData(lookupConsumtion);

            // Lookup Consumption class
            LookupData lookupShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            cboShiftCls.LoadLookupData(lookupShiftCls);


            LookupData lookupWorkResultCls = m_bizLookupData.LoadLookupClassType(DataDefine.WORK_RESULT_CLS.ToNZString());
            cboTypeCls.LoadLookupData(lookupWorkResultCls);

            cboOrderLoc.SelectedIndex = -1;
            cboStoredLoc.SelectedIndex = -1;
            //cboConsumptionCls.SelectedIndex = -1;
            cboShiftCls.SelectedIndex = -1;
            cboTypeCls.SelectedIndex = -1;
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpView);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;


            //LookupDataBIZ biz = new LookupDataBIZ();

            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()));


            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));


        }





        private void InitializeComboBox()
        {
            cboOrderLoc.Format += Common.ComboBox_Format;
            cboShiftCls.Format += Common.ComboBox_Format;
            cboStoredLoc.Format += Common.ComboBox_Format;
            cboTypeCls.Format += Common.ComboBox_Format;
        }

        private void InitlializeBindingControl()
        {
            dmc.AddRangeControl(
                txtWRGroupNo,
                cboTypeCls,
                cboShiftCls,
                txtItemCode,
                txtItemDesc,
                cboOrderLoc,
                txtChildItemNo,
                txtWRGroupNo,
                dtWorkResultDate,
                txtForMachine,
                cboStoredLoc,
                txtRemark,
                txtLotNo,
                txtWorkOrderNo

                );
        }

        private void InitializeKeyPress()
        {
            //cboTypeCls.KeyPress += CtrlUtil.SetNextControl;
            cboShiftCls.KeyPress += CtrlUtil.SetNextControl;
            txtItemCode.KeyPress += CtrlUtil.SetNextControl;
            txtItemDesc.KeyPress += CtrlUtil.SetNextControl;
            txtChildItemNo.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtForMachine.KeyPress += CtrlUtil.SetNextControl;
            dtWorkResultDate.KeyPress += CtrlUtil.SetNextControl;
            txtWRGroupNo.KeyPress += CtrlUtil.SetNextControl;
            txtWorkOrderNo.KeyPress += CtrlUtil.SetNextControl;


            cboOrderLoc.KeyPress += CtrlUtil.SetNextControl;
            cboStoredLoc.KeyPress += CtrlUtil.SetNextControl;


            txtRemark.KeyPress += CtrlUtil.SetNextControl;

        }
        #endregion

        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD);
            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.ITEM_CD_BTN);

            //// fix for Add New Row
            //((DataTable)shtView.DataSource).Rows[rowIndex][2] = cboOrderLoc.SelectedValue;//.Cells[rowIndex, 2].Value = cboOrderLoc.SelectedValue;
        }

        void m_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {
            //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            //if (dr == MessageDialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion

        #region Screen mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.VIEW:
                    DisableAllControl();

                    break;
                case eScreenMode.ADD:
                    //CtrlUtil.EnabledControl(true, dtWorkResultDate, txtItemCode, txtWorkOrderNo
                    //    , cboOrderLoc, cboStoredLoc, txtLotNo, numWorkResultQty, txtRemark, cboShiftCls);
                    //CtrlUtil.EnabledControl(false, txtItemDesc);

                    m_keyboardSpread.StartBind();
                    DisableAllControl();
                    SetSubState(eSubStateAdd.A_OpenScreeen);

                    break;
                case eScreenMode.EDIT:
                    m_keyboardSpread.StartBind();
                    DisableAllControl();

                    CtrlUtil.EnabledControl(true, txtWorkOrderNo, txtRemark);

                    shtView.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.WORK_RESULT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.ON_HAND_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.GOOD_QTY);

                    if (DataDefine.eTRAN_SUB_CLS.WR.ToString() == (string)cboTypeCls.SelectedValue)
                    {
                        CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.RESERVE_QTY);
                    }
                    else
                    {
                        CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.RESERVE_QTY);
                    }
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.NG_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.NG_REASON);

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    break;
            }

            m_screenMode = mode;
        }
        #endregion

        #region Override method
        public override void OnSaveAndNew()
        {
            fpView.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);
            RemoveRowUnused(shtView);
            //if (txtItemCode.SelectedItemData != null)
            //    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    SaveData();
                }


            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                //MessageDialog.ShowBusiness(this, null, err.Message);
                //Console.WriteLine(err.StackTrace);

                // ถ้าเป็น error ที่มาจากการหา FIFO Process
                if (err.Message.IndexOf('|') != -1)
                {
                    string[] msgs = err.Message.Split('|');
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(msgs[0], new[] { msgs[1] }));
                }
                else
                    MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void SaveData()
        {
            ItemValidator val = new ItemValidator();
            ValidateException.ThrowErrorItem(val.CheckEmptyItemCode(txtItemCode.Text.Trim().ToNZString()));
            MultiWorkResultEntryUIDM model = dmc.SaveData(new MultiWorkResultEntryUIDM());
            model.DataView = (DataTable)shtView.DataSource;

            if (m_controller.SaveData(model))
            {
                MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

                ClearNonDefault();

                SetScreenMode(eScreenMode.ADD);
                SetSubState(eSubStateAdd.B_SelectWorkResult);


                m_dialogResult = DialogResult.OK;

                m_listEquivalent.Clear();
                m_orderLoc = null;
            }
        }

        public override void OnSaveAndClose()
        {
            fpView.StopCellEditing();
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }
            }
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);
            RemoveRowUnused(shtView);
            //if (txtItemCode.SelectedItemData != null)
            //    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            try
            {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    SaveData();
                }

                m_dialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                // ถ้าเป็น error ที่มาจากการหา FIFO Process
                if (err.Message.IndexOf('|') != -1)
                {
                    string[] msgs = err.Message.Split('|');
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(msgs[0], new[] { msgs[1] }));
                }
                else
                    MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }
        }
        #endregion

        #region Load Data

        private void LoadDataByItem(DataDefine.eTRAN_SUB_CLS workResultType)
        {
            MultiWorkResultEntryUIDM model = dmc.SaveData(new MultiWorkResultEntryUIDM());


            List<MultiWorkResultEntryViewDTO> listItems = null;
            if (model.ChildItemCode == null || model.StoredLoc == null)
                MessageDialog.ShowBusiness(this, "input item, order location first");


            listItems = m_controller.LoadChildItemToInputMultiWorkResult(model.ChildItemCode, model.OrderLoc, model.LotNo, workResultType);

            model.DataView = DTOUtility.ConvertListToDataTable(listItems);

            // Adjust state all rows to "Added".
            model.DataView.AcceptChanges();

            if (m_screenMode == eScreenMode.ADD)
            {
                for (int i = 0; i < model.DataView.Rows.Count; i++)
                {
                    model.DataView.Rows[i].SetAdded();
                }
            }

            //// Initialize Require Child Item Consumption List.
            //m_listRequireChildItems.Clear();
            //m_listRequireChildItems.AddRange(listItems);

            // generate spread.
            if (m_screenMode == eScreenMode.ADD)
            {

                // If mode ADD will generate new data to display.
                LoadDataTableIntoSpread(model.DataView);
            }
            else
            {
                //// If mode Update, will calculate request qty again.
                //for (int i = 0; i < shtView.RowCount; i++)
                //{
                //    NZObject item_cd = new NZObject(null, shtView.Cells[i, (int)eColView.ITEM_CD].Value);
                //    NZObject lot_no = new NZObject(null, shtView.Cells[i, (int)eColView.LOT_NO].Value);

                //    for (int j = 0; j < listItems.Count; j++)
                //    {
                //        if (Equals(item_cd.Value, listItems[j].ITEM_CD.Value))
                //        {
                //            //shtView.Cells[i, (int)eColView.REQUEST_QTY].Value = listItems[j].REQUEST_QTY.Value;
                //            //shtView.Cells[i, (int)eColView.CONSUMPTION_QTY].Value = listItems[j].CONSUMPTION_QTY.Value;
                //            break;
                //        }
                //    }
                //}

                //// Commit all row in DataTable.
                //if (shtView.DataSource != null)
                //{
                //    DataTable dtView = (DataTable)shtView.DataSource;
                //    for (int i = 0; i < dtView.Rows.Count; i++)
                //    {
                //        dtView.Rows[i].EndEdit();
                //    }
                //}
            }


        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != sheet.RowCount - 1)
            {
                sheet.RemoveRows(sheet.RowCount - 1, 1);
            }
        }

        private void LoadDataTableIntoSpread(DataTable dtView)
        {
            shtView.RowCount = 0;

            shtView.DataSource = dtView;

            // update locked cell by condition on each row.
            for (int i = 0; i < shtView.RowCount; i++)
            {
                DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, i);
                if (drv == null)
                    continue;


                CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.LOT_NO);
                CtrlUtil.SpreadSetCellLocked(shtView, true, i, (int)eColView.ON_HAND_QTY);


            }

        }

        private void ClearAll()
        {
            CtrlUtil.ClearControlData(cboShiftCls, txtItemCode, txtItemDesc,
                txtChildItemNo, txtLotNo, txtForMachine,
                //dtWorkResultDate, 
                txtWRGroupNo,
                txtWorkOrderNo, cboOrderLoc, cboStoredLoc, txtRemark);

            shtView.RowCount = 0;
            if (shtView.DataSource != null)
                ((DataTable)shtView.DataSource).Rows.Clear();
        }

        private void ClearNonDefault()
        {
            CtrlUtil.ClearControlData(txtItemCode, txtItemDesc,
                txtChildItemNo, txtLotNo, txtForMachine,
                txtWRGroupNo,
                txtWorkOrderNo, cboOrderLoc, cboStoredLoc, txtRemark);

            txtChildItemNo.DataSource = null;


            shtView.RowCount = 0;
            if (shtView.DataSource != null)
                ((DataTable)shtView.DataSource).Rows.Clear();
        }

        /// <summary>
        /// Get child item from List of ChildItems global variables.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        private WorkResultEntryViewDTO GetChildItem(NZString itemCode)
        {
            //if (m_listRequireChildItems == null)
            //    return null;

            //for (int i = 0; i < m_listRequireChildItems.Count; i++)
            //{
            //    if (Equals(m_listRequireChildItems[i].ITEM_CD.Value, itemCode.Value))
            //    {
            //        return m_listRequireChildItems[i];
            //    }
            //}

            return null;
        }

        private NZDecimal SumConsumptionQtyByItem(NZString itemCode, params int[] excludeRow)
        {
            NZDecimal sumQty = new NZDecimal(null, 0);

            for (int i = 0; i < shtView.RowCount; i++)
            {

                // check row for not calculate.
                bool bExclude = false;
                for (int iExclude = 0; iExclude < excludeRow.Length; iExclude++)
                {
                    if (i == excludeRow[iExclude])
                    {
                        bExclude = true;
                        break;
                    }
                }

                if (bExclude)
                    continue;

                // summary.
                DataRowView drv = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, i);
                //if (Equals(drv[WorkResultEntryViewDTO.eColumns.ITEM_CD.ToString()], itemCode.StrongValue))
                //{
                //    NZDecimal qty = new NZDecimal(null, drv[WorkResultEntryViewDTO.eColumns.CONSUMPTION_QTY.ToString()]);
                //    sumQty.Value = sumQty.StrongValue + qty.NVL(0);
                //}
            }

            return sumQty;
        }
        #endregion

        #region Form event
        private void TRN160_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            if (m_TransID == null)
            {

                SetScreenMode(eScreenMode.ADD);

                MultiWorkResultEntryUIDM model = m_controller.CreateUIDMForAddMode();
                dmc.LoadData(model);

                // Binding spread sheet with data table which has shcema, but no has any row.
                LoadDataTableIntoSpread(model.DataView);

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN160.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN160.SYS_KEY.DEFAULT_DATE.ToString();
                dtWorkResultDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            }
            else
            {
                bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(m_TransID);

                MultiWorkResultEntryUIDM model = m_controller.LoadForEditMultiWorkResult(m_TransID);

                List<BOMSetupDTO> listBOM = new List<BOMSetupDTO>();
                BOMSetupDTO bom = new BOMSetupDTO();
                bom.LOWER_ITEM_CD = model.ChildItemCode;
                bom.UPPER_ITEM_CD = model.ItemCode;
                listBOM.Add(bom);

                DataTable dtBOM = DTOUtility.ConvertListToDataTable(listBOM);
                LookupData lookupChild = new LookupData(dtBOM
                    , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString()
                    , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString());

                txtChildItemNo.LoadLookupData(lookupChild);


                dmc.LoadData(model);

                //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;

                // Binding spread sheet with data table which has shcema, but no has any row.
                LoadDataTableIntoSpread(model.DataView);

                if (bCanEdit)
                {
                    SetScreenMode(eScreenMode.EDIT);
                }
                else
                {
                    SetScreenMode(eScreenMode.VIEW);
                }

            }
        }

        private void TRN160_Shown(object sender, EventArgs e)
        {
            if (m_screenMode == eScreenMode.ADD)
            {
                CtrlUtil.FocusControl(dtWorkResultDate);
                //if (dtWorkResultDate.Value.HasValue && txtLotNo.Text.Trim() == string.Empty) {
                //    txtLotNo.Text = dtWorkResultDate.Value.Value.ToString("yyyyMMdd");
                //}
            }
            else
            {
                //CtrlUtil.FocusControl(numWorkResultQty);
            }
        }

        private void TRN160_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
        }
        #endregion

        #region Control event
        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tslControl.Select();
                tsbSaveAndNew.Select();

            }
        }

        private void numWorkResultQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    e.Handled = true;
            //    try
            //    {
            //        NZString ComsumptionCls = cboConsumptionCls.SelectedValue == null ? new NZString() : cboConsumptionCls.SelectedValue.ToString().ToNZString();
            //        // Validate data before load data into spread.
            //        WorkResultEntryValidator validator = new WorkResultEntryValidator();
            //        validator.ValidateBeforeLoadConsumption(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal(), ComsumptionCls);

            //        LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());
            //        e.Handled = false;
            //    }
            //    catch (ValidateException err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
            //        err.ErrorResults[0].FocusOnControl();
            //    }
            //    catch (BusinessException err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.Error.Message);
            //        err.Error.FocusOnControl();
            //    }
            //    catch (Exception err)
            //    {
            //        MessageDialog.ShowBusiness(this, err.Message);
            //        System.Diagnostics.Debug.WriteLine(err.StackTrace);
            //    }

            //}
        }
        #endregion


        #region Spread event

        #region Variables
        /// <summary>
        /// เก็บรายการของทุกฟิล์ดในแถวที่กำลังแก้
        /// </summary>
        private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        private bool m_bRowHasModified = false;
        #endregion

        #region Utility method
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex)
        {
            m_mapCellValue.RemoveAll();
            for (int i = 0; i < shtView.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtView.Cells[rowIndex, i].Value);
            }
        }

        /// <summary>
        /// คืนค่า Cell ที่เก็บไว้ กลับคืนไปยัง Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RestoreCellValues(int rowIndex)
        {
            if (m_mapCellValue.Count > 0)
            {
                for (int i = 0; i < m_mapCellValue.Count; i++)
                {
                    shtView.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }
        #endregion

        #region Spread trigger.
        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified)
            {
                m_bRowHasModified = true;
                StoreCellValues(shtView.ActiveRowIndex);
            }
        }

        private void fpView_EditModeOff(object sender, EventArgs e)
        {

            int rowIndex = shtView.ActiveRowIndex;
            int colIndex = shtView.ActiveColumnIndex;

            bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (!bValidateCellPass)
            {
                shtView.SetActiveCell(rowIndex, colIndex);
            }
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (m_bRowHasModified)
            {  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
                if (e.Row != e.NewRow)
                {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!ValidateRowSpread(e.Row, false))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (m_bRowHasModified)
                {
                    int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtView.RowCount - 1)
                    {
                        shtView.RemoveRows(shtView.RowCount - 1, 1);
                    }
                    else
                    {
                        RestoreCellValues(shtView.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused(shtView);
                }
            }
        }

        private void fpView_Validating(object sender, CancelEventArgs e)
        {

            if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Spread Validate
        /// <summary>
        /// Validate เมื่อ Cell มีการแก้ไขเรียบร้อย  และค่าที่แก้ไขเป็นค่าใหม่
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private bool ValidateCellEdited(int row, int column)
        {
            //if (column == (int)eColView.ITEM_CD ||
            //    column == (int)eColView.LOT_NO)
            //{
            //    ItemValidator itemValidator = new ItemValidator();

            //    NZString itemCode = new NZString(null, shtView.GetValue(row, (int)eColView.ITEM_CD));

            //    // Validate Input ItemCode.
            //    if (column == (int)eColView.ITEM_CD)
            //    {
            //        //== Not error, but clear content all columns.
            //        if (itemCode.IsNull || itemCode.StrongValue.Trim() == String.Empty)
            //        {
            //            // Clear content on row.
            //            shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //            shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //            shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //            shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //            return true;
            //        }

            //        // Lookup Lot No
            //        //LookupData lookupLotNo = m_bizLookupData.LoadLookupLotNo(itemCode, new NZString(null, cboOrderLoc.SelectedValue), dtWorkResultDate.Value.Value.ToString("yyyyMM").ToNZString());
            //        //shtView.Cells[row, (int)eColView.LOT_NO].CellType = CtrlUtil.CreateComboBoxCellType(lookupLotNo, false);
            //    }

            //    ItemDTO itemDTO = m_bizItem.LoadItem(itemCode);
            //    if (itemDTO == null)
            //    {
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //        CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //        shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //        shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = null;
            //        shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = null;
            //    }
            //    else
            //    {
            //        //== Update LOT_CONTROL_CLS on DataTable's current row.
            //        DataRowView dataRowView = CtrlUtil.SpreadGetDataRowFromRowIndex(shtView, row);
            //        dataRowView[WorkResultEntryViewDTO.eColumns.LOT_CONTROL_CLS.ToString()] = itemDTO.LOT_CONTROL_CLS.Value;
            //        if (itemDTO.LOT_CONTROL_CLS.StrongValue == "00")
            //        {
            //            CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
            //            CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_BTN);
            //            shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
            //        }
            //        else
            //        {
            //            CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_NO);
            //            CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_BTN);
            //        }

            //        // Load INV_UM_CLS
            //        shtView.Cells[row, (int)eColView.INV_UM_CLS].Value = itemDTO.INV_UM_CLS.Value;


            //        NZString lotNo = new NZString(null, shtView.GetValue(row, (int)eColView.LOT_NO));
            //        WorkResultEntryViewDTO viewDTO = GetChildItem(itemCode);

            //        //== Load stock onhand qty.
            //        //InventoryOnhandDTO inventoryOnhandDTO = m_bizInventory.LoadInventoryOnHandByCurrentPeriod(itemCode, cboOrderLoc.ToNZString(), lotNo);
            //        //// not found stock.
            //        //if (inventoryOnhandDTO == null)
            //        //{
            //        //    shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = 0;
            //        //}
            //        //else
            //        //{
            //        //    shtView.Cells[row, (int)eColView.ON_HAND_QTY].Value = inventoryOnhandDTO.ON_HAND_QTY.Value;
            //        //} // end check stock.



            //        //== Calculate next consumption qty.
            //        if (viewDTO == null)
            //        {
            //            // ถ้า item ที่ระบุ ไม่ใช่ของ Child Item ที่จะตัด Consumption
            //            // ให้ Default ค่า ConsumptionQty = 0;
            //            shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = 0;
            //            shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //        }
            //        else
            //        {
            //            shtView.Cells[row, (int)eColView.REQUEST_QTY].Value = viewDTO.REQUEST_QTY.Value;

            //            NZDecimal consumptionQty = new NZDecimal(null, shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value);

            //            // ถ้าค่า ConsumptionQty เป็นค่าว่างหรือศูนย์ หมายถึงผู้ใช้ยังไม่มีการ Assign ค่า  ดังนั้นจะ default ค่าให้ตรงกับค่าคงเหลือที่จะต้องตัด Consumption
            //            if (consumptionQty.IsNull || consumptionQty.StrongValue == 0)
            //            {
            //                // Find new consumptionQty.
            //                DataTable dtView = (DataTable)shtView.DataSource;
            //                if (dtView == null)
            //                {
            //                    shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = 0;
            //                    return true;
            //                }

            //                NZDecimal sumConsumption = SumConsumptionQtyByItem(itemCode, row);
            //                shtView.Cells[row, (int)eColView.CONSUMPTION_QTY].Value = Math.Max(0, viewDTO.REQUEST_QTY.NVL(0) - sumConsumption.NVL(0));

            //            }
            //        }
            //    }
            //}



            return true;
        }

        /// <summary>
        /// Validate spread row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="forceValidate">force to validate.</param>
        /// <returns></returns>
        private bool ValidateRowSpread(int row, bool forceValidate)
        {
            //if (!forceValidate && !m_bRowHasModified)
            //    return true;

            //if (shtView.RowCount <= 0)
            //    return true;

            //object src_item_cd = shtView.Cells[row, (int)eColView.ITEM_CD].Value;
            //object src_lot_no = shtView.Cells[row, (int)eColView.LOT_NO].Value;

            //for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            //{
            //    if (iRow == row)
            //        continue;

            //    // Check key duplidate.
            //    object item_cd = shtView.Cells[iRow, (int)eColView.ITEM_CD].Value;
            //    object lot_no = shtView.Cells[iRow, (int)eColView.LOT_NO].Value;

            //    if (Equals(src_item_cd, item_cd) && Equals(src_lot_no, lot_no))
            //    {
            //        MessageDialog.ShowBusiness(this, null, "Data has already exist.");
            //        return false;
            //    }
            //}

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }
        #endregion

        private void txtItemCode_KeyPressResult(object sender, bool isFound, NZString ItemCD)
        {
            if (!isFound)
            {
                this.txtItemCode.Text = "";
                this.txtItemDesc.Text = "";
                this.txtChildItemNo.DataSource = null;

                CtrlUtil.EnabledControl(false, txtChildItemNo);

                return;
            }


            ValidateAfterSelectItem();
        }


        #endregion

        #region Check Inventory Period
        private void CheckCurrentInvPeriod()
        {

            try
            {
                InventoryPeriodValidator val = new InventoryPeriodValidator();
                ErrorItem err = val.CheckInventoryCurrentPeriod();
                if (err != null)
                {
                    MessageDialog.ShowInformation(this, "Out of period", err.Message.MessageDescription);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
        }

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            ValidateAfterSelectItem();
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            //NZString ItemCD = new NZString(null, shtView.Cells[e.Row, (int)eColView.ITEM_CD].Value);
            //NZString LotNo = new NZString(null, shtView.Cells[e.Row, (int)eColView.LOT_NO].Value);
            ////NZString LocCD = new NZString(cboOrderLoc, cboOrderLoc.SelectedValue);

            //if (e.Column == (int)eColView.ITEM_CD_BTN)
            //{
            //    ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, null);
            //    dialog.ShowDialog(this);

            //    if (dialog.IsSelected)
            //    {
            //        shtView.Cells[e.Row, (int)eColView.ITEM_CD].Value = dialog.SelectedItem.ITEM_CD.Value;
            //        ValidateCellEdited(e.Row, (int)eColView.ITEM_CD);
            //    }
            //}
            //else if (e.Column == (int)eColView.LOT_BTN)
            //{
            //    NZString locCD = new NZString(null, cboOrderLoc.SelectedValue);
            //    LotNoFindDialog dialog = new LotNoFindDialog(ItemCD, locCD);

            //    dialog.ShowDialog(this);
            //    if (dialog.IsSelected)
            //    {
            //        shtView.Cells[e.Row, (int)eColView.LOT_NO].Value = dialog.SelectedItem.NVL(string.Empty);
            //        LotNo = new NZString(null, shtView.Cells[e.Row, (int)eColView.LOT_NO].Value);
            //        //== Load stock onhand qty.
            //        InventoryOnhandDTO inventoryOnhandDTO = m_bizInventory.LoadInventoryOnHandByCurrentPeriod(ItemCD, cboOrderLoc.ToNZString(), LotNo);
            //        shtView.Cells[e.Row, (int)eColView.ON_HAND_QTY].Value = inventoryOnhandDTO.ON_HAND_QTY.StrongValue;
            //        //txtLotNo_KeyPress(txtLotNo, new KeyPressEventArgs((char)Keys.Return));
            //    }
            //}
        }

        private void cboConsumptionCls_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboConsumptionCls.SelectedValue != null)
            //{
            //    if (cboConsumptionCls.SelectedValue.ToString() != DataDefine.Convert2ClassCode(DataDefine.eCONSUMPTION_CLS.Manual))
            //    {
            //        cmsOperation.Enabled = false;
            //    }
            //    else
            //    {
            //        cmsOperation.Enabled = true;
            //    }
            //}

        }


        private void numWorkResultQty_TextChanged(object sender, EventArgs e)
        {
            ////numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));
            //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString(), numWorkResultQty.ToNZDecimal());
            //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;
        }

        private void txtNGQty_TextChanged(object sender, EventArgs e)
        {
            //txtGoodQty.Double = numWorkResultQty.Double - txtNGQty.Double;
        }

        private void stcHead_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadInputLot();

        }

        public void LoadInputLot()
        {
            try
            {
                //if (this.cboTypeCls.SelectedIndex == -1)
                //{
                //    ValidateException.ThrowErrorItem(new ErrorItem(cboTypeCls, TKPMessages.eValidate.VLM0095.ToString()));
                //}

                if ((DataDefine.eTRAN_SUB_CLS.WR.ToString().Equals(this.cboTypeCls.SelectedValue)))
                {
                    LoadDataByItem(DataDefine.eTRAN_SUB_CLS.WR);
                }
                else if (DataDefine.eTRAN_SUB_CLS.RW.ToString().Equals(this.cboTypeCls.SelectedValue))
                {
                    LoadDataByItem(DataDefine.eTRAN_SUB_CLS.RW);
                }
                else
                {
                    //throw new NotSupportedException();
                }


                SetSubState(eSubStateAdd.C_SpecifyLotNo);

            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }
        }

        //private void numWorkResultQty_Leave(object sender, EventArgs e)
        //{
        //    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));
        //}


        private void LoadChildItem(NZString parentItemCode)
        {
            try
            {
                List<BOMSetupDTO> listBOM = m_controller.LoadChildItem(parentItemCode);

                DataTable dtBOM = DTOUtility.ConvertListToDataTable(listBOM);
                LookupData lookupChild = new LookupData(dtBOM
                    , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString()
                    , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString());

                txtChildItemNo.LoadLookupData(lookupChild);

                if (listBOM.Count >= 1)
                {
                    BOMSetupDTO dtoBOM = listBOM[0];

                    this.txtChildItemNo.Text = dtoBOM.LOWER_ITEM_CD;

                    //if (!dtoBOM.CHILD_ORDER_LOC_CD.IsNull)
                    //{
                    //    //cboOrderLoc

                    //    cboOrderLoc.SelectedValue = dtoBOM.CHILD_ORDER_LOC_CD;
                    //    lblOrderLocFromBOM.Visible = true;
                    //}
                    //else
                    //{
                    //    lblOrderLocFromBOM.Visible = false;
                    //}



                    //ถ้า list BOM == 1 แสดงว่ามันไม่มี equivalent item
                    if (listBOM.Count == 1)
                    {
                        CtrlUtil.EnabledControl(false, txtChildItemNo);
                    }
                    else
                    {
                        CtrlUtil.EnabledControl(true, txtChildItemNo);
                        m_listEquivalent = listBOM;
                    }
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();

                this.txtItemCode.Clear();
                this.txtItemDesc.Clear();
                this.txtChildItemNo.SelectedIndex = -1;
                this.cboOrderLoc.SelectedIndex = -1;
                this.cboStoredLoc.SelectedIndex = -1;

            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, null, err.Message);
                Console.WriteLine(err.StackTrace);
            }

        }


        private void SetSubState(eSubStateAdd eSubState)
        {
            if (m_screenMode == eScreenMode.ADD)
            {
                switch (eSubState)
                {
                    case eSubStateAdd.A_OpenScreeen:
                        DisableAllControl();
                        CtrlUtil.EnabledControl(true, cboTypeCls, btnType);
                        tsbSaveAndNew.Enabled = true;
                        tsbSaveAndClose.Enabled = true;
                        break;
                    case eSubStateAdd.B_SelectWorkResult:
                        CtrlUtil.EnabledControl(false, cboTypeCls, btnType);

                        CtrlUtil.EnabledControl(true, btnClear
                         , cboShiftCls, txtItemCode, btnItemCode
                         , txtLotNo, btnGenerate
                         , txtForMachine, dtWorkResultDate, txtWorkOrderNo
                         , cboOrderLoc, cboStoredLoc, txtRemark);

                        CtrlUtil.FocusControl(txtItemCode);

                        if (cboShiftCls.SelectedValue == null)
                        {
                            cboShiftCls.SelectedValue = DataDefine.eSHIFT_CLS.A.ToString();
                        }

                        break;
                    case eSubStateAdd.C_SpecifyLotNo:
                        shtView.OperationMode = OperationMode.Normal;
                        CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.WORK_RESULT_NO);
                        CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                        CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.ON_HAND_QTY);
                        CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.GOOD_QTY);

                        if (DataDefine.eTRAN_SUB_CLS.WR.ToString() == (string)cboTypeCls.SelectedValue)
                        {
                            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.RESERVE_QTY);
                        }
                        else
                        {
                            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.RESERVE_QTY);
                        }
                        CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.NG_QTY);
                        CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.NG_REASON);

                        tsbSaveAndNew.Enabled = true;
                        tsbSaveAndClose.Enabled = true;
                        break;
                    case eSubStateAdd.D_InputDetail:

                        break;
                    default: break;
                }
            }
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            ChooseWorkResultType();

        }

        private void DisableAllControl()
        {
            CtrlUtil.EnabledControl(false, cboTypeCls, btnType, btnClear
                , cboShiftCls, txtItemCode, btnItemCode, txtItemDesc, txtChildItemNo
                , txtLotNo, btnGenerate
                , txtForMachine, dtWorkResultDate, txtWRGroupNo, txtWorkOrderNo
                , cboOrderLoc, cboStoredLoc, txtRemark);
            shtView.OperationMode = OperationMode.ReadOnly;
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.WORK_RESULT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.ON_HAND_QTY);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.GOOD_QTY);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.RESERVE_QTY);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.NG_QTY);
            tsbSaveAndNew.Enabled = false;
            tsbSaveAndClose.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9005.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.Yes)
            {
                ClearAll();
                SetSubState(eSubStateAdd.A_OpenScreeen);
            }
        }

        private void ValidateAfterSelectItem()
        {
            if (txtItemCode.IsSelected && txtItemCode.SelectedItemData != null)
            {
                m_listEquivalent.Clear();

                //ถ้ากรณีที่เป็น rw ไม่ต้อง check ว่าตัด consumption type ไหน เพราะว่ามันตัด consumption ที่เป็นตัวมันเองอยู่แล้ว
                if (DataDefine.eTRAN_SUB_CLS.RW.ToString().Equals(this.cboTypeCls.SelectedValue))
                {
                    //if (txtItemCode.SelectedItemProcessData.CONSUMTION_CLS.StrongValue
                    //   != DataDefine.Convert2ClassCode(DataDefine.eCONSUMPTION_CLS.Manual))
                    //{
                    //    MessageDialog.ShowBusiness(this, new ErrorItem(null, TKPMessages.eValidate.VLM0097.ToString()).Message);
                    //    txtItemCode.Clear();
                    //    txtItemDesc.Clear();
                    //    txtChildItemNo.SelectedIndex = -1;
                    //    cboOrderLoc.SelectedIndex = -1;
                    //    cboStoredLoc.SelectedIndex = -1;
                    //    return;
                    //}
                }


                ////Load Item Detail
                //cboStoredLoc.SelectedValue = txtItemCode.SelectedItemProcessData.STORE_LOC_CD.Value;

                //กรณี rework ให้ rework จาก store loc ที่ผลิตเสร็จ
                //Load order location ตาม Part , BOM ถ้ามี set ใน BOM ให้ใช้ของ BOM เป็นหลัก
                if (DataDefine.eTRAN_SUB_CLS.RW.ToString().Equals(this.cboTypeCls.SelectedValue))
                {
                    //m_orderLoc = Convert.ToString(txtItemCode.SelectedItemProcessData.STORE_LOC_CD.Value);

                    //cboOrderLoc.SelectedValue = txtItemCode.SelectedItemProcessData.STORE_LOC_CD.Value;
                    ////this.txtChildItemNo.Text = this.txtItemCode.Text;


                    List<BOMSetupDTO> listBOM = new List<BOMSetupDTO>();
                    BOMSetupDTO bom = new BOMSetupDTO();
                    bom.LOWER_ITEM_CD = txtItemCode.SelectedItemData.ITEM_CD;
                    bom.UPPER_ITEM_CD = txtItemCode.SelectedItemData.ITEM_CD;
                    listBOM.Add(bom);

                    DataTable dtBOM = DTOUtility.ConvertListToDataTable(listBOM);
                    LookupData lookupChild = new LookupData(dtBOM
                        , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString()
                        , BOMSetupDTO.eColumns.LOWER_ITEM_CD.ToString());

                    txtChildItemNo.LoadLookupData(lookupChild);


                }
                else
                {
                    //m_orderLoc = Convert.ToString(txtItemCode.SelectedItemProcessData.ORDER_LOC_CD.Value);

                    //cboOrderLoc.SelectedValue = txtItemCode.SelectedItemProcessData.ORDER_LOC_CD.Value;


                    LoadChildItem(txtItemCode.ToNZString());
                }



                //LoadDataByItem(txtItemCode.ToNZString(), cboOrderLoc.ToNZString());
            }
            else
            {
                //shtView.RowCount = 0;
                //if (shtView.DataSource != null)
                //    ((DataTable)shtView.DataSource).Rows.Clear();
            }
        }

        private void fpView_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //if (m_bRowHasModified)
                //{
                CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);

                MoveToLowerCell(shtView);
                m_bRowHasModified = false;
                //}
                //else
                //{
                //    MoveToLowerCell(shtView);
                //}
            }
        }


        private void MoveToLowerCell(SheetView shtView)
        {
            if (shtView.ActiveRowIndex < shtView.RowCount - 1)
            {
                shtView.SetActiveCell(shtView.ActiveRowIndex + 1, shtView.ActiveColumnIndex);
                //fpView.SetActiveViewport(shtView.ActiveRowIndex, shtView.ActiveColumnIndex);
                fpView.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
            }
        }

        private void txtChildItemNo_SelectedValueChanged(object sender, EventArgs e)
        {
            shtView.RowCount = 0;
            if (shtView.DataSource != null)
                ((DataTable)shtView.DataSource).Rows.Clear();

            if (txtChildItemNo.SelectedIndex != -1 && cboTypeCls.SelectedIndex != -1)
            {
                LoadEquivalentOrderLoc();
                //LoadInputLot();
            }
        }

        private void LoadEquivalentOrderLoc()
        {
            if (m_listEquivalent != null)
            {
                int iIndex = m_listEquivalent.FindIndex(objBOM => objBOM.LOWER_ITEM_CD.NVL("").Equals(txtChildItemNo.SelectedValue));

                if (iIndex > -1)
                {
                    BOMSetupDTO dtoBOM = m_listEquivalent[iIndex];

                    //if (!dtoBOM.CHILD_ORDER_LOC_CD.IsNull)
                    //{
                    //    cboOrderLoc.SelectedValue = dtoBOM.CHILD_ORDER_LOC_CD;

                    //    if (iIndex == 0)
                    //    {
                    //        lblOrderLocFromBOM.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        lblOrderLocFromBOM.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    cboOrderLoc.SelectedValue = m_orderLoc;
                    //}

                }

            }

        }

        void txtItemCode_Validating(object sender, CancelEventArgs e)
        {
            ValidateAfterSelectItem();
        }

        private void cboTypeCls_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ChooseWorkResultType();
            }
        }


        private void ChooseWorkResultType()
        {

            string strWorkResultType = (string)cboTypeCls.SelectedValue;
            //check ว่ามีการเลือก type
            if (strWorkResultType != null)
            {

                //clear ข้อมูลที่เคยทำทั้งหมดก่อน แล้วค่อย set value คืน
                ClearNonDefault();
                if (strWorkResultType != null)
                {
                    cboTypeCls.SelectedValue = strWorkResultType;
                }
                SetSubState(eSubStateAdd.B_SelectWorkResult);

            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}
