using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using Rubik.BIZ;
using EVOFramework;
using Rubik.UIDataModel;
using System.Data;

namespace Rubik.Controller {
    public class SalesUnitPriceController 
    {
        #region Mapping
        private SalesUnitPriceDTO MapModelToDTO(SalesUnitPriceUIDM data) {
            SalesUnitPriceDTO dto = new SalesUnitPriceDTO();
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;            
            dto.ITEM_CD = data.ITEM_CD;
            dto.START_EFFECTIVE_DATE = data.START_EFFECTIVE_DATE;
            dto.PRICE = data.PRICE;
            dto.CURRENCY = data.CURRENCY;
            dto.REMARK = data.REMARK;
            dto.OLD_DATA = new NZInt(null,0);
            return dto;
        }

        private SalesUnitPriceUIDM MapDTOToModel(SalesUnitPriceDTO Price, ItemDTO Item, DealingDTO Customer) 
        {
            SalesUnitPriceUIDM model = new SalesUnitPriceUIDM();
            model.CRT_BY = Price.CRT_BY;
            model.CRT_DATE = Price.CRT_DATE;
            model.CRT_MACHINE = Price.CRT_MACHINE;
            model.UPD_BY = Price.UPD_BY;
            model.UPD_DATE = Price.UPD_DATE;
            model.UPD_MACHINE = Price.UPD_MACHINE;
            model.ITEM_CD = Price.ITEM_CD;
            model.START_EFFECTIVE_DATE = Price.START_EFFECTIVE_DATE;
            model.PRICE = Price.PRICE;
            model.CURRENCY = Price.CURRENCY;
            model.REMARK = Price.REMARK;
            model.OLD_DATA = Price.OLD_DATA;

            if(Item != null && !Item.ITEM_DESC.IsNull)
                model.SHORT_NAME = Item.SHORT_NAME;
            if (Customer != null && !Customer.LOC_DESC.IsNull)
                model.CUSTOMER_NAME = Customer.LOC_DESC;

            return model;
        }
        #endregion

        #region Operation

        public void SaveNew(SalesUnitPriceUIDM data) 
        {
            SalesUnitPriceDTO dto = MapModelToDTO(data);

            SalesUnitPriceBIZ biz = new SalesUnitPriceBIZ();
            biz.SaveNew(dto);
        }

        public void SaveUpdate(SalesUnitPriceUIDM data) 
        {
            SalesUnitPriceDTO dto = MapModelToDTO(data);

            SalesUnitPriceBIZ biz = new SalesUnitPriceBIZ();
            biz.SaveUpdate(dto);
        }

        public void DeleteSalesUnitPrice(NZString ITEM_CD, NZDateTime START_EFF_DATE, NZString CURRENCY) 
        {
            SalesUnitPriceBIZ biz = new SalesUnitPriceBIZ();
            biz.DeleteSalesUnitPrice(ITEM_CD, START_EFF_DATE, CURRENCY);
        }

        #endregion

        #region Load Data

        public DataTable LoadSalesUnitPriceList(bool includeLodData, DateTime? priceOnDate) 
        {
            SalesUnitPriceBIZ biz = new SalesUnitPriceBIZ();
            return biz.LoadSalesUnitPriceList(includeLodData, priceOnDate);
        }

        public SalesUnitPriceUIDM LoadSalesUnitPriceWithItemInfo(NZString ITEM_CD, NZDateTime START_EFF_DATE, NZString CURRENCY) 
        {
            SalesUnitPriceBIZ bizPrice = new SalesUnitPriceBIZ();
            SalesUnitPriceDTO dtoPrice = bizPrice.LoadSalesUnitPriceByPK(ITEM_CD, START_EFF_DATE, CURRENCY);

            if (dtoPrice == null)
                return null;

            ItemBIZ bizItem = new ItemBIZ();
            ItemDTO dtoItem = bizItem.LoadItem(ITEM_CD);

            DealingBIZ bizCust = new DealingBIZ();
            DealingDTO dtoCust = null;
            if (dtoItem != null && !dtoItem.CUSTOMER_CD.IsNull) 
            {
                dtoCust = bizCust.LoadLocation(dtoItem.CUSTOMER_CD);
            }


            return MapDTOToModel(dtoPrice, dtoItem, dtoCust);
        }

        #endregion

        #region Validate

        #endregion
    }
}
