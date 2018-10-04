using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using Rubik.DAO;
using Rubik.DTO;
using CommonLib;
using SystemMaintenance.BIZ;

namespace Rubik.BIZ
{
    public class CustomerOrderBIZ
    {
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
            dtoCustomerOrderD.ORDER_DETAIL_NO = dtoCustomerOrderView.ORDER_DETAIL_NO;
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

        public List<CustomerOrderViewDTO> LoadCustomerOrderList(NZDateTime DateBegin, NZDateTime DateEnd, NZInt filterType, bool IncludeOldData)
        {
            CustomerOrderListDAO dao = new CustomerOrderListDAO(Common.CurrentDatabase);
            return DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dao.LoadCustomerOrderList(DateBegin, DateEnd, filterType, IncludeOldData));
        }

        public List<CustomerOrderViewDTO> LoadCustomerOrderEntry(NZString orderNo, bool IncludeOldData)
        {
            CustomerOrderListDAO dao = new CustomerOrderListDAO(Common.CurrentDatabase);
            return DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dao.LoadCustomerOrderEntry(new NZString(), orderNo, IncludeOldData));
        }

        public List<CustomerOrderViewDTO> LoadCustomerOrderEntryByCustomerCD(NZString CustomerCD, bool IncludeOldData)
        {
            CustomerOrderListDAO dao = new CustomerOrderListDAO(Common.CurrentDatabase);
            return DTOUtility.ConvertDataTableToList<CustomerOrderViewDTO>(dao.LoadCustomerOrderEntry(CustomerCD, new NZString(), IncludeOldData));
        }

        public CustomerOrderViewDTO LoadCustomerOrderHeader(NZString orderNo, bool IncludeOldData)
        {
            CustomerOrderHDAO dao = new CustomerOrderHDAO(Common.CurrentDatabase);
            return CustomerOrderHDTO2CustomerOrderViewDTO(dao.LoadByPK(Common.CurrentDatabase, orderNo.Value.ToString()));
        }

        public CustomerOrderDDTO LoadCustomerOrderDetail(String Order_No, NZString Order_Detail_No)
        {
            CustomerOrderDDAO dao = new CustomerOrderDDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, Order_No, Order_Detail_No);
        }

        public List<CustomerOrderDDTO> LoadCustomerOrderDetail(String Order_No)
        {
            CustomerOrderDDAO dao = new CustomerOrderDDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllDetail(null, Order_No);
        }

        #region SaveData
        public void SaveCustomerOrder(Database db
                                        , List<CustomerOrderViewDTO> addItems
                                        , List<CustomerOrderViewDTO> updateItems
                                        , List<CustomerOrderViewDTO> deleteItems
                                        , Common.eScreenMode Mode)
        {
            // For new order
            if (addItems != null && addItems.Count > 0) AddNewCustomerOrder(db, addItems);
            if (updateItems != null && updateItems.Count > 0) UpdateCustomerOrder(db, updateItems);
            if (deleteItems != null && deleteItems.Count > 0) DeleteCustomerOrder(db, deleteItems);
        }

        public void AddNewCustomerOrder(Database database, List<CustomerOrderViewDTO> ListAdd)
        {
            AddCustomerOrderDetail(database, ListAdd);

            //for (int i = 0; i < listData.Count; i++)
            //{
            //    listData[i].RUN_NO = AddCustomerOrderHeader(database, listData[i], isGenTransID);
            //    if (Order_Number != null) listData[i].ORDER_NO = Order_Number;

            //}
        }

        /// <summary>
        /// Add new transaction. ใช้กรณีเพิ่ม Transaction ตัวใหม่  ซึ่งอาจจะกระทบต่อตาราง Inventory Onhand

        public void AddCustomerOrderHeader(Database database, CustomerOrderViewDTO data)
        {
            // Add Inventory transaction.
            CustomerOrderHDAO dao = new CustomerOrderHDAO(database);
            data.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            data.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            data.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            data.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            if (dao.AddNewOrUpdate(database, CustomerOrderViewDTO2CustomerOrderHDTO(data)) <= 0)
                throw new ValidateException("Insert failed. Data is missing, Please check your data.");
        }

        public void AddCustomerOrderDetail(Database database, List<CustomerOrderViewDTO> ListAdd)
        {
            //== Dispatcher Transaction Type.
            RunningNumberBIZ runningNumberBIZ = new RunningNumberBIZ();

            for (int i = 0; i < ListAdd.Count; i++)
            {
                if (ListAdd[i].ORDER_DETAIL_NO.IsNull || ListAdd[i].ORDER_DETAIL_NO.Value == null || ListAdd[i].ORDER_DETAIL_NO.Value.ToString() == "")
                {
                    // Generate new Transaction ID.
                    NZString runningNo = runningNumberBIZ.GetCompleteRunningNo((NZString)"CUSTOMER_ORDER_DETAIL_NO", (NZString)"TB_CUSTOMER_ORDERD_TR");
                    ListAdd[i].ORDER_DETAIL_NO = runningNo;
                }

                // Add Inventory transaction.
                CustomerOrderDDAO dao = new CustomerOrderDDAO(database);
                ListAdd[i].CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                ListAdd[i].CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                ListAdd[i].UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                ListAdd[i].UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                if (dao.AddNewOrUpdate(database, CustomerOrderViewDTO2CustomerOrderDDTO(ListAdd[i])) <= 0)
                    throw new ValidateException("Insert failed. Data is missing, Please check your data.");

                //data.TRANS_CLS = transType;
                // Start update stock.
                //UpdateInventoryOnhand(database, data, DataDefine.eOperationClass.Add);

                //if (data.TRANS_CLS == DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving))
                //{
                //    dao.UpdatePOBalance(null, data, data.QTY.StrongValue);
                //}
            }

        }

        public void UpdateCustomerOrder(Database database, List<CustomerOrderViewDTO> ListUpdate)
        {
            for (int i = 0; i < ListUpdate.Count; i++)
            {
                UpdateCustomerOrderDetail(database, ListUpdate[i]);
            }
            UpdateCustomerOrderHeader(database, ListUpdate[0]);
        }
        /// <summary>
        /// ใช้กรณีต้องการ Adjust Transaction ตัวเก่า
        /// </summary>
        /// <param name="database"></param>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>        
        public void UpdateCustomerOrderHeader(Database database, CustomerOrderViewDTO data)
        {
            CustomerOrderHDAO dao = new CustomerOrderHDAO(database);
            dao.UpdateWithoutPK(database, CustomerOrderViewDTO2CustomerOrderHDTO(data));

            ShipmentDAO_Add daoShipment = new ShipmentDAO_Add();
            daoShipment.UpdateCustomerOrderStatus(database, data.ORDER_DETAIL_NO, 0);
        }
        public void DeleteCustomerOrder(Database database, List<CustomerOrderViewDTO> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                DeleteCustomerOrderDetail(database, data[i]);
            }
        }
        public void UpdateCustomerOrderDetail(Database database, CustomerOrderViewDTO data)
        {
            //InventoryTransactionDAO dao = new InventoryTransactionDAO(database);
            //InventoryTransactionDTO dto = dao.LoadByPK(null, TRANS_ID);
            CustomerOrderDDAO dao = new CustomerOrderDDAO(database);
            dao.UpdateWithoutPK(database, CustomerOrderViewDTO2CustomerOrderDDTO(data));
        }
        public void DeleteCustomerOrderHeader(Database database, List<CustomerOrderViewDTO> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                DeleteCustomerOrderDetail(database, data[i]);
            }

            CustomerOrderHDAO dao = new CustomerOrderHDAO();
            dao.Delete(database, data[0].ORDER_NO.Value.ToString());
        }

        public void DeleteCustomerOrderHeader(Database database, NZString ORderNo)
        {
            CustomerOrderHDAO dao = new CustomerOrderHDAO();
            dao.Delete(database, ORderNo.Value.ToString());
        }

        public void DeleteCustomerOrderDetail(Database database, CustomerOrderViewDTO data)
        {
            CustomerOrderDDAO dao = new CustomerOrderDDAO();
            dao.Delete(database, data.ORDER_NO.Value.ToString(), data.ORDER_DETAIL_NO);
        }

        public void UpdateCustomerHeaderTotal(Database database, CustomerOrderViewDTO data)
        {
            CustomerOrderHDAO dao = new CustomerOrderHDAO();
            dao.UpdateCustomerHeaderTotal(database, data.ORDER_NO.Value.ToString());
        }
        #endregion
    }
}
