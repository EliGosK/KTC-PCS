#define MODIFY_BY_ITIM
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework.Data;
using Rubik.UIDataModel;
using System.Drawing;
using Rubik.Validators;

namespace Rubik.Controller
{
    class ItemController
    {
        internal List<ItemDTO> LoadAllItem() 
        {
            ItemBIZ biz = new ItemBIZ();
            return biz.LoadAllItem();
        }

        internal DataTable LoadAllItem(eSqlOperator sqlOperator, string[] ItemTypes)
        {
            ItemBIZ biz = new ItemBIZ();
            return biz.LoadAllItemWithItemType(sqlOperator, ItemTypes);
        }

        internal DataTable LoadAllItem(eSqlOperator sqlOperator, string[] ItemTypes, NZString strDealing
            , DataDefine.eDealingType argDealingType) {
            ItemBIZ biz = new ItemBIZ();
            return biz.LoadAllItemWithItemType(sqlOperator, ItemTypes, strDealing, argDealingType);
        }

        internal DataTable LoadConsumptionListOfItem(NZString itemCode)
        {
            ItemBIZ biz = new ItemBIZ();
            return biz.LoadConsumptionList(itemCode);
        }

        internal void AddNewItem(ItemUIDM uidmItem)
        {
            ValidateException validationException = new ValidateException();
            ItemValidator itemValidator = new ItemValidator();
            itemValidator.CheckItemExist(uidmItem.ITEM_CD);
            //validationException.AddError(businessException.Error);
            //validationException.ThrowIfHasError();

            #region dtoItem

            ItemDTO dtoItem = new ItemDTO();
            dtoItem.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoItem.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dtoItem.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dtoItem.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoItem.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dtoItem.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            dtoItem.ITEM_CD = uidmItem.ITEM_CD;
            dtoItem.SHORT_NAME = uidmItem.SHORT_NAME;
            dtoItem.ITEM_DESC = uidmItem.ITEM_DESC;
            dtoItem.ROUTING_TEXT = uidmItem.ROUTING_TEXT;

            #region Product Tab

            dtoItem.KIND_OF_PRODUCT = uidmItem.KIND_OF_PRODUCT;
            dtoItem.CUSTOMER_CD = uidmItem.CUSTOMER_CD;
            dtoItem.CUSTOMER_USE_POINT = uidmItem.CUSTOMER_USE_POINT;
            dtoItem.WEIGHT = uidmItem.WEIGHT;
            dtoItem.BOI = uidmItem.BOI;
            dtoItem.PRODUCTION_DI = uidmItem.PRODUCTION_DI;
            dtoItem.ITEM_LEVEL = uidmItem.ITEM_LEVEL;
            dtoItem.MAT_NAME = uidmItem.MAT_NAME;
            dtoItem.MAT_SIZE = uidmItem.MAT_SIZE;
            dtoItem.MAT_SUPPLIER_CD = uidmItem.SUPPLIER_NAME;
            dtoItem.KIND_OF_MAT = uidmItem.KIND_OF_MAT;
            dtoItem.MAT_DI = uidmItem.MAT_DI;
            dtoItem.REMARK = uidmItem.REMARK;

            #endregion

            #region Screw Tab

            dtoItem.SCREW_KIND = uidmItem.SCREW_KIND;
            dtoItem.SCREW_HEAD = uidmItem.SCREW_HEAD;
            dtoItem.SCREW_M = uidmItem.SCREW_M;
            dtoItem.SCREW_L = uidmItem.SCREW_L;
            dtoItem.SCREW_TYPE = uidmItem.SCREW_TYPE;
            dtoItem.SCREW_REMARK1 = uidmItem.SCREW_REMARK1;
            dtoItem.SCREW_REMARK2 = uidmItem.SCREW_REMARK2;
            dtoItem.HEXABULAR = uidmItem.HEXABULAR;

            #endregion

            #region Machine Tab

            dtoItem.PROCESS1 = uidmItem.PROCESS1;
            dtoItem.MACHINE_TYPE1 = uidmItem.MACHINE_TYPE1;
            dtoItem.PROCESS2 = uidmItem.PROCESS2;
            dtoItem.MACHINE_TYPE2 = uidmItem.MACHINE_TYPE2;
            dtoItem.PROCESS3 = uidmItem.PROCESS3;
            dtoItem.MACHINE_TYPE3 = uidmItem.MACHINE_TYPE3;
            dtoItem.PROCESS4 = uidmItem.PROCESS4;
            dtoItem.MACHINE_TYPE4 = uidmItem.MACHINE_TYPE4;
            dtoItem.PROCESS5 = uidmItem.PROCESS5;
            dtoItem.MACHINE_TYPE5 = uidmItem.MACHINE_TYPE5;
            dtoItem.PROCESS6 = uidmItem.PROCESS6;
            dtoItem.MACHINE_TYPE6 = uidmItem.MACHINE_TYPE6;

            #endregion

            #region Heat Treatment Tab

            dtoItem.HEAT_FLAG = uidmItem.HEAT_FLAG;
            dtoItem.HEAT_TYPE = uidmItem.HEAT_TYPE;
            dtoItem.HEAT_HARDNESS = uidmItem.HEAT_HARDNESS;
            dtoItem.HEAT_CORE_HARDNESS = uidmItem.HEAT_CORE_HARDNESS;
            dtoItem.HEAT_CASE_DEPTH = uidmItem.HEAT_CASE_DEPTH;

            #endregion

            #region Plating Tab

            dtoItem.PLATING_FLAG = uidmItem.PLATING_FLAG;
            dtoItem.PLATING_KIND = uidmItem.PLATING_KIND;
            dtoItem.PLATING_SUPPLIER_CD = uidmItem.PLATING_SUPPLIER_NAME;
            dtoItem.PLATING_THICKNESS1_1 = uidmItem.PLATING_THICKNESS1_1;
            dtoItem.PLATING_THICKNESS1_2 = uidmItem.PLATING_THICKNESS1_2;
            dtoItem.PLATING_THICKNESS2_1 = uidmItem.PLATING_THICKNESS2_1;
            dtoItem.PLATING_THICKNESS2_2 = uidmItem.PLATING_THICKNESS2_2;
            dtoItem.PLATING_KTC = uidmItem.PLATING_KTC;
            dtoItem.BAKING_FLAG = uidmItem.BAKING_FLAG;
            dtoItem.BAKING_TIME = uidmItem.BAKING_TIME;
            dtoItem.BAKING_TEMP = uidmItem.BAKING_TEMP;

            #endregion 

            #region Other Tab

            dtoItem.OTHER_TREATMENT1_FLAG = uidmItem.OTHER_TREATMENT1_FLAG;
            dtoItem.OTHER_TREATMENT1_KIND = uidmItem.OTHER_TREATMENT1_KIND;
            dtoItem.OTHER_TREATMENT1_CONDITION = uidmItem.OTHER_TREATMENT1_CONDITION;
            dtoItem.OTHER_TREATMENT2_FLAG = uidmItem.OTHER_TREATMENT2_FLAG;
            dtoItem.OTHER_TREATMENT2_KIND = uidmItem.OTHER_TREATMENT2_KIND;
            dtoItem.OTHER_TREATMENT2_CONDITION = uidmItem.OTHER_TREATMENT2_CONDITION;

            #endregion
                        
            dtoItem.OLD_DATA = new NZInt(null,0);

            //ItemProcessDTO dtoItemProcess = new ItemProcessDTO();
            //dtoItemProcess.ITEM_CD = uidmItem.ITEM_CD;
            //dtoItemProcess.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //dtoItemProcess.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            //dtoItemProcess.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //dtoItemProcess.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //dtoItemProcess.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            //dtoItemProcess.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            #endregion

            List<ItemProcessDTO> listNew = new List<ItemProcessDTO>();            
            List<BOMDTO> listNewComponent = new List<BOMDTO>();
            List<ItemMachineDTO> listNewMachine = new List<ItemMachineDTO>();
            
            //Add
            uidmItem.DataView.AcceptChanges();
            uidmItem.DataComponentView.AcceptChanges();

            #region Routing

            DataTable dtNew = uidmItem.DataView;
            if (dtNew != null)
            {
                foreach (DataRow dr in dtNew.Rows)
                {
                    ItemProcessDTO dto = new ItemProcessDTO();

                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = uidmItem.ITEM_CD;
                    dto.ITEM_SEQ = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.ITEM_SEQ]);
                    dto.PROCESS_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD]);
                    dto.WEIGHT = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.WEIGHT]);
                    dto.PRODUCTION_LEADTIME = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.PRODUCTION_LEADTIME]);
                    dto.QTY_PER_DAY = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.QTY_PER_DAY]);
                    dto.SUPPLIER_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.SUPPLIER_CD]);
                    dto.OLD_DATA = new NZInt(null, 0);


                    listNew.Add(dto);
                }
            }              

            ////Edit
            //DataTable dtEdit = uidmItem.DataView.GetChanges(DataRowState.Modified);
            //if (dtEdit != null)
            //{
            //    foreach (DataRow dr in dtEdit.Rows)
            //    {
            //        ItemProcessDTO dto = new ItemProcessDTO();
            //        //dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //        //dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //        dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //        dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //        dto.ITEM_CD = new NZInt(null, Convert.ToInt32(uidmItem.ITEM_CD.StrongValue));
            //        dto.ITEM_SEQ = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.ITEM_SEQ]);
            //        dto.PROCESS_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD]);
            //        dto.PROCESS_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.PROCESS_NAME]);
            //        dto.WEIGHT = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.WEIGHT]);
            //        dto.PRODUCTION_LEADTIME = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.PRODUCTION_LEADTIME]);
            //        dto.QTY_PER_DAY = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.QTY_PER_DAY]);
            //        dto.SUPPLIER_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.SUPPLIER_CD]);
            //        dto.OLD_DATA = new NZInt(null, 0);

            //        listEdit.Add(dto);
            //    }
            //}

            ////delete
            //DataTable dtDelete = uidmItem.DataView.GetChanges(DataRowState.Deleted);
            //if (dtDelete != null)
            //{
            //    listDelete = DTOUtility.ConvertDataTableToList<ItemProcessDTO>(dtDelete);

            //    for (int i = 0; i < listDelete.Count; i++)
            //    {
            //        listDelete[i].ITEM_CD = new NZInt(null, Convert.ToInt32(uidmItem.ITEM_CD.StrongValue));
            //    }

            //}

            #endregion

            #region Component

            int iComponet_Seq = 0;
            DataTable dtNewComponent = uidmItem.DataComponentView;//.GetChanges(DataRowState.Added);
            if (dtNewComponent != null)
            {
                foreach (DataRow dr in dtNewComponent.Rows)
                {
                    iComponet_Seq = iComponet_Seq + 1;
                    BOMDTO dto = new BOMDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
                    dto.LOWER_ITEM_CD = new NZString(null, dr[(int)ItemComponentDTO.eColumns.ITEM_CD]);
                    dto.ITEM_SEQ = new NZInt(null, iComponet_Seq);
                    dto.UPPER_QTY = new NZDecimal(null, dr[(int)ItemComponentDTO.eColumns.PCS]);
                    dto.LOWER_QTY = new NZDecimal(null, 1);
                    dto.OLD_DATA = new NZInt(null, 0);   

                    listNewComponent.Add(dto);
                }
            }
            //DataTable dtEditComponent = uidmItem.DataView.GetChanges(DataRowState.Modified);
            //if (dtEditComponent != null)
            //{
            //    foreach (DataRow dr in dtEditComponent.Rows)
            //    {
            //        BOMDTO dto = new BOMDTO();
            //        dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //        dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //        dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            //        dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            //        dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
            //        dto.LOWER_ITEM_CD = new NZString(null, dr[(int)ItemComponentDTO.eColumns.ITEM_CD]);
            //        dto.ITEM_SEQ = new NZInt(null, iComponet_Seq);
            //        dto.UPPER_QTY = new NZDecimal(null, dr[(int)ItemComponentDTO.eColumns.PCS]);
            //        dto.LOWER_QTY = new NZDecimal(null, 1);
            //        dto.OLD_DATA = new NZInt(null, 0);  


            //        listEditComponent.Add(dto);
            //    }
            //}

            //DataTable dtDeleteComponent = uidmItem.DataView.GetChanges(DataRowState.Deleted);
            //if (dtDeleteComponent != null)
            //{
            //    List<ItemComponentDTO> list = DTOUtility.ConvertDataTableToList<ItemComponentDTO>(dtDeleteComponent);

            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        BOMDTO dto = new BOMDTO();                    
            //        dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
            //        dto.LOWER_ITEM_CD = new NZString(null, list[i].ITEM_CD);
            //        dto.ITEM_SEQ = new NZInt(null, iComponet_Seq);
            //        listDeleteComponent.Add(dto);                 
            //    }
            //}

            #endregion

            #region Item Machine

            DataTable dtItemMachine = uidmItem.DataItemMachine;
            if (dtItemMachine != null) 
            {
                int iRunNo = 0;
                foreach (DataRow dr in dtItemMachine.Rows) 
                {
                    iRunNo = iRunNo + 1;
                    ItemMachineDTO dto = new ItemMachineDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = uidmItem.ITEM_CD;
                    dto.RUN_NO = new NZInt(null, iRunNo);
                    dto.MACHINE_PROCESS = new NZString(null, dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS]);
                    dto.MACHINE_TYPE = new NZString(null, dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE]);
                    dto.OLD_DATA = new NZInt(null, 0);
                    listNewMachine.Add(dto);
                }
            }

            #endregion

            ItemBIZ biz = new ItemBIZ();
            biz.AddNew(dtoItem, listNew, listNewComponent, listNewMachine);
            //biz.UpdateWithoutPK(dtoItem, listNew, listEdit, listDelete, listNewComponent, listEditComponent, listDeleteComponent);
        }

        internal void DeleteItem(EVOFramework.NZString ItemCD)
        {
            ItemBIZ biz = new ItemBIZ();
            biz.DeleteItem(ItemCD);

        }

        internal ItemUIDM LoadItem(EVOFramework.NZString ItemCD)
        {
            ItemBIZ biz = new ItemBIZ();
            
            ItemDTO dtoItem = biz.LoadItem(ItemCD);
            List<ItemViewProcessDTO> dtoItemProcess = biz.LoadItemProcessList(ItemCD);
            List<ItemComponentDTO> dtoItemComponent = biz.LoadItemComponentList(ItemCD);
            List<ItemMachineDTO> dtoItemMachine = biz.LoadItemMachineByItemCD(ItemCD);

            #region ITEM uidm
            ItemUIDM uidm = new ItemUIDM();
            uidm.CRT_BY = dtoItem.CRT_BY;
            uidm.CRT_DATE = dtoItem.CRT_DATE;
            uidm.CRT_MACHINE = dtoItem.CRT_MACHINE;
            uidm.UPD_BY = dtoItem.UPD_BY;
            uidm.UPD_DATE = dtoItem.UPD_DATE;
            uidm.UPD_MACHINE = dtoItem.UPD_MACHINE;
            uidm.ITEM_CD = dtoItem.ITEM_CD;
            uidm.SHORT_NAME = dtoItem.SHORT_NAME;
            uidm.ITEM_DESC = dtoItem.ITEM_DESC;
            uidm.KIND_OF_PRODUCT = dtoItem.KIND_OF_PRODUCT;
            uidm.CUSTOMER_CD = dtoItem.CUSTOMER_CD;
            uidm.CUSTOMER_USE_POINT = dtoItem.CUSTOMER_USE_POINT;
            uidm.WEIGHT = dtoItem.WEIGHT;
            uidm.BOI = dtoItem.BOI;
            uidm.PRODUCTION_DI = dtoItem.PRODUCTION_DI;
            uidm.ITEM_LEVEL = dtoItem.ITEM_LEVEL;
            uidm.MAT_NAME = dtoItem.MAT_NAME;
            uidm.MAT_SIZE = dtoItem.MAT_SIZE;
            uidm.SUPPLIER_NAME = dtoItem.MAT_SUPPLIER_CD;
            uidm.KIND_OF_MAT = dtoItem.KIND_OF_MAT;
            uidm.MAT_DI = dtoItem.MAT_DI;
            uidm.REMARK = dtoItem.REMARK;
            uidm.SCREW_KIND = dtoItem.SCREW_KIND;
            uidm.SCREW_HEAD = dtoItem.SCREW_HEAD;
            uidm.SCREW_M = dtoItem.SCREW_M;
            uidm.SCREW_L = dtoItem.SCREW_L;
            uidm.SCREW_TYPE = dtoItem.SCREW_TYPE;
            uidm.SCREW_REMARK1 = dtoItem.SCREW_REMARK1;
            uidm.SCREW_REMARK2 = dtoItem.SCREW_REMARK2;
            uidm.HEXABULAR = dtoItem.HEXABULAR;
            uidm.HEAT_FLAG = dtoItem.HEAT_FLAG;
            uidm.HEAT_TYPE = dtoItem.HEAT_TYPE;
            uidm.HEAT_HARDNESS = dtoItem.HEAT_HARDNESS;
            uidm.HEAT_CORE_HARDNESS = dtoItem.HEAT_CORE_HARDNESS;
            uidm.HEAT_CASE_DEPTH = dtoItem.HEAT_CASE_DEPTH;
            uidm.PLATING_FLAG = dtoItem.PLATING_FLAG;
            uidm.PLATING_KIND = dtoItem.PLATING_KIND;
            uidm.PLATING_SUPPLIER_NAME = dtoItem.PLATING_SUPPLIER_CD;
            uidm.PLATING_THICKNESS1_1 = dtoItem.PLATING_THICKNESS1_1;
            uidm.PLATING_THICKNESS1_2 = dtoItem.PLATING_THICKNESS1_2;
            uidm.PLATING_THICKNESS2_1 = dtoItem.PLATING_THICKNESS2_1;
            uidm.PLATING_THICKNESS2_2 = dtoItem.PLATING_THICKNESS2_2;
            uidm.PLATING_KTC = dtoItem.PLATING_KTC;
            uidm.BAKING_FLAG = dtoItem.BAKING_FLAG;
            uidm.BAKING_TIME = dtoItem.BAKING_TIME;
            uidm.BAKING_TEMP = dtoItem.BAKING_TEMP;
            uidm.OTHER_TREATMENT1_FLAG = dtoItem.OTHER_TREATMENT1_FLAG;
            uidm.OTHER_TREATMENT1_KIND = dtoItem.OTHER_TREATMENT1_KIND;
            uidm.OTHER_TREATMENT1_CONDITION = dtoItem.OTHER_TREATMENT1_CONDITION;
            uidm.OTHER_TREATMENT2_FLAG = dtoItem.OTHER_TREATMENT2_FLAG;
            uidm.OTHER_TREATMENT2_KIND = dtoItem.OTHER_TREATMENT2_KIND;
            uidm.OTHER_TREATMENT2_CONDITION = dtoItem.OTHER_TREATMENT2_CONDITION;
            uidm.OLD_DATA = dtoItem.OLD_DATA;
            #endregion

            uidm.DataView = DTOUtility.ConvertListToDataTable<ItemViewProcessDTO>(dtoItemProcess);
            uidm.DataView.AcceptChanges();
            uidm.DataComponentView = DTOUtility.ConvertListToDataTable<ItemComponentDTO>(dtoItemComponent);
            uidm.DataComponentView.AcceptChanges();
            uidm.DataItemMachine = DTOUtility.ConvertListToDataTable<ItemMachineDTO>(dtoItemMachine);
            uidm.DataItemMachine.AcceptChanges();

            return uidm;
        }

        internal void UpdateItem(ItemUIDM uidmItem)
        {

            ItemDTO dtoItem = new ItemDTO();
            dtoItem.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoItem.CRT_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dtoItem.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dtoItem.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoItem.UPD_DATE.Value = CommonLib.Common.GetDatabaseDateTime();
            dtoItem.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            dtoItem.ITEM_CD = uidmItem.ITEM_CD;
            dtoItem.SHORT_NAME = uidmItem.SHORT_NAME;
            dtoItem.ITEM_DESC = uidmItem.ITEM_DESC;
            dtoItem.ROUTING_TEXT = uidmItem.ROUTING_TEXT;

            #region Product Tab

            dtoItem.KIND_OF_PRODUCT = uidmItem.KIND_OF_PRODUCT;
            dtoItem.CUSTOMER_CD = uidmItem.CUSTOMER_CD;
            dtoItem.CUSTOMER_USE_POINT = uidmItem.CUSTOMER_USE_POINT;
            dtoItem.WEIGHT = uidmItem.WEIGHT;
            dtoItem.BOI = uidmItem.BOI;
            dtoItem.PRODUCTION_DI = uidmItem.PRODUCTION_DI;
            dtoItem.ITEM_LEVEL = uidmItem.ITEM_LEVEL;
            dtoItem.MAT_NAME = uidmItem.MAT_NAME;
            dtoItem.MAT_SIZE = uidmItem.MAT_SIZE;
            dtoItem.MAT_SUPPLIER_CD = uidmItem.SUPPLIER_NAME;
            dtoItem.KIND_OF_MAT = uidmItem.KIND_OF_MAT;
            dtoItem.MAT_DI = uidmItem.MAT_DI;
            dtoItem.REMARK = uidmItem.REMARK;

            #endregion

            #region Screw Tab

            dtoItem.SCREW_KIND = uidmItem.SCREW_KIND;
            dtoItem.SCREW_HEAD = uidmItem.SCREW_HEAD;
            dtoItem.SCREW_M = uidmItem.SCREW_M;
            dtoItem.SCREW_L = uidmItem.SCREW_L;
            dtoItem.SCREW_TYPE = uidmItem.SCREW_TYPE;
            dtoItem.SCREW_REMARK1 = uidmItem.SCREW_REMARK1;
            dtoItem.SCREW_REMARK2 = uidmItem.SCREW_REMARK2;
            dtoItem.HEXABULAR = uidmItem.HEXABULAR;

            #endregion

            #region Machine Tab

            dtoItem.PROCESS1 = uidmItem.PROCESS1;
            dtoItem.MACHINE_TYPE1 = uidmItem.MACHINE_TYPE1;
            dtoItem.PROCESS2 = uidmItem.PROCESS2;
            dtoItem.MACHINE_TYPE2 = uidmItem.MACHINE_TYPE2;
            dtoItem.PROCESS3 = uidmItem.PROCESS3;
            dtoItem.MACHINE_TYPE3 = uidmItem.MACHINE_TYPE3;
            dtoItem.PROCESS4 = uidmItem.PROCESS4;
            dtoItem.MACHINE_TYPE4 = uidmItem.MACHINE_TYPE4;
            dtoItem.PROCESS5 = uidmItem.PROCESS5;
            dtoItem.MACHINE_TYPE5 = uidmItem.MACHINE_TYPE5;
            dtoItem.PROCESS6 = uidmItem.PROCESS6;
            dtoItem.MACHINE_TYPE6 = uidmItem.MACHINE_TYPE6;

            #endregion

            #region Heat Treatment Tab

            dtoItem.HEAT_FLAG = uidmItem.HEAT_FLAG;
            dtoItem.HEAT_TYPE = uidmItem.HEAT_TYPE;
            dtoItem.HEAT_HARDNESS = uidmItem.HEAT_HARDNESS;
            dtoItem.HEAT_CORE_HARDNESS = uidmItem.HEAT_CORE_HARDNESS;
            dtoItem.HEAT_CASE_DEPTH = uidmItem.HEAT_CASE_DEPTH;

            #endregion

            #region Plating Tab

            dtoItem.PLATING_FLAG = uidmItem.PLATING_FLAG;
            dtoItem.PLATING_KIND = uidmItem.PLATING_KIND;
            dtoItem.PLATING_SUPPLIER_CD = uidmItem.PLATING_SUPPLIER_NAME;
            dtoItem.PLATING_THICKNESS1_1 = uidmItem.PLATING_THICKNESS1_1;
            dtoItem.PLATING_THICKNESS1_2 = uidmItem.PLATING_THICKNESS1_2;
            dtoItem.PLATING_THICKNESS2_1 = uidmItem.PLATING_THICKNESS2_1;
            dtoItem.PLATING_THICKNESS2_2 = uidmItem.PLATING_THICKNESS2_2;
            dtoItem.PLATING_KTC = uidmItem.PLATING_KTC;
            dtoItem.BAKING_FLAG = uidmItem.BAKING_FLAG;
            dtoItem.BAKING_TIME = uidmItem.BAKING_TIME;
            dtoItem.BAKING_TEMP = uidmItem.BAKING_TEMP;

            #endregion

            #region Other Tab

            dtoItem.OTHER_TREATMENT1_FLAG = uidmItem.OTHER_TREATMENT1_FLAG;
            dtoItem.OTHER_TREATMENT1_KIND = uidmItem.OTHER_TREATMENT1_KIND;
            dtoItem.OTHER_TREATMENT1_CONDITION = uidmItem.OTHER_TREATMENT1_CONDITION;
            dtoItem.OTHER_TREATMENT2_FLAG = uidmItem.OTHER_TREATMENT2_FLAG;
            dtoItem.OTHER_TREATMENT2_KIND = uidmItem.OTHER_TREATMENT2_KIND;
            dtoItem.OTHER_TREATMENT2_CONDITION = uidmItem.OTHER_TREATMENT2_CONDITION;

            #endregion

            dtoItem.OLD_DATA = new NZInt(null, 0);

            List<ItemProcessDTO> listNew = new List<ItemProcessDTO>();
            List<ItemProcessDTO> listEdit = new List<ItemProcessDTO>();
            List<ItemProcessDTO> listDelete = new List<ItemProcessDTO>();
            List<BOMDTO> listNewComponent = new List<BOMDTO>();
            List<BOMDTO> listEditComponent = new List<BOMDTO>();
            List<BOMDTO> listDeleteComponent = new List<BOMDTO>();
            List<ItemMachineDTO> listItemMachine = new List<ItemMachineDTO>();

            #region Routing            

            //Add
            DataTable dtNew = uidmItem.DataView.GetChanges(DataRowState.Added);
            if (dtNew != null) 
            {
                foreach(DataRow dr in dtNew.Rows)
                {
                    ItemProcessDTO dto = new ItemProcessDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = uidmItem.ITEM_CD;
                    dto.ITEM_SEQ = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.ITEM_SEQ]);
                    dto.PROCESS_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD]);
                    dto.WEIGHT = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.WEIGHT]);
                    dto.PRODUCTION_LEADTIME = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.PRODUCTION_LEADTIME]);
                    dto.QTY_PER_DAY = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.QTY_PER_DAY]);
                    dto.SUPPLIER_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.SUPPLIER_CD]);
                    dto.OLD_DATA = new NZInt(null, 0);
                   

                    listNew.Add(dto);
                }
            }
            
            //Edit
            DataTable dtEdit = uidmItem.DataView.GetChanges(DataRowState.Modified);
            if (dtEdit != null)
            {
                foreach (DataRow dr in dtEdit.Rows)
                {
                    ItemProcessDTO dto = new ItemProcessDTO();
                    //dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                   // dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = uidmItem.ITEM_CD;
                    dto.ITEM_SEQ = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.ITEM_SEQ]);
                    dto.PROCESS_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD]);
                    dto.WEIGHT = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.WEIGHT]);
                    dto.PRODUCTION_LEADTIME = new NZInt(null, dr[(int)ItemViewProcessDTO.eColumns.PRODUCTION_LEADTIME]);
                    dto.QTY_PER_DAY = new NZDecimal(null, dr[(int)ItemViewProcessDTO.eColumns.QTY_PER_DAY]);
                    dto.SUPPLIER_CD = new NZString(null, dr[(int)ItemViewProcessDTO.eColumns.SUPPLIER_CD]);
                    dto.OLD_DATA = new NZInt(null, 0);

                    listEdit.Add(dto);
                }
            }

            //delete
            DataTable dtDelete = uidmItem.DataView.GetChanges(DataRowState.Deleted);
            if (dtDelete != null) {
                listDelete = DTOUtility.ConvertDataTableToList<ItemProcessDTO>(dtDelete);

                for (int i = 0; i < listDelete.Count; i++) {
                    listDelete[i].ITEM_CD = uidmItem.ITEM_CD;
                }

            }

            #endregion

            #region Component
            
            int iComponet_Seq = 0; // get max seq of item
            DataTable dtNewComponent = uidmItem.DataComponentView.GetChanges(DataRowState.Added);
            if (dtNewComponent != null)
            {
                foreach (DataRow dr in dtNewComponent.Rows)
                {
                    iComponet_Seq = iComponet_Seq + 1;
                    BOMDTO dto = new BOMDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
                    dto.LOWER_ITEM_CD = new NZString(null, dr[(int)ItemComponentDTO.eColumns.ITEM_CD]);
                    dto.ITEM_SEQ = new NZInt(null, iComponet_Seq);
                    dto.UPPER_QTY = new NZDecimal(null, dr[(int)ItemComponentDTO.eColumns.PCS]);
                    dto.LOWER_QTY = new NZDecimal(null, 1);
                    dto.OLD_DATA = new NZInt(null, 0);

                    listNewComponent.Add(dto);
                }
            }
            DataTable dtEditComponent = uidmItem.DataComponentView.GetChanges(DataRowState.Modified);
            if (dtEditComponent != null)
            {
                foreach (DataRow dr in dtEditComponent.Rows)
                {
                    BOMDTO dto = new BOMDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
                    dto.LOWER_ITEM_CD = new NZString(null, dr[(int)ItemComponentDTO.eColumns.ITEM_CD]);
                    dto.ITEM_SEQ = new NZInt(null, dr[(int)ItemComponentDTO.eColumns.SEQ_NO]);
                    dto.UPPER_QTY = new NZDecimal(null, dr[(int)ItemComponentDTO.eColumns.PCS]);
                    dto.LOWER_QTY = new NZDecimal(null, 1);
                    dto.OLD_DATA = new NZInt(null, 0);


                    listEditComponent.Add(dto);
                }
            }

            DataTable dtDeleteComponent = uidmItem.DataComponentView.GetChanges(DataRowState.Deleted);
            if (dtDeleteComponent != null) {
                List<ItemComponentDTO> list = DTOUtility.ConvertDataTableToList<ItemComponentDTO>(dtDeleteComponent);

                for (int i = 0; i < list.Count; i++) {
                    BOMDTO dto = new BOMDTO();
                    dto.UPPER_ITEM_CD = uidmItem.ITEM_CD;
                    dto.LOWER_ITEM_CD = new NZString(null, list[i].ITEM_CD.StrongValue);
                    dto.ITEM_SEQ = new NZInt(null, list[i].SEQ_NO.StrongValue);
                    listDeleteComponent.Add(dto);
                }
            }

            #endregion

            #region Item Machine 

            DataTable dtItemMachine = uidmItem.DataItemMachine;
            if (dtItemMachine != null) 
            {
                int iRunNo = 0;
                foreach (DataRow dr in dtItemMachine.Rows) {
                    iRunNo = iRunNo + 1;
                    ItemMachineDTO dto = new ItemMachineDTO();
                    dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    dto.ITEM_CD = uidmItem.ITEM_CD;
                    dto.RUN_NO = new NZInt(null, iRunNo);
                    dto.MACHINE_PROCESS = new NZString(null, dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS]);
                    dto.MACHINE_TYPE = new NZString(null, dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE]);
                    dto.OLD_DATA = new NZInt(null, 0);
                    listItemMachine.Add(dto);
                }
            }

            #endregion

            ItemBIZ biz = new ItemBIZ();
            biz.UpdateWithoutPK(dtoItem, listNew, listEdit, listDelete, listNewComponent, listEditComponent, listDeleteComponent, listItemMachine);
            //biz.UpdateWithoutPK(dtoItem, listNewComponent, listEditComponent, listDeleteComponent);
        }

        internal int AddNewImage(string ItemCD, Image image)
        {
            ItemImageBIZ biz = new ItemImageBIZ();
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, image.RawFormat);
            memStream.Position = 0;

            byte[] byteArray = memStream.ToArray();
            memStream.Close();
            return biz.AddImage(ItemCD, byteArray);

        }

        internal Image LoadImageForItem(EVOFramework.NZString ItemCD)
        {
            ItemImageBIZ biz = new ItemImageBIZ();
            ItemImageDTO dto = biz.LoadImage(ItemCD);
            if (dto == null) return null;
            // Convert byte array to Image.
            byte[] byteArray = dto.IMAGE.StrongValue;
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image img = Image.FromStream(memoryStream);
            return img;
        }

        internal void ReMoveImage(EVOFramework.NZString ItemCD)
        {
            ItemImageBIZ biz = new ItemImageBIZ();
            biz.DeleteImage(ItemCD);
        }
    }
}
