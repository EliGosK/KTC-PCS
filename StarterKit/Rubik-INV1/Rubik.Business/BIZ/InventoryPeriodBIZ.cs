using System;
using System.Collections.Generic;
using Rubik.DTO;
using Rubik.DAO;
using Rubik.Validators;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.BIZ
{
    public class InventoryPeriodBIZ
    {
        public int UpdatePeriod(InventoryPeriodDTO dto)
        {
            // check exist before add new
            InventoryPeriodValidator val = new InventoryPeriodValidator();
            val.ValidateBeforeSaveUpdate(dto);
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            List<InventoryPeriodDTO>dtoInvPeriodList= dao.LoadAll(null, true);

            return dao.UpdateWithPK(null, dto, dtoInvPeriodList[0].YEAR_MONTH);
        }

        public InventoryPeriodDTO LoadByPK(EVOFramework.NZString YearMonth)
        {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, YearMonth);
        }

        public InventoryPeriodDTO LoadCurrentPeriod()
        {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadCurrentYearMonth(null);
        }

        /// <summary>
        /// ใช้สำหรับ load inventory period โดยใช้range จาก system config ในการคำนวณด้วย
        /// เพื่อให้ข้อมูลแสดงน้อยลง
        /// </summary>
        /// <returns></returns>
        public InventoryPeriodDTO LoadCurrentPeriodWithQueryRange()
        {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadCurrentPeriodWithQueryRange(null);
        }
        public InventoryPeriodDTO LoadPeriodByDate(NZDateTime date) {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadPeriodByDate(null, date);
        }

        public bool Exist(NZString YearMonth)
        {
            InventoryPeriodDAO dao = new InventoryPeriodDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, YearMonth);
        }


    }
}
