using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace Rubik.DTO
{
    public class ItemWeightDTO
    {
        private NZDecimal m_decQtyKG;
        private NZDecimal m_decQtyPCS;
        private NZDecimal m_decWeight;
        private NZString m_strItemCD;
        private NZString m_strProcessCD;

        public NZDecimal QtyKG
        {
            get { return m_decQtyKG; }
            set
            {
                if (value == null)
                    m_decQtyKG.Value = value;
                else
                    m_decQtyKG = value;
            }
        }

        public NZDecimal QtyPCS
        {
            get { return m_decQtyPCS; }
            set
            {
                if (value == null)
                    m_decQtyPCS.Value = value;
                else
                    m_decQtyPCS = value;
            }
        }

        public NZDecimal Weight
        {
            get { return m_decWeight; }
            set
            {
                if (value == null)
                    m_decWeight.Value = value;
                else
                    m_decWeight = value;
            }
        }

        public NZString ItemCD
        {
            get { return m_strItemCD; }
            set
            {
                if (value == null)
                    m_strItemCD.Value = value;
                else
                    m_strItemCD = value;
            }
        }

        public NZString ProcessCD
        {
            get { return m_strProcessCD; }
            set
            {
                if (value == null)
                    m_strProcessCD.Value = value;
                else
                    m_strProcessCD = value;
            }
        }

    }
}
