using EVOFramework;
using Rubik.DTO;
using Rubik.BIZ;
using System.Collections.Generic;
using EVOFramework.Database;

namespace Rubik.Validators
{
    public class InventoryOnhandValidator
    {
        /// <summary>
        /// Check On hand Inventory function follow business rule
        /// </summary>
        /// <param name="eOperation"></param>
        /// <param name="eInoutCls"></param>
        /// <param name="QTY"></param>
        /// <param name="ItemCD"></param>
        /// <param name="LocationCD"></param>
        /// <param name="LotNo"></param>
        /// <param name="strTranID">in case of Update, this value must be sent, the others send null.</param>
        /// <returns></returns>
        public ErrorItem CheckOnhandQty(DataDefine.eOperationClass eOperation, DataDefine.eIN_OUT_CLASS eInoutCls, NZDecimal QTY, NZString ItemCD, NZString LocationCD, NZString LotNo, NZString strTranID)
        {
            // FIRST CHECK FOR LOCATION IF IT ALLOW NEGATIVE STOCK
            DealingBIZ bizLoc = new DealingBIZ();
            DealingDTO dtoLoc = bizLoc.LoadLocation(LocationCD);
            if (!dtoLoc.ALLOW_NEGATIVE.IsNull && dtoLoc.ALLOW_NEGATIVE.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eALLOW_NEGATIVE.Yes))
            {
                // IF THE LOCATION IS ALLOW FOR NEGATIVE THEN NOT CHECK ONHAND
                return null;
            }

            //Operation Class
            switch (eOperation)
            {
                case DataDefine.eOperationClass.Add:
                    //Do notting
                    break;
                case DataDefine.eOperationClass.Update:
                    //Find Diff Qty
                    InventoryTransBIZ biz = new InventoryTransBIZ();
                    InventoryTransactionDTO dto = biz.LoadByTransactionID(strTranID);
                    if (dto != null)
                    {
                        QTY = (QTY - dto.QTY).ToNZDecimal();
                    }
                    break;
                case DataDefine.eOperationClass.Delete:
                    //Delete Inverse Qty
                    QTY = (-1 * QTY.StrongValue).ToNZDecimal();
                    break;
            }

            //inout Class
            if (eInoutCls == DataDefine.eIN_OUT_CLASS.Out)
            {
                QTY = (-1 * QTY.StrongValue).ToNZDecimal();
            }

            // CHECK FOR ONHAND WITH ACTUAL INVENTORY ONHAND
            InventoryBIZ bizInv = new InventoryBIZ();
            ActualOnhandViewDTO dtoActOnhand = bizInv.LoadActualInventoryOnHand(ItemCD, LocationCD, LotNo);
            decimal decActualOnhandQty = 0;
            if (dtoActOnhand != null && !dtoActOnhand.ONHAND_QTY.IsNull)
            {
                decActualOnhandQty = dtoActOnhand.ONHAND_QTY.StrongValue;
            }

            decActualOnhandQty = decActualOnhandQty + QTY;

            if (decActualOnhandQty < 0)
            {
                return new ErrorItem(QTY.Owner, TKPMessages.eValidate.VLM0063.ToString(), new[] { ItemCD, LocationCD });
            }
            return null;
        }


        /// <summary>
        /// Check On hand Inventory function follow business rule
        /// </summary>
        /// <param name="eOperation"></param>
        /// <param name="eInoutCls"></param>
        /// <param name="QTY"></param>
        /// <param name="ItemCD"></param>
        /// <param name="LocationCD"></param>
        /// <param name="LotNo"></param>
        /// <param name="strTranID">in case of Update, this value must be sent, the others send null.</param>
        /// <returns></returns>
        public ErrorItem CheckOnhandQty(DataDefine.eOperationClass eOperation, string strInOutClass, NZDecimal QTY, NZString ItemCD, NZString LocationCD, NZString LotNo, NZString strTranID)
        {
            return CheckOnhandQty(eOperation, DataDefine.Convert2ClassCode(strInOutClass), QTY, ItemCD, LocationCD, LotNo, strTranID);
        }

        public ErrorItem CheckOnhandQty_AfterTR(Database db, EVOFramework.Windows.Forms.IControlIdentify owner, NZString ItemCD, NZString LocationCD, NZString LotNo)
        {
            // FIRST CHECK FOR LOCATION IF IT ALLOW NEGATIVE STOCK
            DealingBIZ bizLoc = new DealingBIZ();
            DealingDTO dtoLoc = bizLoc.LoadLocation(LocationCD);
            if (!dtoLoc.ALLOW_NEGATIVE.IsNull && dtoLoc.ALLOW_NEGATIVE.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eALLOW_NEGATIVE.Yes))
            {
                // IF THE LOCATION IS ALLOW FOR NEGATIVE THEN NOT CHECK ONHAND
                return null;
            }

            InventoryBIZ biz = new InventoryBIZ();
            ActualOnhandViewDTO dto = biz.LoadActualInventoryOnHand(db, ItemCD, LocationCD, LotNo);

            SysConfigBIZ bizConfig = new SysConfigBIZ();
            SysConfigDTO dtoMinusQty = bizConfig.LoadByPK(DataDefine.eSYSTEM_CONFIG.LOCATION.SYS_GROUP_ID, (NZString)DataDefine.eSYSTEM_CONFIG.LOCATION.SYS_KEY.MINUS_QTY.ToString());

            decimal decMinusQty = 0;
            decimal.TryParse(dtoMinusQty.CHAR_DATA.StrongValue, out decMinusQty);

            if (dto.ONHAND_QTY < decMinusQty)
            {
                return new ErrorItem(owner, TKPMessages.eValidate.VLM0063.ToString(), new[] { ItemCD, LocationCD });
            }
            return null;
        }

        internal ErrorItem CheckIfItemLotHasNegativeQty(NZString YearMonth)
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            List<InventoryOnhandDTO> dtoList = bizInv.LoadInvOnhandWithNegativeQty(YearMonth);

            if (dtoList != null && dtoList.Count > 0)
            {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0076.ToString());
            }
            return null;
        }

        internal ErrorItem CheckIfExistWithYearMonth(NZString PreMonth)
        {
            InventoryBIZ bizInv = new InventoryBIZ();
            List<InventoryOnhandDTO> dtoList = bizInv.LoadInventoryWithYearMonth(PreMonth);

            if (dtoList == null || dtoList.Count == 0)
            {
                ErrorItem err = new ErrorItem(null, TKPMessages.eValidate.VLM0077.ToString());
                return err;
            }
            return null;
        }
    }
}
