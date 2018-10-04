using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TZ_LOG_TABLE_MS", typeof(eColumns))]
    public class LogTableDTO
    {
        public enum eColumns
        {
            TableID,
            TABLE_NAME,
            TABLE_DESCRIPTION,
        };
    }
}
