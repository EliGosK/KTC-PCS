using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.UIDataModel;
using EVOFramework;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Controller
{
    public class InventoryMovementInqController
    {
        private List<InventoryMovementInqUIDM> GenerateLines(InventoryOnhandDTO dtoInvOnHand, List<InventoryTransactionDTO> listData)
        {
            //== Generate line of inquiry item.
            List<InventoryMovementInqUIDM> listModel = new List<InventoryMovementInqUIDM>();

            InventoryMovementInqUIDM model = null;

            // first line.
            model = new InventoryMovementInqUIDM();
            if (dtoInvOnHand == null)
            {
                model.BALANCE.Value = 0;
            }
            else
            {
                model.BALANCE.Value = dtoInvOnHand.OPEN_QTY.Value;
                model.TRANS_DATE.Value = dtoInvOnHand.PERIOD_BEGIN_DATE.Value;
            }

            model.TRANS_INFO.Value = "Open Bal";
            listModel.Add(model);

            decimal dOpenQty = model.BALANCE.NVL(0);
            // add each transaction line.
            for (int i = 0; i < listData.Count; i++)
            {
                InventoryTransactionDTO dto = listData[i];
                model = new InventoryMovementInqUIDM();
                model.TRANS_DATE = dto.TRANS_DATE;
                model.TRANS_ID = dto.TRANS_ID;
                model.TRANS_INFO = dto.TRANS_CLS;
                model.REF_SLIP_NO = dto.REF_SLIP_NO;
                model.REF_TYPE = dto.REF_SLIP_CLS;
                model.LOT_NO = dto.LOT_NO;
                model.IN_QTY.Value = 0;
                model.OUT_QTY.Value = 0;
                model.BALANCE.Value = 0;

                model.REF_NO = dto.REF_NO;
                model.REMARK = dto.REMARK;

                if (dto.IN_OUT_CLS.StrongValue == "01")
                {
                    model.IN_QTY = dto.QTY;
                    dOpenQty += dto.QTY.NVL(0);
                }
                else if (dto.IN_OUT_CLS.StrongValue == "02")
                {
                    model.OUT_QTY = dto.QTY;
                    dOpenQty -= dto.QTY.NVL(0);
                }
                else
                {
                    model.NG_CRITERIA = dto.TRAN_SUB_CLS;
                    model.NG_QTY = dto.QTY;
                }

                model.BALANCE.Value = dOpenQty; //calculate previous balance.
                listModel.Add(model);
            }

            return listModel;
        }
        public List<InventoryMovementInqUIDM> LoadDataInventoryMovementInquiry(NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            )
        {

            InventoryBIZ biz = new InventoryBIZ();
            List<InventoryTransactionDTO> listData = biz.LoadInventoryMovement(PERIOD_BEGIN_DATE, PERIOD_END_DATE, ITEM_CD, LOC_CD, LOT_NO);
            InventoryOnhandDTO dtoInvOnHand = biz.LoadInventoryOnHandAllLotNo(YEAR_MONTH, PERIOD_BEGIN_DATE, PERIOD_END_DATE, ITEM_CD, LOC_CD, LOT_NO);


            return GenerateLines(dtoInvOnHand, listData);
        }

        public List<InventoryMovementInqUIDM> LoadDataInventorymovementInquiryByLotNo(NZString YEAR_MONTH, NZDateTime PERIOD_BEGIN_DATE, NZDateTime PERIOD_END_DATE
            , NZString ITEM_CD
            , NZString LOC_CD
            , NZString LOT_NO
            , NZString PACK_NO
            )
        {

            InventoryBIZ biz = new InventoryBIZ();
            List<InventoryTransactionDTO> listData = biz.LoadInventoryMovementByLotNo(PERIOD_BEGIN_DATE, PERIOD_END_DATE, ITEM_CD, LOC_CD, LOT_NO);
            InventoryOnhandDTO dtoInvOnHand = biz.LoadInventoryOnHandByYearMonth(YEAR_MONTH, ITEM_CD, LOC_CD, LOT_NO, PACK_NO);

            return GenerateLines(dtoInvOnHand, listData);
        }
    }
}
