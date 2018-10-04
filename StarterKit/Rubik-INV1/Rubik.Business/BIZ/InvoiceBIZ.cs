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
    public class InvoiceBIZ : BaseDAO
    {
        #region LOAD

        public List<InvoiceDTO> Load_All()
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.LoadAll(null,true);
        }

        public List<InvoiceDTO> Load_All_Ascending(bool Ascending)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.LoadAll(null, Ascending, true);
        }

        public List<InvoiceDTO> Load_All_Ascending_By_Params(bool Ascending, params InvoiceDTO.eColumns[] orderByColumns)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.LoadAll(null, Ascending,true, orderByColumns);
        }

        public InvoiceDTO Load_By_PK(string TRANS_ID)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.LoadByPK(null, TRANS_ID, true);
        }

        public List<InvoiceDTO> Load_By_Bill_No(string BILL_NO)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.LoadByBillNo(null, BILL_NO, true);
        }

        public List<InvoiceDTO> Load_Delivery_Detail(string DELIVERY_NO)
        {
            Database db = Common.CurrentDatabase;

            DataRequest req = new DataRequest("S_TRN350_Invoice_Order_Load");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(DELIVERY_NO));
            if (false)
                req.Parameters.Add("@OLD_DATA", DataType.Int16, 0);    //not include old value  

            return db.ExecuteForList<InvoiceDTO>(req);
        }
        #endregion

        #region SAVE
        
        public int Add_New(InvoiceDTO data)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.AddNew(null, data);
        }

        public int Add_NewOrUpdate(InvoiceDTO data)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.AddNewOrUpdate(null, data);
        }

        public int Update_With_PK(InvoiceDTO data, string TRANS_ID)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.UpdateWithPK(null, data, TRANS_ID);
        }

        public int Update_WithOut_PK(InvoiceDTO data)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }

        #endregion

        #region DELETE

        public int Delete(string TRANS_ID)
        {
            InvoiceDAO dao = new InvoiceDAO(Common.CurrentDatabase);
            return dao.Delete(null, TRANS_ID);
        }

        #endregion
    }
}
