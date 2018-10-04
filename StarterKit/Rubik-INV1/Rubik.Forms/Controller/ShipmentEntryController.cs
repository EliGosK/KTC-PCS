using System;
using System.Collections.Generic;
using SystemMaintenance.BIZ;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using Rubik.BIZ;
using Rubik.DTO;
using System.Data;
using Rubik.UIDataModel;
using Rubik.Validators;
using EVOFramework.Database;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

namespace Rubik.Controller
{
    public class ShipmentEntryController
    {
        private enum eColView
        {
            PART_NO,
            PART_NAME,
            LOT_NO,
            ONHAND_QTY,
            ISSUE_QTY,
            TRANS_ID,
            OTHER_DL_NO,
            DEALING_NO
        }
        internal NZString SaveShipmentEntry(ShipmentEntryUIDM model, Common.eScreenMode Mode, DataTable OldOrder, DataTable NewOrder, DataTable OldLot, DataTable NewLot)
        {
            Database db = Common.CurrentDatabase.CreateNewDatabase();
            NZString SlipNo = new NZString();


            try
            {
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                //bizShipment.AddShipmentEntry(dtoInvTrnsList);
                ShipmentBIZ bizShipment = new ShipmentBIZ();
                IssueEntryValidator val = new IssueEntryValidator();
                CommonBizValidator commonVal = new CommonBizValidator();


                //== If data not has to processing.
                if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

                DataTable dtData = model.DATA_VIEW;
                DataTable dtAdd = new DataTable();
                DataTable dtModify = new DataTable();
                DataTable dtDelete = new DataTable();

                if (Mode == Common.eScreenMode.ADD || OldOrder.Rows.Count <= 0)
                {
                    dtAdd = dtData.GetChanges(DataRowState.Added);
                    dtModify = dtData.GetChanges(DataRowState.Modified);
                    dtDelete = dtData.GetChanges(DataRowState.Deleted);
                }
                else
                {
                    dtAdd = dtData.Clone();
                    dtModify = dtData.Clone();
                    dtDelete = dtData.Clone();

                    // Manage for Update and Delete 
                    for (int i = 0; i < OldOrder.Rows.Count; i++)
                    {
                        string OrderDetailNo = Convert.ToString(OldOrder.Rows[i]["ORDER_DETAIL_NO"]);
                        decimal ShipQTY = Convert.ToDecimal(OldOrder.Rows[i]["SHIP_QTY"]);
                        string ItemCd = Convert.ToString(OldOrder.Rows[i]["ITEM_CD"]);
                        bool found_order_detail = false;
                        for (int j = 0; j < NewOrder.Rows.Count; j++)
                        {
                            
                            if (Convert.ToString(NewOrder.Rows[j]["ORDER_DETAIL_NO"]) == OrderDetailNo
                                && Convert.ToString(NewOrder.Rows[j]["ITEM_CD"]) == ItemCd
                                && Convert.ToDecimal(NewOrder.Rows[j]["SHIP_QTY"]) != ShipQTY)
                            {
                                found_order_detail = true;
                                // Delete Old
                                for (int k = 0; k < OldLot.Rows.Count; k++)
                                {
                                    
                                    if (Convert.ToString(OldLot.Rows[k]["REF_SLIP_NO"]) == OrderDetailNo
                                        && Convert.ToString(OldLot.Rows[k]["ITEM_CD"]) == ItemCd)
                                    {
                                        DataRow row = dtDelete.NewRow();
                                        row["TRANS_ID"] = OldLot.Rows[k]["TRANS_ID"];
                                        row["ITEM_CD"] = OldLot.Rows[k]["ITEM_CD"];
                                        row["LOC_CD"] = OldLot.Rows[k]["LOC_CD"];
                                        row["TRANS_DATE"] = OldLot.Rows[k]["TRANS_DATE"];
                                        row["TRANS_CLS"] = OldLot.Rows[k]["TRANS_CLS"];
                                        row["IN_OUT_CLS"] = OldLot.Rows[k]["IN_OUT_CLS"];
                                        row["QTY"] = OldLot.Rows[k]["QTY"];
                                        row["REF_SLIP_NO"] = OrderDetailNo;
                                        dtDelete.Rows.Add(row);
                                    }
                                }
                                //bizShipment.AddShipmentEntry(db, null, null, DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete));

                                // Add New
                                for (int l = 0; l < NewLot.Rows.Count; l++)
                                {
                                    if (Convert.ToString(NewLot.Rows[l]["REF_SLIP_NO"]) == OrderDetailNo
                                        && Convert.ToString(NewLot.Rows[l]["ITEM_CD"]) == ItemCd)
                                    {
                                        dtAdd.ImportRow(NewLot.Rows[l]);
                                    }
                                }
                            }
                            else if (Convert.ToString(NewOrder.Rows[j]["ORDER_DETAIL_NO"]) == OrderDetailNo
                                && Convert.ToString(NewOrder.Rows[j]["ITEM_CD"]) == ItemCd
                                && Convert.ToDecimal(NewOrder.Rows[j]["SHIP_QTY"]) == ShipQTY)
                            {
                                found_order_detail = true;
                                bool diff_pack = false;

                                for (int x = 0; x < NewLot.Rows.Count; x++)
                                {
                                    bool check_same = false;
                                    string pack_no = Convert.ToString(NewLot.Rows[x]["PACK_NO"]);
                                    string lot_no = Convert.ToString(NewLot.Rows[x]["LOT_NO"]);
                                    
                                    for (int y = 0; y < OldLot.Rows.Count; y++)
                                    {
                                        if (Convert.ToString(OldLot.Rows[y]["REF_SLIP_NO"]) == OrderDetailNo
                                            && Convert.ToString(OldLot.Rows[y]["ITEM_CD"]) == ItemCd
                                            && Convert.ToString(OldLot.Rows[y]["PACK_NO"]) == pack_no
                                            && Convert.ToString(OldLot.Rows[y]["LOT_NO"]) == lot_no)
                                        {
                                            check_same = true;
                                            continue;
                                        }
                                    }

                                    if (!check_same)
                                    {
                                        diff_pack = !check_same;
                                        continue;
                                    }
                                }

                                if (diff_pack)
                                {
                                    // Delete Old
                                    for (int k = 0; k < OldLot.Rows.Count; k++)
                                    {

                                        if (Convert.ToString(OldLot.Rows[k]["REF_SLIP_NO"]) == OrderDetailNo
                                            && Convert.ToString(OldLot.Rows[k]["ITEM_CD"]) == ItemCd)
                                        {
                                            DataRow row = dtDelete.NewRow();
                                            row["TRANS_ID"] = OldLot.Rows[k]["TRANS_ID"];
                                            row["ITEM_CD"] = OldLot.Rows[k]["ITEM_CD"];
                                            row["LOC_CD"] = OldLot.Rows[k]["LOC_CD"];
                                            row["TRANS_DATE"] = OldLot.Rows[k]["TRANS_DATE"];
                                            row["TRANS_CLS"] = OldLot.Rows[k]["TRANS_CLS"];
                                            row["IN_OUT_CLS"] = OldLot.Rows[k]["IN_OUT_CLS"];
                                            row["QTY"] = OldLot.Rows[k]["QTY"];
                                            row["REF_SLIP_NO"] = OrderDetailNo;
                                            dtDelete.Rows.Add(row);
                                        }
                                    }
                                    //bizShipment.AddShipmentEntry(db, null, null, DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete));

                                    // Add New
                                    for (int l = 0; l < NewLot.Rows.Count; l++)
                                    {
                                        if (Convert.ToString(NewLot.Rows[l]["REF_SLIP_NO"]) == OrderDetailNo
                                            && Convert.ToString(NewLot.Rows[l]["ITEM_CD"]) == ItemCd)
                                        {
                                            dtAdd.ImportRow(NewLot.Rows[l]);
                                        }
                                    }
                                }
                            }

                            // In  update have remove order
                            if (j == NewOrder.Rows.Count - 1 && !found_order_detail)
                            {
                                for (int k = 0; k < OldLot.Rows.Count; k++)
                                {
                                    if (Convert.ToString(OldLot.Rows[k]["REF_SLIP_NO"]) == OrderDetailNo
                                        && Convert.ToString(OldLot.Rows[k]["ITEM_CD"]) == ItemCd)
                                    {
                                        DataRow row = dtDelete.NewRow();
                                        row["TRANS_ID"] = OldLot.Rows[k]["TRANS_ID"];
                                        row["ITEM_CD"] = OldLot.Rows[k]["ITEM_CD"];
                                        row["LOC_CD"] = OldLot.Rows[k]["LOC_CD"];
                                        row["TRANS_DATE"] = OldLot.Rows[k]["TRANS_DATE"];
                                        row["TRANS_CLS"] = OldLot.Rows[k]["TRANS_CLS"];
                                        row["IN_OUT_CLS"] = OldLot.Rows[k]["IN_OUT_CLS"];
                                        row["QTY"] = OldLot.Rows[k]["QTY"];
                                        row["REF_SLIP_NO"] = OrderDetailNo;
                                        dtDelete.Rows.Add(row);
                                    }
                                }
                            }
                        }
                    }

                    // Manage for check add new order on update mode
                    for (int i = 0; i < NewOrder.Rows.Count; i++)
                    {
                        string OrderDetailNo = Convert.ToString(NewOrder.Rows[i]["ORDER_DETAIL_NO"]);
                        string ItemCd = Convert.ToString(NewOrder.Rows[i]["ITEM_CD"]);
                        bool found_order_detail = false;
                        for (int j = 0; j < OldOrder.Rows.Count; j++)
                        {
                            
                            if (Convert.ToString(OldOrder.Rows[j]["ORDER_DETAIL_NO"]) == OrderDetailNo
                                && Convert.ToString(OldOrder.Rows[j]["ITEM_CD"]) == ItemCd)
                                found_order_detail = true;

                            // Not found old order in new order then add new order
                            if (j == OldOrder.Rows.Count - 1 && !found_order_detail)
                            {
                                for (int l = 0; l < NewLot.Rows.Count; l++)
                                {
                                    if (Convert.ToString(NewLot.Rows[l]["REF_SLIP_NO"]) == OrderDetailNo
                                        && Convert.ToString(NewLot.Rows[l]["ITEM_CD"]) == ItemCd)
                                    {
                                        dtAdd.ImportRow(NewLot.Rows[l]);
                                    }
                                }
                            }
                        }
                    }
                }

                InventoryBIZ biz = new InventoryBIZ();

                List<InventoryTransactionDTO> listAdd = null;
                List<InventoryTransactionDTO> listUpdate = null;
                List<InventoryTransactionDTO> listDelete = null;


                //== Insert process.
                if (dtAdd != null && dtAdd.Rows.Count > 0)
                {
                    listAdd = new List<InventoryTransactionDTO>();
                    listAdd = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtAdd);
                    RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();
                    NZString runningNo_SLIP_NO = null;
                    NZString runningNo_GROUP_TRANS_ID = null;

                    if (model.SLIP_NO.IsNull || model.SLIP_NO.Value == "")
                    {
                        runningNo_SLIP_NO = runningNumberBIZ.GetCompleteRunningNo((NZString)"DELIVERY_SLIP_NO", (NZString)"TB_INV_TRANS_TR");
                    }
                    else
                    {
                        runningNo_SLIP_NO = model.SLIP_NO;
                    }

                    SlipNo = runningNo_SLIP_NO;

                    if (model.GROUP_TRANS_ID.IsNull)
                    {
                        runningNo_GROUP_TRANS_ID = runningNumberBIZ.GetCompleteRunningNo(new NZString(null, "TRAN_GROUP_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                    }
                    else
                    {
                        runningNo_GROUP_TRANS_ID = model.SLIP_NO;
                    }

                    for (int i = 0; i < listAdd.Count; i++)
                    {
                        InventoryTransactionDTO dto = listAdd[i];

                        // มีการ Gen Running Number ของ NO_LOT_TRANS_ID ไว้แล้วใน InventoryBIZ FN: AddInventoryTransaction
                        //NZString runningNo_LOT_TRANS_ID = runningNumberBIZ.GetCompleteRunningNo(new NZString(null, "TRAN_ID"), new NZString(null, "TB_INV_TRANS_TR"));
                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto);

                        dto.SLIP_NO = runningNo_SLIP_NO;
                        dto.GROUP_TRANS_ID = runningNo_GROUP_TRANS_ID;
                        //dto.TRANS_ID = runningNo_LOT_TRANS_ID;

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        listAdd[i] = dto;
                        // check for lot no if ship type is SHIP
                        //if (model.TRANS_CLS.StrongValue != DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment_Return))
                        //    ValidateException.ThrowErrorItem(commonVal.CheckInputLot(dto.ITEM_CD, dto.LOC_CD, dto.LOT_NO, true));
                    }
                }

                //== Update process.
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtModify);

                    for (int i = 0; i < listUpdate.Count; i++)
                    {
                        InventoryTransactionDTO dto = listUpdate[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        listUpdate[i] = dto;
                    }
                }


                //== Delete process.
                if (dtDelete != null && dtDelete.Rows.Count > 0)
                {
                    listDelete = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete);
                }

                bizShipment.AddShipmentEntry(db, listAdd, listUpdate, listDelete);

                if (Mode == Common.eScreenMode.EDIT)
                {
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtData);

                        for (int i = 0; i < listUpdate.Count; i++)
                        {
                            InventoryTransactionDTO dto = listUpdate[i];

                            // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                            AssignHeaderToDTO(model, dto);

                            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                            DeliveryBIZ bizDelivery = new DeliveryBIZ();
                            bizDelivery.UpdateReceiveHeader(db,listUpdate[i]);
                        }

                        SlipNo = listUpdate[0].SLIP_NO;
                    }

                    //if (dtDelete != null && dtDelete.Rows.Count > 0)
                    //{
                    //    ShipmentEntryController ctlShip = new ShipmentEntryController();

                    //    for (int i = 0; i < dtDelete.Rows.Count; i++)
                    //    {
                    //        NZString strOrderDetailNo = dtDelete.Rows[i]["REF_SLIP_NO"].ToString().ToNZString();
                    //        decimal dQTY = Convert.ToDecimal(dtDelete.Rows[i]["QTY"]);
                    //        if (dQTY == null || dQTY <= 0) continue;
                    //        ctlShip.UpdateShipQTY(strOrderDetailNo, dQTY * -1);
                    //    }
                    //}

                    //if (dtAdd != null && dtAdd.Rows.Count > 0)
                    //{
                    //    ShipmentEntryController ctlShip = new ShipmentEntryController();

                    //    for (int i = 0; i < dtAdd.Rows.Count; i++)
                    //    {
                    //        NZString strOrderDetailNo = dtAdd.Rows[i]["REF_SLIP_NO"].ToString().ToNZString();
                    //        decimal dQTY = Convert.ToDecimal(dtAdd.Rows[i]["QTY"]);
                    //        if (dQTY == null || dQTY <= 0) continue;
                    //        ctlShip.UpdateShipQTY(strOrderDetailNo, dQTY);
                    //    }
                    //}

                }

                //if (Mode == Common.eScreenMode.EDIT)
                //{
                //    if (dtAdd != null && dtAdd.Rows.Count > 0)
                //    {
                //        listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtAdd);

                //        for (int i = 0; i < listUpdate.Count; i++)
                //        {
                //            InventoryTransactionDTO dto = listUpdate[i];

                //            // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                //            AssignHeaderToDTO(model, dto);

                //            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                //            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                //            //biz.UpdateReceiveHeader(db, dto);

                //            biz.UpdateInventoryOnhand(db, dto, DataDefine.eOperationClass.Add);
                //        }
                //    }
                //}
                db.Commit();

                return SlipNo;
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                {
                    db.Close();
                }
            }
        }

        internal void UpdateShipQTY(NZString OrderDetailNo, decimal QTY)
        {
            Database db = Common.CurrentDatabase.CreateNewDatabase();
            try
            {
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);

                ShipmentBIZ bizShipment = new ShipmentBIZ();
                bizShipment.UpdateShipmentDetail(db, OrderDetailNo, QTY);
                db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                {
                    db.Close();
                }
            }
        }

        private List<InventoryTransactionDTO> ConvertDataTableToList(DataTable dt)
        {
            List<InventoryTransactionDTO> list = new List<InventoryTransactionDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                DataRowVersion drVersion = DataRowVersion.Current;
                if (dr.RowState == DataRowState.Deleted)
                    drVersion = DataRowVersion.Original;
                InventoryTransactionDTO dto = new InventoryTransactionDTO();
                dto.ITEM_CD.Value = dr[(int)eColView.PART_NO, drVersion];// PART_NO,
                dto.TRANS_ID.Value = dr[(int)eColView.TRANS_ID, drVersion];//PART_NAME,
                dto.LOT_NO.Value = dr[(int)eColView.LOT_NO, drVersion];//LOT_NO,
                dto.QTY.Value = dr[(int)eColView.ISSUE_QTY, drVersion];//ISSUE_QTY,
                dto.OTHER_DL_NO.Value = dr[(int)eColView.OTHER_DL_NO, drVersion];//OTHER_DL_NO,


                list.Add(dto);
            }
            return list;
        }

        internal DataTable LoadShipList(NZString SlipNo)
        {
            ShipmentBIZ bizShipment = new ShipmentBIZ();
            return bizShipment.LoadShipList(SlipNo);
        }

        /// <summary>
        /// คัดลอกค่าที่เป็น Header ของ Model ไปเก็บไว้ใน DTO
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dto"></param>
        private void AssignHeaderToDTO(ShipmentEntryUIDM model, InventoryTransactionDTO dto)
        {
            //dto.TRANS_DATE = model.TRANS_DATE;
            dto.SLIP_NO = model.SLIP_NO;
            dto.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment.ToNZString();
            dto.IN_OUT_CLS = DataDefine.eIN_OUT_CLASS.Out.ToString().ToNZString();
            dto.EFFECT_STOCK.Value = (int)DataDefine.eEFFECT_STOCK.Out;
            dto.REMARK = model.REMARK;
            dto.LOC_CD = model.LOC_CD;
            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Shipment);
            dto.SCREEN_TYPE = DataDefine.ScreenType.ShipmentEntry.ToNZString();
            dto.DEALING_NO = model.DEALING_NO;
            dto.OLD_DATA.Value = 0;
            dto.CURRENCY = model.CURRENCY;
            dto.TRANS_DATE = model.TRANS_DATE;
            dto.REF_SLIP_NO2 = model.REF_SLIP_NO2;


            if (dto.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment))
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            else
            {
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            }
        }
    }
}
