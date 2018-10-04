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
    public class InvoiceController
    {
        #region Util

        public InvoiceEntryUIDM CreateUIDMForAddMode()
        {
            InvoiceEntryUIDM model = new InvoiceEntryUIDM();
            model.PO_NO.Value = string.Empty;
            model.ORDER_NO.Value = string.Empty;
            model.ORDER_DETAIL_NO.Value = string.Empty;
            model.ITEM_CD.Value = string.Empty;
            model.SHORT_NAME.Value = string.Empty;
            model.ITEM_DESC.Value = string.Empty;
            model.UNIT.Value = string.Empty;
            model.QTY.Value = 0;
            model.PRICE.Value = 0;
            model.AMOUNT.Value = 0;
            model.TRANS_ID.Value = string.Empty;
            model.DATA_VIEW.AcceptChanges();
            return model;
        }

        public InvoiceEntryUIDM MapDTOToUIDM(InvoiceDTO dto)
        {
            InvoiceEntryUIDM model = new InvoiceEntryUIDM();
            model.TRANS_ID = dto.TRANS_ID;
            model.BILL_NO = dto.BILL_NO;
            model.DELIVERY_NO = dto.DELIVERY_NO;
            model.ADDRESS_NO = dto.ADDRESS_NO;
            model.ADDRESS = dto.ADDRESS;
            model.INVOICE_NO = dto.INVOICE_NO;
            model.INVOICE_DATE = dto.INVOICE_DATE;
            model.TERM_OF_PAYMENT = dto.TERM_OF_PAYMENT;
            model.PAYMENT_DUE_DATE = dto.PAYMENT_DUE_DATE;
            model.REFER_TEM_NO = dto.REFER_TEM_NO;
            model.REMARK = dto.REMARK;
            model.SUB_TOTAL = dto.SUB_TOTAL;
            model.VAT = dto.VAT;
            model.VAT_AMOUNT = dto.VAT_AMOUNT;
            model.TOTAL = dto.TOTAL;
            model.CANCEL_FLAG = dto.CANCEL_FLAG;
            model.PO_NO = dto.PO_NO;
            model.ORDER_NO = dto.ORDER_NO;
            model.ORDER_DETAIL_NO = dto.ORDER_DETAIL_NO;
            model.ITEM_CD = dto.ITEM_CD;
            model.SHORT_NAME = dto.SHORT_NAME;
            model.ITEM_DESC = dto.ITEM_DESC;
            model.UNIT = dto.UNIT;
            model.QTY = dto.QTY;
            model.PRICE = dto.PRICE;
            model.AMOUNT = dto.AMOUNT;
            model.OLD_DATA = dto.OLD_DATA;
            return model;
        }

        private void AssignHeaderToDTO(InvoiceEntryUIDM model, InvoiceDTO dto, Common.eScreenMode Mode)
        {
            //dto.TRANS_ID = model.TRANS_ID;
            dto.BILL_NO = model.BILL_NO;
            //dto.DELIVERY_NO = model.DELIVERY_NO;
            //dto.ADDRESS_NO = model.ADDRESS_NO;
            //dto.ADDRESS = model.ADDRESS;
            //dto.INVOICE_NO = model.INVOICE_NO;
            //dto.INVOICE_DATE = model.INVOICE_DATE;
            //dto.TERM_OF_PAYMENT = model.TERM_OF_PAYMENT;
            //dto.PAYMENT_DUE_DATE = model.PAYMENT_DUE_DATE;
            //dto.REFER_TEM_NO = model.REFER_TEM_NO;
            //dto.REMARK = model.REMARK;
            //dto.SUB_TOTAL = model.SUB_TOTAL;
            //dto.VAT = model.VAT;
            //dto.VAT_AMOUNT = model.VAT_AMOUNT;
            //dto.TOTAL = model.TOTAL;
            //dto.CANCEL_FLAG = model.CANCEL_FLAG;
            dto.PO_NO = model.PO_NO;
            dto.ORDER_NO = model.ORDER_NO;
            dto.ORDER_DETAIL_NO = model.ORDER_DETAIL_NO;
            dto.ITEM_CD = model.ITEM_CD;
            dto.SHORT_NAME = model.SHORT_NAME;
            dto.ITEM_DESC = model.ITEM_DESC;
            dto.UNIT = model.UNIT;
            dto.QTY = model.QTY;
            dto.PRICE = model.PRICE;
            dto.AMOUNT = model.AMOUNT;
            //dto.OLD_DATA = model.OLD_DATA;
            if (Mode == Common.eScreenMode.ADD) dto.OLD_DATA.Value = 0;
        }

        #endregion

        #region LOAD

        public List<InvoiceDTO> Load_All()
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_All();
        }

        public List<InvoiceDTO> Load_All_Ascending(bool Ascending)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_All_Ascending(Ascending);
        }

        public List<InvoiceDTO> Load_All_Ascending_By_Params(bool Ascending, params InvoiceDTO.eColumns[] orderByColumns)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_All_Ascending_By_Params(Ascending, orderByColumns);
        }

        public InvoiceDTO Load_By_PK(string TRANS_ID)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_By_PK(TRANS_ID);
        }

        public List<InvoiceDTO> Load_By_Bill_No(string BILL_NO)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_By_Bill_No(BILL_NO);
        }

        public List<InvoiceDTO> Load_Delivery_Detail(string DELIVERY_NO)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Load_Delivery_Detail(DELIVERY_NO);
        }
        #endregion

        #region SAVE
        
        public int Add_New(InvoiceDTO data)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Add_New(data);
        }

        public int Add_NewOrUpdate(InvoiceDTO data)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Add_NewOrUpdate(data);
        }

        public int Update_With_PK(InvoiceDTO data, string TRANS_ID)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Update_With_PK(data, TRANS_ID);
        }

        public int Update_WithOut_PK(InvoiceDTO data)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Update_WithOut_PK(data);
        }

        public void SaveInvoiceEntry(InvoiceEntryUIDM model, Common.eScreenMode Mode)
        {
            try
            {
                Common.CurrentDatabase.KeepConnection = true;
                Common.CurrentDatabase.BeginTransaction(IsolationLevel.Serializable);

                InvoiceBIZ biz = new InvoiceBIZ();

                #region Validate Data
                //== If data not has to processing.
                if (model.DATA_VIEW == null || model.DATA_VIEW.Rows.Count == 0)
                    ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0055.ToString()));

                DataTable dtNonDelete = model.DATA_VIEW.GetChanges(DataRowState.Unchanged | DataRowState.Added | DataRowState.Modified);
                List<InvoiceDTO> listData = DTOUtility.ConvertDataTableToList<InvoiceDTO>(dtNonDelete);

                #endregion


                DataTable dtData = model.DATA_VIEW;
                DataTable dtAdd = dtData.GetChanges(DataRowState.Added);
                DataTable dtModify = dtData.GetChanges(DataRowState.Modified);
                DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

                // แก้บั๊ก GetChange แล้ว Data ไม่ถูกต้อง
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    for (int i = 0; i < dtModify.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtData.Rows.Count; j++)
                        {
                            if (Convert.ToString(dtModify.Rows[i]["TRANS_ID"]) == Convert.ToString(dtData.Rows[j]["TRANS_ID"]))
                            {
                                dtModify.Rows[i]["PO_NO"] = dtData.Rows[j]["PO_NO"];
                                dtModify.Rows[i]["ORDER_NO"] = dtData.Rows[j]["ORDER_NO"];
                                dtModify.Rows[i]["ORDER_DETAIL_NO"] = dtData.Rows[j]["ORDER_DETAIL_NO"];
                                dtModify.Rows[i]["ITEM_CD"] = dtData.Rows[j]["ITEM_CD"];
                                dtModify.Rows[i]["SHORT_NAME"] = dtData.Rows[j]["SHORT_NAME"];
                                dtModify.Rows[i]["ITEM_DESC"] = dtData.Rows[j]["ITEM_DESC"];
                                dtModify.Rows[i]["UNIT"] = dtData.Rows[j]["UNIT"];
                                dtModify.Rows[i]["QTY"] = dtData.Rows[j]["QTY"];
                                dtModify.Rows[i]["PRICE"] = dtData.Rows[j]["PRICE"];
                                dtModify.Rows[i]["AMOUNT"] = dtData.Rows[j]["AMOUNT"];
                            }
                        }
                    }
                }
                List<InvoiceDTO> listAdd = new List<InvoiceDTO>();
                List<InvoiceDTO> listUpdate = new List<InvoiceDTO>();
                List<InvoiceDTO> listDelete = new List<InvoiceDTO>();


                //มีการปรับให้ทำคำสั่งทีละ set ของ add , update , delete เลย
                //ที่เริ่มจาก delete ก่อนเพราะ consumption จะได้มีการเอาไปใช้สำหรับตัวที่ add ได้เลย ไม่ต้องค้างไว้ lot หน้า
                //== Delete process.
                if (dtDelete != null && dtDelete.Rows.Count > 0)
                {
                    listDelete = DTOUtility.ConvertDataTableToList<InvoiceDTO>(dtDelete);
                    for (int i = 0; i < listDelete.Count; i++)
                    {
                        AssignHeaderToDTO(model, listDelete[i], Mode);
                    }

                    foreach (InvoiceDTO dto in listDelete)
                    {
                        biz.Delete(dto.TRANS_ID.StrongValue);
                    }
                }

                //== Insert process.
                if (dtAdd != null && dtAdd.Rows.Count > 0)
                {
                    NZString BillNo = null;
                    NZString TransID = null;
                    listAdd = DTOUtility.ConvertDataTableToList<InvoiceDTO>(dtAdd);
                    if (!listAdd[0].TRANS_ID.IsNull && listAdd[0].TRANS_ID.StrongValue != "")
                        TransID = listAdd[0].TRANS_ID;

                    RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();

                    if (model.BILL_NO.IsNull)
                    {
                        BillNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"BILL_NO", (NZString)"BILL_NO");
                        model.BILL_NO = BillNo;
                    }
                    else
                    {
                        BillNo = model.BILL_NO;
                    }

                    for (int i = 0; i < listAdd.Count; i++)
                    {
                        InvoiceDTO dto = listAdd[i];

                        if (dto.TRANS_ID.IsNull)
                        {
                            TransID = runningNumberBIZ.GetCompleteRunningNo((NZString)"INVOICE_TRANS_ID", (NZString)"TRANS_ID");
                            dto.TRANS_ID = TransID;
                        }

                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto, Mode);

                        //dto.TRANS_ID = runningNumberBIZ.GetCompleteRunningNo(DataDefine.TRANS_ID.ToNZString(), DataDefine.TRANSACTION_TABLE_NAME.ToNZString());

                        //add header ใส่ list 
                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    }

                    foreach (InvoiceDTO dto in listAdd)
                    {
                        biz.Add_New(dto);
                    }
                }

                //== Update process.
                if (dtModify != null && dtModify.Rows.Count > 0)
                {
                    listUpdate = DTOUtility.ConvertDataTableToList<InvoiceDTO>(dtModify);

                    foreach (InvoiceDTO dto in listUpdate)
                    {
                        // Copy ค่า Header จาก Model ไปยัง DTO แต่ละตัว
                        AssignHeaderToDTO(model, dto, Mode);

                        dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
                        dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
                        dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
                    }

                    foreach (InvoiceDTO dto in listUpdate)
                    {
                        biz.Update_WithOut_PK(dto);
                    }
                }

                Common.CurrentDatabase.Commit();
            }
            catch (Exception)
            {
                Common.CurrentDatabase.Rollback();
                throw;
            }
        }

        #endregion

        #region DELETE

        public int Delete(string TRANS_ID)
        {
            InvoiceBIZ biz = new InvoiceBIZ();
            return biz.Delete(TRANS_ID);
        }

        #endregion
    }
}
