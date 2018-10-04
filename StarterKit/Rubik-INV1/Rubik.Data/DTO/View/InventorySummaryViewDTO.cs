using System;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("INV_SUMMARY_VIEW_DTO", typeof(eColumns))]
    public class InventorySummaryViewDTO : AbstractDTO
    {
        public enum eColumns
        {
            ItemNo,
            ItemName,
            Header,
            Rolling,
            Cutting_I,
            Cutting_E,
            Plating_I,
            Plating_E,
            Heating_E,
            Others,
            QC,
            QC_Hold,
            Packing,
            FG,

        }
        private NZString m_ItemNo = new NZString();
        private NZString m_ItemName = new NZString();
        private NZDecimal m_Header = new NZDecimal();
        private NZDecimal m_Rolling = new NZDecimal();
        private NZDecimal m_Cutting_I = new NZDecimal();
        private NZDecimal m_Cutting_E = new NZDecimal();
        private NZDecimal m_Plating_I = new NZDecimal();
        private NZDecimal m_Plating_E = new NZDecimal();
        private NZDecimal m_Heating_E = new NZDecimal();
        private NZDecimal m_Others = new NZDecimal();
        private NZDecimal m_QC = new NZDecimal();
        private NZDecimal m_QC_Hold = new NZDecimal();
        private NZDecimal m_Packing = new NZDecimal();
        private NZDecimal m_FG = new NZDecimal();

        public NZString ItemNo
        {
            get { return m_ItemNo; }
            set { m_ItemNo = value; }
        }

        public NZString ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }

        public NZDecimal Header
        {
            get { return m_Header; }
            set { m_Header = value; }
        }

        public NZDecimal Rolling
        {
            get { return m_Rolling; }
            set { m_Rolling = value; }
        }

        public NZDecimal Cutting_I
        {
            get { return m_Cutting_I; }
            set { m_Cutting_I = value; }
        }

        public NZDecimal Cutting_E
        {
            get { return m_Cutting_E; }
            set { m_Cutting_E = value; }
        }

        public NZDecimal Plating_I
        {
            get { return m_Plating_I; }
            set { m_Plating_I = value; }
        }

        public NZDecimal Plating_E
        {
            get { return m_Plating_E; }
            set { m_Plating_E = value; }
        }

        public NZDecimal Heating_E
        {
            get { return m_Heating_E; }
            set { m_Heating_E = value; }
        }

        public NZDecimal Others
        {
            get { return m_Others; }
            set { m_Others = value; }
        }

        public NZDecimal QC
        {
            get { return m_QC; }
            set { m_QC = value; }
        }

        public NZDecimal QC_Hold
        {
            get { return m_QC_Hold; }
            set { m_QC_Hold = value; }
        }

        public NZDecimal Packing
        {
            get { return m_Packing; }
            set { m_Packing = value; }
        }

        public NZDecimal FG
        {
            get { return m_FG; }
            set { m_FG = value; }
        }


    }
}
