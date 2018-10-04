using System;
using System.Data;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using CommonLib;
using Rubik.BIZ;
using System.Windows.Forms;
using Rubik.Validators;
using Rubik.DTO;
using SystemMaintenance;

namespace Rubik.Inventory
{
   // [Screen("INV030", "TAG Card Printing", eShowAction.Normal, eScreenType.Screen, "TAG Card Printing")]
    public partial class INV030 : SystemMaintenance.Forms.CustomizeBaseForm
    {
        #region Enum

        private enum eColView
        {
            PART_NO,
            PART_NAME,
            ITEM_TYPE,
            LOT_NO,
            LOT_SIZE,
            NUM_OF_COPY,
        }

        //private string m_LotSize = string.Empty;
        private enum eTAGCardFG
        {
            BARCODE,
            IMAGE_BIN,
            ITEM_CD,
            ITEM_DESC,
            FOR_CUSTOMER,
            PART_8_DIGIT,
            LOT_NO,
            PACK_SIZE,
            INV_UM_CLS,
            BARCODE2,
            IMAGE_BIN2,
            ITEM_CD2,
            ITEM_DESC2,
            FOR_CUSTOMER2,
            PART_8_DIGIT2,
            LOT_NO2,
            PACK_SIZE2,
            INV_UM_CLS2,
            MODEL,
            MODEL2
        }

        private enum eTAGCardWIP
        {
            BARCODE,
            IMAGE_BIN,
            ITEM_CD,
            ITEM_DESC,
            FOR_CUSTOMER,
            PART_8_DIGIT,
            LOT_NO,
            MAIN_MATTERIAL,
            PACK_SIZE,
            INV_UM_CLS,
        }

        private enum eTAGCardRM
        {
            BARCODE,
            ITEM_CD,
            ITEM_DESC,
            LOT_NO,
            COLOR,
            PACK_SIZE,
            INV_UM_CLS,
            BARCODE2,
            ITEM_CD2,
            ITEM_DESC2,
            LOT_NO2,
            COLOR2,
            PACK_SIZE2,
            INV_UM_CLS2,
        }

        #endregion

        #region Constructor

        public INV030()
        {
            InitializeComponent();
        }

        #endregion

        #region Variable

        private eBarCodeType m_barCodeType = eBarCodeType.CODE39;
        #endregion

        #region Private Method

        private void InitialScreen()
        {
            ClearData(true);
            InitialSpread();
            CtrlUtil.EnabledControl(false, txtPartName);
            rdoTagTypeFG.Checked = true;
            txtNumberofCopies.Double = 1;
            txtPartNo.Focus();
            txtPartNo.Select();
        }

        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            // lock spread cannot edit
            int col = shtView.Columns.Count;
            for (int i = 0; i < col; i++)
            {
                shtView.Columns[i].Locked = true;
            }

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup Lot Control
            LookupData lookupItemType = bizLookup.LoadLookupClassType(new NZString(null, "ITEM_CLS"));

            ReadOnlyPairCellType ItemTypecellType = new ReadOnlyPairCellType(lookupItemType, Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.ITEM_TYPE].CellType = ItemTypecellType;
        }

        private void ClearData(bool isClearList)
        {
            CtrlUtil.ClearControlData(txtPartNo, txtPartName, chkNoQty, txtLotNo, txtLotSize);
            txtPartNo.SelectedItemData = null;
            txtPartNo.SelectedItemProcessData = null;
            txtNumberofCopies.Double = 1;
            //rdoTagTypeFG.Checked = true;

            if (isClearList)
            {
                shtView.Rows.Count = 0;
            }
            txtPartNo.Focus();
            txtPartNo.Select();
        }

        private void AddDataToList()
        {
            try
            {
                if (ValidateData())
                {
                    shtView.Rows.Add(shtView.Rows.Count, 1);
                    int newRow = shtView.Rows.Count - 1;
                    shtView.Cells[newRow, (int)eColView.PART_NO].Value = txtPartNo.SelectedItemData.ITEM_CD.StrongValue;
                    shtView.Cells[newRow, (int)eColView.PART_NAME].Value = txtPartNo.SelectedItemData.ITEM_DESC.StrongValue;
                    //shtView.Cells[newRow, (int)eColView.ITEM_TYPE].Value = txtPartNo.SelectedItemData.ITEM_CLS.StrongValue;
                    shtView.Cells[newRow, (int)eColView.LOT_NO].Value = txtLotNo.Text.Trim();
                    shtView.Cells[newRow, (int)eColView.LOT_SIZE].Value = txtLotSize.Text.Trim();
                    shtView.Cells[newRow, (int)eColView.NUM_OF_COPY].Value = txtNumberofCopies.Double;

                    ClearData(false);
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

        private bool ValidateData()
        {
            NZString ItemCD = new NZString(txtPartNo, txtPartNo.Text.Trim());
            ItemValidator val = new ItemValidator();
            ErrorItem err;
            err = val.CheckEmptyItemCode(ItemCD);
            if (err != null)
            {
                ValidateException.ThrowErrorItem(err);
            }
            BusinessException bizErr = val.CheckItemNotExist(ItemCD);
            if (bizErr != null)
            {
                ValidateException.ThrowErrorItem(bizErr.Error);
            }

            if (txtNumberofCopies.Text.Trim() == string.Empty || txtNumberofCopies.Double == 0)
                txtNumberofCopies.Double = 1;
            return true;
        }

        private void ShowPreView()
        {
            try
            {
                if (shtView.Rows.Count == 0)
                {
                    MessageDialog.ShowBusiness(this, TKPMessages.eValidate.VLM0071.ToString()
                                               , new EVOFramework.Message(TKPMessages.eValidate.VLM0071.ToString()).MessageDescription);
                    txtPartNo.Focus();
                    txtPartNo.Select();
                    return;
                }
                DataDefine.eTAGCardType tagCardType = DataDefine.eTAGCardType.FG;
                if (rdoTagTypeRM.Checked) tagCardType = DataDefine.eTAGCardType.RM;
                if (rdoTagTypeWIP.Checked) tagCardType = DataDefine.eTAGCardType.WIP;
                DataTable dt = GetReportTable(tagCardType);
                if (dt.Rows.Count > 0)
                {
                    INV031 frmINV031 = new INV031(dt, tagCardType);
                    frmINV031.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private DataTable GetDataTableSchema(DataDefine.eTAGCardType tagCardType)
        {
            DataTable dt = new DataTable();
            string[] names;
            switch (tagCardType)
            {
                case DataDefine.eTAGCardType.FG:
                    names = Enum.GetNames(typeof(eTAGCardFG));
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == eTAGCardFG.IMAGE_BIN.ToString() || names[i] == eTAGCardFG.IMAGE_BIN2.ToString())
                        {
                            dt.Columns.Add(names[i], typeof(Byte[]));
                            continue;
                        }
                        //if (names[i] == eTAGCardFG.PACK_SIZE.ToString() || names[i] == eTAGCardFG.PACK_SIZE2.ToString())
                        //{
                        //    dt.Columns.Add(names[i], typeof(decimal));
                        //    continue;
                        //}
                        dt.Columns.Add(names[i]);
                    }
                    break;
                case DataDefine.eTAGCardType.WIP:
                    names = Enum.GetNames(typeof(eTAGCardWIP));
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == eTAGCardWIP.IMAGE_BIN.ToString())
                        {
                            dt.Columns.Add(names[i], typeof(Byte[]));
                            continue;
                        }
                        //if (names[i] == eTAGCardWIP.PACK_SIZE.ToString())// || names[i] == eTAGCardWIP.PACK_SIZE2.ToString())
                        //{
                        //    dt.Columns.Add(names[i], typeof(decimal));
                        //    continue;
                        //}
                        dt.Columns.Add(names[i]);
                    }
                    break;
                case DataDefine.eTAGCardType.RM:
                    names = Enum.GetNames(typeof(eTAGCardRM));
                    for (int i = 0; i < names.Length; i++)
                    {
                        //if (names[i] == eTAGCardRM.PACK_SIZE.ToString() || names[i] == eTAGCardRM.PACK_SIZE2.ToString())
                        //{
                        //    dt.Columns.Add(names[i], typeof(decimal));
                        //    continue;
                        //}
                        dt.Columns.Add(names[i]);
                    }
                    break;

            }
            return dt;
        }

        private enum eBarCodeType
        {
            CODE39,
            CODE128,
        }
        //Example: BarCode 1
        //Message : Start B   B   a   r   C   o   d   e      1
        //Value      104      34  65  82  35  79  68  69  0  17
        //Position:   -       1   2   3   4   5   6   7   8  9
        //Calculate Total: 104 + (34x1) + (65x2) + (82x3) + (35x4) + (79x5) +
        //                 (68x6) + (69x7) + (0x8) + (17x9) = 2093
        //2093/103 = 20 remainder 33
        //33 = A
        //Final message: (Start B)BarCode 1(A)(STOP)

        private String GenBarcodeEncode(string rawData, eBarCodeType barCodeType)
        {
            if (rawData.IndexOf(',') > 0)
                rawData = rawData.Remove(rawData.IndexOf(','), 1);

            string Barcode = rawData;

            switch (barCodeType)
            {
                case eBarCodeType.CODE39:
                    Barcode = string.Format("*{0}*", rawData);
                    break;
                case eBarCodeType.CODE128:
                    string StartChar;
                    string StopChar;
                    string CheckSumChar;

                    int sum = 104;

                    StartChar = ((char)136).ToString();   // ASCII 136
                    StopChar = ((char)138).ToString();     // ASCII 138
                    for (int i = 0; i < rawData.Length; i++)
                    {
                        sum = sum + (Convert.ToInt32((byte)rawData[i]) - 32) * (i + 1);
                        //NewData = NewData + ((byte) Convert.ToInt32((byte)rawData[i]) - 32).ToString();
                    }
                    sum = (sum % 103) + 32;
                    CheckSumChar = ((char)sum).ToString();

                    //Barcode = StartChar + rawData + CheckSumChar.ToString() + StopChar.ToString();
                    Barcode = string.Format("{0}{1}{2}{3}", StartChar, rawData, CheckSumChar, StopChar);
                    //Barcode = StartChar + rawData + CheckSumChar + StopChar;
                    //Barcode = string.Format("{0}{1},{2},{3}", ((char)136).ToString(), rawData, ((char)sum).ToString(), ((char)138).ToString());
                    //Barcode = Barcode.Remove(rawData.IndexOf(','), 1);
                    break;

            }


            return Barcode;
        }


        private DataTable GetReportTable(DataDefine.eTAGCardType tagCardType)
        {
            switch (tagCardType)
            {
                case DataDefine.eTAGCardType.FG:
                    return GetReportTableFG();
                case DataDefine.eTAGCardType.WIP:
                    return GetReportTableWIP();
                case DataDefine.eTAGCardType.RM:
                    return GetReportTableRM();

            }
            return null;
        }

        private DataTable GetReportTableRM()
        {
            DataTable dt = GetDataTableSchema(DataDefine.eTAGCardType.RM);

            ItemBIZ bizItem = new ItemBIZ();

            int row = shtView.Rows.Count;

            if (row == 0) return null;

            int printItemCount = 0;
            int rowdt = -1;
            for (int i = 0; i < row; i++)
            {
                // get Item Information for each row
                NZString ItemCD = new NZString(null, shtView.Cells[i, (int)eColView.PART_NO].Value);
                ItemDTO dtoItem = bizItem.LoadItem(ItemCD);

                int copyCount = Convert.ToInt32(shtView.Cells[i, (int)eColView.NUM_OF_COPY].Value);

                if (dtoItem == null)
                {
                    continue;
                }

                for (int j = 0; j < copyCount; j++)
                {
                    if (printItemCount % 2 == 0)
                    {
                        dt.Rows.Add();
                        rowdt++;

                        dt.Rows[rowdt][(int)eTAGCardRM.BARCODE] = string.Format("{0}{3}{1}{3}{2}"
                                                                                , shtView.Cells[i, (int)eColView.PART_NO].Value
                                                                                , shtView.Cells[i, (int)eColView.LOT_NO].Value
                                                                                , shtView.Cells[i, (int)eColView.LOT_SIZE].Value
                                                                                , DataDefine.BARCODE_SEPARATER);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardRM.BARCODE] = GenBarcodeEncode((dt.Rows[rowdt][(int)eTAGCardRM.BARCODE]).ToString(), m_barCodeType);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardRM.ITEM_CD] = dtoItem.ITEM_CD.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardRM.ITEM_DESC] = dtoItem.ITEM_DESC.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardRM.LOT_NO] = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                        //dt.Rows[rowdt][(int)eTAGCardRM.COLOR] = dtoItem.COLOR.StrongValue;
                        if (shtView.Cells[i, (int)eColView.LOT_SIZE].Value.ToString() != string.Empty)
                            dt.Rows[rowdt][(int)eTAGCardRM.PACK_SIZE] = Convert.ToDecimal(shtView.Cells[i, (int)eColView.LOT_SIZE].Value).ToString();
                        //dt.Rows[rowdt][(int)eTAGCardRM.INV_UM_CLS] = GetInventoryUMCls(dtoItem.ORDER_UM_CLS);


                    }
                    else
                    {
                        dt.Rows[rowdt][(int)eTAGCardRM.BARCODE2] = string.Format("{0}{3}{1}{3}{2}"
                                                                                 , shtView.Cells[i, (int)eColView.PART_NO].Value
                                                                                 , shtView.Cells[i, (int)eColView.LOT_NO].Value
                                                                                 , shtView.Cells[i, (int)eColView.LOT_SIZE].Value
                                                                                 , DataDefine.BARCODE_SEPARATER);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardRM.BARCODE2] = GenBarcodeEncode((dt.Rows[rowdt][(int)eTAGCardRM.BARCODE2]).ToString(), m_barCodeType);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardRM.ITEM_CD2] = dtoItem.ITEM_CD.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardRM.ITEM_DESC2] = dtoItem.ITEM_DESC.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardRM.LOT_NO2] = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                        //dt.Rows[rowdt][(int)eTAGCardRM.COLOR2] = dtoItem.COLOR.StrongValue;
                        if (shtView.Cells[i, (int)eColView.LOT_SIZE].Value.ToString() != string.Empty)
                            dt.Rows[rowdt][(int)eTAGCardRM.PACK_SIZE2] = Convert.ToDecimal(shtView.Cells[i, (int)eColView.LOT_SIZE].Value).ToString();
                        //dt.Rows[rowdt][(int)eTAGCardRM.INV_UM_CLS2] = GetInventoryUMCls(dtoItem.ORDER_UM_CLS);
                    }
                    printItemCount++;
                }
            }
            return dt;
        }

        private DataTable GetReportTableWIP()
        {
            DataTable dt = GetDataTableSchema(DataDefine.eTAGCardType.WIP);

            ItemBIZ bizItem = new ItemBIZ();
            ItemImageBIZ bizImage = new ItemImageBIZ();

            int row = shtView.Rows.Count;

            if (row == 0) return null;

            int rowdt = -1;

            for (int i = 0; i < row; i++)
            {
                // get Item Information for each row
                NZString ItemCD = new NZString(null, shtView.Cells[i, (int)eColView.PART_NO].Value);
                ItemDTO dtoItem = bizItem.LoadItem(ItemCD);
                ItemImageDTO dtoImage = bizImage.LoadImage(ItemCD);
                int copyCount = Convert.ToInt32(shtView.Cells[i, (int)eColView.NUM_OF_COPY].Value);

                if (dtoItem == null)
                {
                    continue;
                }
                for (int j = 0; j < copyCount; j++)
                {
                    dt.Rows.Add();
                    rowdt++;

                    dt.Rows[rowdt][(int)eTAGCardWIP.BARCODE] = string.Format("{0}{3}{1}{3}{2}"
                                                                             , shtView.Cells[i, (int)eColView.PART_NO].Value
                                                                             , shtView.Cells[i, (int)eColView.LOT_NO].Value
                                                                             , shtView.Cells[i, (int)eColView.LOT_SIZE].Value
                                                                             , DataDefine.BARCODE_SEPARATER);
                    // Add by Pichet
                    dt.Rows[rowdt][(int)eTAGCardWIP.BARCODE] = GenBarcodeEncode((dt.Rows[rowdt][(int)eTAGCardWIP.BARCODE]).ToString(), m_barCodeType);
                    // Add by Pichet
                    dt.Rows[rowdt][(int)eTAGCardWIP.IMAGE_BIN] = dtoImage == null ? null : dtoImage.IMAGE.StrongValue;
                    dt.Rows[rowdt][(int)eTAGCardWIP.ITEM_CD] = dtoItem.ITEM_CD.StrongValue;
                    dt.Rows[rowdt][(int)eTAGCardWIP.ITEM_DESC] = dtoItem.ITEM_DESC.StrongValue;
                    //dt.Rows[rowdt][(int)eTAGCardWIP.FOR_CUSTOMER] = dtoItem.FOR_CUSTOMER.StrongValue;
                    //dt.Rows[rowdt][(int)eTAGCardWIP.PART_8_DIGIT] = dtoItem.ITEM_8_DIGITS.StrongValue;
                    dt.Rows[rowdt][(int)eTAGCardWIP.LOT_NO] = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                    //dt.Rows[rowdt][(int)eTAGCardWIP.MAIN_MATTERIAL] = dtoItem.MAIN_MATTERIAL.StrongValue;
                    if (shtView.Cells[i, (int)eColView.LOT_SIZE].Value.ToString() != string.Empty)
                        dt.Rows[rowdt][(int)eTAGCardWIP.PACK_SIZE] = Convert.ToDecimal(shtView.Cells[i, (int)eColView.LOT_SIZE].Value).ToString();
                    //dt.Rows[rowdt][(int)eTAGCardWIP.INV_UM_CLS] = GetInventoryUMCls(dtoItem.INV_UM_CLS);
                }
            }
            return dt;
        }

        private DataTable GetReportTableFG()
        {
            DataTable dt = GetDataTableSchema(DataDefine.eTAGCardType.FG);

            ItemBIZ bizItem = new ItemBIZ();
            ItemImageBIZ bizImage = new ItemImageBIZ();

            int row = shtView.Rows.Count;

            if (row == 0) return null;

            int rowdt = -1;
            int printItemCount = 0;

            for (int i = 0; i < row; i++)
            {
                // get Item Information for each row
                NZString ItemCD = new NZString(null, shtView.Cells[i, (int)eColView.PART_NO].Value);
                ItemDTO dtoItem = bizItem.LoadItem(ItemCD);
                ItemImageDTO dtoImage = bizImage.LoadImage(ItemCD);

                int copyCount = Convert.ToInt32(shtView.Cells[i, (int)eColView.NUM_OF_COPY].Value);

                if (dtoItem == null)
                {
                    continue;
                }

                for (int j = 0; j < copyCount; j++)
                {
                    if (printItemCount % 2 == 0)
                    {
                        dt.Rows.Add();
                        rowdt++;
                        dt.Rows[rowdt][(int)eTAGCardFG.BARCODE] = string.Format("{0}{3}{1}{3}{2}"
                                                                                , shtView.Cells[i, (int)eColView.PART_NO].Value
                                                                                , shtView.Cells[i, (int)eColView.LOT_NO].Value
                                                                                , shtView.Cells[i, (int)eColView.LOT_SIZE].Value
                                                                                , DataDefine.BARCODE_SEPARATER);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardFG.BARCODE] = GenBarcodeEncode((dt.Rows[rowdt][(int)eTAGCardFG.BARCODE]).ToString(), m_barCodeType);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardFG.IMAGE_BIN] = dtoImage == null ? null : dtoImage.IMAGE.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.ITEM_CD] = dtoItem.ITEM_CD.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.ITEM_DESC] = dtoItem.ITEM_DESC.StrongValue;
                        //dt.Rows[rowdt][(int)eTAGCardFG.FOR_CUSTOMER] = dtoItem.FOR_CUSTOMER.StrongValue;
                        //dt.Rows[rowdt][(int)eTAGCardFG.PART_8_DIGIT] = dtoItem.ITEM_8_DIGITS.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.LOT_NO] = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                        if (shtView.Cells[i, (int)eColView.LOT_SIZE].Value.ToString() != string.Empty)
                            dt.Rows[rowdt][(int)eTAGCardFG.PACK_SIZE] = Convert.ToDecimal(shtView.Cells[i, (int)eColView.LOT_SIZE].Value).ToString();
                        //dt.Rows[rowdt][(int)eTAGCardFG.INV_UM_CLS] = GetInventoryUMCls(dtoItem.INV_UM_CLS);
                        //dt.Rows[rowdt][(int)eTAGCardFG.MODEL] = dtoItem.MODEL.StrongValue;
                    }
                    else
                    {

                        dt.Rows[rowdt][(int)eTAGCardFG.BARCODE2] = string.Format("{0}{3}{1}{3}{2}"
                                                                                 , shtView.Cells[i, (int)eColView.PART_NO].Value
                                                                                 , shtView.Cells[i, (int)eColView.LOT_NO].Value
                                                                                 , shtView.Cells[i, (int)eColView.LOT_SIZE].Value
                                                                                 , DataDefine.BARCODE_SEPARATER);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardFG.BARCODE2] = GenBarcodeEncode((dt.Rows[rowdt][(int)eTAGCardFG.BARCODE2]).ToString(), m_barCodeType);
                        // Add by Pichet
                        dt.Rows[rowdt][(int)eTAGCardFG.IMAGE_BIN2] = dtoImage == null ? null : dtoImage.IMAGE.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.ITEM_CD2] = dtoItem.ITEM_CD.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.ITEM_DESC2] = dtoItem.ITEM_DESC.StrongValue;
                        //dt.Rows[rowdt][(int)eTAGCardFG.FOR_CUSTOMER2] = dtoItem.FOR_CUSTOMER.StrongValue;
                        //dt.Rows[rowdt][(int)eTAGCardFG.PART_8_DIGIT2] = dtoItem.ITEM_8_DIGITS.StrongValue;
                        dt.Rows[rowdt][(int)eTAGCardFG.LOT_NO2] = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                        if (shtView.Cells[i, (int)eColView.LOT_SIZE].Value.ToString() != string.Empty)
                            dt.Rows[rowdt][(int)eTAGCardFG.PACK_SIZE2] = Convert.ToDecimal(shtView.Cells[i, (int)eColView.LOT_SIZE].Value).ToString();
                        //dt.Rows[rowdt][(int)eTAGCardFG.INV_UM_CLS2] = GetInventoryUMCls(dtoItem.INV_UM_CLS);
                        //dt.Rows[rowdt][(int)eTAGCardFG.MODEL2] = dtoItem.MODEL.StrongValue;
                    }
                    printItemCount++;
                }
            }
            return dt;
        }

        private string GetInventoryUMCls(NZString InventoryUMCls)
        {
            ClassListBIZ biz = new ClassListBIZ();
            ClassListDTO dto = biz.LoadByPK((NZString)"UM_CLS", InventoryUMCls);
            if (dto == null) return string.Empty;
            return dto.CLS_DESC.StrongValue;
        }

        #endregion

        #region Form Event

        private void INV030_Load(object sender, EventArgs e)
        {
            InitialScreen();
            PermissionControl();
        }

        #endregion

        #region Control Event

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData(false);
        }

        private void txtPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            if (txtPartNo.SelectedItemData != null && txtPartNo.SelectedItemProcessData != null)
            {
                if (!chkNoQty.Checked)
                {
                    //txtLotSize.Double = (double)txtPartNo.SelectedItemProcessData.PACK_SIZE.StrongValue;
                }
                else
                {
                    txtLotSize.Text = string.Empty;
                }
            }
            else
            {
                txtLotSize.Text = string.Empty;
            }
            txtLotNo.Focus();
            txtLotNo.SelectAll();
        }

        private void chkNoQty_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPartNo.SelectedItemData != null && txtPartNo.SelectedItemProcessData != null)
            {
                if (!chkNoQty.Checked)
                {
                    //txtLotSize.Double = (double)txtPartNo.SelectedItemProcessData.PACK_SIZE.StrongValue;
                    CtrlUtil.EnabledControl(true, txtLotSize);
                }
                else
                {
                    txtLotSize.Text = string.Empty;
                    CtrlUtil.EnabledControl(false, txtLotSize);
                }
            }
            else
            {
                txtLotSize.Text = string.Empty;
            }
        }

        private void btnPartNo_Click(object sender, EventArgs e)
        {
            txtPartNo_KeyPress(txtPartNo, new KeyPressEventArgs((char)Keys.Return));
        }

        private void tsbAddToList_Click(object sender, EventArgs e)
        {
            AddDataToList();
            EnableRadioButtonGroup(false);
        }

        private void EnableRadioButtonGroup(bool p)
        {
            CtrlUtil.EnabledControl(p, rdoTagTypeWIP, rdoTagTypeRM, rdoTagTypeFG);
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            ShowPreView();
        }

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            ClearData(true);
            EnableRadioButtonGroup(true);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shtView.Rows.Count == 0) return;
            if (shtView.ActiveRowIndex < 0) return;

            shtView.Rows.Remove(shtView.ActiveRowIndex, 1);
            if (shtView.Rows.Count == 0)
            {
                EnableRadioButtonGroup(true);
            }
            txtPartNo.Focus();
            txtPartNo.Select();
        }
        #endregion

        #region Permission Control
        public void PermissionControl()
        {
            if (!DesignMode)
            {
                if (!ActivePermission.View)
                {
                    EVOFramework.Windows.Forms.MessageDialog.ShowInformation(this, "Permissionn Control"
                        , EVOFramework.Message.LoadMessage(Messages.eInformation.INF9004.ToString()).MessageDescription);
                    Close();
                    return;
                }
                if (!ActivePermission.Edit)
                {
                    CommonLib.CtrlUtil.EnabledControl(false, Controls);
                }
            }

            //tsbSaveAndClose.Enabled = UserPermission.Edit;
            //tsbSaveAndNew.Enabled = UserPermission.Edit;
        }
        #endregion

        private void rdoTagType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTagTypeFG.Checked)
            {
                //txtPartNo.ItemType = new[] { eItemType.FinishGoods, eItemType.SemiFinishGoods };
            }
            if (rdoTagTypeWIP.Checked)
            {
                //txtPartNo.ItemType = new[] { eItemType.WorkInProcess, eItemType.SemiFinishGoods };

            }
            if (rdoTagTypeRM.Checked)
            {
                //txtPartNo.ItemType = new[] { eItemType.RawMaterial };
            }

        }

        private void txtNumberofCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            toolStrip1.Select();
            tsbAddToList.Select();
        }

        private void txtLotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            txtNumberofCopies.Focus();
            txtNumberofCopies.SelectAll();
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }




    }
}
