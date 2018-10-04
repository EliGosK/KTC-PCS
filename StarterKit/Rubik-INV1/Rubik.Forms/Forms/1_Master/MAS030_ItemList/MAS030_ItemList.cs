using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubik.Controller;
using Rubik.BIZ;
using Rubik.Validators;
using SystemMaintenance.Forms;
using EVOFramework.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using CommonLib;


namespace Rubik.Master
{
    [Screen("MAS030", "Master No. List", eShowAction.Normal, eScreenType.ScreenPane, "Master No. List")]
    public partial class MAS030_ItemList : CustomizeListPaneForm
    {
        #region Enum

        public enum eColView
        {
            //ITEM_CD,
            //SHORT_NAME,
            //ITEM_DESC,
            //KIND_OF_PRODUCT,
            //CUSTOMER_CD,
            //CUSTOMER_USE_POINT,
            //WEIGHT,
            //BOI,
            //PRODUCTION_DI,
            //ITEM_LEVEL,
            //MAT_NAME,
            //MAT_SIZE,
            //MAT_SUPPLIER_CD,
            //KIND_OF_MAT,
            //MAT_DI,
            //REMARK,
            //CRT_DATE,
            //CRT_BY,
            //UPD_DATE,
            //UPD_BY,
            //SCREW_KIND,
            //SCREW_HEAD,
            //SCREW_M,
            //SCREW_L,
            //SCREW_TYPE,
            //SCREW_REMARK1,
            //SCREW_REMARK2,
            //HEXABULAR,
            //PROCESS1,
            //MACHINE_TYPE1,
            //PROCESS2,
            //MACHINE_TYPE2,
            //PROCESS3,
            //MACHINE_TYPE3,
            //PROCESS4,
            //MACHINE_TYPE4,
            //PROCESS5,
            //MACHINE_TYPE5,
            //PROCESS6,
            //MACHINE_TYPE6,
            //HEAT_FLAG,
            //HEAT_TYPE,
            //HEAT_HARDNESS,
            //HEAT_CORE_HARDNESS,
            //HEAT_CASE_DEPTH,
            //PLATING_FLAG,
            //PLATING_KIND,
            //PLATING_SUPPLIER_CD,
            //PLATING_THICKNESS1_1,
            //PLATING_THICKNESS1_2,
            //PLATING_THICKNESS2_1,
            //PLATING_THICKNESS2_2,
            //PLATING_KTC,
            //BAKING_FLAG,
            //BAKING_TIME,
            //BAKING_TEMP,
            //OTHER_TREATMENT1_FLAG,
            //OTHER_TREATMENT1_KIND,
            //OTHER_TREATMENT1_CONDITION,
            //OTHER_TREATMENT2_FLAG,
            //OTHER_TREATMENT2_KIND,
            //OTHER_TREATMENT2_CONDITION,
            //ROUTING_TEXT

            ITEM_CD,
            SHORT_NAME,
            ITEM_DESC,
            KIND_OF_PRODUCT,
            KIND_OF_PRODUCT_NAME,
            CUSTOMER_CD,

            CUSTOMER_NAME,
            CUSTOMER_USE_POINT,
            WEIGHT,
            BOI,
            BOI_NAME,
            PRODUCTION_DI,
            PRODUCTION_DI_NAME,

            ITEM_LEVEL,
            ITEM_LEVEL_NAME,
            MAT_NAME,
            MAT_SIZE,
            MAT_SUPPLIER_CD,
            MAT_SUPPLIER_NAME,

            KIND_OF_MAT,
            KIND_OF_MAT_NAME,
            MAT_DI,
            MAT_DI_NAME,
            REMARK,

            SCREW_KIND,
            SCREW_KIND_NAME,
            SCREW_HEAD,
            SCREW_HEAD_NAME,
            SCREW_M,
            SCREW_L,
            SCREW_TYPE,
            SCREW_TYPE_NAME,
            SCREW_REMARK1,
            SCREW_REMARK1_NAME,
            SCREW_REMARK2,
            SCREW_REMARK2_NAME,
            HEXABULAR,
            PROCESS1,
            PROCESS1_NAME,
            MACHINE_TYPE1,
            MACHINE_TYPE1_NAME,

            PROCESS2,
            PROCESS2_NAME,
            MACHINE_TYPE2,
            MACHINE_TYPE2_NAME,
            PROCESS3,

            PROCESS3_NAME,
            MACHINE_TYPE3,
            MACHINE_TYPE3_NAME,
            PROCESS4,
            PROCESS4_NAME,

            MACHINE_TYPE4,
            MACHINE_TYPE4_NAME,
            PROCESS5,
            PROCESS5_NAME,
            MACHINE_TYPE5,

            MACHINE_TYPE5_NAME,
            PROCESS6,
            PROCESS6_NAME,
            MACHINE_TYPE6,
            MACHINE_TYPE6_NAME,

            HEAT_FLAG,
            HEAT_TYPE,
            HEAT_TYPE_NAME,
            HEAT_HARDNESS,
            HEAT_CORE_HARDNESS,

            HEAT_CASE_DEPTH,
            PLATING_FLAG,
            PLATING_KIND,
            PLATING_SUPPLIER_CD,
            PLATING_SUPPLIER_CD_NAME,

            PLATING_THICKNESS1_1,
            PLATING_THICKNESS1_2,
            PLATING_THICKNESS2_1,
            PLATING_THICKNESS2_2,
            PLATING_KTC,
            PLATING_KTC_NAME,

            BAKING_FLAG,
            BAKING_TIME,
            BAKING_TIME_NAME,
            BAKING_TEMP,
            BAKING_TEMP_NAME,

            OTHER_TREATMENT1_FLAG,
            OTHER_TREATMENT1_KIND,
            OTHER_TREATMENT1_KIND_NAME,
            OTHER_TREATMENT1_CONDITION,
            OTHER_TREATMENT1_CONDITION_NAME,

            OTHER_TREATMENT2_FLAG,
            OTHER_TREATMENT2_KIND,
            OTHER_TREATMENT2_KIND_NAME,
            OTHER_TREATMENT2_CONDITION,
            OTHER_TREATMENT2_CONDITION_NAME,
            ROUTING_TEXT,

            CRT_DATE,
            CRT_BY,
            UPD_DATE,
            UPD_BY,
        };

        #endregion

        #region Variable

        private DataTable m_dtAllData;

        private const int AUTO_COMPLETE_DELAY = 500;

        #endregion

        #region Constructor

        public MAS030_ItemList()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method
        public override void OnAddNew()
        {
            base.OnAddNew();
            MAS040_ItemMaster frmItemMaster = new MAS040_ItemMaster();
            frmItemMaster.ShowDialog();
            LoadItemData(txtSearch.Text.Trim());
        }

        public override void OnRefresh()
        {
            LoadItemData(txtSearch.Text.Trim());
        }

        #endregion

        #region Private Method

        private void InitialScreen()
        {
            shtItemView.ActiveSkin = Common.ACTIVE_SKIN;

            this.tmrAutoComplete.Interval = AUTO_COMPLETE_DELAY;

            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            InitialSpread();

            LoadItemData(string.Empty);
        }

        private void InitialSpread()
        {
            LoadLookupCellType();

            #region No Export Column

            shtItemView.Columns[(int)eColView.KIND_OF_PRODUCT_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.BOI_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.PRODUCTION_DI_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.ITEM_LEVEL_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.KIND_OF_MAT_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MAT_DI_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.SCREW_KIND_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.SCREW_HEAD_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.SCREW_TYPE_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.SCREW_REMARK1_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.SCREW_REMARK2_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE1_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE2_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE3_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE4_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE5_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.MACHINE_TYPE6_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.HEAT_TYPE_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.PLATING_KTC_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.BAKING_TIME_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.BAKING_TEMP_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_KIND_NAME].StyleName = DataDefine.NO_EXPORT.ToString();
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_KIND_NAME].StyleName = DataDefine.NO_EXPORT.ToString();

            #endregion

            #region visible column

            shtItemView.Columns[(int)eColView.CUSTOMER_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.BOI_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PRODUCTION_DI_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.KIND_OF_PRODUCT_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.ITEM_LEVEL_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MAT_SUPPLIER_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.KIND_OF_MAT_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MAT_DI_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.SCREW_KIND_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.SCREW_HEAD_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.SCREW_TYPE_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.SCREW_REMARK1_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.SCREW_REMARK2_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE1_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE2_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE3_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE4_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE5_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.MACHINE_TYPE6_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS1_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS2_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS3_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS4_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS5_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PROCESS6_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.HEAT_TYPE_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PLATING_KTC_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.PLATING_SUPPLIER_CD_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.BAKING_TIME_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.BAKING_TEMP_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_KIND_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_CONDITION_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_KIND_NAME].Visible = false;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_CONDITION_NAME].Visible = false;


            #endregion

            CtrlUtil.MappingDataFieldWithEnum(shtItemView, typeof(eColView));

            CtrlUtil.SpreadUpdateColumnSorting(shtItemView);

        }

        private void LoadLookupCellType()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            //Kind of Item
            LookupData lookupKind = bizLookup.LoadLookupClassType(DataDefine.KIND_OF_PRODUCT.ToNZString());
            ReadOnlyPairCellType cellmachineType = new ReadOnlyPairCellType(lookupKind.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.KIND_OF_PRODUCT].CellType = cellmachineType;

            //ReadOnlyPairCellType cellmatType = new ReadOnlyPairCellType(lookupKind.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtItemView.Columns[(int)eColView.KIND_OF_MAT].CellType = cellmatType;

            //BOI
            LookupData lookupBOI = bizLookup.LoadLookupClassType(DataDefine.BOI_PROJECT.ToNZString());
            ReadOnlyPairCellType cellBOI = new ReadOnlyPairCellType(lookupBOI, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.BOI].CellType = cellBOI;

            //Customer
            NZString[] CustomerType = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupCustomer = bizLookup.LoadLookupLocation(CustomerType);
            ReadOnlyPairCellType cellCust = new ReadOnlyPairCellType(LookupCustomer, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.CUSTOMER_CD].CellType = cellCust;

            // Production DI
            LookupData LookupProductionDI = bizLookup.LoadLookupClassType(DataDefine.PRODUCTION_DI.ToNZString());
            ReadOnlyPairCellType cellProductionDI = new ReadOnlyPairCellType(LookupProductionDI, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PRODUCTION_DI].CellType = cellProductionDI;

            // Matchine Supplier
            NZString[] MatSupplier = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupMatSupplier = bizLookup.LoadLookupLocation(MatSupplier);

            ReadOnlyPairCellType cellMatSupplier = new ReadOnlyPairCellType(LookupMatSupplier.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MAT_SUPPLIER_CD].CellType = cellMatSupplier;

            ReadOnlyPairCellType cellPlatingSupplier = new ReadOnlyPairCellType(LookupMatSupplier.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PLATING_SUPPLIER_CD].CellType = cellPlatingSupplier;

            // Matchine DI
            LookupData LookupMatDI = bizLookup.LoadLookupClassType(DataDefine.MAT_DI.ToNZString());
            ReadOnlyPairCellType cellMatDI = new ReadOnlyPairCellType(LookupMatDI, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MAT_DI].CellType = cellMatDI;

            // Item Level
            LookupData LookupItemLevel = bizLookup.LoadLookupClassType(DataDefine.ITEM_LEVEL.ToNZString());
            ReadOnlyPairCellType cellItemLevel = new ReadOnlyPairCellType(LookupItemLevel, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.ITEM_LEVEL].CellType = cellItemLevel;

            // Screw Kind
            LookupData LookupScrewKind = bizLookup.LoadLookupClassType(DataDefine.SCREW_KIND.ToNZString());
            ReadOnlyPairCellType cellScrewKind = new ReadOnlyPairCellType(LookupScrewKind, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.SCREW_KIND].CellType = cellScrewKind;

            // Screw Head
            LookupData LookupScrewHead = bizLookup.LoadLookupClassType(DataDefine.SCREW_HEAD.ToNZString());
            ReadOnlyPairCellType cellScrewHead = new ReadOnlyPairCellType(LookupScrewHead, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.SCREW_HEAD].CellType = cellScrewHead;

            // Screw Type
            LookupData LookupScrewType = bizLookup.LoadLookupClassType(DataDefine.SCREW_TYPE.ToNZString());
            ReadOnlyPairCellType cellScrewType = new ReadOnlyPairCellType(LookupScrewType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.SCREW_TYPE].CellType = cellScrewType;

            // Screw Remark1
            LookupData LookupScrewRemark1 = bizLookup.LoadLookupClassType(DataDefine.SCREW_REMARK1.ToNZString());
            ReadOnlyPairCellType cellScrewRemark1 = new ReadOnlyPairCellType(LookupScrewRemark1, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.SCREW_REMARK1].CellType = cellScrewRemark1;

            // Screw Remark2
            LookupData LookupScrewRemark2 = bizLookup.LoadLookupClassType(DataDefine.SCREW_REMARK2.ToNZString());
            ReadOnlyPairCellType cellScrewRemark2 = new ReadOnlyPairCellType(LookupScrewRemark2, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.SCREW_REMARK2].CellType = cellScrewRemark2;

            // Machine Type1
            LookupData LookupMCType = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            ReadOnlyPairCellType cellMCType1 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE1].CellType = cellMCType1;

            // Machine Type2
            ReadOnlyPairCellType cellMCType2 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE2].CellType = cellMCType2;

            // Machine Type3
            ReadOnlyPairCellType cellMCType3 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE3].CellType = cellMCType3;

            // Machine Type4
            ReadOnlyPairCellType cellMCType4 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE4].CellType = cellMCType4;

            // Machine Type5
            ReadOnlyPairCellType cellMCType5 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE5].CellType = cellMCType5;

            // Machine Type6
            ReadOnlyPairCellType cellMCType6 = new ReadOnlyPairCellType(LookupMCType.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.MACHINE_TYPE6].CellType = cellMCType6;

            // Process1
            NZString[] Production = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production) };
            LookupData LookupProduction = bizLookup.LoadLookupLocation(Production);
            ReadOnlyPairCellType cellProduction1 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS1].CellType = cellProduction1;

            //Process2
            ReadOnlyPairCellType cellProduction2 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS2].CellType = cellProduction2;

            //Process3
            ReadOnlyPairCellType cellProduction3 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS3].CellType = cellProduction3;

            //Process4
            ReadOnlyPairCellType cellProduction4 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS4].CellType = cellProduction4;

            //Process5
            ReadOnlyPairCellType cellProduction5 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS5].CellType = cellProduction5;

            //Process6
            ReadOnlyPairCellType cellProduction6 = new ReadOnlyPairCellType(LookupProduction.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PROCESS6].CellType = cellProduction6;

            // HeatTreatmentType
            LookupData LookupHeatTreatmentType = bizLookup.LoadLookupClassType(DataDefine.HEAT_TREATMENT_TYPE.ToNZString());
            ReadOnlyPairCellType cellTreatmentType = new ReadOnlyPairCellType(LookupHeatTreatmentType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.HEAT_TYPE].CellType = cellTreatmentType;

            // KTC Plating
            LookupData LookupKTCPlating = bizLookup.LoadLookupClassType(DataDefine.KTC_PLATING.ToNZString());
            ReadOnlyPairCellType cellKTCPlating = new ReadOnlyPairCellType(LookupKTCPlating, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.PLATING_KTC].CellType = cellKTCPlating;

            // Baking Time
            LookupData LookupBakTime = bizLookup.LoadLookupClassType(DataDefine.BAKING_TIME.ToNZString());
            ReadOnlyPairCellType cellBakTime = new ReadOnlyPairCellType(LookupBakTime, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.BAKING_TIME].CellType = cellBakTime;

            // Baking Temp
            LookupData LookupBakTemp = bizLookup.LoadLookupClassType(DataDefine.BAKING_TEMP.ToNZString());
            ReadOnlyPairCellType cellBakTemp = new ReadOnlyPairCellType(LookupBakTemp, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.BAKING_TEMP].CellType = cellBakTemp;

            // Other Kind
            LookupData LookupOtherKind = bizLookup.LoadLookupClassType(DataDefine.OTHER_KIND.ToNZString());
            ReadOnlyPairCellType cellOtherKind1 = new ReadOnlyPairCellType(LookupOtherKind.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_KIND].CellType = cellOtherKind1;

            ReadOnlyPairCellType cellOtherKind2 = new ReadOnlyPairCellType(LookupOtherKind.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_KIND].CellType = cellOtherKind2;

            // Other Condition
            LookupData LookupOtherCon = bizLookup.LoadLookupClassType(DataDefine.OTHER_CONDITION.ToNZString());
            ReadOnlyPairCellType cellOtherCon1 = new ReadOnlyPairCellType(LookupOtherCon.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_CONDITION].CellType = cellOtherCon1;

            ReadOnlyPairCellType cellOtherCon2 = new ReadOnlyPairCellType(LookupOtherCon.Clone(), CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_CONDITION].CellType = cellOtherCon2;

            //shtItemView.Columns[(int)eColView.CRT_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            //shtItemView.Columns[(int)eColView.UPD_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            shtItemView.Columns[(int)eColView.HEAT_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtItemView.Columns[(int)eColView.HEAT_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtItemView.Columns[(int)eColView.PLATING_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtItemView.Columns[(int)eColView.PLATING_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtItemView.Columns[(int)eColView.BAKING_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtItemView.Columns[(int)eColView.BAKING_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT1_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtItemView.Columns[(int)eColView.OTHER_TREATMENT2_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;




            FormatUtil.SetNumberFormat(shtItemView.Columns[(int)eColView.WEIGHT], FormatUtil.eNumberFormat.Qty_Gram);
            FormatUtil.SetNumberFormat(shtItemView.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);

            FormatUtil.SetDateTimeFormat(shtItemView.Columns[(int)eColView.CRT_DATE]);
            FormatUtil.SetDateTimeFormat(shtItemView.Columns[(int)eColView.UPD_DATE]);

            //// Lookup Item Type
            //LookupData lookupItemType = bizLookup.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            //// Lookup Lot Control
            //LookupData lookupLotControl = bizLookup.LoadLookupClassType(DataDefine.LOT_CONTROL_CLS.ToNZString());
            //// Lookup Lot Customer
            //LookupData lookupCustomer = bizLookup.LoadLookupLocation();// bizLookup.LoadLookupClassType(DataDefine.LOCATION_CLS.ToNZString());
            //// Lookup OrderLoc
            //LookupData lookupOrderLoc = bizLookup.LoadLookupLocation();
            //// Lookup ORDER_PROCESS_CLS
            //LookupData lookupOrderProcess = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.ORDER_PROCESS_CLS));
            //// Lookup StoreLoc
            //LookupData lookupStoreLoc = bizLookup.LoadLookupLocation();
            //// Lookup CustoemrLoc
            //LookupData lookupCustoemrLoc = bizLookup.LoadLookupLocation();
            //// Lookup Consumption
            //LookupData lookupConsumption = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.CONSUMPTION_CLS));
            //// Lookup InventUM
            //LookupData lookupInventUM = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.UM_CLS));
            //// Lookup OrderUM
            //LookupData lookupOrderUM = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.UM_CLS));

            //ReadOnlyPairCellType ItemTypecellType = new ReadOnlyPairCellType(lookupItemType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType LotControlcellType = new ReadOnlyPairCellType(lookupLotControl, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType CustomercellType = new ReadOnlyPairCellType(lookupCustomer, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType OrderProcess = new ReadOnlyPairCellType(lookupOrderProcess, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType OrderLoc = new ReadOnlyPairCellType(lookupOrderLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType StoreLoc = new ReadOnlyPairCellType(lookupStoreLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType CustoemrLoc = new ReadOnlyPairCellType(lookupCustoemrLoc, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType Consumption = new ReadOnlyPairCellType(lookupConsumption, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType InventUM = new ReadOnlyPairCellType(lookupInventUM, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //ReadOnlyPairCellType OrderUM = new ReadOnlyPairCellType(lookupOrderUM, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);

            //shtItemView.Columns[(int)eColView.ORDER_UM_CLS1].CellType = OrderUM;
            //shtItemView.Columns[(int)eColView.INV_UM_CLS1].CellType = InventUM;
            //shtItemView.Columns[(int)eColView.STORE_LOC_CD1].CellType = StoreLoc;
            //shtItemView.Columns[(int)eColView.ORDER_LOC_CD1].CellType = OrderLoc;
            //shtItemView.Columns[(int)eColView.ORDER_PROCESS_CLS1].CellType = OrderProcess;
            //shtItemView.Columns[(int)eColView.FOR_CUSTOMER1].CellType = CustomercellType;
            //shtItemView.Columns[(int)eColView.LOT_CONTROL_CLS1].CellType = LotControlcellType;
            //shtItemView.Columns[(int)eColView.ITEM_CLS].CellType = ItemTypecellType;
            //shtItemView.Columns[(int)eColView.ITEM_CLS_MINOR1].CellType = CtrlUtil.CreateReadOnlyPairCellType(bizLookup.LoadLookupClassType((NZString)DataDefine.ITEM_CLS_MINOR04));
            //shtItemView.Columns[(int)eColView.CONSUMTION_CLS1].CellType = Consumption;

        }

        private void LoadItemData(string keyFilter)
        {
            try
            {
                ItemBIZ biz = new ItemBIZ();
                m_dtAllData = biz.LoadItemList();

                DataTable dtView = null;// m_dtAllData.Clone();

                if (keyFilter != string.Empty)
                {
                    string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), keyFilter);

                    DataView dv = m_dtAllData.DefaultView;
                    dv.RowFilter = filterString;
                    dtView = dv.ToTable();

                    ////get only the rows you want
                    //DataRow[] results = m_dtAllData.Select(filterString);
                    ////populate new destination table
                    //foreach (DataRow dr in results)
                    //    dtView.ImportRow(dr);
                }
                else
                {
                    //foreach (DataRow dr in m_dtAllData.Rows)
                    //    dtView.ImportRow(dr);
                    dtView = m_dtAllData.Copy();
                }
                fpItemView.DataSource = dtView;

                CtrlUtil.SpreadUpdateColumnSorting(shtItemView);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void DeleteItem()
        {
            try
            {
                if (shtItemView.Rows.Count == 0) return;
                if (shtItemView.ActiveRowIndex < 0) return;

                NZString ItemCD = new NZString(null, shtItemView.Cells[shtItemView.ActiveRowIndex, (int)eColView.ITEM_CD].Text);

                ItemValidator validator = new ItemValidator();
                ErrorItem errorItem = validator.ValidateBeforeDelete(ItemCD);
                if (errorItem != null) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckExistsTransactionByItem(ItemCD);
                if (errorItem != null)
                {
                    MessageDialog.ShowBusiness(this, errorItem.Message);
                }


                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(SystemMaintenance.Messages.eConfirm.CFM9002.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;
                }

                ItemController ctlItem = new ItemController();
                ctlItem.DeleteItem(ItemCD);

                shtItemView.RemoveRows(shtItemView.ActiveRowIndex, 1);
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        private void EditItem()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtItemView.Rows.Count == 0) return;
            if (shtItemView.ActiveRowIndex < 0) return;

            NZString ItemCD = new NZString(null, shtItemView.Cells[shtItemView.ActiveRowIndex, (int)eColView.ITEM_CD].Text);
            MAS040_ItemMaster frmItemMaster = new MAS040_ItemMaster(ItemCD);
            frmItemMaster.ShowDialog();

            LoadItemData(txtSearch.Text.Trim());
        }

        private void FindDataFromMemory()
        {
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtItemView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtItemView);
        }

        private DataTable FilterData(DataTable dtView, string keyFilter)
        {
            if (keyFilter.Trim() == String.Empty)
                return dtView;

            string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), keyFilter);
            ////get only the rows you want
            DataRow[] results = dtView.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            ////populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            //DataView dv = m_dtAllData.DefaultView;
            //dv.RowFilter = filterString;
            //dtFilter = dv.ToTable();

            return dtFilter;
        }
        #endregion

        #region Form Event

        private void MAS030_ItemList_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        #endregion

        #region Control Event

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ////LoadItemData(txtSearch.Text.Trim());
            //FindDataFromMemory();

            try
            {
                tmrAutoComplete.Enabled = true;

                tmrAutoComplete.Stop();
                tmrAutoComplete.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        #endregion

        #region Spread Event

        private void fpItemView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            EditItem();
        }
        private void fpItemView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                EditItem();
            }
        }
        #endregion

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                cmsItem.Items[0].Enabled = ActivePermission.Edit;
                cmsItem.Items[1].Enabled = ActivePermission.Delete;
            }
        }

        private void fpItemView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                FarPoint.Win.Spread.Model.CellRange cellRange = fpItemView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtItemView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtItemView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    editToolStripMenuItem.Enabled = ActivePermission.Edit;
                    deleteToolStripMenuItem.Enabled = ActivePermission.Delete;
                }
                else
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
                cmsItem.Show(fpItemView, e.Location);
            }

        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtItemView, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtItemView);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
                tsbAdvanceSearch.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtItemView, this.ScreenCode);
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtItemView);
        }

        private void fpItemView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void fpItemView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void MAS030_ItemList_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }

        private void tmrAutoComplete_Tick(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_USE_AUTO_COMPLETE)
            {
                try
                {
                    FindDataFromMemory();

                    tmrAutoComplete.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowBusiness(this, ex.Message);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }

        private void fpItemView_AutoFilteredColumn(object sender, FarPoint.Win.Spread.AutoFilteredColumnEventArgs e)
        {
            //shtItemView.GetDropDownFilterItems((int)eColView.ITEM_CD).Sort(CompareUtil.CompareDecimal());
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtItemView, typeof(eColView), m_dtAllData);
        }
    }
}
