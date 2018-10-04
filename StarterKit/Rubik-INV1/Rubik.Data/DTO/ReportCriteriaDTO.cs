using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DTO
{
    public class ReportCriteriaDTO
    {
        public class EPR010
        {
            private DateTime m_dtmDateFrom;
            private DateTime m_dtmDateTo;
            private string m_strLocationFrom;
            private string m_strLocationTo;
            private string m_strPartNoFrom;
            private string m_strPartNoTo;
            private string m_strTransactionClass;
            private string m_strInOutClass;

            public DateTime DateFrom { get { return m_dtmDateFrom; } set { m_dtmDateFrom = value; } }
            public DateTime DateTo { get { return m_dtmDateTo; } set { m_dtmDateTo = value; } }
            public string LocationFrom { get { return m_strLocationFrom; } set { m_strLocationFrom = value; } }
            public string LocationTo { get { return m_strLocationTo; } set { m_strLocationTo = value; } }
            public string PartNoFrom { get { return m_strPartNoFrom; } set { m_strPartNoFrom = value; } }
            public string PartNoTo { get { return m_strPartNoTo; } set { m_strPartNoTo = value; } }
            public string TransactionClass { get { return m_strTransactionClass; } set { m_strTransactionClass = value; } }
            public string InOutClass { get { return m_strInOutClass; } set { m_strInOutClass = value; } }

        }

        public class EPR020
        {
            private DateTime m_dtmDateFrom;
            private DateTime m_dtmDateTo;
            private string m_strFromLocation;
            private string m_strToLocation;
            private string m_strPartNoFrom;
            private string m_strPartNoTo;


            public DateTime DateFrom { get { return m_dtmDateFrom; } set { m_dtmDateFrom = value; } }
            public DateTime DateTo { get { return m_dtmDateTo; } set { m_dtmDateTo = value; } }
            public string FromLocation { get { return m_strFromLocation; } set { m_strFromLocation = value; } }
            public string ToLocation { get { return m_strToLocation; } set { m_strToLocation = value; } }
            public string PartNoFrom { get { return m_strPartNoFrom; } set { m_strPartNoFrom = value; } }
            public string PartNoTo { get { return m_strPartNoTo; } set { m_strPartNoTo = value; } }

        }

        public class IVR010
        {
            private string m_strYearMonth;
            public string YearMonth { get { return m_strYearMonth; } set { m_strYearMonth = value; } }
        }

        public class INV060
        {
            private DateTime m_dtmDateFrom;
            private DateTime m_dtmDateTo;

            public DateTime DateFrom { get { return m_dtmDateFrom; } set { m_dtmDateFrom = value; } }
            public DateTime DateTo { get { return m_dtmDateTo; } set { m_dtmDateTo = value; } }
        }

        public class INV090
        {
            private DateTime m_dtmDateFrom;
            private DateTime m_dtmDateTo;

            public DateTime DateFrom { get { return m_dtmDateFrom; } set { m_dtmDateFrom = value; } }
            public DateTime DateTo { get { return m_dtmDateTo; } set { m_dtmDateTo = value; } }

        }
    }
}
