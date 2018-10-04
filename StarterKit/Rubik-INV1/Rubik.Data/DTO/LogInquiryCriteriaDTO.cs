using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace Rubik.DTO
{
    public class LogInquiryCriteriaDTO
    {
        private NZDateTime m_dtFromDate;
        private NZDateTime m_dtToDate;
        private NZString m_strTable;


        public NZDateTime FromDate
        {
            get { return m_dtFromDate; }
            set { m_dtFromDate = value; }
        }

        public NZDateTime ToDate
        {
            get { return m_dtToDate; }
            set { m_dtToDate = value; }
        }

        public NZString TableName
        {
            get { return m_strTable; }
            set { m_strTable = value; }
        }

    }
}
