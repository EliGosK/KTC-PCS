using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;
using CommonLib;
using System.Data.SqlClient;
using Rubik.UIDataModel;
using EVOFramework.Data;
using SystemMaintenance;
using Rubik.Validators;
using SystemMaintenance.BIZ;
using EVOFramework.Database;

namespace Rubik.Controller
{
    public class ReturnController
    {

        public DataTable Load_ReturnListEntry(NZString SlipNo, bool IncludeOldData)
        {
            ReturnBIZ biz = new ReturnBIZ();
            return biz.Load_ReturnListEntry(SlipNo,IncludeOldData);
        }

        public DataTable Load_ReturnProductionList(NZDateTime DateBegin, NZDateTime DateEnd, bool OldData)
        {
            ReturnBIZ biz = new ReturnBIZ();
            return biz.Load_ReturnProductionList(DateBegin, DateEnd, OldData);
        }

        private void AssignHeaderToDTO(ReturnEntryUIDM model, InventoryTransactionDTO dto,Common.eScreenMode Mode)
        {
            //dto.TRANS_DATE = model.TRANS_DATE;
            //dto.SLIP_NO = model.SLIP_NO;
            dto.TRANS_CLS = DataDefine.eTRANS_TYPE_string.Shipment_Return.ToNZString();
            dto.IN_OUT_CLS = DataDefine.eIN_OUT_CLASS.In.ToString().ToNZString();
            dto.EFFECT_STOCK.Value = (int)DataDefine.eEFFECT_STOCK.In;
            dto.REMARK = model.REMARK;
            dto.LOC_CD = model.LOC_CD;
            dto.REF_SLIP_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eREF_SLIP_CLS.Shipment);
            dto.SCREEN_TYPE = DataDefine.ScreenType.ReturnEntry.ToNZString();
            dto.DEALING_NO = model.DEALING_NO;
            if (Mode == Common.eScreenMode.ADD) dto.OLD_DATA.Value = 0;
            //dto.CURRENCY = model.CURRENCY;
            dto.TRANS_DATE = model.TRANS_DATE;


            if (dto.TRANS_CLS.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Shipment))
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out);
            else
            {
                dto.IN_OUT_CLS.Value = DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.In);
            }
        }

        public void Save(ReturnEntryUIDM model, Common.eScreenMode Mode)
        {
            NZString m_EditSlipNo;
            DataTable m_OldReturn = new DataTable();
            DataTable m_NewReturn = new DataTable();

            ReturnBIZ bizReturn = new ReturnBIZ();

            Database db = Common.CurrentDatabase.CreateNewDatabase();

            try
            {
                db.KeepConnection = true;
                db.BeginTransaction(IsolationLevel.Serializable);
                ShipmentBIZ bizShipment = new ShipmentBIZ();
                //bizShipment.AddShipmentEntry(dtoInvTrnsList);
                if (Mode != Common.eScreenMode.ADD)
                {
                    m_EditSlipNo = model.SLIP_NO;
                    m_OldReturn = bizReturn.Load_ReturnListEntry(m_EditSlipNo, false);
                }

                IssueEntryValidator val = new IssueEntryValidator();
                CommonBizValidator commonVal = new CommonBizValidator();


                //== If data not has to processing.
                if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

                DataTable dtData = model.DATA_VIEW;
                DataTable dtUnChange = new DataTable();
                DataTable dtAdd = new DataTable();
                DataTable dtModify = new DataTable();
                DataTable dtDelete = new DataTable();

                //if (Mode == Common.eScreenMode.ADD || m_OldReturn.Rows.Count <= 0)
                //{
                    dtUnChange = dtData.GetChanges(DataRowState.Unchanged);
                    dtAdd = dtData.GetChanges(DataRowState.Added);
                    dtModify = dtData.GetChanges(DataRowState.Modified);
                    dtDelete = dtData.GetChanges(DataRowState.Deleted);
                /*}
                else
                {
                    dtAdd = dtData.Clone();
                    dtModify = dtData.Clone();
                    dtDelete = dtData.Clone();

                    m_NewReturn = model.DATA_VIEW.Copy();
                    m_NewReturn.AcceptChanges();

                    // Manage for Update and Delete 
                    for (int i = 0; i < m_OldReturn.Rows.Count; i++)
                    {
                        string OrderDetailNo = Convert.ToString(m_OldReturn.Rows[i]["REF_SLIP_NO"]);
                        string ItemCd = Convert.ToString(m_OldReturn.Rows[i]["ITEM_CD"]);

                        //decimal ShipQTY = Convert.ToDecimal(m_OldReturn.Rows[i]["SHIP_QTY"]);
                        //decimal RemainableQTY = Convert.ToDecimal(m_OldReturn.Rows[i]["RETURNABLE_QTY"]);
                        decimal ReturnQTY = Convert.ToDecimal(m_OldReturn.Rows[i]["RETURN_QTY"]);

                        bool found_order_detail = false;
                        for (int j = 0; j < m_NewReturn.Rows.Count; j++)
                        {

                            if (Convert.ToString(m_NewReturn.Rows[j]["REF_SLIP_NO"]) == OrderDetailNo
                                && Convert.ToString(m_NewReturn.Rows[j]["ITEM_CD"]) == ItemCd
                                && Convert.ToDecimal(m_NewReturn.Rows[j]["RETURN_QTY"]) != ReturnQTY)
                            {
                                found_order_detail = true;

                                // Delete Old
                                DataRow row = dtDelete.NewRow();
                                row["TRANS_ID"] = m_OldReturn.Rows[i]["TRANS_ID"];
                                row["ITEM_CD"] = m_OldReturn.Rows[i]["ITEM_CD"];
                                row["LOC_CD"] = m_OldReturn.Rows[i]["LOC_CD"];
                                row["TRANS_DATE"] = m_OldReturn.Rows[i]["TRANS_DATE"];
                                row["TRANS_CLS"] = m_OldReturn.Rows[i]["TRANS_CLS"];
                                row["IN_OUT_CLS"] = m_OldReturn.Rows[i]["IN_OUT_CLS"];
                                row["RETURN_QTY"] = m_OldReturn.Rows[i]["RETURN_QTY"];
                                row["REF_SLIP_NO"] = OrderDetailNo;
                                dtDelete.Rows.Add(row);


                                if (Convert.ToString(m_NewReturn.Rows[j]["REF_SLIP_NO"]) == OrderDetailNo
                                    && Convert.ToString(m_NewReturn.Rows[j]["ITEM_CD"]) == ItemCd)
                                {
                                    dtAdd.ImportRow(m_NewReturn.Rows[j]);
                                }

                            }
                            else if (Convert.ToString(m_NewReturn.Rows[j]["REF_SLIP_NO"]) == OrderDetailNo
                                && Convert.ToString(m_NewReturn.Rows[j]["ITEM_CD"]) == ItemCd
                                && Convert.ToDecimal(m_NewReturn.Rows[j]["RETURN_QTY"]) == ReturnQTY)
                            {
                                found_order_detail = true;
                            }

                            // In  update have remove order
                            if (j == m_NewReturn.Rows.Count - 1 && !found_order_detail)
                            {
                                // Delete Old
                                DataRow row = dtDelete.NewRow();
                                row["TRANS_ID"] = m_OldReturn.Rows[i]["TRANS_ID"];
                                row["ITEM_CD"] = m_OldReturn.Rows[i]["ITEM_CD"];
                                row["LOC_CD"] = m_OldReturn.Rows[i]["LOC_CD"];
                                row["TRANS_DATE"] = m_OldReturn.Rows[i]["TRANS_DATE"];
                                row["TRANS_CLS"] = m_OldReturn.Rows[i]["TRANS_CLS"];
                                row["IN_OUT_CLS"] = m_OldReturn.Rows[i]["IN_OUT_CLS"];
                                row["RETURN_QTY"] = m_OldReturn.Rows[i]["RETURN_QTY"];
                                row["REF_SLIP_NO"] = OrderDetailNo;
                                dtDelete.Rows.Add(row);
                            }
                        }
                    }

                    // Manage for check add new order on update mode
                    for (int i = 0; i < m_NewReturn.Rows.Count; i++)
                    {
                        string OrderDetailNo = Convert.ToString(m_NewReturn.Rows[i]["REF_SLIP_NO"]);
                        string ItemCd = Convert.ToString(m_NewReturn.Rows[i]["ITEM_CD"]);

                        //decimal ShipQTY = Convert.ToDecimal(m_NewReturn.Rows[i]["SHIP_QTY"]);
                        //decimal RemainableQTY = Convert.ToDecimal(m_NewReturn.Rows[i]["RETURNABLE_QTY"]);
                        decimal ReturnQTY = Convert.ToDecimal(m_NewReturn.Rows[i]["RETURN_QTY"]);
                        bool found_order_detail = false;
                        for (int j = 0; j < m_OldReturn.Rows.Count; j++)
                        {

                            if (Convert.ToString(m_OldReturn.Rows[j]["REF_SLIP_NO"]) == OrderDetailNo
                                && Convert.ToString(m_OldReturn.Rows[j]["ITEM_CD"]) == ItemCd
                                && Convert.ToDecimal(m_OldReturn.Rows[j]["RETURN_QTY"]) != ReturnQTY)
                            {
                                found_order_detail = true;
                            }


                            // Not found old order in new order then add new order
                            if (j == m_OldReturn.Rows.Count - 1 && !found_order_detail)
                            {
                                if (Convert.ToString(m_NewReturn.Rows[i]["REF_SLIP_NO"]) == OrderDetailNo
                                        && Convert.ToString(m_NewReturn.Rows[i]["ITEM_CD"]) == ItemCd)
                                {
                                    dtAdd.ImportRow(m_NewReturn.Rows[i]);
                                }
                            }
                        }
                    }
                }*/

                InventoryBIZ biz = new InventoryBIZ();

                List<InventoryTransactionDTO> listAdd = null;
                List<InventoryTransactionDTO> listUpdate = null;
                List<InventoryTransactionDTO> listDelete = null;
                List<InventoryTransactionDTO> listUnChange = null;

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
                        runningNo_SLIP_NO = runningNumberBIZ.GetCompleteRunningNo((NZString)"RETURN_NO", (NZString)"TB_INV_TRANS_TR");
                    }
                    else
                    {
                        runningNo_SLIP_NO = model.SLIP_NO;
                    }

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
                        AssignHeaderToDTO(model, dto,Mode);

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
                        AssignHeaderToDTO(model, dto,Mode);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        listUpdate[i] = dto;
                    }
                }

                //== Update for Unchage กรณีที่ header เปลี่ยนแต่ส่วนของ Spread ไม่มีการเปลี่ยนแปลงต้องใช้ UnChanged ช่วย Update
                if (dtUnChange != null && dtUnChange.Rows.Count > 0)
                {
                    listUnChange = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtUnChange);
                    if (listUpdate == null) listUpdate = new List<InventoryTransactionDTO>();
                    for (int i = 0; i < listUnChange.Count; i++)
                    {
                        InventoryTransactionDTO dto = listUnChange[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto, Mode);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                        //dto.QTY.Value = 0;

                        listUpdate.Add(dto);
                    }
                }


                //== Delete process.
                if (dtDelete != null && dtDelete.Rows.Count > 0)
                {
                    listDelete = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtDelete);
                }

                bizReturn.SaveShipmentEntry(db, listAdd, listUpdate, listDelete);

                //if (Mode == Common.eScreenMode.EDIT)
                //{
                //    if (dtData != null && dtData.Rows.Count > 0)
                //    {
                //        listUpdate = DTOUtility.ConvertDataTableToList<InventoryTransactionDTO>(dtData);

                //        for (int i = 0; i < listUpdate.Count; i++)
                //        {
                //            InventoryTransactionDTO dto = listUpdate[i];

                //            // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                //            AssignHeaderToDTO(model, dto,Mode);

                //            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                //            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                //            DeliveryBIZ bizDelivery = new DeliveryBIZ();
                //            bizDelivery.UpdateReceiveHeader(db, listUpdate[i]);
                //        }
                //    }

                //    //if (dtDelete != null && dtDelete.Rows.Count > 0)
                //    //{
                //    //    ShipmentEntryController ctlShip = new ShipmentEntryController();

                //    //    for (int i = 0; i < dtDelete.Rows.Count; i++)
                //    //    {
                //    //        NZString strOrderDetailNo = dtDelete.Rows[i]["REF_SLIP_NO"].ToString().ToNZString();
                //    //        decimal dQTY = Convert.ToDecimal(dtDelete.Rows[i]["QTY"]);
                //    //        if (dQTY == null || dQTY <= 0) continue;
                //    //        ctlShip.UpdateShipQTY(strOrderDetailNo, dQTY * -1);
                //    //    }
                //    //}

                //    //if (dtAdd != null && dtAdd.Rows.Count > 0)
                //    //{
                //    //    ShipmentEntryController ctlShip = new ShipmentEntryController();

                //    //    for (int i = 0; i < dtAdd.Rows.Count; i++)
                //    //    {
                //    //        NZString strOrderDetailNo = dtAdd.Rows[i]["REF_SLIP_NO"].ToString().ToNZString();
                //    //        decimal dQTY = Convert.ToDecimal(dtAdd.Rows[i]["QTY"]);
                //    //        if (dQTY == null || dQTY <= 0) continue;
                //    //        ctlShip.UpdateShipQTY(strOrderDetailNo, dQTY);
                //    //    }
                //    //}

                //}

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

    }
}
