using System.Data;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.UIDataModel
{
    public class LotMaintenanceUIDM : IUIDataModel
    {
        private NZString m_Location = new NZString();
        private NZString m_Item_No = new NZString();
        private NZString m_Item_Name = new NZString();
        private NZString m_Lot_No = new NZString();
        private DataTable m_dtView = null;
        private NZBoolean m_ShowReserveLot = new NZBoolean();


        public NZString Location { get { return m_Location; } set { m_Location = value; } }
        public NZString Item_No { get { return m_Item_No; } set { m_Item_No = value; } }
        public NZString Item_Name { get { return m_Item_Name; } set { m_Item_Name = value; } }
        public NZString Lot_No { get { return m_Lot_No; } set { m_Lot_No = value; } }
        public NZBoolean ShowReserveLot { get { return m_ShowReserveLot; } set { m_ShowReserveLot = value; } }
        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }

    }
}
