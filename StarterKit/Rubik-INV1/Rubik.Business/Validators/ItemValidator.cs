using EVOFramework;
using Rubik.DTO;
using Rubik.DAO;
using SystemMaintenance;

namespace Rubik.Validators {
    public class ItemValidator {
        #region Mandatory Check
        public ErrorItem CheckEmptyItemCode(NZString ItemCode) {
            if (ItemCode.IsNull)
                return new ErrorItem(ItemCode.Owner, TKPMessages.eValidate.VLM0006.ToString());

            //if (ItemCode.StrongValue.Trim().IndexOf(' ') > -1)
            //Modify by Bunyapat L.
            //To support ' ' in the middle of Item code

            if (!ItemCode.StrongValue.Equals(ItemCode.StrongValue.Trim()))
                return new ErrorItem(ItemCode.Owner, TKPMessages.eValidate.VLM0072.ToString());

            return null;
        }

        public ErrorItem CheckEmptyItemDesc(NZString ItemDesc) {
            if (ItemDesc.IsNull)
                return new ErrorItem(ItemDesc.Owner, TKPMessages.eValidate.VLM0212.ToString());

            return null;
        }

        public ErrorItem CheckEmptyItemType(NZString ItemType) {
            if (ItemType.IsNull)
                return new ErrorItem(ItemType.Owner, TKPMessages.eValidate.VLM0008.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLotControlType(NZString LotControlType) {
            if (LotControlType.IsNull)
                return new ErrorItem(LotControlType.Owner, TKPMessages.eValidate.VLM0011.ToString());

            return null;
        }

        public ErrorItem CheckEmptyOrderLoc(NZString OrderLoc) {
            if (OrderLoc.IsNull)
                return new ErrorItem(OrderLoc.Owner, TKPMessages.eValidate.VLM0012.ToString());

            return null;
        }

        public ErrorItem CheckEmptyStoreLoc(NZString StoreLoc) {
            if (StoreLoc.IsNull)
                return new ErrorItem(StoreLoc.Owner, TKPMessages.eValidate.VLM0015.ToString());

            return null;
        }

        public ErrorItem CheckEmptyOrderProcess(NZString OrderProcess) {
            if (OrderProcess.IsNull)
                return new ErrorItem(OrderProcess.Owner, TKPMessages.eValidate.VLM0056.ToString());

            return null;
        }

        public ErrorItem CheckEmptyInventoryUM(NZString InventoryUM) {
            if (InventoryUM.IsNull)
                return new ErrorItem(InventoryUM.Owner, TKPMessages.eValidate.VLM0057.ToString());

            return null;
        }

        public ErrorItem CheckEmptyOrderUM(NZString OrderUM) {
            if (OrderUM.IsNull)
                return new ErrorItem(OrderUM.Owner, TKPMessages.eValidate.VLM0058.ToString());

            return null;
        }

        public ErrorItem CheckEmptyUnitConvert(NZDecimal InventoryUM, NZDecimal OrderUM) {
            if (InventoryUM / OrderUM == 0)
                return new ErrorItem(InventoryUM.Owner, TKPMessages.eValidate.VLM0059.ToString());

            return null;
        }

        public ErrorItem CheckEmptyOrderUMRate(NZDecimal OrderUMRate) {
            if (OrderUMRate.IsNull || OrderUMRate.StrongValue == 0)
                return new ErrorItem(OrderUMRate.Owner, TKPMessages.eValidate.VLM0060.ToString());

            return null;
        }

        public ErrorItem CheckEmptyConsumptionClass(NZString ConsumptionClass) {
            if (ConsumptionClass.IsNull)
                return new ErrorItem(ConsumptionClass.Owner, TKPMessages.eValidate.VLM0061.ToString());

            return null;
        }
        #endregion

        public void ValidateBeforeSaveNew(ItemDTO dtoItem, ItemProcessDTO dtoItemProcess) {
            ValidateException validateException = new ValidateException();
            //ErrorItem errorItem = null;

            #region mandatory check
            //errorItem = CheckEmptyItemCode(dtoItem.ITEM_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyItemDesc(dtoItem.ITEM_DESC);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //validateException.ThrowIfHasError();

            //errorItem = CheckEmptyItemType(dtoItem.ITEM_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyLotControlType(dtoItem.LOT_CONTROL_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyStoreLoc(dtoItemProcess.STORE_LOC_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);
            
            //errorItem = CheckEmptyInventoryUM(dtoItem.INV_UM_CLS);
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
            //errorItem = CheckEmptyOrderUM(dtoItem.ORDER_UM_CLS);
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
            //errorItem = CheckEmptyOrderUMRate(dtoItem.ORDER_UM_RATE);
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            //errorItem = CheckEmptyUnitConvert(dtoItem.INV_UM_RATE, dtoItem.ORDER_UM_RATE);
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            //errorItem = CheckEmptyOrderProcess(dtoItemProcess.ORDER_PROCESS_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyConsumptionClass(dtoItemProcess.CONSUMTION_CLS);
            //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            BusinessException businessException = CheckItemExist(dtoItem.ITEM_CD);
            if (businessException != null)
            {
                throw businessException;
            }

            #endregion

        
        }

        /// <exception cref="BusinessException"><c>BusinessException</c>.</exception>
        public void ValidateBeforeSaveUpdate(ItemDTO dtoItem, ItemProcessDTO dtoItemProcess) {
            ValidateException validateException = new ValidateException();
            ErrorItem errorItem = null;

            #region mandatory check
            errorItem = CheckEmptyItemCode(dtoItem.ITEM_CD);
            if (errorItem != null)
                validateException.AddError(errorItem);

            //errorItem = CheckEmptyItemDesc(dtoItem.ITEM_DESC);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyItemType(dtoItem.ITEM_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyLotControlType(dtoItem.LOT_CONTROL_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyOrderProcess(dtoItemProcess.ORDER_PROCESS_CLS);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyStoreLoc(dtoItemProcess.STORE_LOC_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);
            validateException.ThrowIfHasError();
            #endregion

            BusinessException businessException = CheckItemNotExist(dtoItem.ITEM_CD);
            if (businessException != null) {
                throw businessException;
            }
        }

        public ErrorItem CheckExistWithItemType(NZString ItemCD, eSqlOperator sqlOperator, string[] itemTypes) {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            if (dao.ExistWithItemTypes(null, ItemCD, sqlOperator, itemTypes)) {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0010.ToString());
                return errorItem;
            }
            return null;
        }

        public ErrorItem CheckNotExistWithItemType(NZString ItemCD, eSqlOperator sqlOperator, string[] itemTypes) {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            if (!dao.ExistWithItemTypes(null, ItemCD, sqlOperator, itemTypes)) {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0009.ToString());
                return errorItem;
            }
            return null;
        }

        public ErrorItem CheckItemByCustomer(NZString ItemCD, NZString CustomerCode)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            if (!dao.ExistWithCustomer(null, ItemCD, CustomerCode))
            {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0182.ToString());
                return errorItem;
            }
            return null;
        }

         

        public BusinessException CheckItemExist(NZString ItemCD) {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, ItemCD)) {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0010.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }

        public BusinessException CheckItemNotExist(NZString ItemCD) {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            if (!dao.Exist(null, ItemCD)) {
                ErrorItem errorItem = new ErrorItem(ItemCD.Owner, TKPMessages.eValidate.VLM0009.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }

        public ErrorItem CheckExistsTransactionByItem(NZString ItemCD) {
            InventoryTransactionDAO dao = new InventoryTransactionDAO(CommonLib.Common.CurrentDatabase);
            if (dao.ExistsByItem(null, ItemCD)) {
                return new ErrorItem(null, TKPMessages.eValidate.VLM0073.ToString());
            }
            return null;
        }



        public ErrorItem CheckEmptyYieldRate(NZDecimal nZDecimal)
        {
            if (nZDecimal == 0)
                return new ErrorItem(nZDecimal.Owner, Messages.eValidate.VLM0144.ToString());

            return null;
        }

        public ErrorItem CheckReorderPoint(NZDecimal dReorderPoint, NZDecimal dSafetyStock)
        {
            if ( dReorderPoint <  dSafetyStock)
                return new ErrorItem(dReorderPoint.Owner, Messages.eValidate.VLM0148.ToString());

            return null;
        }

        public ErrorItem CheckEmptyLeadTime(NZDecimal nZDecimal)
        {
            if (nZDecimal == 0)
                return new ErrorItem(nZDecimal.Owner, Messages.eValidate.VLM0145.ToString());

            return null;
        }

        public ErrorItem CheckEmptyOrderCondition(NZString nZString)
        {
            if (nZString.IsNull)
                return new ErrorItem(nZString.Owner, Messages.eValidate.VLM0147.ToString());

            return null;
        }

        public ErrorItem CheckEmptyMRPFlag(NZString nZString)
        {
            if (nZString.IsNull)
                return new ErrorItem(nZString.Owner, Messages.eValidate.VLM0146.ToString());

            return null;
        }

        public ErrorItem CheckNullString(NZString nZString, Messages.eValidate eValidate)
        {
            if (nZString.IsNull)
                return new ErrorItem(nZString.Owner, eValidate.ToString());

            return null;
        }

        public ErrorItem CheckEmptyKindOfProduct(NZString nZString) {
            if (nZString.IsNull)
                return new ErrorItem(nZString.Owner, TKPMessages.eValidate.VLM0193.ToString());

            return null;
        }

        public ErrorItem CheckEmptyCustomer(NZString nZString) {
            if (nZString.IsNull)
                return new ErrorItem(nZString.Owner, Messages.eValidate.VLM0113.ToString());

            return null;
        }

        public ErrorItem ValidateBeforeDelete(NZString ITEM_CD)
        {

            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            string returnString = dao.ValidateBeforeDelete(null, ITEM_CD);
            if (returnString == null)
            {
                return null;
            }
            else
            {
                return new ErrorItem(ITEM_CD.Owner, returnString);
            }
        }
    }
}
