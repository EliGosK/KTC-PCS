using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
using System;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_INV_ONHAND_TR", typeof(eColumns))]
    public class LotMaintenanceDTO : AbstractDTO
    {

        public enum eColumns
        {
            EDIT_FLAG,
            LOT_NO,
            ON_HAND_QTY,
            Shipment,
            Location,
            Item_NO,
            Item_Name,
        }
        private NZInt m_iEDIT_FLAG = new NZInt();
        private NZString m_LOT_NO = new NZString();
        private NZDecimal m_ON_HAND_QTY = new NZDecimal();
        private NZDecimal m_Shipment = new NZDecimal();
        private NZString m_Location = new NZString();
        private NZString m_Item_NO = new NZString();
        private NZString m_Item_Name = new NZString();
        private NZBoolean m_ShowReserveLot = new NZBoolean();

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "EDIT_FLAG", 10, 0, 4)]
        public NZInt EDIT_FLAG
        {
            get { return m_iEDIT_FLAG; }
            set
            {
                if (value == null)
                    m_iEDIT_FLAG.Value = value;
                else
                    m_iEDIT_FLAG = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOT_NO", 0, 0, 20)]
        public NZString LOT_NO
        {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ON_HAND_QTY", 10, 0, 9)]
        public NZDecimal ON_HAND_QTY
        {
            get { return m_ON_HAND_QTY; }
            set { m_ON_HAND_QTY = value; }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "Shipment", 10, 0, 9)]
        public NZDecimal Shipment
        {
            get { return m_Shipment; }
            set { m_Shipment = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "Location", 0, 0, 20)]
        public NZString Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "Item_NO", 0, 0, 20)]
        public NZString Item_NO
        {
            get { return m_Item_NO; }
            set { m_Item_NO = value; }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "Item_Name", 0, 0, 20)]
        public NZString Item_Name
        {
            get { return m_Item_Name; }
            set { m_Item_Name = value; }
        }

        public NZBoolean ShowReserveLot
        {
            get { return m_ShowReserveLot; }
            set { m_ShowReserveLot = value; }
        }

    }
}
