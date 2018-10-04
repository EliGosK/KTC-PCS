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

namespace Rubik.Controller
{
    public class CustomerOrderController
    {
        public CustomerOrderEntryUIDM CreateUIDMForAddMode()
        {
            CustomerOrderEntryUIDM model = new CustomerOrderEntryUIDM();
            model.CUSTOMER_CD.Value = string.Empty;
            model.ORDER_TYPE.Value = string.Empty;
            model.CURRENCY.Value = string.Empty;
            model.PO_DATE.Value = DateTime.MinValue;
            model.EXCHANGE_RATE.Value = decimal.Parse(DataDefine.DEFAULT_EXCHANGE_RATE);
            model.REMARK.Value = string.Empty;
            model.QTY.Value = 0;
            model.AMOUNT.Value = 0;
            model.AMOUNT_THB.Value = 0;
            model.DATA_VIEW.AcceptChanges();
            return model;
        }

        private CustomerOrderEntryUIDM MapDTOToUIDM(CustomerOrderViewDTO dto)
        {
            CustomerOrderEntryUIDM model = new CustomerOrderEntryUIDM();
            model.ORDER_NO = dto.ORDER_NO;
            model.RECEIVE_DATE = dto.RECEIVE_DATE;
            model.CUSTOMER_CD = dto.CUSTOMER_CD;
            model.LOC_CD = dto.LOC_CD;
            model.LOC_DESC = dto.LOC_DESC;
            model.ORDER_TYPE = dto.ORDER_TYPE;
            model.PO_NO = dto.PO_NO;
            model.PO_DATE = dto.PO_DATE;
            model.CURRENCY = dto.CURRENCY;
            model.EXCHANGE_RATE = dto.EXCHANGE_RATE;
            model.REMARK = dto.REMARK;
            model.ITEM_CD = dto.ITEM_CD;
            model.SHORT_NAME = dto.SHORT_NAME;
            model.ITEM_DELIVERY_DATE = dto.ITEM_DELIVERY_DATE;
            model.QTY = dto.QTY;
            model.PRICE = dto.PRICE;
            model.AMOUNT = dto.AMOUNT;
            model.AMOUNT_THB = dto.AMOUNT_THB;
            model.TOTAL_QTY = dto.TOTAL_QTY;
            model.TOTAL_AMOUNT = dto.TOTAL_AMOUNT;
            model.TOTAL_AMOUNT_THB = dto.TOTAL_AMOUNT_THB;
            return model;
        }

        private void AssignHeaderToDTO(CustomerOrderEntryUIDM model, CustomerOrderViewDTO dto,Common.eScreenMode Mode)
        {
            dto.ORDER_NO = model.ORDER_NO;
            dto.RECEIVE_DATE = model.RECEIVE_DATE;
            dto.CUSTOMER_CD = model.CUSTOMER_CD;
            dto.LOC_CD = model.LOC_CD;
            dto.LOC_DESC = model.LOC_DESC;
            dto.ORDER_TYPE = model.ORDER_TYPE;
            dto.PO_NO = model.PO_NO;
            dto.PO_DATE = model.PO_DATE;
            dto.CURRENCY = model.CURRENCY;
            dto.EXCHANGE_RATE = model.EXCHANGE_RATE;
            dto.REMARK = model.REMARK;
            //dto.ITEM_CD = model.ITEM_CD;
            dto.SHORT_NAME = model.SHORT_NAME;
            //dto.ITEM_DELIVERY_DATE = model.ITEM_DELIVERY_DATE;
            //dto.QTY = model.QTY;
            //dto.PRICE = model.PRICE;
            //dto.AMOUNT = model.AMOUNT;
            //dto.AMOUNT_THB = model.AMOUNT_THB;
            dto.TOTAL_QTY = model.TOTAL_QTY;
            dto.TOTAL_AMOUNT = model.TOTAL_AMOUNT;
            dto.TOTAL_AMOUNT_THB = model.TOTAL_AMOUNT_THB;
            if (Mode == Common.eScreenMode.ADD) dto.OLD_DATA.Value = 0;
        }

        //public List<CustomerOrderViewDTO> LoadCustomerOrderList(NZDateTime beginPeriod, NZDateTime endPeriod)
        //{
        //    CustomerOrderBIZ biz = new CustomerOrderBIZ();
        //    return biz.LoadCustomerOrderList(beginPeriod, endPeriod,false);
        //}

        public CustomerOrderHDTO CustomerOrderViewDTO2CustomerOrderHDTO(CustomerOrderViewDTO dtoCustomerOrderView)
        {
            CustomerOrderHDTO dtoCustomerOrderH = new CustomerOrderHDTO();
            dtoCustomerOrderH.CRT_BY = dtoCustomerOrderView.CRT_BY;
            dtoCustomerOrderH.CRT_DATE = dtoCustomerOrderView.CRT_DATE;
            dtoCustomerOrderH.CRT_MACHINE = dtoCustomerOrderView.CRT_MACHINE;
            dtoCustomerOrderH.UPD_BY = dtoCustomerOrderView.UPD_BY;
            dtoCustomerOrderH.UPD_DATE = dtoCustomerOrderView.UPD_DATE;
            dtoCustomerOrderH.UPD_MACHINE = dtoCustomerOrderView.UPD_MACHINE;
            dtoCustomerOrderH.ORDER_NO = dtoCustomerOrderView.ORDER_NO;
            dtoCustomerOrderH.RECEIVE_DATE = dtoCustomerOrderView.RECEIVE_DATE;
            dtoCustomerOrderH.CUSTOMER_CD = dtoCustomerOrderView.CUSTOMER_CD;
            dtoCustomerOrderH.ORDER_TYPE = dtoCustomerOrderView.ORDER_TYPE;
            dtoCustomerOrderH.CURRENCY = dtoCustomerOrderView.CURRENCY;
            dtoCustomerOrderH.PO_NO = dtoCustomerOrderView.PO_NO;
            dtoCustomerOrderH.PO_DATE = dtoCustomerOrderView.PO_DATE;
            dtoCustomerOrderH.EXCHANGE_RATE = dtoCustomerOrderView.EXCHANGE_RATE;
            dtoCustomerOrderH.REMARK = dtoCustomerOrderView.REMARK;
            dtoCustomerOrderH.TOTAL_QTY = dtoCustomerOrderView.TOTAL_QTY;
            dtoCustomerOrderH.TOTAL_AMOUNT = dtoCustomerOrderView.TOTAL_AMOUNT;
            dtoCustomerOrderH.TOTAL_AMOUNT_THB = dtoCustomerOrderView.TOTAL_AMOUNT_THB;
            dtoCustomerOrderH.OLD_DATA = dtoCustomerOrderView.OLD_DATA;

            return dtoCustomerOrderH;
        }

        public CustomerOrderViewDTO CustomerOrderHDTO2CustomerOrderViewDTO(CustomerOrderHDTO dtoCustomerOrderHDTO)
        {
            CustomerOrderViewDTO dtoCustomerOrderView = new CustomerOrderViewDTO();
            dtoCustomerOrderView.CRT_BY = dtoCustomerOrderHDTO.CRT_BY;
            dtoCustomerOrderView.CRT_DATE = dtoCustomerOrderHDTO.CRT_DATE;
            dtoCustomerOrderView.CRT_MACHINE = dtoCustomerOrderHDTO.CRT_MACHINE;
            dtoCustomerOrderView.UPD_BY = dtoCustomerOrderHDTO.UPD_BY;
            dtoCustomerOrderView.UPD_DATE = dtoCustomerOrderHDTO.UPD_DATE;
            dtoCustomerOrderView.UPD_MACHINE = dtoCustomerOrderHDTO.UPD_MACHINE;
            dtoCustomerOrderView.ORDER_NO = dtoCustomerOrderHDTO.ORDER_NO;
            dtoCustomerOrderView.RECEIVE_DATE = dtoCustomerOrderHDTO.RECEIVE_DATE;
            dtoCustomerOrderView.CUSTOMER_CD = dtoCustomerOrderHDTO.CUSTOMER_CD;
            dtoCustomerOrderView.ORDER_TYPE = dtoCustomerOrderHDTO.ORDER_TYPE;
            dtoCustomerOrderView.CURRENCY = dtoCustomerOrderHDTO.CURRENCY;
            dtoCustomerOrderView.PO_NO = dtoCustomerOrderHDTO.PO_NO;
            dtoCustomerOrderView.PO_DATE = dtoCustomerOrderHDTO.PO_DATE;
            dtoCustomerOrderView.EXCHANGE_RATE = dtoCustomerOrderHDTO.EXCHANGE_RATE;
            dtoCustomerOrderView.REMARK = dtoCustomerOrderHDTO.REMARK;
            dtoCustomerOrderView.TOTAL_QTY = dtoCustomerOrderHDTO.TOTAL_QTY;
            dtoCustomerOrderView.TOTAL_AMOUNT = dtoCustomerOrderHDTO.TOTAL_AMOUNT;
            dtoCustomerOrderView.TOTAL_AMOUNT_THB = dtoCustomerOrderHDTO.TOTAL_AMOUNT_THB;
            dtoCustomerOrderView.OLD_DATA = dtoCustomerOrderHDTO.OLD_DATA;

            return dtoCustomerOrderView;
        }

        public CustomerOrderDDTO CustomerOrderViewDTO2CustomerOrderDDTO(CustomerOrderViewDTO dtoCustomerOrderView)
        {
            CustomerOrderDDTO dtoCustomerOrderD = new CustomerOrderDDTO();
            dtoCustomerOrderD.CRT_BY = dtoCustomerOrderView.CRT_BY;
            dtoCustomerOrderD.CRT_DATE = dtoCustomerOrderView.CRT_DATE;
            dtoCustomerOrderD.CRT_MACHINE = dtoCustomerOrderView.CRT_MACHINE;
            dtoCustomerOrderD.UPD_BY = dtoCustomerOrderView.UPD_BY;
            dtoCustomerOrderD.UPD_DATE = dtoCustomerOrderView.UPD_DATE;
            dtoCustomerOrderD.UPD_MACHINE = dtoCustomerOrderView.UPD_MACHINE;
            dtoCustomerOrderD.ORDER_NO = dtoCustomerOrderView.ORDER_NO;
            dtoCustomerOrderD.RUN_NO = dtoCustomerOrderView.RUN_NO;
            dtoCustomerOrderD.ITEM_CD = dtoCustomerOrderView.ITEM_CD;
            dtoCustomerOrderD.ITEM_DELIVERY_DATE = dtoCustomerOrderView.ITEM_DELIVERY_DATE;
            dtoCustomerOrderD.QTY = dtoCustomerOrderView.QTY;
            dtoCustomerOrderD.PRICE = dtoCustomerOrderView.PRICE;
            dtoCustomerOrderD.AMOUNT = dtoCustomerOrderView.AMOUNT;
            dtoCustomerOrderD.AMOUNT_THB = dtoCustomerOrderView.AMOUNT_THB;
            dtoCustomerOrderD.SHIP_QTY = dtoCustomerOrderView.SHIP_QTY;
            dtoCustomerOrderD.COMPLETE_FLAG = dtoCustomerOrderView.COMPLETE_FLAG;
            dtoCustomerOrderD.OLD_DATA = dtoCustomerOrderView.OLD_DATA;
            return dtoCustomerOrderD;
        }

        public CustomerOrderViewDTO CustomerOrderDDTO2CustomerOrderViewDTO(CustomerOrderDDTO dtoCustomerOrderDDTO)
        {
            CustomerOrderViewDTO dtoCustomerOrderView = new CustomerOrderViewDTO();
            dtoCustomerOrderView.CRT_BY = dtoCustomerOrderDDTO.CRT_BY;
            dtoCustomerOrderView.CRT_DATE = dtoCustomerOrderDDTO.CRT_DATE;
            dtoCustomerOrderView.CRT_MACHINE = dtoCustomerOrderDDTO.CRT_MACHINE;
            dtoCustomerOrderView.UPD_BY = dtoCustomerOrderDDTO.UPD_BY;
            dtoCustomerOrderView.UPD_DATE = dtoCustomerOrderDDTO.UPD_DATE;
            dtoCustomerOrderView.UPD_MACHINE = dtoCustomerOrderDDTO.UPD_MACHINE;
            dtoCustomerOrderView.ORDER_NO = dtoCustomerOrderDDTO.ORDER_NO;
            dtoCustomerOrderView.RUN_NO = dtoCustomerOrderDDTO.RUN_NO;
            dtoCustomerOrderView.ITEM_CD = dtoCustomerOrderDDTO.ITEM_CD;
            dtoCustomerOrderView.ITEM_DELIVERY_DATE = dtoCustomerOrderDDTO.ITEM_DELIVERY_DATE;
            dtoCustomerOrderView.QTY = dtoCustomerOrderDDTO.QTY;
            dtoCustomerOrderView.PRICE = dtoCustomerOrderDDTO.PRICE;
            dtoCustomerOrderView.AMOUNT = dtoCustomerOrderDDTO.AMOUNT;
            dtoCustomerOrderView.AMOUNT_THB = dtoCustomerOrderDDTO.AMOUNT_THB;
            dtoCustomerOrderView.SHIP_QTY = dtoCustomerOrderDDTO.SHIP_QTY;
            dtoCustomerOrderView.COMPLETE_FLAG = dtoCustomerOrderDDTO.COMPLETE_FLAG;
            dtoCustomerOrderView.OLD_DATA = dtoCustomerOrderDDTO.OLD_DATA;
            return dtoCustomerOrderView;
        }

        public CustomerOrderEntryUIDM LoadData(NZString orderNo)
        {

            CustomerOrderBIZ biz = new CustomerOrderBIZ();
            CustomerOrderViewDTO ViewDTO = biz.LoadCustomerOrderHeader(orderNo, false);
            List<CustomerOrderViewDTO> listViewDTO = biz.LoadCustomerOrderEntry(orderNo, false);
            if (ViewDTO != null)
            {
                CustomerOrderEntryUIDM model = MapDTOToUIDM(ViewDTO);
                model.DATA_VIEW = DTOUtility.ConvertListToDataTable(listViewDTO);

                //== Ensure that data has not modified.
                model.DATA_VIEW.AcceptChanges();

                return model;
            }
            return new CustomerOrderEntryUIDM();
        }

        //public CustomerOrderEntryUIDM LoadData(NZString orderNo)
        //{

        //    CustomerOrderBIZ biz = new CustomerOrderBIZ();
        //    List<CustomerOrderViewDTO> listViewDTO = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(biz.LoadCustomerOrderEntry(orderNo, false));
        //    if (listViewDTO != null)
        //    {
        //        if (listViewDTO.Count > 0)
        //        {
        //            CustomerOrderEntryUIDM model = MapDTOToUIDM(listViewDTO[0]);
        //            model.DATA_VIEW = DTOUtility.ConvertListToDataTable(listViewDTO);

        //            //== Ensure that data has not modified.
        //            model.DATA_VIEW.AcceptChanges();

        //            return model;
        //        }
        //    }
        //    return new CustomerOrderEntryUIDM();
        //}

        #region SaveData
        public void Save(CustomerOrderEntryUIDM model, Common.eScreenMode Mode)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

                CustomerOrderBIZ biz = new CustomerOrderBIZ();

                #region Validate Data
                //== If data not has to processing.
                if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

                DataTable dtNonDelete = model.DATA_VIEW.GetChanges(DataRowState.Unchanged | DataRowState.Added | DataRowState.Modified);
                List<CustomerOrderViewDTO> listData = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dtNonDelete);

                #endregion


                DataTable dtData = model.DATA_VIEW.Copy();
                DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
                DataTable dtModify = dtData.GetChanges(DataRowState.Modified);
                DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

                //ORDER_DETAIL_NO,
                //ITEM_CD,
                //ITEM_CD_BTN,
                //PART_NO,
                //ITEM_DELIVERY_DATE,
                //OLD_ITEM_DELIVERY_DATE,
                //QTY,
                //OLD_QTY,
                //PRICE,
                //AMOUNT,
                //PRICE_THB,
                //AMOUNT_THB

                // แก้บั๊ก GetChange แล้ว Data ไม่ถูกต้อง
                dtData.AcceptChanges();
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    for (int i = 0; i < dtModify.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtData.Rows.Count; j++)
                        {
                            if (Convert.ToString(dtModify.Rows[i]["ORDER_DETAIL_NO"]) == Convert.ToString(dtData.Rows[j]["ORDER_DETAIL_NO"]))
                            {
                                dtModify.Rows[i]["ITEM_CD"] = dtData.Rows[j]["ITEM_CD"];
                                dtModify.Rows[i]["PART_NO"] = dtData.Rows[j]["PART_NO"];
                                dtModify.Rows[i]["ITEM_DELIVERY_DATE"] = dtData.Rows[j]["ITEM_DELIVERY_DATE"];
                                dtModify.Rows[i]["QTY"] = dtData.Rows[j]["QTY"];
                                dtModify.Rows[i]["PRICE"] = dtData.Rows[j]["PRICE"];
                                dtModify.Rows[i]["AMOUNT"] = dtData.Rows[j]["AMOUNT"];
                                dtModify.Rows[i]["PRICE_THB"] = dtData.Rows[j]["PRICE_THB"];
                                dtModify.Rows[i]["AMOUNT_THB"] = dtData.Rows[j]["AMOUNT_THB"];
                            }
                        }
                    }
                }
                List<CustomerOrderViewDTO> listAdd = new List<CustomerOrderViewDTO>();
                List<CustomerOrderViewDTO> listUpdate = new List<CustomerOrderViewDTO>();
                List<CustomerOrderViewDTO> listDelete = new List<CustomerOrderViewDTO>();


                //มีการปรับให้ทำคำสั่งทีละ set ของ add , update , delete เลย
                //ที่เริ่มจาก delete ก่อนเพราะ consumption จะได้มีการเอาไปใช้สำหรับตัวที่ add ได้เลย ไม่ต้องค้างไว้ lot หน้า
                //== Delete process.
                if (dtDelete != null && dtDelete.Rows.Count > 0)
                {
                    listDelete = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dtDelete);
                    for (int i = 0; i < listDelete.Count; i++)
                    {
                        AssignHeaderToDTO(model, listDelete[i],Mode);

                    }

                    biz.SaveCustomerOrder(Common.CurrentDatabase, null, null, listDelete, Mode);

                    // When detail row <= 0 then delete header row

                    if ((dtAdd == null || dtAdd.Rows.Count == 0) 
                        && (dtModify == null || dtModify.Rows.Count == 0) 
                        && biz.LoadCustomerOrderEntry(listDelete[0].ORDER_NO, false).Count <= 0)
                    {
                        biz.DeleteCustomerOrderHeader(Common.CurrentDatabase, listDelete);
                    }

                }

                //== Insert process.
                if (dtAdd != null && dtAdd.Rows.Count > 0)
                {
                    listAdd = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dtAdd);

                    List<CustomerOrderViewDTO> listAddEachDetail = null;

                    NZString runningNo = null;
                    RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();

                    if (model.ORDER_NO.IsNull)
                    {
                        runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"CUSTOMER_ORDER_NO", (NZString)"TB_CUSTOMER_ORDERH_TR");
                        model.ORDER_NO = runningNo;
                        // Insert Header
                        AssignHeaderToDTO(model, listAdd[0],Mode);
                        biz.AddCustomerOrderHeader(Common.CurrentDatabase, listAdd[0]);
                    }
                    else
                    {
                        runningNo = model.ORDER_NO;
                    }


                    listAddEachDetail = new List<CustomerOrderViewDTO>();

                    for (int i = 0; i < listAdd.Count; i++)
                    {
                        CustomerOrderViewDTO dto = listAdd[i];

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto,Mode);

                        //dto.TRANS_ID = runningNumberBIZ.GetCompleteRunningNo(DataDefine.TRANS_ID.ToNZString(), DataDefine.TRANSACTION_TABLE_NAME.ToNZString());

                        //add header ใส่ list 
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        // Check all lines.


                        listAddEachDetail.Add(dto);

                    }

                    biz.SaveCustomerOrder(Common.CurrentDatabase, listAddEachDetail, null, null, Mode);

                }

                //== Update process.
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    listUpdate = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dtModify);


                    List<CustomerOrderViewDTO> listUpdateDetail = new List<CustomerOrderViewDTO>();


                    for (int i = 0; i < listUpdate.Count; i++)
                    {

                        CustomerOrderViewDTO dto = listUpdate[i];

                        CustomerOrderBIZ bizCustomer = new CustomerOrderBIZ();

                        CustomerOrderDDTO dtoDDTO = bizCustomer.LoadCustomerOrderDetail(dto.ORDER_NO.StrongValue, dto.ORDER_DETAIL_NO);

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto,Mode);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                        //add header ใส่ list
                        listUpdateDetail.Add(dto);

                    }

                    biz.SaveCustomerOrder(Common.CurrentDatabase, null, listUpdateDetail, null, Mode);
                }


                //Update Header for Edit Case
                //if (Mode == Common.eScreenMode.EDIT && dtData != null && dtData.Rows.Count > 0)
                //{
                //    listUpdate = DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dtData);

                //    for (int i = 0; i < listUpdate.Count; i++)
                //    {
                //        CustomerOrderViewDTO dto = listUpdate[i];

                //        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                //        AssignHeaderToDTO(model, dto);

                //        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                //        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                //        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                //        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

                //        biz.UpdateCustomerOrderHeader(Common.CurrentDatabase, dto);
                //    }
                //}

                Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        public void DeleteItem(NZString OrderNo, NZString OrderDetailNo)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction();

                CustomerOrderBIZ biz = new CustomerOrderBIZ();
                CustomerOrderViewDTO dtoDelItem = new CustomerOrderViewDTO();
                dtoDelItem.ORDER_NO = OrderNo;
                dtoDelItem.ORDER_DETAIL_NO = OrderDetailNo;
                biz.DeleteCustomerOrderDetail(Common.CurrentDatabase, dtoDelItem);
                biz.UpdateCustomerHeaderTotal(Common.CurrentDatabase, dtoDelItem);
                Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                Common.CurrentDatabase.Rollback();
                throw ex;
            }

        }

        public void DeleteGroupTransaction(NZString OrderNo)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction();
                CustomerOrderBIZ biz = new CustomerOrderBIZ();
                List<CustomerOrderViewDTO> dto = biz.LoadCustomerOrderEntry(OrderNo, false);
                biz.DeleteCustomerOrderHeader(Common.CurrentDatabase, dto);
                Common.CurrentDatabase.Commit();
            }
            catch (Exception ex)
            {
                Common.CurrentDatabase.Rollback();
                throw ex;
            }
        }
        #endregion
    }
}
