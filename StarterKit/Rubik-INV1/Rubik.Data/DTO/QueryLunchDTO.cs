using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_QUERY_LUNCH_MS", typeof(eColumns))]
    public class QueryLunchDTO : AbstractDTO
    {
        public enum eColumns
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            ID,
            Name,
            SQLCommand,
            ExcelTemplate,
            StartRow,
            StartColumn,
            Remark
        };

        private NZString m_CRT_BY = new NZString();
        private NZDateTime m_CRT_DATE = new NZDateTime();
        private NZString m_CRT_MACHINE = new NZString();
        private NZString m_UPD_BY = new NZString();
        private NZDateTime m_UPD_DATE = new NZDateTime();
        private NZString m_UPD_MACHINE = new NZString();
        private NZString m_ID = new NZString();
        private NZString m_Name = new NZString();
        private NZString m_SQLCommand = new NZString();
        private NZString m_ExcelTemplate = new NZString();
        private NZInt m_StartRow = new NZInt();
        private NZInt m_StartColumn = new NZInt();
        private NZString m_Remark = new NZString();

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 15)]
        public NZString CRT_BY
        {
            get { return m_CRT_BY; }
            set
            {
                if (value == null)
                    m_CRT_BY.Value = value;
                else
                    m_CRT_BY = value;
            }
        }

        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        public NZDateTime CRT_DATE
        {
            get { return m_CRT_DATE; }
            set
            {
                if (value == null)
                    m_CRT_DATE.Value = value;
                else
                    m_CRT_DATE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        public NZString CRT_MACHINE
        {
            get { return m_CRT_MACHINE; }
            set
            {
                if (value == null)
                    m_CRT_MACHINE.Value = value;
                else
                    m_CRT_MACHINE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 15)]
        public NZString UPD_BY
        {
            get { return m_UPD_BY; }
            set
            {
                if (value == null)
                    m_UPD_BY.Value = value;
                else
                    m_UPD_BY = value;
            }
        }

        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        public NZDateTime UPD_DATE
        {
            get { return m_UPD_DATE; }
            set
            {
                if (value == null)
                    m_UPD_DATE.Value = value;
                else
                    m_UPD_DATE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        public NZString UPD_MACHINE
        {
            get { return m_UPD_MACHINE; }
            set
            {
                if (value == null)
                    m_UPD_MACHINE.Value = value;
                else
                    m_UPD_MACHINE = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ID", 0, 0, 20)]
        public NZString ID
        {
            get { return m_ID; }
            set
            {
                if (value == null)
                    m_ID.Value = value;
                else
                    m_ID = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "Name", 0, 0, 50)]
        public NZString Name
        {
            get { return m_Name; }
            set
            {
                if (value == null)
                    m_Name.Value = value;
                else
                    m_Name = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SQLCommand", 0, 0, -1)]
        public NZString SQLCommand
        {
            get { return m_SQLCommand; }
            set
            {
                if (value == null)
                    m_SQLCommand.Value = value;
                else
                    m_SQLCommand = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ExcelTemplate", 0, 0, 100)]
        public NZString ExcelTemplate
        {
            get { return m_ExcelTemplate; }
            set
            {
                if (value == null)
                    m_ExcelTemplate.Value = value;
                else
                    m_ExcelTemplate = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.Int32, "StartRow", 10, 0, 4)]
        public NZInt StartRow
        {
            get { return m_StartRow; }
            set
            {
                if (value == null)
                    m_StartRow.Value = value;
                else
                    m_StartRow = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.Int32, "StartColumn", 10, 0, 4)]
        public NZInt StartColumn
        {
            get { return m_StartColumn; }
            set
            {
                if (value == null)
                    m_StartColumn.Value = value;
                else
                    m_StartColumn = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "Remark", 0, 0, 255)]
        public NZString Remark
        {
            get { return m_Remark; }
            set
            {
                if (value == null)
                    m_Remark.Value = value;
                else
                    m_Remark = value;
            }
        }


    }
}
